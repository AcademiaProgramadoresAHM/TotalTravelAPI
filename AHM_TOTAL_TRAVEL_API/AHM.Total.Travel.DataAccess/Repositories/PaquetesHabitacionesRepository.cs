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
    public class PaquetesHabitacionesRepository : IRepository<tbPaquetesHabitaciones, VW_tbPaquetesHabitaciones>
    {
        TotalTravelContext DB = new TotalTravelContext();
        public RequestStatus Delete(int ID, int Mod)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@PaHa_Id", ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@PaHa_UsuarioModifica", Mod, DbType.Int32, ParameterDirection.Input);

            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.QueryFirst<RequestStatus>(ScriptDataBase.UDP_tbPaquetesHabitaciones_Delete, parameters, commandType: CommandType.StoredProcedure);
        }

        public VW_tbPaquetesHabitaciones Find(int? id)
        {
            return DB.VW_tbPaquetesHabitaciones.Where(x => x.ID == id).FirstOrDefault();
        }

        public RequestStatus Insert(tbPaquetesHabitaciones item)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Paqu_Id", item.Paqu_Id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Habi_Id", item.Habi_Id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@PaHa_UsuarioCreacion", item.PaHa_UsuarioCreacion, DbType.Int32, ParameterDirection.Input);

            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.QueryFirst<RequestStatus>(ScriptDataBase.UDP_tbPaquetesHabitaciones_Insert, parameters, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<VW_tbPaquetesHabitaciones> List()
        {
            return DB.VW_tbPaquetesHabitaciones.AsList();
        }

        public RequestStatus Update(tbPaquetesHabitaciones item, int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@PaHa_Id", id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Paqu_Id", item.Paqu_Id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Habi_Id", item.Habi_Id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@PaHa_UsuarioModifica", item.PaHa_UsuarioModifica, DbType.Int32, ParameterDirection.Input);

            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.QueryFirst<RequestStatus>(ScriptDataBase.UDP_tbPaquetesHabitaciones_Update, parameters, commandType: CommandType.StoredProcedure);

        }
    }
}
