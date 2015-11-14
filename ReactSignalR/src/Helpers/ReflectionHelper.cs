namespace Leads.Helpers
{
	using System.Collections.Generic;
	using System.Reflection;

	public static class ReflectionHelper
	{
		public static bool HasProperty(this object value, string propertyName)
		{
			var propertyInfo = value.GetType().GetProperty(propertyName);

			return propertyInfo != null;
		}

		public static bool IsEnumerable(this PropertyInfo propertyInfo)
		{
			if (propertyInfo.PropertyType.IsArray)
			{
				return true;
			}

			return propertyInfo.PropertyType != typeof(string) 
				&& propertyInfo.PropertyType.GetInterface(typeof(IEnumerable<>).FullName) != null;
		}
	}
}