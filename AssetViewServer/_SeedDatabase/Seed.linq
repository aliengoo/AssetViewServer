<Query Kind="Program">
  <NuGetReference>MongoDB.Driver</NuGetReference>
  <NuGetReference>Newtonsoft.Json</NuGetReference>
  <Namespace>MongoDB.Bson</Namespace>
  <Namespace>MongoDB.Bson.Serialization.IdGenerators</Namespace>
  <Namespace>MongoDB.Driver</Namespace>
  <Namespace>MongoDB.Bson.Serialization.Attributes</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>MongoDB.Bson.Serialization.Conventions</Namespace>
</Query>

async Task Main()
{
	
	var db = new MongoClient("mongodb://localhost").GetDatabase("asset-view");

	var entities = await InitEntitiesCollectionAsync(db);

	Console.WriteLine("Running adjective tasks");

	var adjectives = new List<Task<Entity>> {
		InsertContainerEntityAsync(entities),
		InsertRelatedEntityAsync(entities),
		InsertHostsEntityAsync(entities)
	};

	var pack = new ConventionPack
							{
								new CamelCaseElementNameConvention(),
								new EnumRepresentationConvention(BsonType.String)
							};

	ConventionRegistry.Register("conventions", pack, t => true);

	Console.WriteLine("Waiting for all adjective tasks to complete");
	var whenAllCompleted = Task.WhenAll(adjectives);
	Console.WriteLine("All adjective tasks completed");

	var adjectiveEntities = whenAllCompleted.Result;

	var containerAdjectiveEntity = adjectiveEntities[0];
	var relatedAdjectiveEntity = adjectiveEntities[1];
	var hostsAdjectiveEntity = adjectiveEntities[2];

	var entityLinks = await InitEntityLinksCollectionAsync(db);

	var developmentServerEnvironmentEntity = await DevelopmentServerEnvironmentAsync(entities);

	var numberOfServers = 5;
	var servers = new List<Task<Entity>>(numberOfServers);

	for (var i = 0; i < numberOfServers; i++)
	{
		servers.Add(AddServer(entities, entityLinks, developmentServerEnvironmentEntity, containerAdjectiveEntity, i));
	}

	var whenAllServersCompleted = Task.WhenAll(servers);

	var firstServerEntity = whenAllServersCompleted.Result.First();

	await AddAppToHostingServer(entities, entityLinks, hostsAdjectiveEntity, firstServerEntity);
}

public async Task<Entity> InsertContainerEntityAsync(IMongoCollection<Entity> entities)
{
	var entity = new Entity
	{
		Name = "container",
		Description = "Container for other entities",
		Icon = "icon-box",
		Classificiation = "Adjective",
		Labels = new List<string> {
			"contains", "container"
		},
        Uri = "container"
	};
	
	await entities.InsertOneAsync(entity);
	
	return entity;
}

public async Task<Entity> InsertRelatedEntityAsync(IMongoCollection<Entity> entities)
{
	var entity = new Entity
	{
		Name = "related",
		Description = "Related entity",
		Icon = "icon-link",
		Classificiation = "Adjective",
		Labels = new List<string> {
			"related", "relates"
		},
        Uri = "related"
	};

	await entities.InsertOneAsync(entity);

	return entity;
}

public async Task<Entity> InsertHostsEntityAsync(IMongoCollection<Entity> entities)
{
	var entity = new Entity
	{
		Name = "hosts",
		Description = "Hosts other entities, e.g. lhs is a server, rhs is an application",
		Icon = "icon-server",
		Classificiation = "Adjective",
		Labels = new List<string> {
			"hosts", "host"
		},
        Uri = "hosts"
	};

	await entities.InsertOneAsync(entity);

	return entity;
}

public async Task<IMongoCollection<Entity>> InitEntitiesCollectionAsync(IMongoDatabase db)
{
	var collectionName = "entities";

	await db.DropCollectionAsync(collectionName);

	var entities = db.GetCollection<Entity>(collectionName);

	return entities;
}

public async Task<IMongoCollection<EntityLink>> InitEntityLinksCollectionAsync(IMongoDatabase db)
{
	var collectionName = "entityLinks";

	await db.DropCollectionAsync(collectionName);

	var entityLinks = db.GetCollection<EntityLink>(collectionName);

	return entityLinks;
}

public async Task<Entity> DevelopmentServerEnvironmentAsync(IMongoCollection<Entity> entities)
{
	var entity = new Entity
	{
		Name = "Development Server Environment",
		Description = "Development server environment",
		Icon = "icon-cube",
		Classificiation = "Noun",
		Labels = new List<string> {
			"development", "environment", "server", "servers"
		},
		Uri = "development-server-environment"
	};

	await entities.InsertOneAsync(entity);

	return entity;
}

public async Task<Entity> AddServer(
	IMongoCollection<Entity> entities, 
	IMongoCollection<EntityLink> entityLinks,
	Entity developmentServerEnvironmentEntity, 
	Entity containsAdjectiveEntity, 
	int id)
{
	var serverName = $"hqdevserver{id}";
	var entity = new Entity
	{
		Name = serverName,
		Description = $"{serverName} development server",
		Icon = "icon-server",
		Classificiation = "Noun",
		Labels = new List<string> {
			"development", "server"
		},
		Uri = serverName
	};

	await entities.InsertOneAsync(entity);

	var entityLink = new EntityLink 
	{
		Description = "contains the server",
		Lhs = developmentServerEnvironmentEntity.Id,
		Rhs = entity.Id,
		Link = containsAdjectiveEntity.Id,
	};
	
	await entityLinks.InsertOneAsync(entityLink);

	return entity;
}

public async Task<Entity> AddAppToHostingServer(
	IMongoCollection<Entity> entities, 
	IMongoCollection<EntityLink> entityLinks,
	Entity hostsAdjectiveEntity, 
	Entity serverEntity)
{
	var entity = new Entity
	{
		Name = "WebApp",
		Description = $"WebApp",
		Icon = "icon-earth",
		Classificiation = "Noun",
		Labels = new List<string> {
			"web", "app"
		},
        Uri = "WebApp"
	};

	await entities.InsertOneAsync(entity);

	var entityLink = new EntityLink
	{
		Description = "hosts the application",
		Lhs = serverEntity.Id,
		Rhs = entity.Id,
		Link = hostsAdjectiveEntity.Id,
	};

	await entityLinks.InsertOneAsync(entityLink);

	return entity;
}

// Define other methods and classes here

public class Entity
{
	[BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
	public string Id { get; set; }

	public string Name { get; set; }

	public string Description { get; set; }

	public string Icon { get; set; }

	public List<string> Labels { get; set; }

	public string Classificiation { get; set; }

	public string Uri { get; set; }

	public IDictionary<string, object> Meta { get; set; }
}

public class EntityLink
{
	[BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
	public string Id { get; set; }

	public string Lhs { get; set; }

	public string Rhs { get; set; }

	public string Link { get; set; }

	public string Description { get; set; }
}