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
    public class NavbarRepository : IRepository<tblGruposElementosNavbar, VW_tblGruposElementosNavbar>
    {
        TotalTravelContext DB = new TotalTravelContext();
        public RequestStatus Delete(int Id, int Mod)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@GrEN_Id", Id, DbType.Int32, ParameterDirection.Input);

            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.QueryFirst<RequestStatus>(ScriptDataBase.UDP_tblGruposElementosNavbar_Delete, parameters, commandType: CommandType.StoredProcedure);
        }


        public VW_tblGruposElementosNavbar Find(int? id)
        {

            return DB.VW_tblGruposElementosNavbar.Where(x => x.ID == id).FirstOrDefault();
        }

        public RequestStatus Insert(tblGruposElementosNavbar item)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@GrEN_NombreGrupo", item.GrEN_NombreGrupo, DbType.String, ParameterDirection.Input);

            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.QueryFirst<RequestStatus>(ScriptDataBase.UDP_tblGruposElementosNavbar_Insert, parameters, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<VW_tblGruposElementosNavbar> List()
        {
            return DB.VW_tblGruposElementosNavbar.AsList();
        }

        public RequestStatus Update(tblGruposElementosNavbar item, int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@GrEN_Id", id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@GrEN_NombreGrupo", item.GrEN_NombreGrupo, DbType.String, ParameterDirection.Input);
            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.QueryFirst<RequestStatus>(ScriptDataBase.UDP_tblGruposElementosNavbar_Update, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
