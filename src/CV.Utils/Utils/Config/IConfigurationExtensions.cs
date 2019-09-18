using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Utils.Utils.Config
{
    public static class IConfigurationExtensions
    {
        public static T GetSection<T>(this IConfiguration configuration, string key = null) where T : new()
        {
            return IConfigurationHelper.GetSection<T>(configuration, key);
        }

        /// <summary>
        ///     Get Value follow Priority: Key:[Machine Name] &gt; Key:[Environment] &gt; Key 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="configuration"></param>
        /// <param name="key">          </param>
        /// <returns></returns>
        public static T GetValueByEnv<T>(this IConfiguration configuration, string key)
        {
            return IConfigurationHelper.GetValueByEnv<T>(configuration, key);
        }
    }
}
