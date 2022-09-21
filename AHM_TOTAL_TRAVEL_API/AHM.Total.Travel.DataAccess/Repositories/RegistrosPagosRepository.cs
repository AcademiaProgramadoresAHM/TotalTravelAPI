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
    public class RegistrosPagosRepository : IRepository<tbRegistrosPagos, VW_tbRegistrosPagos>
    {
        TotalTravelContext DB = new TotalTravelContext();
        public int Delete(int Id, int Mod)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@ID", Id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@UsuarioModifica", Mod, DbType.Int32, ParameterDirection.Input);

            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.ExecuteScalar<int>(ScriptDataBase.UDP_tbRegistrosPagos_Delete, parameters, commandType: CommandType.StoredProcedure);
        }

        public VW_tbRegistrosPagos Find(int? id)
        {
            return DB.VW_tbRegistrosPagos.Where(x => x.ID == id).FirstOrDefault();
        }

        public int Insert(tbRegistrosPagos item)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@ReservacionID", item.Resv_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@TipoPagoID", item.TiPa_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Monto", item.RePa_Monto, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("@FechaPago", item.RePa_FechaPago, DbType.Date, ParameterDirection.Input);
            parameters.Add("@UsuarioCreacion", item.RePa_UsuarioCreacion, DbType.Int32, ParameterDirection.Input);

            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.ExecuteScalar<int>(ScriptDataBase.UDP_tbRegistrosPagos_Insert, parameters, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<VW_tbRegistrosPagos> List()
        {
            return DB.VW_tbRegistrosPagos.ToList();
        }

        public int Update(tbRegistrosPagos item, int id)
        {
            throw new NotImplementedException();
        }
    }
}
