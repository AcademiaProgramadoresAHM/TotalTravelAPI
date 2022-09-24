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
    public class HabitacionesRepository : IRepository<tbHabitaciones, VW_tbHabitaciones>
    {
        TotalTravelContext DB = new TotalTravelContext();
        public RequestStatus Delete(int ID, int Mod)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Habi_ID", ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Habi_UsuarioModifica", Mod, DbType.Int32, ParameterDirection.Input);

            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.QueryFirst<RequestStatus>(ScriptDataBase.UDP_tbHabitaciones_Delete, parameters, commandType: CommandType.StoredProcedure);
        }

        public VW_tbHabitaciones Find(int? id)
        {
            return DB.VW_tbHabitaciones.Where(x => x.ID == id).FirstOrDefault();
        }

        public RequestStatus Insert(tbHabitaciones item)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Habi_Nombre", item.Habi_Nombre, DbType.String, ParameterDirection.Input);
            parameters.Add("@Habi_Descripcion", item.Habi_Descripcion, DbType.String, ParameterDirection.Input);
            parameters.Add("@CaHa_ID", item.CaHa_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Hote_ID", item.Hote_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Habi_Precio", item.Habi_Precio, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Habi_UsuarioCreacion", item.Habi_UsuarioCreacion, DbType.Int32, ParameterDirection.Input);

            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.QueryFirst<RequestStatus>(ScriptDataBase.UDP_tbHabitaciones_Insert, parameters, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<VW_tbHabitaciones> List()
        {
            return DB.VW_tbHabitaciones.AsList();
        }

        public RequestStatus Update(tbHabitaciones item, int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Habi_ID", id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Habi_Nombre", item.Habi_Nombre, DbType.String, ParameterDirection.Input);
            parameters.Add("@Habi_Descripcion", item.Habi_Descripcion, DbType.String, ParameterDirection.Input);
            parameters.Add("@CaHa_ID", item.CaHa_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Hote_ID", item.Hote_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Habi_Precio", item.Habi_Precio, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Habi_UsuarioModifica", item.Habi_UsuarioModifica, DbType.Int32, ParameterDirection.Input);
            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.QueryFirst<RequestStatus>(ScriptDataBase.UDP_tbHabitaciones_Update, parameters, commandType: CommandType.StoredProcedure);
        }

    }
}
