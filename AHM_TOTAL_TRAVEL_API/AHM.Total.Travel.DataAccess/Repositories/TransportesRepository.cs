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
    public class TransportesRepository : IRepository<tbTransportes, VW_tbTransportesCompleto>
    {
        TotalTravelContext DB = new TotalTravelContext();

        public RequestStatus Delete(int ID, int Mod)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Tprt_ID", ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Tprt_UsuarioModifica", Mod, DbType.Int32, ParameterDirection.Input);

            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.QueryFirst<RequestStatus>(ScriptDataBase.UDP_tbTransportes_Delete, parameters, commandType: CommandType.StoredProcedure);
        }

        public VW_tbTransportesCompleto Find(int? id)
        {
            return DB.VW_tbTransportesCompleto.Where(x => x.ID == id).FirstOrDefault();
        }

        public RequestStatus Insert(tbTransportes item)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@TiTr_ID", item.TiTr_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Part_ID", item.Part_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Dire_ID", item.Dire_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Tprt_UsuarioCreacion", item.Tprt_UsuarioCreacion, DbType.Int32, ParameterDirection.Input);

            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.QueryFirst<RequestStatus>(ScriptDataBase.UDP_tbTransportes_Insert, parameters, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<VW_tbTransportesCompleto> List()
        {
            return DB.VW_tbTransportesCompleto.AsList();
        }
        public IEnumerable<VW_tbTransportesCompleto> ListComplete()
        {
            return DB.VW_tbTransportesCompleto.AsList();
        }

        public RequestStatus Update(tbTransportes item, int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Tprt_ID", id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@TiTr_ID", item.TiTr_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Part_ID", item.Part_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Dire_ID", item.Dire_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Tprt_UsuarioModifica", item.Tprt_UsuarioModifica, DbType.Int32, ParameterDirection.Input);
            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.QueryFirst<RequestStatus>(ScriptDataBase.UDP_tbTransportes_Update, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
