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

        public int Delete(int Id, int Mod)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@HoMe_ID", Id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@HoMe_UsuarioModifica", Mod, DbType.Int32, ParameterDirection.Input);

            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.ExecuteScalar<int>(ScriptDataBase.UDP_tbHotelesMenus_Delete, parameters, commandType: CommandType.StoredProcedure);
        }

        public VW_tbHotelesMenus Find(int? id)
        {
            return DB.VW_tbHotelesMenus.Where(x => x.ID == id).FirstOrDefault();
        }

        public int Insert(tbHotelesMenus item)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@HoMe_Descripcion", item.HoMe_Descripcion, DbType.String, ParameterDirection.Input);
            parameters.Add("@HoMe_Precio", item.HoMe_Precio, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("@Hote_ID", item.Hote_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Time_ID", item.Hote_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@HoMe_UsuarioCreacion", item.HoMe_UsuarioCreacion, DbType.Int32, ParameterDirection.Input);

            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.ExecuteScalar<int>(ScriptDataBase.UDP_tbHotelesMenus_Insert, parameters, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<VW_tbHotelesMenus> List()
        {
            return DB.VW_tbHotelesMenus.AsList();
        }

        public int Update(tbHotelesMenus item, int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@HoMe_ID", item.HoMe_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@HoMe_Descripcion", item.HoMe_Descripcion, DbType.String, ParameterDirection.Input);
            parameters.Add("@HoMe_Precio", item.HoMe_Precio, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("@Hote_ID", item.Hote_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Time_ID", item.Hote_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@HoMe_UsuarioModifica", item.HoMe_UsuarioModifica, DbType.Int32, ParameterDirection.Input);
            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.ExecuteScalar<int>(ScriptDataBase.UDP_tbHotelesMenus_Update, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
