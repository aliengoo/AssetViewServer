﻿namespace AssetViewServer.StartUp
{
	using System.Web.Http;

	using AssetViewServer.Common;
	using AssetViewServer.Database;
	using AssetViewServer.Database.Collections;
	using AssetViewServer.Database.Models;

	using Microsoft.Practices.Unity;

	using Unity.WebApi;

	public class Dependencies
	{
		public static void Register(HttpConfiguration config)
		{
			var c = new UnityContainer();

			config.DependencyResolver = new UnityDependencyResolver(c);

			// TODO: Dependencies here

			// Common dependencies
			c.RegisterType<IAssetViewConfiguration, AssetViewConfiguration>();

			// Database dependencies
			c.RegisterType<IAssetViewDatabase, AssetViewDatabase>();

			// Collection dependencies
			c.RegisterType<IEntities, Entities>();
			c.RegisterType<IEntityLinks, EntityLinks>();

			// Model dependencies
			c.RegisterType<IEntityLinkage, EntityLinkage>();

		}
	}
}