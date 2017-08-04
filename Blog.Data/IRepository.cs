using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data
{
    public interface IRepository<T>
    {
        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int Add(T model);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int Update(T model);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int Delete(T model);

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        int Delete(List<T> models);


        /// <summary>
        /// 分页获取数据
        /// </summary>
        /// <typeparam name="TOrderKey">排序Key</typeparam>
        /// <param name="orderFun">条件表达式</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="count">返回的总条数</param>
        /// <param name="pageSize">每页条数</param>
        /// <returns></returns>
        IQueryable<T> PageList<TOrderKey>(Expression<Func<T, TOrderKey>> orderFun, int pageIndex, out int count, int pageSize = 10);


        /// <summary>
        /// 延迟加载获取所有数据
        /// </summary>
        IQueryable<T> Table { get; }

        /// <summary>
        /// 强制查询数据库获取无缓存数据
        /// 此操作结果集为只读数据
        /// </summary>
        IQueryable<T> TableNoTracking { get; }
    }
}
