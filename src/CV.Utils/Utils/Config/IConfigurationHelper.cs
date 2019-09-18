using CV.Utils.Utils.Attributes;
using CV.Utils.Utils.Check;
using CV.Utils.Utils.Env;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Utils.Utils.Config
{
    public class IConfigurationHelper
    {
        [CanBeNull]
        public static T GetSection<T>(IConfiguration configuration, string key = null) where T : new()
        {
            var value = new T();

            key = string.IsNullOrWhiteSpace(key) ? typeof(T).Name : key;

            configuration.GetSection(key).Bind(value);

            return value;
        }

        /// <summary>
        ///     Get Value follow Priority: Key:[Machine Name] &gt; Key:[Environment] &gt; Key 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="configuration"></param>
        /// <param name="key">          </param>
        /// <returns></returns>
        [CanBeNull]
        public static T GetValueByEnv<T>(IConfiguration configuration, string key)
        {
            CheckHelper.CheckNullOrWhiteSpace(key, nameof(key));

            var value = configuration.GetValue<T>($"{key}:{EnvHelper.MachineName}");

            if (value != null)
            {
                return value;
            }

            var environmentName = !string.IsNullOrWhiteSpace(EnvHelper.CurrentEnvironment) ? EnvHelper.CurrentEnvironment : EnvHelper.EnvDevelopmentName;

            value = configuration.GetValue<T>($"{key}:{environmentName}");

            if (value != null)
            {
                return value;
            }

            value = configuration.GetValue<T>($"{key}");

            return value;
        }
    }
}
