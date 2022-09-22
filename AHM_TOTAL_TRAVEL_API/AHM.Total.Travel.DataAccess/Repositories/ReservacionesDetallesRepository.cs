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
    public class ReservacionesDetallesRepository : IRepository<tbReservacionesDetalles, VW_tbReservacionesDetalles>
    {
        TotalTravelContext DB = new TotalTravelContext();
        public int Delete(int ID, int Mod)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@ReDe_ID", ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@ReDe_UsuarioModifica", Mod, DbType.Int32, ParameterDirection.Input);

            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.ExecuteScalar<int>(ScriptDataBase.UDP_tbReservacionesDetalles_Delete, parameters, commandType: CommandType.StoredProcedure);
        }

        public VW_tbReservacionesDetalles Find(int? id)
        {
            return DB.VW_tbReservacionesDetalles.Where(x => x.ID == id).FirstOrDefault();
        }

        public int Insert(tbReservacionesDetalles item)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Habi_ID", item.Habi_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@ReHo_ID", item.ReHo_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@ReDe_UsuarioCreacion", item.ReDe_UsuarioCreacion, DbType.String, ParameterDirection.Input);

            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.ExecuteScalar<int>(ScriptDataBase.UDP_tbReservacionesDetalles_Insert, parameters, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<VW_tbReservacionesDetalles> List()
        {
            return DB.VW_tbReservacionesDetalles.AsList();
        }

        public int Update(tbReservacionesDetalles item, int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@ReDe_ID", id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Habi_ID", item.Habi_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@ReHo_ID", item.ReHo_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@ReDe_UsuarioModifica", item.ReDe_UsuarioModifica, DbType.String, ParameterDirection.Input);

            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.ExecuteScalar<int>(ScriptDataBase.UDP_tbReservacionesDetalles_Update, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
