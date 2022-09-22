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
    public class ReservacionesActividadesExtraRepository : IRepository<tbReservacionesActividadesExtras, VW_tbReservacionesActividadesExtras>
    {
        TotalTravelContext DB = new TotalTravelContext();
        public int Delete(int ID, int Mod)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@ReAE_ID", ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@ReAE_UsuarioModifica", Mod, DbType.Int32, ParameterDirection.Input);

            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.ExecuteScalar<int>(ScriptDataBase.UDP_tbReservacionesActividadesExtras_Delete, parameters, commandType: CommandType.StoredProcedure);
        }

        public VW_tbReservacionesActividadesExtras Find(int? id)
        {
            return DB.VW_tbReservacionesActividadesExtras.Where(x => x.ID == id).FirstOrDefault();
        }

        public int Insert(tbReservacionesActividadesExtras item)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Resv_ID", item.Resv_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@AcEx_ID", item.AcEx_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@ReAE_Cantidad", item.ReAE_Cantidad, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@ReAE_FechaReservacion", item.ReAE_FechaReservacion, DbType.Date, ParameterDirection.Input);
            parameters.Add("@ReAE_HoraReservacion", item.ReAE_HoraReservacion, DbType.String, ParameterDirection.Input);
            parameters.Add("@ReAE_UsuarioCreacion", item.ReAE_UsuarioCreacion, DbType.Int32, ParameterDirection.Input);

            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.ExecuteScalar<int>(ScriptDataBase.UDP_tbReservacionesActividadesExtras_Insert, parameters, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<VW_tbReservacionesActividadesExtras> List()
        {
            return DB.VW_tbReservacionesActividadesExtras.AsList();
        }

        public int Update(tbReservacionesActividadesExtras item, int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@ReAE_ID", id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Resv_ID", item.Resv_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@AcEx_ID", item.AcEx_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@ReAE_Cantidad", item.ReAE_Cantidad, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@ReAE_FechaReservacion", item.ReAE_FechaReservacion, DbType.Date, ParameterDirection.Input);
            parameters.Add("@ReAE_HoraReservacion", item.ReAE_HoraReservacion, DbType.String, ParameterDirection.Input);
            parameters.Add("@ReAE_UsuarioModifica", item.ReAE_UsuarioModifica, DbType.Int32, ParameterDirection.Input);

            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.ExecuteScalar<int>(ScriptDataBase.UDP_tbReservacionesActividadesExtras_Update, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
