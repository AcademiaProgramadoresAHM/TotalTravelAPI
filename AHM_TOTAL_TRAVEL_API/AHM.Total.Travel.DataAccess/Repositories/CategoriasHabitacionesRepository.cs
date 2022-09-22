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
    public class CategoriasHabitacionesRepository : IRepository<tbCategoriasHabitaciones, VW_tbCategoriasHabitaciones>
    {
        TotalTravelContext DB = new TotalTravelContext();

        public int Delete(int ID, int Mod)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@CaHa_ID", ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@CaHa_UsuarioModifica", Mod, DbType.Int32, ParameterDirection.Input);

            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.ExecuteScalar<int>(ScriptDataBase.UDP_tbCategoriasHabitaciones_Delete, parameters, commandType: CommandType.StoredProcedure);
        }

        public VW_tbCategoriasHabitaciones Find(int? id)
        {
            return DB.VW_tbCategoriasHabitaciones.Where(x => x.ID == id).FirstOrDefault();
        }

        public int Insert(tbCategoriasHabitaciones item)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@CaHa_Descripcion", item.CaHa_Descripcion, DbType.String, ParameterDirection.Input);
            parameters.Add("@CaHa_UsuarioCreacion", item.CaHa_UsuarioCreacion, DbType.Int32, ParameterDirection.Input);

            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.ExecuteScalar<int>(ScriptDataBase.UDP_tbCategoriasHabitaciones_Insert, parameters, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<VW_tbCategoriasHabitaciones> List()
        {
            return DB.VW_tbCategoriasHabitaciones.AsList();
        }

        public int Update(tbCategoriasHabitaciones item, int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@CaHa_ID", id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@CaHa_Descripcion", item.CaHa_Descripcion, DbType.String, ParameterDirection.Input);
            parameters.Add("@CaHa_UsuarioModifica", item.CaHa_UsuarioModifica, DbType.Int32, ParameterDirection.Input);
            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.ExecuteScalar<int>(ScriptDataBase.UDP_tbCategoriasHabitaciones_Update, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
