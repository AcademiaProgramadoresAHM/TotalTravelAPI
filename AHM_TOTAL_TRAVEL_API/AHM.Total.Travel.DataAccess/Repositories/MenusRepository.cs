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
    public class MenusRepository : IRepository<tbMenus, VW_tbMenus>
    {
        TotalTravelContext db = new TotalTravelContext();

        public RequestStatus Delete(int Id, int Mod)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Menu_ID", Id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Menu_UsuarioModifica", Mod, DbType.Int32, ParameterDirection.Input);

            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.QueryFirst<RequestStatus>(ScriptDataBase.UDP_tbMenu_Delete, parameters, commandType: CommandType.StoredProcedure);
        }

        public VW_tbMenus Find(int? id)
        {
            return db.VW_tbMenus.Where(x => x.ID == id).FirstOrDefault();
        }

        public RequestStatus Insert(tbMenus item)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Time_ID", item.Time_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Menu_Descripcion", item.Menu_Descripcion, DbType.String, ParameterDirection.Input);
            parameters.Add("@Menu_Nombre", item.Menu_Nombre, DbType.String, ParameterDirection.Input);
            parameters.Add("@Menu_Precio", item.Menu_Precio, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("@Rest_ID", item.Rest_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Menu_UsuarioCreacion", item.Menu_UsuarioCreacion, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Menu_Url", item.Menu_Url, DbType.String, ParameterDirection.Input);

            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.QueryFirst<RequestStatus>(ScriptDataBase.UDP_tbMenu_Insert, parameters, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<VW_tbMenus> List()
        {
            return db.VW_tbMenus.AsList();
        }

        public RequestStatus Update(tbMenus item, int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Menu_ID", id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Time_ID", item.Time_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Menu_Descripcion", item.Menu_Descripcion, DbType.String, ParameterDirection.Input);
            parameters.Add("@Menu_Nombre", item.Menu_Nombre, DbType.String, ParameterDirection.Input);
            parameters.Add("@Menu_Precio", item.Menu_Precio, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("@Rest_ID", item.Rest_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Menu_UsuarioModifica", item.Menu_UsuarioModifica, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Menu_Url", item.Menu_Url, DbType.String, ParameterDirection.Input);


            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.QueryFirst<RequestStatus>(ScriptDataBase.UDP_tbMenu_Update, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
