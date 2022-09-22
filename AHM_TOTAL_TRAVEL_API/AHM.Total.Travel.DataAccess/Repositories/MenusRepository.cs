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
        TotalTravelContext DB = new TotalTravelContext();

        public int Delete(int Id, int Mod)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Menu_ID", Id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Menu_UsuarioModifica", Mod, DbType.Int32, ParameterDirection.Input);

            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.ExecuteScalar<int>(ScriptDataBase.UDP_tbMenus_Delete, parameters, commandType: CommandType.StoredProcedure);
        }

        public VW_tbMenus Find(int? id)
        {
            return DB.VW_tbMenus.Where(x => x.ID == id).FirstOrDefault();
        }

        public int Insert(tbMenus item)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Time_ID", item.Time_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Menu_Descripcion", item.Menu_Descripcion, DbType.String, ParameterDirection.Input);
            parameters.Add("@Menu_Nombre", item.Menu_Nombre, DbType.String, ParameterDirection.Input);
            parameters.Add("@Menu_Precio", item.Menu_Precio, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("@Rest_ID", item.Time_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Menu_UsuarioCreacion", item.Menu_UsuarioCreacion, DbType.Int32, ParameterDirection.Input);

            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.ExecuteScalar<int>(ScriptDataBase.UDP_tbMenus_Insert, parameters, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<VW_tbMenus> List()
        {
            return DB.VW_tbMenus.ToList();
        }

        public int Update(tbMenus item, int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Menu_ID", item.Menu_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Time_ID", item.Time_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Menu_Descripcion", item.Menu_Descripcion, DbType.String, ParameterDirection.Input);
            parameters.Add("@Menu_Nombre", item.Menu_Nombre, DbType.String, ParameterDirection.Input);
            parameters.Add("@Menu_Precio", item.Menu_Precio, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("@Rest_ID", item.Time_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Menu_UsuarioModifica", item.Menu_UsuarioModifica, DbType.Int32, ParameterDirection.Input);

            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.ExecuteScalar<int>(ScriptDataBase.UDP_tbMenus_Update, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
