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
    public class TiposActividadesRepository : IRepository<tbTiposActividades, VW_tbTiposActividades>
    {
        TotalTravelContext DB = new TotalTravelContext();
        public RequestStatus Delete(int ID, int Mod)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@TiAc_ID", ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@TiAc_UsuarioModifica", Mod, DbType.Int32, ParameterDirection.Input);

            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.QueryFirst<RequestStatus>(ScriptDataBase.UDP_tbTiposActividades_Delete, parameters, commandType: CommandType.StoredProcedure);
        }

        public VW_tbTiposActividades Find(int? id)
        {
            return DB.VW_tbTiposActividades.Where(x => x.ID == id).FirstOrDefault();
        }

        public RequestStatus Insert(tbTiposActividades item)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@TiAc_Descripcion", item.TiAc_Descripcion, DbType.String, ParameterDirection.Input);
            parameters.Add("@TiAc_UsuarioCreacion", item.TiAc_UsuarioCreacion, DbType.Int32, ParameterDirection.Input);

            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.QueryFirst<RequestStatus>(ScriptDataBase.UDP_tbTiposActividades_Insert, parameters, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<VW_tbTiposActividades> List()
        {
            return DB.VW_tbTiposActividades.AsList();
        }

        public RequestStatus Update(tbTiposActividades item, int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@TiAc_ID", id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@TiAc_Descripcion", item.TiAc_Descripcion, DbType.String, ParameterDirection.Input);
            parameters.Add("@TiAc_UsuarioModifica", item.TiAc_UsuarioCreacion, DbType.Int32, ParameterDirection.Input);
            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.QueryFirst<RequestStatus>(ScriptDataBase.UDP_tbTiposActividades_Update, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
