using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Utils.Utils.Actions
{
    public static class ActionExtensions
    {
        /// <summary>
        ///     Get instance of T from Action 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="action"></param>
        /// <returns></returns>
        public static T GetValue<T>(this Action<T> action) where T : class, new()
        {
            return ActionHelper.GetValue(action);
        }
    }
}
