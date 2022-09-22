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
    public class ActividadesRepository : IRepository<tbActividades, VW_tbActividades>
    {
        TotalTravelContext DB = new TotalTravelContext();
        public int Delete(int Id, int Mod)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Actv_ID", Id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Actc_UsuarioModifica", Mod, DbType.Int32, ParameterDirection.Input);

            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.ExecuteScalar<int>(ScriptDataBase.UDP_tbActividades_Delete, parameters, commandType: CommandType.StoredProcedure);
        }

        public VW_tbActividades Find(int? id)
        {
            return DB.VW_tbActividades.Where(x => x.ID == id).FirstOrDefault();
        }

        public int Insert(tbActividades item)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Actc_Descripcion", item.Actv_Descripcion, DbType.String, ParameterDirection.Input);
            parameters.Add("@TiAc_ID", item.TiAc_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Actc_UsuarioCreacion", item.Actv_UsuarioCreacion, DbType.Int32, ParameterDirection.Input);

            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.ExecuteScalar<int>(ScriptDataBase.UDP_tbActividades_Insert, parameters, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<VW_tbActividades> List()
        {
            return DB.VW_tbActividades.AsList();
        }

        public int Update(tbActividades item, int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Actv_ID", id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Actc_Descripcion", item.Actv_Descripcion, DbType.String, ParameterDirection.Input);
            parameters.Add("@TiAc_ID", item.TiAc_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Actc_UsuarioModifica", item.Actv_UsuarioModifica, DbType.Int32, ParameterDirection.Input);

            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.ExecuteScalar<int>(ScriptDataBase.UDP_tbActividades_Update, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
