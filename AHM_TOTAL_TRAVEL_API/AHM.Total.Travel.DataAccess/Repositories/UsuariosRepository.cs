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
    public class UsuariosRepository : IRepository<tbUsuarios, VW_tbUsuarios>
    {
        TotalTravelContext db = new TotalTravelContext();
        public int Delete(int Id, int Mod)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Usua_ID", Id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Usuario_Modifica", Mod, DbType.Int32, ParameterDirection.Input);

            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.ExecuteScalar<int>(ScriptDataBase.UDP_tbUsuarios_Delete, parameters, commandType: CommandType.StoredProcedure);
        }

        public VW_tbUsuarios Find(int? id)
        {
            return db.VW_tbUsuarios.Where(x => x.ID == id).FirstOrDefault();
        }

        public int Insert(tbUsuarios item)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Usua_DNI", item.Usua_DNI, DbType.String, ParameterDirection.Input);
            parameters.Add("@Usua_Nombre", item.Usua_Nombre, DbType.String, ParameterDirection.Input);
            parameters.Add("@Usua_Apellido", item.Usua_Apellido, DbType.String, ParameterDirection.Input);
            parameters.Add("@Usua_FechaNaci", item.Usua_FechaNaci, DbType.Date, ParameterDirection.Input);
            parameters.Add("@Usua_Email", item.Usua_Email, DbType.String, ParameterDirection.Input);
            parameters.Add("@Usua_Sexo", item.Usua_Sexo, DbType.String, ParameterDirection.Input);
            parameters.Add("@Usua_Telefono", item.Usua_Telefono, DbType.String, ParameterDirection.Input);
            parameters.Add("@Usua_Url", item.Usua_Url, DbType.String, ParameterDirection.Input);
            parameters.Add("@Usua_Password", item.Usua_Password, DbType.String, ParameterDirection.Input);
            parameters.Add("@Usua_esAdmin", item.Usua_esAdmin, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Role_ID", item.Role_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Dire_ID", item.Dire_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Part_ID", item.Part_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Usuario_Creacion", item.Usua_UsuarioCreacion, DbType.Int32, ParameterDirection.Input);

            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.ExecuteScalar<int>(ScriptDataBase.UDP_tbUsuarios_Insert, parameters, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<VW_tbUsuarios> List()
        {
            return db.VW_tbUsuarios.AsList();
        }

        public int Update(tbUsuarios item, int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Usua_ID", item.Usua_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Usua_DNI", item.Usua_DNI, DbType.String, ParameterDirection.Input);
            parameters.Add("@Usua_Nombre", item.Usua_Nombre, DbType.String, ParameterDirection.Input);
            parameters.Add("@Usua_Apellido", item.Usua_Apellido, DbType.String, ParameterDirection.Input);
            parameters.Add("@Usua_Email", item.Usua_Email, DbType.Date, ParameterDirection.Input);
            parameters.Add("@Usua_Sexo", item.Usua_Sexo, DbType.String, ParameterDirection.Input);
            parameters.Add("@Usua_Telefono", item.Usua_Telefono, DbType.String, ParameterDirection.Input);
            parameters.Add("@Usuario_Modifica", item.Usua_UsuarioModifica, DbType.Int32, ParameterDirection.Input);

            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.ExecuteScalar<int>(ScriptDataBase.UDP_tbUsuarios_Update, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
