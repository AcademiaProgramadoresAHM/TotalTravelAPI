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
    public class PaisesRepository : IRepository<tbPaises, VW_tbPaises>
    {
        TotalTravelContext DB = new TotalTravelContext();
        public int Delete(int ID, int Mod)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Pais_ID", ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Pais_UsuarioModifica", Mod, DbType.Int32, ParameterDirection.Input);

            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.ExecuteScalar<int>(ScriptDataBase.UDP_tbPaises_Delete, parameters, commandType: CommandType.StoredProcedure);
        }

        public VW_tbPaises Find(int? id)
        {
            return DB.VW_tbPaises.Where(x => x.ID == id).FirstOrDefault();
        }

        public int Insert(tbPaises item)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Pais_Codigo", item.Pais_Codigo, DbType.String, ParameterDirection.Input);
            parameters.Add("@Pais_Descripcion", item.Pais_Descripcion, DbType.String, ParameterDirection.Input);
            parameters.Add("@Pais_UsuarioCreacion", item.Pais_UsuarioCreacion, DbType.Int32, ParameterDirection.Input);

            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.ExecuteScalar<int>(ScriptDataBase.UDP_tbPaises_Insert, parameters, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<VW_tbPaises> List()
        {
            return (IEnumerable<VW_tbPaises>)DB.VW_tbPaises.AsList();
        }

        public int Update(tbPaises item, int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Pais_ID", id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Pais_Codigo", item.Pais_Codigo, DbType.String, ParameterDirection.Input);
            parameters.Add("@Pais_Descripcion", item.Pais_Descripcion, DbType.String, ParameterDirection.Input);
            parameters.Add("@Pais_UsuarioModifica", item.Pais_UsuarioModifica, DbType.Int32, ParameterDirection.Input);
            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.ExecuteScalar<int>(ScriptDataBase.UDP_tbPaises_Update, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
