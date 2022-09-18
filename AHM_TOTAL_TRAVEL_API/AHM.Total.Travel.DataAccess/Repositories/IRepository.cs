using System;
using System.Collections.Generic;
using System.Text;

namespace AHM.Total.Travel.DataAccess.Repositories
{
    public interface IRepository<T, U>
    {
        public IEnumerable<U> List();
        public int Insert(T item);
        public int Update(T item, int id);
        public U Find(int? id);
        public int Delete(int Id, int Mod);
    }
}

