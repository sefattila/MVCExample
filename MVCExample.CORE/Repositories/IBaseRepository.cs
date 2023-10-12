using MVCExample.CORE.Abstarct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MVCExample.CORE.Repositories
{
    public interface IBaseRepository<T> where T : class, IBaseEntity
    {
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);

        /// <summary>
        /// Expression'daki koşulu sağlıyorsa True sağlamıyorsa False dönecek
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        bool Any(Expression<Func<T, bool>> expression);

        /// <summary>
        /// Verilen expressiondaki koşulu sağlayan entity return ediliyor
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        T GetDefault(Expression<Func<T, bool>> expression);

        /// <summary>
        /// Verilen Id değerine göre entity return ediliyor
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T GetDefaultById(int id);

        /// <summary>
        /// Verilen expressiondaki koşula göre bir veya birden fazla entity içeren list return ediliyor
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        IList<T> GetDefaults(Expression<Func<T, bool>> expression);

        /// <summary>
        /// Gelen entity'nin bütün değerlerini geri döndür
        /// </summary>
        /// <returns></returns>
        IList<T> GetAll();

        /// <summary>
        /// Koşula göre sıralı ifadeler
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        IList<T> OrderByAsc<TKey>(Expression<Func<T, TKey>> expression);
        IList<T> OrderByDesc<TKey>(Expression<Func<T, TKey>> expression);

        /// <summary>
        /// Verilen koşula göre filtreleme yap ve sırala
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        /// <returns></returns>
        IList<T> FilteredList(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null
            );
    }
}
