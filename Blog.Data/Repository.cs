using Blog.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private EFDbContext context;
        private IDbSet<T> _entities;
        public Repository()
        {
            context = new EFDbContext();
        }

        #region 方法
        public virtual int Add(T model)
        {
            try
            {
                if (null != model)
                {
                    Entities.Add(model);
                    return context.SaveChanges();
                }
                else
                {
                    return 0;
                }
            }
            catch(Exception e)
            {
                return 0;
            }
        }

        public virtual int Delete(T model)
        {
            if (model == null)
                throw new ArgumentNullException("model");
            
            Entities.Remove(model);
            return context.SaveChanges();
        }


        public virtual int Delete(List<T> models)
        {
            if (models == null)
                throw new ArgumentNullException("model");

            foreach (var item in models)
            {
                Entities.Remove(item);
            }
            return context.SaveChanges();
        }

        public virtual IQueryable<T> PageList<TOrderKey>(Expression<Func<T, TOrderKey>> orderFun, int pageIndex, out int count, int pageSize = 10)
        {
            throw new NotImplementedException();
        }

        public virtual int Update(T model)
        {
            if (model == null)
                throw new ArgumentNullException("model");

            this.Entities.Attach(model);
            context.Entry(model).State = EntityState.Modified;
            return context.SaveChanges();
        }

        #endregion

        #region 属性
        /// <summary>
        /// 延迟加载获取所有数据
        /// </summary>
        public virtual IQueryable<T> Table
        {
            get
            {
                return this.Entities;
            }
        }

        /// <summary>
        /// 强制查询数据库获取无缓存数据
        /// </summary>
        public virtual IQueryable<T> TableNoTracking
        {
            get
            {
                return this.Entities.AsNoTracking();
            }
        }

        /// <summary>
        /// Entities
        /// </summary>
        protected virtual IDbSet<T> Entities
        {
            get
            {
                if (_entities == null)
                    _entities = context.Set<T>();
                return _entities;
            }
        }
        #endregion


    }
}
