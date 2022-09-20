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
    public class HorariosTransportesRepository : IRepository<tbHorariosTransportes, VW_tbHorariosTransportes>
    {
        TotalTravelContext DB = new TotalTravelContext();

        public int Delete(int ID, int Mod)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@ID", ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@UsuarioModifica", Mod, DbType.Int32, ParameterDirection.Input);

            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.ExecuteScalar<int>(ScriptDataBase.UDP_tbHorariosTransportes_Delete, parameters, commandType: CommandType.StoredProcedure);
        }

        public VW_tbHorariosTransportes Find(int? id)
        {
            return DB.VW_tbHorariosTransportes.Where(x => x.ID == id).FirstOrDefault();
        }

        public int Insert(tbHorariosTransportes item)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@DestinoTransporte", item.DsTr_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Fecha", item.HoTr_Fecha, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("@HoraSalida", item.HoTr_HoraSalida, DbType.String, ParameterDirection.Input);
            parameters.Add("@HoraLlegada", item.HoTr_HoraLlegada, DbType.String, ParameterDirection.Input);
            parameters.Add("@UsuarioCrea", item.HoTr_UsuarioCreacion, DbType.Int32, ParameterDirection.Input);

            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.ExecuteScalar<int>(ScriptDataBase.UDP_tbHorariosTransportes_Insert, parameters, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<VW_tbHorariosTransportes> List()
        {
            return DB.VW_tbHorariosTransportes.AsList();
        }

        public int Update(tbHorariosTransportes item, int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@ID", item.HoTr_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Fecha", item.HoTr_Fecha, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("@HoraSalida", item.HoTr_HoraSalida, DbType.String, ParameterDirection.Input);
            parameters.Add("@HoraLlegada", item.HoTr_HoraLlegada, DbType.String, ParameterDirection.Input);
            parameters.Add("@UsuarioModifica", item.HoTr_UsuarioModifica, DbType.Int32, ParameterDirection.Input);
            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.ExecuteScalar<int>(ScriptDataBase.UDP_tbHorariosTransportes_Update, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}

