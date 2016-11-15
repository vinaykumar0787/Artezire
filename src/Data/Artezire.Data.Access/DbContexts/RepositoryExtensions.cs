using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;

namespace Artezire.Data.Access
{
    /// <summary>
    /// Extension class for entity framework object context
    /// </summary>
    public static class RepositoryExtensions
    {
        #region Public Methods

        /// <summary>
        /// Method to get entity collection from table
        /// </summary>
        /// <typeparam name="T">Generic type</typeparam>
        /// <param name="context">object context</param>
        /// <returns>returns entity collection</returns>
        public static IList<T> GetList<T>(this IObjectContextAdapter context) where T : class
        {
            return context.ObjectContext.CreateObjectSet<T>().ToList();
        }

        /// <summary>
        /// Method to get entity collection from table
        /// </summary>
        /// <typeparam name="T">Generic type</typeparam>
        /// <param name="context">object context</param>
        /// <returns>returns entity collection</returns>
        public static IQueryable<T> GetQueryable<T>(this IObjectContextAdapter context) where T : class
        {
            return context.ObjectContext.CreateObjectSet<T>();
        }

        /// <summary>
        /// Overload method to get entity collection by passed conditional statement
        /// </summary>
        /// <typeparam name="T">Generic type</typeparam>
        /// <param name="context">Object context</param>
        /// <param name="condition">conditional statement</param>
        /// <returns>returns entity collection</returns>
        public static IList<T> GetList<T>(this IObjectContextAdapter context, Expression<Func<T, Boolean>> condition) where T : class
        {
            return context.ObjectContext.CreateObjectSet<T>().Where(condition).ToList<T>();
        }

        /// <summary>
        /// Overload method to get paged entity collection list
        /// </summary>
        /// <typeparam name="T">Generic type</typeparam>
        /// <param name="context">object context</param>
        /// <param name="condition">conditional statement</param>
        /// <param name="orderByExp">order by expression</param>
        /// <param name="skipPosition">no of records to skip</param>
        /// <param name="takePosition">no of records to take</param>
        /// <returns>returns entity collection</returns>
        public static IList<T> GetList<T>(this IObjectContextAdapter context, Expression<Func<T, Boolean>> condition, Expression<Func<T, int>> orderByExp, int skipPosition, int takePosition) where T : class
        {
            return context.ObjectContext.CreateObjectSet<T>().Where(condition).OrderBy(orderByExp).Skip(skipPosition).Take(takePosition).ToList<T>();
        }

        /// <summary>
        /// Method to get single record from entity collection in object context
        /// </summary>
        /// <typeparam name="T">Generic type</typeparam>
        /// <param name="context">Object context</param>
        /// <param name="condition">conditional statement</param>
        /// <returns>returns entity instance</returns>
        public static T GetSingle<T>(this IObjectContextAdapter context, Expression<Func<T, Boolean>> condition) where T : class
        {
            return context.ObjectContext.CreateObjectSet<T>().Where(condition).FirstOrDefault<T>();
        }

        /// <summary>
        /// Method to save entity into object context with commit changes
        /// </summary>
        /// <typeparam name="T">Generic type</typeparam>
        /// <param name="context">object context</param>
        /// <param name="entity">entity instance</param>
        /// <returns>returns boolean response</returns>
        public static int AddEntityWithSave<T>(this IObjectContextAdapter context, T entity)
        {
            context.ObjectContext.AddObject(GetBase<T>(context).Name, entity);
            var artezireDbContext = context as ArtezireDbContext;
            if (artezireDbContext != null) return artezireDbContext.SaveChanges();
            return 0; //no database insertion happenned
        }

        /// <summary>
        /// Method to save entity into object context without committing changes
        /// </summary>
        /// <typeparam name="T">Generic type</typeparam>
        /// <param name="context">context instance</param>
        /// <param name="entity">entity instance</param>
        public static void AddEntity<T>(this IObjectContextAdapter context, T entity)
        {
            context.ObjectContext.AddObject(GetBase<T>(context).Name, entity);
        }

        /// <summary>
        /// Method to update entity into object context without commit changes
        /// </summary>
        /// <typeparam name="T">Generic type</typeparam>
        /// <param name="context">object context</param>
        /// <param name="entity">entity instance</param>
        /// <returns>returns boolean response</returns>
        public static bool UpdateEntity<T>(this IObjectContextAdapter context, T entity) where T : class
        {
            object originalItem = default(T);
            EntityKey key = context.ObjectContext.CreateEntityKey(GetBase<T>(context).Name, entity);
            if (context.ObjectContext.TryGetObjectByKey(key, out originalItem))
                return context.ObjectContext.ApplyCurrentValues(key.EntitySetName, entity) != null ? true : false;
            return false;
        }

        /// <summary>
        /// Method to update entity into object context with save changes
        /// </summary>
        /// <typeparam name="T">Generic type</typeparam>
        /// <param name="context">object context</param>
        /// <param name="entity">entity instance</param>
        /// <returns>returns boolean instance</returns>
        public static bool UpdateEntityWithSave<T>(this IObjectContextAdapter context, T entity) where T : class
        {
            bool isUpdated = false;
            object originalItem = default(T);
            EntityKey key = context.ObjectContext.CreateEntityKey(GetBase<T>(context).Name, entity);
            if (context.ObjectContext.TryGetObjectByKey(key, out originalItem))
            {
                context.ObjectContext.ApplyCurrentValues(key.EntitySetName, entity);
                try
                {
                    var artezireDbContext = context as ArtezireDbContext;
                    artezireDbContext.SaveChanges();
                    //context.ObjectContext.SaveChanges();
                    isUpdated = true;
                }
                catch (OptimisticConcurrencyException ox)
                {
                    context.ObjectContext.Refresh(RefreshMode.ClientWins, entity);
                    var artezireDbContext = context as ArtezireDbContext;
                    artezireDbContext.SaveChanges();
                    //context.ObjectContext.SaveChanges();
                    isUpdated = true;
                }
                catch (Exception ex)
                {
                    isUpdated = false;
                }
            }
            return isUpdated;
        }

        /// <summary>
        /// Method to delete entity from object context without committing changes to database
        /// </summary>
        /// <typeparam name="T">Generic type</typeparam>
        /// <param name="context">object context</param>
        /// <param name="entity">entity instance</param>
        public static void DeleteEntity<T>(this IObjectContextAdapter context, T entity)
        {
            object originalItem = default(T);
            EntityKey key = context.ObjectContext.CreateEntityKey(GetBase<T>(context).Name, entity);
            if (context.ObjectContext.TryGetObjectByKey(key, out originalItem))
            {
                context.ObjectContext.ObjectStateManager.GetObjectStateEntry(key).Delete();
            }
            else
            {
                context.ObjectContext.DeleteObject(entity);
            }
        }

        /// <summary>
        /// Method to delete entity from object context with commit changes
        /// </summary>
        /// <typeparam name="T">Generic type</typeparam>
        /// <param name="context">object context</param>
        /// <param name="entity">entity instance</param>
        /// <returns>returns boolean response</returns>
        public static bool DeleteEntityWithSave<T>(this IObjectContextAdapter context, T entity)
        {
            object originalItem = default(T);
            EntityKey key = context.ObjectContext.CreateEntityKey(GetBase<T>(context).Name, entity);
            if (context.ObjectContext.TryGetObjectByKey(key, out originalItem))
            {
                context.ObjectContext.ObjectStateManager.GetObjectStateEntry(key).Delete();
            }
            else
            {
                context.ObjectContext.DeleteObject(entity);
            }
            return context.ObjectContext.SaveChanges() > 0 ? true : false;
        }

        /// <summary>
        /// Method to get record count from table on the basis of provided conditional statement
        /// </summary>
        /// <typeparam name="T">Generic type</typeparam>
        /// <param name="context">object context</param>
        /// <param name="condition">conditional statement</param>
        /// <returns>returns record count</returns>
        public static int Count<T>(this IObjectContextAdapter context, Expression<Func<T, Boolean>> condition) where T : class
        {
            return context.ObjectContext.CreateObjectSet<T>().Count(condition);
        }

        public static void LoadProperty(this IObjectContextAdapter context, object entity, string navigationProperty)
        {
            context.ObjectContext.LoadProperty(entity, navigationProperty);
        }
        //public static void LoadProperty<T>(this IObjectContextAdapter context, T entity, Expression<Func<T, object>> selector) where T : class
        //{

        //}

        ///// <summary>
        ///// Method to commit save changes into database
        ///// </summary>
        ///// <typeparam name="T">Generic type</typeparam>
        ///// <param name="context">Object context</param>
        ///// <returns>returns rows affected</returns>
        //internal static int SaveChanges<T>(this IObjectContextAdapter context)
        //{
        //    return context.ObjectContext.SaveChanges(SaveOptions.DetectChangesBeforeSave);
        //}

        /// <summary>
        /// Method to return entity set base from object context entity
        /// </summary>
        /// <typeparam name="TEntity">Generic type</typeparam>
        /// <param name="context">object context</param>
        /// <returns>returns entity set</returns>
        private static EntitySetBase GetBase<TEntity>(IObjectContextAdapter context)
        {
            EntityContainer container = context.ObjectContext.MetadataWorkspace.GetEntityContainer(context.ObjectContext.DefaultContainerName, DataSpace.CSpace);
            EntitySetBase entitySet = container.BaseEntitySets.FirstOrDefault(item => item.ElementType.Name.Equals(typeof(TEntity).Name));
            return entitySet;
        }

        /// <summary>
        /// Method to include multiple entities with a single entity query on the basis of db relationships
        /// </summary>
        /// <typeparam name="T">Generic Type</typeparam>
        /// <param name="query">query</param>
        /// <param name="includes">include objects</param>
        /// <returns>returns query</returns>
        private static IQueryable<T> IncludeMultipleEntities<T>(this IQueryable<T> query, params Expression<Func<T, object>>[] includes) where T : class
        {
            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.IncludeMultipleEntities(include));
            }
            return query;
        }

        #endregion
    }
}
