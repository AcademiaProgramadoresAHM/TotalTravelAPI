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
    public class ReservacionRestaurantesRepository : IRepository<tbReservacionRestaurantes, VW_tbReservacionRestaurante>
    {
        TotalTravelContext DB = new TotalTravelContext();

        public int Delete(int ID, int Mod)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@ReRe_ID", ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@ReRe_UsuarioModifica", Mod, DbType.Int32, ParameterDirection.Input);

            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.ExecuteScalar<int>(ScriptDataBase.UDP_tbReservacionRestaurantes_Delete, parameters, commandType: CommandType.StoredProcedure);
        }

        public VW_tbReservacionRestaurante Find(int? id)
        {
            return DB.VW_tbReservacionRestaurante.Where(x => x.Id == id).FirstOrDefault();
        }

        public int Insert(tbReservacionRestaurantes item)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Resv_ID", item.Resv_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Rest_ID", item.Rest_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@ReRe_FechaReservacion", item.ReRe_FechaReservacion, DbType.Date, ParameterDirection.Input);
            parameters.Add("@ReRe_HoraReservacion", item.ReRe_HoraReservacion, DbType.String, ParameterDirection.Input);
            parameters.Add("@ReRe_UsuarioCreacion", item.ReRe_UsuarioCreacion, DbType.Int32, ParameterDirection.Input);

            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.ExecuteScalar<int>(ScriptDataBase.UDP_tbReservacionRestaurantes_Insert, parameters, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<VW_tbReservacionRestaurante> List()
        {
            return DB.VW_tbReservacionRestaurante.AsList();
        }

        public int Update(tbReservacionRestaurantes item, int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@ReRe_ID", item.ReRe_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Resv_ID", item.Resv_ID, DbType.String, ParameterDirection.Input);
            parameters.Add("@Rest_ID", item.Rest_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@ReRe_FechaReservacion", item.ReRe_FechaReservacion, DbType.Date, ParameterDirection.Input);
            parameters.Add("@ReRe_HoraReservacion", item.ReRe_HoraReservacion, DbType.String, ParameterDirection.Input);
            parameters.Add("@ReRe_UsuarioModifica", item.ReRe_UsuarioModifica, DbType.Int32, ParameterDirection.Input);
            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.ExecuteScalar<int>(ScriptDataBase.UDP_tbReservacionRestaurantes_Update, parameters, commandType: CommandType.StoredProcedure);
        }

    }
}
