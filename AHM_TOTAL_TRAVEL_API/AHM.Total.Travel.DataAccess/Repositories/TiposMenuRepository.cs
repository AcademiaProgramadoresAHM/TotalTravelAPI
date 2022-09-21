using AHM.Total.Travel.DataAccess.Context;
using AHM.Total.Travel.Entities.Entities;
using Dapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AHM.Total.Travel.DataAccess.Repositories
{
    class TiposMenuRepository : IRepository<tbTipoMenus, VW_tbTiposMenus>
    {
        TotalTravelContext DB = new TotalTravelContext();
        public int Delete(int Id, int Mod)
        {
            throw new NotImplementedException();
        }

        public VW_tbTiposMenus Find(int? id)
        {
            throw new NotImplementedException();
        }

        public int Insert(tbTipoMenus item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<VW_tbTiposMenus> List()
        {
            throw new NotImplementedException();
        }

        public int Update(tbTipoMenus item, int id)
        {
            throw new NotImplementedException();
        }
    }
}
