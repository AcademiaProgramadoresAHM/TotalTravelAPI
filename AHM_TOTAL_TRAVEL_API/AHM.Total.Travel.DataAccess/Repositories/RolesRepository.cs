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
    public class RolesRepository : IRepository<tbRoles, VW_tbRoles>

    {
        TotalTravelContext DB = new TotalTravelContext();
        public RequestStatus Delete(int Id, int Mod)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Role_ID", Id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Usuario_Modifica", Mod, DbType.Int32, ParameterDirection.Input);

            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.QueryFirst<RequestStatus>(ScriptDataBase.UDP_tbRoles_Delete, parameters, commandType: CommandType.StoredProcedure);
        }

        public VW_tbRoles Find(int? id)
        {

            return DB.VW_tbRoles.Where(x => x.ID == id).FirstOrDefault();

        }

        public RequestStatus Insert(tbRoles item)
        {

            var parameters = new DynamicParameters();
            parameters.Add("@Role_Descripcion", item.Role_Descripcion, DbType.String, ParameterDirection.Input);
            parameters.Add("@Usuario_Creacion", item.Role_UsuarioCreacion, DbType.Int32, ParameterDirection.Input);

            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.QueryFirst<RequestStatus>(ScriptDataBase.UDP_tbRoles_Insert, parameters, commandType: CommandType.StoredProcedure);

        }

        public IEnumerable<VW_tbRoles> List()
        {

            return DB.VW_tbRoles.AsList();

        }

        public RequestStatus Update(tbRoles item, int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Role_ID", id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Role_Descripcion", item.Role_Descripcion, DbType.String, ParameterDirection.Input);
            parameters.Add("@Usuario_Modifica", item.Role_UsuarioModifica, DbType.Int32, ParameterDirection.Input);
            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.QueryFirst<RequestStatus>(ScriptDataBase.UDP_tbRoles_Update, parameters, commandType: CommandType.StoredProcedure);

        }
    }
}