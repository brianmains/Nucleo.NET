using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.Data
{
    /// <summary>
    /// Represents core actions for data objects.
    /// </summary>
    public static class Objects
    {
        /// <summary>
        /// Creates or updates the object of a given type.  Uses an action to perform the create/update setting.
        /// </summary>
        /// <typeparam name="T">The type of entity.</typeparam>
        /// <param name="existingEntity">The existing entity (nulls allowed).  If null, the object will be constucted.</param>
        /// <param name="action">The action.</param>
        /// <returns>The created or updated entity.</returns>
        public static T CreateOrUpdate<T>(T existingEntity, Action<T> action)
            where T: class, new()
        {
            bool val;
            return CreateOrUpdate<T>(existingEntity, action, out val);
        }

        /// <summary>
        /// Creates or updates the object of a given type.  Uses an action to perform the create/update setting.
        /// </summary>
        /// <typeparam name="T">The type of entity.</typeparam>
        /// <param name="existingEntity">The existing entity (nulls allowed).  If null, the object will be constucted.</param>
        /// <param name="action">The action.</param>
        /// <param name="created">The returned value for whether the object was newly constructed.</param>
        /// <returns>The created or updated entity.</returns>
        public static T CreateOrUpdate<T>(T existingEntity, Action<T> action, out bool created)
            where T : class, new()
        {
            if (existingEntity == null)
            {
                existingEntity = new T();
                created = true;
            }
            else
                created = false;

            action(existingEntity);

            return existingEntity;
        }
    }
}
