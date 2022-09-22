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
    public class RestaurantesRepository : IRepository<tbRestaurantes, VW_tbRestaurantes>
    {
        TotalTravelContext DB = new TotalTravelContext();

        public int Delete(int Id, int Mod)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@ID", Id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@UsuarioModifica", Mod, DbType.Int32, ParameterDirection.Input);

            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.ExecuteScalar<int>(ScriptDataBase.UDP_tbRestaurantes_Delete, parameters, commandType: CommandType.StoredProcedure);
        }

        public VW_tbRestaurantes Find(int? id)
        {
            return DB.VW_tbRestaurantes.Where(x => x.ID == id).FirstOrDefault();
        }

        public int Insert(tbRestaurantes item)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Dire_ID", item.Dire_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Rest_Nombre", item.Rest_Nombre, DbType.String, ParameterDirection.Input);
            parameters.Add("@Part_ID", item.Part_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Rest_UsuarioCreacion", item.Rest_UsuarioCreacion, DbType.Int32, ParameterDirection.Input);

            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.ExecuteScalar<int>(ScriptDataBase.UDP_tbRestaurantes_Insert, parameters, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<VW_tbRestaurantes> List()
        {
            return DB.VW_tbRestaurantes.ToList();
        }

        public int Update(tbRestaurantes item, int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Rest_ID", id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Dire_ID", item.Dire_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Rest_Nombre", item.Rest_Nombre, DbType.String, ParameterDirection.Input);
            parameters.Add("@Part_ID", item.Part_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Rest_UsuarioModifica", item.Rest_UsuarioModifica, DbType.Int32, ParameterDirection.Input);
            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.ExecuteScalar<int>(ScriptDataBase.UDP_tbRestaurantes_Update, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}

