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
    public class CiudadesRepository : IRepository<tbCiudades, VW_tbCiudades>
    {
        TotalTravelContext DB = new TotalTravelContext();

        public int Delete(int ID, int Mod)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Ciud_ID", ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@CiudUsuarioModifica", Mod, DbType.Int32, ParameterDirection.Input);

            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.ExecuteScalar<int>(ScriptDataBase.UDP_tbCiudades_Delete, parameters, commandType: CommandType.StoredProcedure);
        }

        public VW_tbCiudades Find(int? id)
        {
            return DB.VW_tbCiudades.Where(x => x.ID == id).FirstOrDefault();
        }

        public int Insert(tbCiudades item)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Ciud_Descripcion", item.Ciud_Descripcion, DbType.String, ParameterDirection.Input);
            parameters.Add("@Pais_ID", item.Pais_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Ciud_UsuarioCreacion", item.Ciud_UsuarioCreacion, DbType.Int32, ParameterDirection.Input);

            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.ExecuteScalar<int>(ScriptDataBase.UDP_tbCiudades_Insert, parameters, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<VW_tbCiudades> List()
        {
            return DB.VW_tbCiudades.AsList();
        }

        public int Update(tbCiudades item, int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Ciud_ID", item.Ciud_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Ciud_Descripcion", item.Ciud_Descripcion, DbType.String, ParameterDirection.Input);
            parameters.Add("@Pais_ID", item.Pais_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Ciud_UsuarioModifica", item.Ciud_UsuarioModifica, DbType.Int32, ParameterDirection.Input);
            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.ExecuteScalar<int>(ScriptDataBase.UDP_tbCiudades_Update, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
