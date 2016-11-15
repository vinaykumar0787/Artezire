using Artezire.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Artezire.Data.Core
{
    /// <summary>
    /// Interface to expose core base methods of db operations
    /// </summary>
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        /// <summary>
        /// interface method to add entity into db context
        /// </summary>
        /// <typeparam name="T">Generic type</typeparam>
        /// <param name="entity">entity instance</param>
        /// <returns>returns identity value</returns>
        int AddEntity<T>(T entity);

        /// <summary>
        /// Interface method to delete entity into db context
        /// </summary>
        /// <typeparam name="T">Generic entity</typeparam>
        /// <param name="entity">entity instance</param>
        /// <returns>returns boolean response</returns>
        bool DeleteEntity<T>(T entity);



        /// <summary>
        /// Interface method to update entity in db context
        /// </summary>
        /// <typeparam name="T">Generic entity</typeparam>
        /// <param name="entity">entity instance</param>
        /// <returns>returns boolean response</returns>
        bool UpdateEntity<T>(T entity) where T : class;

        /// <summary>
        /// interface method to add entity into db context
        /// </summary>
        /// <typeparam name="T">Generic type</typeparam>
        /// <param name="entity">entity instance</param>
        void AddEntityWithoutSave<T>(T entity);

        /// <summary>
        /// Interface method to delete entity into db context without saving context
        /// </summary>
        /// <typeparam name="T">Generic entity</typeparam>
        /// <param name="entity">entity instance</param>
        void DeleteEntityWithoutSave<T>(T entity);

        /// <summary>
        /// Interface method to update entity in db context without saving context
        /// </summary>
        /// <typeparam name="T">Generic entity</typeparam>
        /// <param name="entity">entity instance</param>
        /// <returns>returns boolean response</returns>
        bool UpdateEntityWithoutSave<T>(T entity) where T : class;

        /// <summary>
        /// save unsaved changes in database
        /// </summary>
        /// <returns>The number of objects Added, Modified or Deleted</returns>
        int SavePendingChanges();
        /// <summary>
        /// Interface method to get records count on the basis of passed condition
        /// </summary>
        /// <typeparam name="T">Generic type></typeparam>
        /// <param name="entity">entity instance</param>
        /// <param name="condition">conditional statement</param>
        /// <returns>returns record count</returns>
        int Count<T>(T entity, Expression<Func<T, Boolean>> condition) where T : class;

        /// <summary>
        /// Method to get collection of entitie
        /// </summary>
        /// <typeparam name="T">Generic entity type</typeparam>
        /// <returns>returns collection of entity</returns>
        IList<T> Get<T>() where T : class;

        IList<T> Get<T>(List<string> loadProperty) where T : class;

        /// <summary>
        /// Method to get collection of entitie on the basis of condition provided
        /// </summary>
        /// <typeparam name="T">Generic entity type</typeparam>
        /// <param name="condition">conditional statement</param>
        /// <returns>returns collection of entity</returns>
        IList<T> Get<T>(Expression<Func<T, Boolean>> condition) where T : class;

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IQueryable<T> GetQueryable<T>() where T : class;

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="condition"></param>
        /// <returns></returns>
        IQueryable<T> GetQueryable<T>(Expression<Func<T, Boolean>> condition) where T : class;

        IList<T> Get<T>(Expression<Func<T, Boolean>> condition, List<string> loadProperty) where T : class;
        /// <summary>
        /// Method to get entity on the basis of condition provided
        /// </summary>
        /// <typeparam name="T">Generic entity type</typeparam>
        /// <param name="condition">conditional statement</param>
        /// <returns>returns collection of entity</returns>
        T GetSingle<T>(Expression<Func<T, Boolean>> condition) where T : class;

        /// <summary>
        /// Method to get entity on the basis of condition provided with load refrences
        /// </summary>
        /// <typeparam name="T">Generic entity type</typeparam>
        /// <param name="condition">conditional statement</param>
        /// <param name="loadProperty">collection of entities</param>
        /// <returns>return single entity</returns>
        T GetSingle<T>(Expression<Func<T, Boolean>> condition, List<string> loadProperty) where T : class;

        void LoadProperty<T>(IList<T> entities, List<string> loadProperty) where T : class;

        bool DeleteEntityByCondition<T>(Expression<Func<T, Boolean>> condition) where T : class;
        
        string GetSqlQuery<T>(IQueryable<T> query);
    }
}
