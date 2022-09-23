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
    public class ReservacionesHotelesRepository : IRepository<tbReservacionesHoteles, VW_tbReservacionesHoteles>
    {
        TotalTravelContext DB = new TotalTravelContext();
        public int Delete(int Id, int Mod)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@ReHo_ID", Id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Usuario_Modifica", Mod, DbType.Int32, ParameterDirection.Input);

            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.ExecuteScalar<int>(ScriptDataBase.UDP_tbReservacionesHoteles_DELETE, parameters, commandType: CommandType.StoredProcedure);
        }

        public VW_tbReservacionesHoteles Find(int? id)
        {
            return DB.VW_tbReservacionesHoteles.Where(x => x.ID == id).FirstOrDefault();
        }

        public int Insert(tbReservacionesHoteles item)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@ReHo_FechaEntrada", item.ReHo_FechaEntrada, DbType.Date, ParameterDirection.Input);
            parameters.Add("@ReHo_FechaSalida", item.ReHo_FechaSalida, DbType.Date, ParameterDirection.Input);
            parameters.Add("@Resv_ID", item.Resv_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@ReHo_PrecioTotal", item.ReHo_PrecioTotal, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("@Usuario_Creacion", item.ReHo_UsuarioCreacion, DbType.Int32, ParameterDirection.Input);

            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.ExecuteScalar<int>(ScriptDataBase.UDP_tbReservacionesHoteles_INSERT, parameters, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<VW_tbReservacionesHoteles> List()
        {
            return DB.VW_tbReservacionesHoteles.ToList();
        }

        public int Update(tbReservacionesHoteles item, int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@ReHo_ID", id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@ReHo_FechaEntrada", item.ReHo_FechaEntrada, DbType.Date, ParameterDirection.Input);
            parameters.Add("@ReHo_FechaSalida", item.ReHo_FechaSalida, DbType.Date, ParameterDirection.Input);
            parameters.Add("@Resv_ID", item.Resv_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@ReHo_PrecioTotal", item.ReHo_PrecioTotal, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("@Usuario_Modifica", item.ReHo_UsuarioModifica, DbType.Int32, ParameterDirection.Input);

            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.ExecuteScalar<int>(ScriptDataBase.UDP_tbReservacionesHoteles_UPDATE, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
