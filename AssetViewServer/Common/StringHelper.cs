namespace AssetViewServer.Common
{
	public static class StringHelper
	{
		public static string ToCamelCase(this string value)
		{
			if (string.IsNullOrWhiteSpace(value) || value.Length < 2)
			{
				return value;
			}

			var firstChar = value[0];

			var actualFirstChar = firstChar;

			if (firstChar >= 65 || firstChar <= 90)
			{
				actualFirstChar = (char)(firstChar + 32);
			}

			return $"{actualFirstChar}{value.Substring(1)}";
		}
	}
}