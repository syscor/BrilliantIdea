using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BrilliantIdea.Framework.DAL
{
    public interface IRepository<T> where T:class 
    {
        
        /// <summary>
        /// Get all instances of type T
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetAllRows();

        /// <summary> 
        /// Return all instances of type T that match the expression exp. 
        /// </summary> 
        /// <param name="exp"></param> 
        /// <returns></returns> 
        IEnumerable<T> GetAllRowsWhere(Func<T, bool> exp);
        
        /// <summary>
        /// Return if exist the row expected in the expression
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        bool Any(Func<T, bool> exp);

        /// <summary>Returns the single entity matching the expression. Throws an exception if there is not exactly one such entity.</summary> 
        /// <param name="exp"></param><returns></returns> 
        T Single(Func<T, bool> exp);

        /// <summary>Returns the first element satisfying the condition.</summary> 
        /// <param name="exp"></param><returns></returns> 
        T First(Func<T, bool> exp);

        /// <summary> 
        /// Mark an entity to be deleted when the context is saved. 
        /// </summary> 
        /// <param name="entity"></param> 
        void Delete(T entity);

        /// <summary> 
        /// Adds new entity.. 
        /// </summary> 
        /// <param name="entity"></param> 
        void Insert(T entity);



        void Update(T entity);

        /// <summary> 
        /// Create a new instance of type T. 
        /// </summary> 
        /// <returns></returns> 
        T New();

        /// <summary>Persist the data context.</summary> 
        void SaveAll(); 

    }
}
