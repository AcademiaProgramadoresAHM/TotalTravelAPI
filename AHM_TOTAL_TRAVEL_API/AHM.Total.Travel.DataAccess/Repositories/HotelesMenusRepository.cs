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
    public class HotelesMenusRepository : IRepository<tbHotelesMenus, VW_tbHotelesMenus>
    {
        TotalTravelContext DB = new TotalTravelContext();

        public RequestStatus Delete(int Id, int Mod)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@HoMe_ID", Id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@HoMe_UsuarioModifica", Mod, DbType.Int32, ParameterDirection.Input);

            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.QueryFirst<RequestStatus>(ScriptDataBase.UDP_tbHotelesMenus_Delete, parameters, commandType: CommandType.StoredProcedure);
        }

        public VW_tbHotelesMenus Find(int? id)
        {
            return DB.VW_tbHotelesMenus.Where(x => x.ID == id).FirstOrDefault();
        }

        public RequestStatus Insert(tbHotelesMenus item)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@HoMe_Descripcion", item.HoMe_Descripcion, DbType.String, ParameterDirection.Input);
            parameters.Add("@HoMe_Precio", item.HoMe_Precio, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("@Hote_ID", item.Hote_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Time_ID", item.Time_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@HoMe_UsuarioCreacion", item.HoMe_UsuarioCreacion, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Home_Url", item.HoMe_Url, DbType.String, ParameterDirection.Input);

            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.QueryFirst<RequestStatus>(ScriptDataBase.UDP_tbHotelesMenus_Insert, parameters, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<VW_tbHotelesMenus> List()
        {
            return DB.VW_tbHotelesMenus.AsList();
        }

        public RequestStatus Update(tbHotelesMenus item, int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@HoMe_ID", id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@HoMe_Descripcion", item.HoMe_Descripcion, DbType.String, ParameterDirection.Input);
            parameters.Add("@HoMe_Precio", item.HoMe_Precio, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("@Hote_ID", item.Hote_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Time_ID", item.Time_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@HoMe_UsuarioModifica", item.HoMe_UsuarioModifica, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Home_Url", item.HoMe_Url, DbType.String, ParameterDirection.Input);
            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.QueryFirst<RequestStatus>(ScriptDataBase.UDP_tbHotelesMenus_Update, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
