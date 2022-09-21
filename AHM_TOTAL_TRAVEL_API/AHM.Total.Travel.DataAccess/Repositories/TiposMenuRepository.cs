using AHM.Total.Travel.DataAccess.Context;
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
    public class TiposMenuRepository : IRepository<tbTipoMenus, VW_tbTiposMenus>
    {
        TotalTravelContext DB = new TotalTravelContext();
        public int Delete(int Id, int Mod)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Time_ID", Id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Time_UsuarioModifica", Mod, DbType.Int32, ParameterDirection.Input);

            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.ExecuteScalar<int>(ScriptDataBase.UDP_tbTipoMenus_Delete, parameters, commandType: CommandType.StoredProcedure);
        }

        public VW_tbTiposMenus Find(int? id)
        {
            return DB.VW_tbTiposMenus.Where(x=>x.ID == id).FirstOrDefault();
        }

        public int Insert(tbTipoMenus item)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Time_Descripcion", item.Time_Descripcion, DbType.String, ParameterDirection.Input);
            parameters.Add("@Time_UsuarioCreacion", item.Time_UsuarioCreacion, DbType.Int32, ParameterDirection.Input);

            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.ExecuteScalar<int>(ScriptDataBase.UDP_tbTipoMenus_Insert, parameters, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<VW_tbTiposMenus> List()
        {
            return DB.VW_tbTiposMenus.ToList();
        }

        public int Update(tbTipoMenus item, int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Time_ID", id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Time_Descripcion", item.Time_Descripcion, DbType.String, ParameterDirection.Input);
            parameters.Add("@Time_UsuarioModifica", item.Time_UsuarioModifica, DbType.Int32, ParameterDirection.Input);

            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.ExecuteScalar<int>(ScriptDataBase.UDP_tbTipoMenus_Update, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
