using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;

namespace InfraStructure
{
  public class AppSettings
  {
    protected static readonly IDictionary<string, object> Settings = new Dictionary<string, object>();

    protected static T Get<T>(String propertyName, T defaultValue = default(T))
    {
      if (Settings.ContainsKey(propertyName))
        return (T)Settings[propertyName];

      String property = ConfigurationManager.AppSettings.Get(propertyName);

      T value = defaultValue;

      if (!string.IsNullOrEmpty(property))
        value = (T)TypeDescriptor.GetConverter(typeof(T)).ConvertFromInvariantString(property);

      Settings.Add(propertyName, value);
      return value;
    }
  }
}
