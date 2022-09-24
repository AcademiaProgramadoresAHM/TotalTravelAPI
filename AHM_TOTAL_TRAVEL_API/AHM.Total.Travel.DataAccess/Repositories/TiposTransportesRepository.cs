using AHM.Total.Travel.Entities.Entities;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace AHM.Total.Travel.DataAccess.Repositories
{
    public class TiposTransportesRepository : IRepository<tbTiposTransportes, VW_tbTiposTransportes>
    {
        TotalTravelContext DB = new TotalTravelContext();

        public RequestStatus Delete(int ID, int Mod)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@TiTr_ID", ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@TiTr_UsuarioModifica", Mod, DbType.Int32, ParameterDirection.Input);

            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.QueryFirst<RequestStatus>(ScriptDataBase.UDP_tbTiposTransportes_Delete, parameters, commandType: CommandType.StoredProcedure);
        }

        public VW_tbTiposTransportes Find(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Insert(tbTiposTransportes item)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@TiTr_Descripcion", item.TiTr_Descripcion, DbType.String, ParameterDirection.Input);
            parameters.Add("@TiTr_UsuarioCreacion", item.TiTr_UsuarioCreacion, DbType.Int32, ParameterDirection.Input);

            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.QueryFirst<RequestStatus>(ScriptDataBase.UDP_tbTiposTransportes_Insert, parameters, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<VW_tbTiposTransportes> List()
        {
            return DB.VW_tbTiposTransportes.AsList();
        }

        public RequestStatus Update(tbTiposTransportes item, int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@TiTr_ID", id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@TiTr_Descripcion", item.TiTr_Descripcion, DbType.String, ParameterDirection.Input);
            parameters.Add("@TiTr_UsuarioModifica", item.TiTr_UsuarioModifica, DbType.Int32, ParameterDirection.Input);
            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.QueryFirst<RequestStatus>(ScriptDataBase.UDP_tbTiposTransportes_Update, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
