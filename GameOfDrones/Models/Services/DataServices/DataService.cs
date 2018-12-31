using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameOfDrones.Models.DataServices
{
    public class DataService<T> : IDataService<T> where T : class
    {

        protected GameOfDronesDbContext GetContext() => new GameOfDronesDbContext();

        public async Task<T> Create(T entity)
        {
            var ctx = GetContext();
            await ctx.AddAsync(entity);
            await ctx.SaveChangesAsync();
            return entity;
        }

        public async Task<int> Delete(T entity)
        {
            var ctx = GetContext();
            ctx.Remove(entity);
            return await ctx.SaveChangesAsync();
        }

        public async Task<ICollection<T>> Read(Func<T,bool> func)
        {
            var ctx = GetContext();
            return ctx.Set<T>().Where (func).ToList();
        }

        public async Task<T> Update(T entity)
        {
            var ctx = GetContext();
            ctx.Update(entity);
            await ctx.SaveChangesAsync();
            return entity;
        }
    }

}