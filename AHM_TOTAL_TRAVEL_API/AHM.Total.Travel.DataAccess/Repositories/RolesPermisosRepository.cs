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
    class RolesPermisosRepository : IRepository<tbRolesPermisos, VW_tbRolesPermisos>
    {
        TotalTravelContext DB = new TotalTravelContext();
        public int Delete(int Id, int Mod)
        {

            var parameters = new DynamicParameters();
            parameters.Add("@ID", Id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@UsuarioModifica", Mod, DbType.Int32, ParameterDirection.Input);

            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.ExecuteScalar<int>(ScriptDataBase.UDP_tbRolesPermisos_Delete, parameters, commandType: CommandType.StoredProcedure);



        }

        public VW_tbRolesPermisos Find(int? id)
        {
            return DB.VW_tbRolesPermisos.Where(x => x.ID == id).FirstOrDefault();
        }

        public int Insert(tbRolesPermisos item)
        {

            var parameters = new DynamicParameters();
            parameters.Add("@PermID", item.Perm_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@RolID", item.Role_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@UsuarioCrea", item.RoPe_UsuarioCreacion, DbType.Int32, ParameterDirection.Input);

            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.ExecuteScalar<int>(ScriptDataBase.UDP_tbRolesPermisos_Insert, parameters, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<VW_tbRolesPermisos> List()
        {
            return DB.VW_tbRolesPermisos.AsList();

        }

        public int Update(tbRolesPermisos item, int id)
        {

            var parameters = new DynamicParameters();
            parameters.Add("@ID", item.RoPe_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Perm_ID", item.Perm_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Rol_ID", item.Role_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@UsuarioModifica", item.RoPe_UsuarioModifica, DbType.Int32, ParameterDirection.Input);
            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.ExecuteScalar<int>(ScriptDataBase.UDP_tbRolesPermisos_Update, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
