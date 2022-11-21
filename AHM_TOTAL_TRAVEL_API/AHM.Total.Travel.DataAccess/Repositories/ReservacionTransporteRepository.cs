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
    public class ReservacionTransporteRepository : IRepository<tbReservacionTransporte, VW_tbReservacionTransporte>
    {
        TotalTravelContext DB = new TotalTravelContext();

        public RequestStatus Delete(int ID, int Mod)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@ReTr_ID", ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@ReTr_UsuarioModifica", Mod, DbType.Int32, ParameterDirection.Input);

            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.QueryFirst<RequestStatus>(ScriptDataBase.UDP_tbReservacionTransporte_Delete, parameters, commandType: CommandType.StoredProcedure);
        }

        public VW_tbReservacionTransporte Find(int? id)
        {
            return DB.VW_tbReservacionTransporte.Where(x => x.Id == id).FirstOrDefault();
        }

        public RequestStatus Insert(tbReservacionTransporte item)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Detr_ID", item.Detr_ID, DbType.String, ParameterDirection.Input);
            parameters.Add("@Resv_ID", item.Resv_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@ReTr_CantidadAsientos", item.ReTr_CantidadAsientos, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@ReTr_Cancelado", item.ReTr_Cancelado, DbType.String, ParameterDirection.Input);
            parameters.Add("@ReTr_FechaCancelado", item.ReTr_FechaCancelado, DbType.String, ParameterDirection.Input);
            parameters.Add("@ReTr_UsuarioCreacion", item.ReTr_UsuarioCreacion, DbType.Int32, ParameterDirection.Input);

            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.QueryFirst<RequestStatus>(ScriptDataBase.UDP_tbReservacionTransporte_Insert, parameters, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<VW_tbReservacionTransporte> List()
        {
            return DB.VW_tbReservacionTransporte.AsList();
        }

        public RequestStatus Update(tbReservacionTransporte item, int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@ReTr_ID", id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Detr_ID", item.Detr_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Resv_ID", item.Resv_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@ReTr_CantidadAsientos", item.ReTr_CantidadAsientos, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@ReTr_Cancelado", item.ReTr_Cancelado, DbType.String, ParameterDirection.Input);
            parameters.Add("@ReTr_FechaCancelado", item.ReTr_FechaCancelado, DbType.String, ParameterDirection.Input);
            parameters.Add("@ReTr_UsuarioModifica", item.ReTr_UsuarioCreacion, DbType.Int32, ParameterDirection.Input);

            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.QueryFirst<RequestStatus>(ScriptDataBase.UDP_tbReservacionTransporte_Update, parameters, commandType: CommandType.StoredProcedure);
        }

    }
}
