using AHM.Total.Travel.Entities;
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
    public class UsuariosLoginsRepository : IRepository<tbUsuariosLogins, VW_tbUsuariosLogins>
    {
        TotalTravelContext DB = new TotalTravelContext();

        public RequestStatus Delete(int Id, int Mod)
        {
            throw new NotImplementedException();
        }

        public VW_tbUsuariosLogins Find(int? id)
        {
            return DB.VW_tbUsuariosLogins.Where(x => x.ID == id).FirstOrDefault();
        }

        public VW_tbUsuariosLogins FindByToken(string token)
        {
            return DB.VW_tbUsuariosLogins.Where(x => x.RefreshToken == token).FirstOrDefault();
        }

        public RequestStatus Insert(tbUsuariosLogins item)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Usua_ID", item.Usua_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@RefreshToken", item.RefreshToken, DbType.String, ParameterDirection.Input);
            parameters.Add("@Expires", item.Expires, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("@Created", item.Created, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("@Revoked", item.Revoked, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("@isActive", item.isActive, DbType.Boolean, ParameterDirection.Input);
            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.QueryFirst<RequestStatus>(ScriptDataBase.UDP_tbUsuariosLogins_Insert, parameters, commandType: CommandType.StoredProcedure);

        }

        public IEnumerable<VW_tbUsuariosLogins> List()
        {
            throw new NotImplementedException();
        }

        public RequestStatus Update(tbUsuariosLogins item, int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@ID", id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@RefreshToken", item.RefreshToken, DbType.String, ParameterDirection.Input);
            parameters.Add("@Expires", item.Expires, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("@Created", item.Created, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("@Revoked", item.Revoked, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("@isActive", item.isActive, DbType.Boolean, ParameterDirection.Input);
           using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.QueryFirst<RequestStatus>(ScriptDataBase.UDP_tbUsuariosLogins_Update, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
