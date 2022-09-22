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
    public class DireccionesRepository : IRepository<tbDirecciones, VW_tbDirecciones>
    {
        TotalTravelContext DB = new TotalTravelContext();
        public int Delete(int ID, int Mod)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Dire_ID", ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Usuario_Modifica", Mod, DbType.Int32, ParameterDirection.Input);

            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.ExecuteScalar<int>(ScriptDataBase.UDP_tbDirecciones_Delete, parameters, commandType: CommandType.StoredProcedure);
        }

        public VW_tbDirecciones Find(int? id)
        {
            return DB.VW_tbDirecciones.Where(x => x.ID == id).FirstOrDefault();
        }

        public int Insert(tbDirecciones item)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Dire_Descripcion", item.Dire_Descripcion, DbType.String, ParameterDirection.Input);
            parameters.Add("@Ciud_ID", item.Ciud_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Usuario_Creacion", item.Dire_UsuarioCreacion, DbType.Int32, ParameterDirection.Input);

            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.ExecuteScalar<int>(ScriptDataBase.UDP_tbCiudades_Insert, parameters, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<VW_tbDirecciones> List()
        {
            return DB.VW_tbDirecciones.AsList();
        }

        public int Update(tbDirecciones item, int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Dire_ID", id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Dire_Descripcion", item.Dire_Descripcion, DbType.String, ParameterDirection.Input);
            parameters.Add("@Ciud_ID", item.Ciud_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Usuario_Modifica", item.Dire_UsuarioCreacion, DbType.Int32, ParameterDirection.Input);
            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.ExecuteScalar<int>(ScriptDataBase.UDP_tbCiudades_Update, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
