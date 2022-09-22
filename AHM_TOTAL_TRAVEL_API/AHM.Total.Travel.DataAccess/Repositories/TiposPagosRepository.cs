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
    public class TiposPagosRepository : IRepository<tbTiposPagos, VW_tbTiposPagos>
    {
        TotalTravelContext DB = new TotalTravelContext();
        public int Delete(int ID, int Mod)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@TiPa_Id", ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Usuario_Modifica", Mod, DbType.Int32, ParameterDirection.Input);

            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.ExecuteScalar<int>(ScriptDataBase.UDP_tbTiposPagos_DELETE, parameters, commandType: CommandType.StoredProcedure);

        }

        public VW_tbTiposPagos Find(int? id)
        {
            return DB.VW_tbTiposPagos.Where(x => x.ID == id).FirstOrDefault();
        }

        public int Insert(tbTiposPagos item)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@TiPa_Descripcion", item.TiPa_Descripcion, DbType.String, ParameterDirection.Input);
            parameters.Add("@Usuario_Creacion", item.TiPa_UsuarioCreacion, DbType.Int32, ParameterDirection.Input);

            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.ExecuteScalar<int>(ScriptDataBase.UDP_tbTiposPagos_INSERT, parameters, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<VW_tbTiposPagos> List()
        {
            return DB.VW_tbTiposPagos.AsList();
        }

        public int Update(tbTiposPagos item, int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@TiPa_Id", id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@TiPa_Descripcion", item.TiPa_Descripcion, DbType.String, ParameterDirection.Input);
            parameters.Add("@Usuario_Modifica", item.TiPa_UsuarioModifica, DbType.Int32, ParameterDirection.Input);
            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.ExecuteScalar<int>(ScriptDataBase.UDP_tbTiposPagos_UPDATE, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
