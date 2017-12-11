
using Data;
using Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Pattern
{
    public abstract class Service<TEntity> : IService<TEntity> where TEntity : class
    {
        #region Private Fields
        // private readonly IRepositoryBaseAsync<TEntity> _repository;
        IUnitOfWork utwk;
        #endregion Private Fields

        #region Constructor
        protected Service(IUnitOfWork utwk)
        {
            this.utwk = utwk;
        }
        #endregion Constructor



        public virtual void Add(TEntity entity)
        {
           utwk.getRepository<TEntity>().Add(entity);

        }

        public virtual void Update(TEntity entity)
        {
            utwk.getRepository<TEntity>().Update(entity);
            utwk.Commit();
        }

        public virtual void Delete(TEntity entity)
        {
            //   _repository.Delete(entity);
            utwk.getRepository<TEntity>().Delete(entity);
        }

        public virtual void Delete(Expression<Func<TEntity, bool>> where)
        {
            // _repository.Delete(where);
            utwk.getRepository<TEntity>().Delete(where);
        }

        public virtual TEntity GetById(long id)
        {
            
            return utwk.getRepository<TEntity>().GetById(id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return utwk.getRepository<TEntity>().GetAll();
            
        }

        public virtual IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> filter = null, Expression<Func<TEntity, bool>> orderBy = null)
        {
            return utwk.getRepository<TEntity>().GetMany(filter, orderBy);
        }

        public virtual TEntity Get(Expression<Func<TEntity, bool>> where)
        {
           return utwk.getRepository<TEntity>().Get(where);
        }



        public void Commit()
        {
            try
            {
                utwk.Commit();
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        public void Dispose()
        {
            utwk.Dispose();
        }
    }
}
