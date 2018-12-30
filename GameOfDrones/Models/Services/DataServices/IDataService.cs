

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameOfDrones.Models.DataServices
{

    public interface IDataService<T> where T: class
    {
        Task<T> Create(T entity);
        Task<T> Update(T entity);

        Task<ICollection<T>> Read(Func<T,bool> func);
        Task<int> Delete(T entity);
    }

}