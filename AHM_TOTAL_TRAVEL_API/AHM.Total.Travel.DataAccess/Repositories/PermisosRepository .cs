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
    public class PermisosRepository : IRepository<tbPermisos, VW_tbPermisos>
    {
        TotalTravelContext DB = new TotalTravelContext();
        public RequestStatus Delete(int Id, int Mod)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Perm_ID", Id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Usuario_Modifica", Mod, DbType.Int32, ParameterDirection.Input);

            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.QueryFirst<RequestStatus>(ScriptDataBase.UDP_tbPermisos_Delete, parameters, commandType: CommandType.StoredProcedure);
        }

        public VW_tbPermisos Find(int? id)
        {
            return DB.VW_tbPermisos.Where(x => x.ID == id).FirstOrDefault();
        }

        public RequestStatus Insert(tbPermisos item)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Perm_EsVisible", item.Perm_esVisible, DbType.Boolean, ParameterDirection.Input);
            parameters.Add("@Perm_Icono", item.Perm_Icono, DbType.String, ParameterDirection.Input);
            parameters.Add("@Perm_Descripcion", item.Perm_Descripcion, DbType.String, ParameterDirection.Input);
            parameters.Add("@Perm_Controlador", item.Perm_Controlador, DbType.String, ParameterDirection.Input);
            parameters.Add("@Perm_Action", item.Perm_Action, DbType.String, ParameterDirection.Input);
            parameters.Add("@Modu_ID", item.Modu_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@UsuarioCreacion", item.Perm_UsuarioCreacion, DbType.Int32, ParameterDirection.Input);

            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.QueryFirst<RequestStatus>(ScriptDataBase.UDP_tbPermisos_Insert, parameters, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<VW_tbPermisos> List()
        {
            return DB.VW_tbPermisos.AsList();
        }

        public RequestStatus Update(tbPermisos item, int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Perm_ID", id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Perm_EsVisible", item.Perm_esVisible, DbType.Boolean, ParameterDirection.Input);
            parameters.Add("@Perm_Icono", item.Perm_Icono, DbType.String, ParameterDirection.Input);
            parameters.Add("@Perm_Descripcion", item.Perm_Descripcion, DbType.String, ParameterDirection.Input);
            parameters.Add("@Perm_Controlador", item.Perm_Controlador, DbType.String, ParameterDirection.Input);
            parameters.Add("@Perm_Action", item.Perm_Action, DbType.String, ParameterDirection.Input);
            parameters.Add("@Modu_ID", item.Modu_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@GrEN_Id", item.GrEN_Id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@UsuarioModifica", item.Perm_UsuarioModifica, DbType.Int32, ParameterDirection.Input);
            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.QueryFirst<RequestStatus>(ScriptDataBase.UDP_tbPermisos_Update, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
