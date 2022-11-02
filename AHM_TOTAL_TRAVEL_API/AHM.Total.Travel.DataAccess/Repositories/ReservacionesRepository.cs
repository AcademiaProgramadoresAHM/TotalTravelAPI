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
    public class ReservacionesRepository : IRepository<tbReservaciones, VW_tbReservaciones>
    {
        TotalTravelContext DB = new TotalTravelContext();
        public RequestStatus Delete(int Id, int Mod)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Resv_ID", Id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Resv_UsuarioModifica", Mod, DbType.Int32, ParameterDirection.Input);

            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.QueryFirst<RequestStatus>(ScriptDataBase.UDP_tbReservaciones_Delete, parameters, commandType: CommandType.StoredProcedure);
        }

        public VW_tbReservaciones Find(int? id)
        {
            return DB.VW_tbReservaciones.Where(x => x.ID == id).FirstOrDefault();
        }

        public RequestStatus Insert(tbReservaciones item)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Usua_ID", item.Usua_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Resv_UsuarioCreacion", item.Resv_UsuarioCreacion, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Resv_Precio", item.Resv_Precio, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("@Paqu_ID", item.Paqu_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Resv_esPersonalizado", item.Resv_esPersonalizado, DbType.Boolean, ParameterDirection.Input);
            parameters.Add("@Resv_CantidadPagos", item.Resv_CantidadPagos, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Resv_NumeroPersonas", item.Resv_NumeroPersonas, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Resv_ConfirmacionPago", item.Resv_ConfirmacionPago, DbType.Boolean, ParameterDirection.Input);
            parameters.Add("@Resv_ConfirmacionHotel", item.Resv_ConfirmacionHotel, DbType.Boolean, ParameterDirection.Input);
            parameters.Add("@Resv_ConfirmacionRestaurante", item.Resv_ConfirmacionRestaurante, DbType.Boolean, ParameterDirection.Input);
            parameters.Add("@Resv_ConfirmacionTrans", item.Resv_ConfirmacionTrans, DbType.Boolean, ParameterDirection.Input);

            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.QueryFirst<RequestStatus>(ScriptDataBase.UDP_tbReservaciones_Insert, parameters, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<VW_tbReservaciones> List()
        {
            return DB.VW_tbReservaciones.ToList();
        }

        public RequestStatus Update(tbReservaciones item, int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Resv_ID", id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Usua_ID", item.Usua_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Resv_UsuarioModifica", item.Resv_UsuarioModifica, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Resv_Precio", item.Resv_Precio, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("@Paqu_ID", item.Paqu_ID, DbType.Int32, ParameterDirection.Input);

            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.QueryFirst<RequestStatus>(ScriptDataBase.UDP_tbReservaciones_Update, parameters, commandType: CommandType.StoredProcedure);
        }

        public RequestStatus Confirmaciones(int id, int mod, int ConfirmTipe)
        {
            /*
			    -- CONFIRM CODES --
			    1 = hotel
			    2 = restaurante,
			    3 = transporte,
			    4 = pago
		    */

            var parameters = new DynamicParameters();
            parameters.Add("@Resv_ID", id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@ConfirmTipe", ConfirmTipe, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Resv_UsuarioModifica", mod, DbType.Int32, ParameterDirection.Input);

            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.QueryFirst<RequestStatus>(ScriptDataBase.UDP_tbReservaciones_Confirmaciones, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
