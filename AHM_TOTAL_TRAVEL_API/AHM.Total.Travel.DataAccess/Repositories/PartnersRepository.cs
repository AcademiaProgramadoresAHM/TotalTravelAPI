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
    public class PartnersRepository : IRepository<tbPartners, VW_tbPartners>
    {
        TotalTravelContext DB = new TotalTravelContext();

        public int Delete(int ID, int Mod)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Part_ID", ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Part_UsuarioModifica", Mod, DbType.Int32, ParameterDirection.Input);

            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.ExecuteScalar<int>(ScriptDataBase.UDP_tbPartners_Delete, parameters, commandType: CommandType.StoredProcedure);
        }

        public VW_tbPartners Find(int? id)
        {
            return DB.VW_tbPartners.Where(x => x.ID == id).FirstOrDefault();
        }

        public int Insert(tbPartners item)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Part_Nombre", item.Part_Nombre, DbType.String, ParameterDirection.Input);
            parameters.Add("@Part_Email", item.Part_Email, DbType.String, ParameterDirection.Input);
            parameters.Add("@Part_Telefono", item.Part_Telefono, DbType.String, ParameterDirection.Input);
            parameters.Add("@Part_UsuarioCreacion", item.Part_UsuarioCreacion, DbType.Int32, ParameterDirection.Input);

            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.ExecuteScalar<int>(ScriptDataBase.UDP_tbPartners_Insert, parameters, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<VW_tbPartners> List()
        {
            return (IEnumerable<VW_tbPartners>)DB.VW_tbPartners.AsList();
        }

        public int Update(tbPartners item, int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Part_ID", id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Part_Nombre", item.Part_Nombre, DbType.String, ParameterDirection.Input);
            parameters.Add("@Part_Email", item.Part_Email, DbType.String, ParameterDirection.Input);
            parameters.Add("@Part_Telefono", item.Part_Telefono, DbType.String, ParameterDirection.Input);
            parameters.Add("@Part_UsuarioModifica", item.Part_UsuarioModifica, DbType.Int32, ParameterDirection.Input);
            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.ExecuteScalar<int>(ScriptDataBase.UDP_tbPartners_Update, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
