using Artezire.Data.Core;
using Artezire.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity.Core.Objects;

namespace Artezire.Data.Access.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        #region Private Variables and Constants

        protected ArtezireDbContext _dbContext;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Constructor to create an instance for Db context
        /// </summary>
        public BaseRepository()
        {
            _dbContext = new ArtezireDbContext();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Property to get Cloud Object context
        /// </summary>
        internal ArtezireDbContext DbContext
        {
            get
            {
                return _dbContext;
            }
        }
        #endregion

        #region Methods

        /// <summary>
        /// Method to add entity into db context
        /// </summary>
        /// <typeparam name="T">Generic type</typeparam>
        /// <param name="entity">entity instance</param>
        /// <returns>returns identity value</returns>
        public int AddEntity<T>(T entity)
        {
            return _dbContext.AddEntityWithSave<T>(entity);
        }

        /// <summary>
        /// Method to delete entity into db context
        /// </summary>
        /// <typeparam name="T">Generic entity</typeparam>
        /// <param name="entity">entity instance</param>
        /// <returns>returns boolean response</returns>
        public bool DeleteEntity<T>(T entity)
        {
            return _dbContext.DeleteEntityWithSave<T>(entity);
        }


        /// <summary>
        /// Method to update entity in db context
        /// </summary>
        /// <typeparam name="T">Generic entity</typeparam>
        /// <param name="entity">entity instance</param>
        /// <returns>returns boolean response</returns>
        public bool UpdateEntity<T>(T entity) where T : class
        {
            return _dbContext.UpdateEntityWithSave<T>(entity);
        }

        public void AddEntityWithoutSave<T>(T entity)
        {
            _dbContext.AddEntity<T>(entity);
        }

        public void DeleteEntityWithoutSave<T>(T entity)
        {
            _dbContext.DeleteEntity<T>(entity);
        }

        public bool UpdateEntityWithoutSave<T>(T entity) where T : class
        {
            return _dbContext.UpdateEntity<T>(entity);
        }

        /// <summary>
        /// save unsaved changes in database
        /// </summary>
        /// <returns>The number of objects Added, Modified or Deleted</returns>
        public int SavePendingChanges()
        {
            var changes = _dbContext.SaveChanges();
            return changes;
        }

        /// <summary>
        /// Method to get records count on the basis of passed condition
        /// </summary>
        /// <typeparam name="T">Generic type></typeparam>
        /// <param name="entity">entity instance</param>
        /// <param name="condition">conditional statement</param>
        /// <returns>returns record count</returns>
        public int Count<T>(T entity, Expression<Func<T, Boolean>> condition) where T : class
        {
            return _dbContext.Count(condition);
        }

        /// <summary>
        /// Method to get collection of entitie
        /// </summary>
        /// <typeparam name="T">Generic entity type</typeparam>
        /// <returns>returns collection of entity</returns>
        public IList<T> Get<T>() where T : class
        {
            return _dbContext.GetList<T>();
        }

        public IList<T> Get<T>(List<string> loadProperty) where T : class
        {
            IList<T> entities = _dbContext.GetList<T>();
            foreach (T entity in entities)
            {
                if (entity != null)
                {
                    foreach (string loadproperty in loadProperty)
                        _dbContext.LoadProperty(entity, loadproperty);
                }
            }
            return entities;
        }

        /// <summary>
        /// Method to get collection of entitie on the basis of condition provided
        /// </summary>
        /// <typeparam name="T">Generic entity type</typeparam>
        /// <param name="condition">conditional statement</param>
        /// <returns>returns collection of entity</returns>
        public IList<T> Get<T>(Expression<Func<T, Boolean>> condition) where T : class
        {
            return _dbContext.GetList<T>(condition);
        }

        public IQueryable<T> GetQueryable<T>() where T : class
        {
            return _dbContext.GetQueryable<T>();
        }


        public IQueryable<T> GetQueryable<T>(Expression<Func<T, bool>> condition) where T : class
        {
            return _dbContext.GetQueryable<T>().Where(condition);
        }

        public IList<T> Get<T>(Expression<Func<T, bool>> condition, List<string> loadProperty) where T : class
        {
            IList<T> entities = _dbContext.GetList<T>(condition);
            foreach (T entity in entities)
            {
                if (entity != null)
                {
                    foreach (string loadproperty in loadProperty)
                        _dbContext.LoadProperty(entity, loadproperty);
                }
            }
            return entities;
        }
        /// <summary>
        /// Method to get entity on the basis of condition provided
        /// </summary>
        /// <typeparam name="T">Generic entity type</typeparam>
        /// <param name="condition">conditional statement</param>
        /// <returns>returns collection of entity</returns>
        public T GetSingle<T>(Expression<Func<T, Boolean>> condition) where T : class
        {
            return _dbContext.GetSingle<T>(condition);
        }


        public T GetSingle<T>(Expression<Func<T, Boolean>> condition, List<string> loadProperty) where T : class
        {
            T entity = _dbContext.GetSingle<T>(condition);
            if (entity != null)
            {
                foreach (string loadproperty in loadProperty)
                    _dbContext.LoadProperty(entity, loadproperty);
            }
            return entity;
        }

        public void LoadProperty<T>(IList<T> entities, List<string> loadProperty) where T : class
        {
            foreach (T entity in entities)
            {
                if (entity != null)
                {
                    foreach (string loadproperty in loadProperty)
                        _dbContext.LoadProperty(entity, loadproperty);
                }
            }
        }

        public void DeleteEntityBy<T>(Expression<Func<T, Boolean>> condition) where T : class
        {

        }

        public bool DeleteEntityByCondition<T>(Expression<Func<T, bool>> condition) where T : class
        {
            T entity = _dbContext.GetSingle<T>(condition);
            return _dbContext.DeleteEntityWithSave<T>(entity);
        }
        
        public string GetSqlQuery<T>(IQueryable<T> query)
        {
            string sql = ((ObjectQuery)query).ToTraceString();
            return sql;
        }
        #endregion
    }
}
