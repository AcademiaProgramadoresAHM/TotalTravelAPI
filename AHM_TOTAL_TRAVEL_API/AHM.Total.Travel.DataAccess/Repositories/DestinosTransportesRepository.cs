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
    public class DestinosTransportesRepository : IRepository<tbDestinosTransportes, VW_tbDestinosTransportes>
    {
        TotalTravelContext DB = new TotalTravelContext();

        public RequestStatus Delete(int ID, int Mod)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@ID", ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@UsuarioModifica", Mod, DbType.Int32, ParameterDirection.Input);

            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.QueryFirst<RequestStatus>(ScriptDataBase.UDP_tbDestinosTransportes_Delete, parameters, commandType: CommandType.StoredProcedure);
        }

        public VW_tbDestinosTransportes Find(int? id)
        {
            return DB.VW_tbDestinosTransportes.Where(x => x.ID == id).FirstOrDefault();
        }

        public RequestStatus Insert(tbDestinosTransportes item)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@CiudadSalida", item.DsTr_CiudadSalida, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@CiudadDestino", item.DsTr_CiudadDestino, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Partner_ID", item.Partner_ID, DbType.Int32, ParameterDirection.Input);          
            parameters.Add("@UsuarioCrea", item.DsTr_UsuarioCreacion, DbType.Int32, ParameterDirection.Input);

            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.QueryFirst<RequestStatus>(ScriptDataBase.UDP_tbDestinosTransportes_Insert, parameters, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<VW_tbDestinosTransportes> List()
        {
            return DB.VW_tbDestinosTransportes.AsList();
        }

        public RequestStatus Update(tbDestinosTransportes item, int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@ID", id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@CiudadSalida", item.DsTr_CiudadSalida, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@CiudadDestino", item.DsTr_CiudadDestino, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Partner_ID", item.Partner_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@UsuarioModifica", item.DsTr_UsuarioModifica, DbType.Int32, ParameterDirection.Input);
            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.QueryFirst<RequestStatus>(ScriptDataBase.UDP_tbDestinosTransportes_Update, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}

