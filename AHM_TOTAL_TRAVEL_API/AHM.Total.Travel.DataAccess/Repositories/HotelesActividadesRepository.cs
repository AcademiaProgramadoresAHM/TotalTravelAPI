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
    public class HotelesActividadesRepository : IRepository<tbHotelesActividades, VW_tbHotelesActividades>
    {
        TotalTravelContext DB = new TotalTravelContext();
        public RequestStatus Delete(int ID, int Mod)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@HoAc_ID", ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@HoAc_UsuarioModifica", Mod, DbType.Int32, ParameterDirection.Input);

            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.QueryFirst<RequestStatus>(ScriptDataBase.UDP_tbHotelesActividades_Delete, parameters, commandType: CommandType.StoredProcedure);
        }

        public VW_tbHotelesActividades Find(int? id)
        {
            return DB.VW_tbHotelesActividades.Where(x => x.ID == id).FirstOrDefault();
        }

        public RequestStatus Insert(tbHotelesActividades item)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Actv_ID", item.Actv_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@HoAc_Descripcion", item.HoAc_Descripcion, DbType.String, ParameterDirection.Input);
            parameters.Add("@HoAc_Precio", item.HoAc_Precio, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Hote_ID", item.Hote_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@HoAc_UsuarioCreacion", item.HoAc_UsuarioCreacion, DbType.Int32, ParameterDirection.Input);

            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.QueryFirst<RequestStatus>(ScriptDataBase.UDP_tbHotelesActividades_Insert, parameters, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<VW_tbHotelesActividades> List()
        {
            return DB.VW_tbHotelesActividades.AsList();
        }

        public RequestStatus Update(tbHotelesActividades item, int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@HoAc_ID", id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Actv_ID", item.Actv_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@HoAc_Descripcion", item.HoAc_Descripcion, DbType.String, ParameterDirection.Input);
            parameters.Add("@HoAc_Precio", item.HoAc_Precio, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Hote_ID", item.Hote_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@HoAc_UsuarioModifica", item.HoAc_UsuarioModifica, DbType.Int32, ParameterDirection.Input);
            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.QueryFirst<RequestStatus>(ScriptDataBase.UDP_tbHotelesActividades_Update, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
