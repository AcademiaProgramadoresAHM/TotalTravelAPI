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
    public class ColoniasRepository : IRepository<tbColonias, VW_tbColonias>
    {
        TotalTravelContext DB = new TotalTravelContext();
        public RequestStatus Delete(int Id, int Mod)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Colo_ID", Id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Colo_UsuarioModifica", Mod, DbType.Int32, ParameterDirection.Input);

            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.QueryFirst<RequestStatus>(ScriptDataBase.UDP_tbColonias_Delete, parameters, commandType: CommandType.StoredProcedure);
        }

        public VW_tbColonias Find(int? id)
        {
            return DB.VW_tbColonias.Where(x => x.ID == id).FirstOrDefault();
        }

        public RequestStatus Insert(tbColonias item)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Colo_Descripcion", item.Colo_Descripcion, DbType.String, ParameterDirection.Input);
            parameters.Add("@Ciud_ID", item.Ciud_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Colo_UsuarioCreacion", item.Colo_UsuarioCreacion, DbType.Int32, ParameterDirection.Input);

            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.QueryFirst<RequestStatus>(ScriptDataBase.UDP_tbColonias_Insert, parameters, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<VW_tbColonias> List()
        {
            return DB.VW_tbColonias.AsList();
        }

        public RequestStatus Update(tbColonias item, int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Colo_ID", id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Colo_Descripcion", item.Colo_Descripcion, DbType.String, ParameterDirection.Input);
            parameters.Add("@Ciud_ID", item.Ciud_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Colo_UsuarioModifica", item.Colo_UsuarioModifica, DbType.Int32, ParameterDirection.Input);
            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.QueryFirst<RequestStatus>(ScriptDataBase.UDP_tbColonias_Update, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
