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
    public class ReservacionesActividadesHotelesRepository : IRepository<tbReservacionesActividadesHoteles, VW_tbReservacionesActividadesHoteles>
    {
        TotalTravelContext DB = new TotalTravelContext();
        public RequestStatus Delete(int ID, int Mod)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@ReAH_ID", ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@ReAH_UsuarioModifica", Mod, DbType.Int32, ParameterDirection.Input);

            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.QueryFirst<RequestStatus>(ScriptDataBase.UDP_tbReservacionesActividadesHoteles_Delete, parameters, commandType: CommandType.StoredProcedure);
        }

        public VW_tbReservacionesActividadesHoteles Find(int? id)
        {
            return DB.VW_tbReservacionesActividadesHoteles.Where(x => x.ID == id).FirstOrDefault();
        }

        public RequestStatus Insert(tbReservacionesActividadesHoteles item)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Resv_ID", item.Resv_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@HoAc_ID", item.HoAc_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@ReAH_Precio", item.ReAH_Precio, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@ReAH_Cantidad", item.ReAH_Cantidad, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@ReAH_FechaReservacion", item.ReAH_FechaReservacion, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("@ReAH_HoraReservacion", item.ReAH_HoraReservacion, DbType.String, ParameterDirection.Input);
            parameters.Add("@ReAH_UsuarioCreacion", item.ReAH_UsuarioCreacion, DbType.Int32, ParameterDirection.Input);

            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.QueryFirst<RequestStatus>(ScriptDataBase.UDP_tbReservacionesActividadesHoteles_Insert, parameters, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<VW_tbReservacionesActividadesHoteles> List()
        {
            return DB.VW_tbReservacionesActividadesHoteles.AsList();
        }

        public RequestStatus Update(tbReservacionesActividadesHoteles item, int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@ReAH_ID", id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Resv_ID", item.Resv_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@HoAc_ID", item.HoAc_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@ReAH_Cantidad", item.ReAH_Cantidad, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@ReAH_FechaReservacion", item.ReAH_FechaReservacion, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("@ReAH_HoraReservacion", item.ReAH_HoraReservacion, DbType.String, ParameterDirection.Input);
            parameters.Add("@ReAH_UsuarioModifica", item.ReAH_UsuarioModifica, DbType.Int32, ParameterDirection.Input);

            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.QueryFirst<RequestStatus>(ScriptDataBase.UDP_tbReservacionesActividadesHoteles_Update, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
