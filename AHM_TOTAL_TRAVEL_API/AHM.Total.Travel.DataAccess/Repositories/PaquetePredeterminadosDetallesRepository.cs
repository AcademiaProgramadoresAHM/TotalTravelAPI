using AHM.Total.Travel.Entities.Entities;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace AHM.Total.Travel.DataAccess.Repositories
{
    public class PaquetePredeterminadosDetallesRepository : IRepository <tbPaquetePredeterminadosDetalles, VW_tbPaquetePredeterminadosDetalles>
    {
        TotalTravelContext DB = new TotalTravelContext();

        public int Delete(int ID, int Mod)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@PaDe_ID", ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@PaDe_UsuarioModifica", Mod, DbType.Int32, ParameterDirection.Input);

            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.ExecuteScalar<int>(ScriptDataBase.UDP_tbPaquetePredeterminadosDetalles_Delete, parameters, commandType: CommandType.StoredProcedure);
        }

        public VW_tbPaquetePredeterminadosDetalles Find(int? id)
        {
            throw new NotImplementedException();
        }

        public int Insert(tbPaquetePredeterminadosDetalles item)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Paqu_ID", item.Paqu_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Actv_ID", item.Actv_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@PaDe_UsuarioCreacion", item.PaDe_UsuarioCreacion, DbType.Int32, ParameterDirection.Input);

            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.ExecuteScalar<int>(ScriptDataBase.UDP_tbPaquetePredeterminadosDetalles_Insert, parameters, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<VW_tbPaquetePredeterminadosDetalles> List()
        {
            return DB.VW_tbPaquetePredeterminadosDetalles.AsList();
        }

        public int Update(tbPaquetePredeterminadosDetalles item, int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@PaDe_ID", item.PaDe_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Paqu_ID", item.Paqu_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Actv_ID", item.Actv_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@PaDe_UsuarioModifica", item.PaDe_UsuarioModifica, DbType.Int32, ParameterDirection.Input);
            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.ExecuteScalar<int>(ScriptDataBase.UDP_tbPaquetePredeterminadosDetalles_Update, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
