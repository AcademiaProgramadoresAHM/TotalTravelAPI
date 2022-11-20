using AHM.Total.Travel.Entities.Entities;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace AHM.Total.Travel.DataAccess.Repositories
{
    public class ModulosRepository : IRepository<tbModulos, VW_tbModulos>
    {
        TotalTravelContext DB = new TotalTravelContext();
        public RequestStatus Delete(int Id, int Mod)
        {
            throw new NotImplementedException();
        }

        public VW_tbModulos Find(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Insert(tbModulos item)
        {
            throw new NotImplementedException();
        }

        // AL QUE LE SALGA ESTE ERROR HAGA REVERSE ENGENIERE
        // YA EXISTE ESTA VISTA, SOLO QUE NO HAY ENTITY
        public IEnumerable<VW_tbModulos> List()
        {
            return DB.VW_tbModulos.AsList();
        }

        public RequestStatus Update(tbModulos item, int id)
        {
            throw new NotImplementedException();
        }
    }
}
