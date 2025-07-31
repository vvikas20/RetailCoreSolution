using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailCore.Persistance
{
    public static class EntityFrameworkRecursiveDeleter
    {
        public static void DeleteEntityWithDependencies<TEntity>(DbContext context, TEntity entity)
            where TEntity : class
        {
            var visited = new HashSet<object>();
            DeleteEntityWithDependencies(context, entity, visited);
        }

        private static void DeleteEntityWithDependencies(DbContext context, object entity, HashSet<object> visited)
        {
            if (entity == null || visited.Contains(entity))
                return;

            visited.Add(entity);

            var entry = context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                entry.State = EntityState.Unchanged;
            }

            // Process all navigation properties
            foreach (var navigation in entry.Navigations)
            {
                if (navigation is NavigationEntry collectionNav && collectionNav.Metadata.IsCollection)
                {
                    // Handle collection navigation (one-to-many)
                    if (collectionNav.CurrentValue != null)
                    {
                        foreach (var relatedEntity in (IEnumerable<object>)collectionNav.CurrentValue)
                        {
                            DeleteEntityWithDependencies(context, relatedEntity, visited);
                        }
                    }
                }
                else if (navigation is ReferenceEntry referenceNav)
                {
                    // Handle reference navigation (many-to-one or one-to-one)
                    if (referenceNav.CurrentValue != null)
                    {
                        DeleteEntityWithDependencies(context, referenceNav.CurrentValue, visited);
                    }
                }
            }

            // Finally mark the entity as deleted
            entry.State = EntityState.Deleted;
        }
    }
}
