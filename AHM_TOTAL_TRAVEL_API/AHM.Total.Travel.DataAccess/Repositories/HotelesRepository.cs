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
    public class HotelesRepository : IRepository<tbHoteles, VW_tbHoteles>
    {
        TotalTravelContext DB = new TotalTravelContext();
        public int Delete(int ID, int Mod)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Hote_ID", ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Hote_UsuarioModifica", Mod, DbType.Int32, ParameterDirection.Input);

            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.ExecuteScalar<int>(ScriptDataBase.UDP_tbHoteles_Delete, parameters, commandType: CommandType.StoredProcedure);
        }

        public VW_tbHoteles Find(int? id)
        {
            return DB.VW_tbHoteles.Where(x => x.ID == id).FirstOrDefault();
        }

        public int Insert(tbHoteles item)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Hote_Nombre", item.Hote_Nombre, DbType.String, ParameterDirection.Input);
            parameters.Add("@Hote_Descripcion", item.Hote_Descripcion, DbType.String, ParameterDirection.Input);
            parameters.Add("@Dire_ID", item.Dire_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Part_ID", item.Part_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Hote_UsuarioCreacion", item.Hote_UsuarioCreacion, DbType.Int32, ParameterDirection.Input);

            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.ExecuteScalar<int>(ScriptDataBase.UDP_tbHoteles_Insert, parameters, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<VW_tbHoteles> List()
        {
            return DB.VW_tbHoteles.AsList();
        }

        public int Update(tbHoteles item, int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Hote_ID", id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Hote_Nombre", item.Hote_Nombre, DbType.String, ParameterDirection.Input);
            parameters.Add("@Hote_Descripcion", item.Hote_Descripcion, DbType.String, ParameterDirection.Input);
            parameters.Add("@Dire_ID", item.Dire_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Part_ID", item.Part_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Hote_UsuarioModifica", item.Hote_UsuarioModifica, DbType.Int32, ParameterDirection.Input);
            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.ExecuteScalar<int>(ScriptDataBase.UDP_tbHoteles_Update, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
