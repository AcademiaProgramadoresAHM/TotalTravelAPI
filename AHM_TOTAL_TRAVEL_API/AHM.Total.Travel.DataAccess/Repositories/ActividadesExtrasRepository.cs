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
    public class ActividadesExtrasRepository : IRepository<tbActividadesExtras, VW_tbActividadesExtras>
    {
        TotalTravelContext DB = new TotalTravelContext();
        public RequestStatus Delete(int Id, int Mod)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@AcEx_ID", Id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@AcEx_UsuarioModifica", Mod, DbType.Int32, ParameterDirection.Input);

            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.QueryFirst<RequestStatus>(ScriptDataBase.UDP_tbActividadesExtra_Delete, parameters, commandType: CommandType.StoredProcedure);
        }

        public VW_tbActividadesExtras Find(int? id)
        {
            return DB.VW_tbActividadesExtras.Where(x => x.ID == id).FirstOrDefault();
        }

        public RequestStatus Insert(tbActividadesExtras item)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Part_ID", item.Part_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Actv_ID", item.Actv_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Dire_ID", item.AcEx_UsuarioCreacion, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@AcEx_Precio", item.Dire_ID, DbType.String, ParameterDirection.Input);
            parameters.Add("@AcEx_Descripcion", item.AcEx_Descripcion, DbType.String, ParameterDirection.Input);
            parameters.Add("@AcEx_UsuarioCreacion", item.AcEx_UsuarioCreacion, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@AcEx_Url", item.AcEx_Url, DbType.String, ParameterDirection.Input);
            parameters.Add("@Dire_ID", item.Dire_ID, DbType.Int32, ParameterDirection.Input);
            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.QueryFirst<RequestStatus>(ScriptDataBase.UDP_tbActividadesExtra_Insert, parameters, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<VW_tbActividadesExtras> List()
        {
            return DB.VW_tbActividadesExtras.AsList();
        }

        public RequestStatus Update(tbActividadesExtras item, int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@AcEx_ID", id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Part_ID", item.Part_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Actv_ID", item.Actv_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Dire_ID", item.Dire_ID, DbType.String, ParameterDirection.Input);
            parameters.Add("@AcEx_Precio", item.AcEx_Precio, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@AcEx_Descripcion", item.AcEx_Descripcion, DbType.String, ParameterDirection.Input);
            parameters.Add("@AcEx_UsuarioModifica", item.AcEx_UsuarioModifica, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@AcEx_Url", item.AcEx_Url, DbType.String, ParameterDirection.Input);
            parameters.Add("@Dire_ID", item.Dire_ID, DbType.Int32, ParameterDirection.Input);

            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.QueryFirst<RequestStatus>(ScriptDataBase.UDP_tbActividadesExtra_Update, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
