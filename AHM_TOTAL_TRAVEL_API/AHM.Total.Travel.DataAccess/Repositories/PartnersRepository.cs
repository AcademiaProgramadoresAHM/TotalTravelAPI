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

        public RequestStatus Delete(int ID, int Mod)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Part_ID", ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Part_UsuarioModifica", Mod, DbType.Int32, ParameterDirection.Input);

            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.QueryFirst<RequestStatus>(ScriptDataBase.UDP_tbPartners_Delete, parameters, commandType: CommandType.StoredProcedure);
        }

        public VW_tbPartners Find(int? id)
        {
            return DB.VW_tbPartners.Where(x => x.ID == id).FirstOrDefault();
        }

        public RequestStatus Insert(tbPartners item)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Part_Nombre", item.Part_Nombre, DbType.String, ParameterDirection.Input);
            parameters.Add("@Part_Email", item.Part_Email, DbType.String, ParameterDirection.Input);
            parameters.Add("@Part_Telefono", item.Part_Telefono, DbType.String, ParameterDirection.Input);
            parameters.Add("@Part_UsuarioCreacion", item.Part_UsuarioCreacion, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Part_Url", item.Part_Url, DbType.String, ParameterDirection.Input);
            parameters.Add("@TiPart_Id", item.TiPart_Id, DbType.Int32, ParameterDirection.Input);

            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.QueryFirst<RequestStatus>(ScriptDataBase.UDP_tbPartners_Insert, parameters, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<VW_tbPartners> List()
        {
            return DB.VW_tbPartners.AsList();
        }

        public RequestStatus Update(tbPartners item, int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Part_ID", id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Part_Nombre", item.Part_Nombre, DbType.String, ParameterDirection.Input);
            parameters.Add("@Part_Email", item.Part_Email, DbType.String, ParameterDirection.Input);
            parameters.Add("@Part_Telefono", item.Part_Telefono, DbType.String, ParameterDirection.Input);
            parameters.Add("@Part_UsuarioModifica", item.Part_UsuarioModifica, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Part_Url", item.Part_Url, DbType.String, ParameterDirection.Input);
            parameters.Add("@TiPart_Id", item.TiPart_Id, DbType.Int32, ParameterDirection.Input);
            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.QueryFirst<RequestStatus>(ScriptDataBase.UDP_tbPartners_Update, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
