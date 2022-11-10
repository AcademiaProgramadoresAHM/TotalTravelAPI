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
    
    public class PaquetePredeterminadosRepository : IRepository<tbPaquetePredeterminados, VW_tbPaquetePredeterminados>
    {
        TotalTravelContext DB = new TotalTravelContext();
        public RequestStatus Delete(int ID, int Mod)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Paqu_ID", ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Paqu_UsuarioModifica", Mod, DbType.Int32, ParameterDirection.Input);

            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.QueryFirst<RequestStatus>(ScriptDataBase.UDP_tbPaquetePredeterminado_Delete, parameters, commandType: CommandType.StoredProcedure);
        }

        public VW_tbPaquetePredeterminados Find(int? id)
        {
            return DB.VW_tbPaquetePredeterminados.Where(x => x.Id == id).FirstOrDefault();
        }

        public RequestStatus Insert(tbPaquetePredeterminados item)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Paqu_Nombre", item.Paqu_Nombre, DbType.String, ParameterDirection.Input);
            parameters.Add("@Paqu_Descripcion", item.Paqu_Descripcion, DbType.String, ParameterDirection.Input);
            parameters.Add("@Paqu_Duracion", item.Paqu_Duracion, DbType.String, ParameterDirection.Input);
            parameters.Add("@Hote_ID", item.Hote_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Rest_ID", item.Rest_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Paqu_Precio", item.Paqu_Precio, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Paqu_CantPer", item.Paqu_CantPersonas, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Paqu_Url", item.Paqu_Url, DbType.String, ParameterDirection.Input);
            parameters.Add("@Paqu_UsuarioCreacion", item.Paqu_UsuarioCreacion, DbType.Int32, ParameterDirection.Input);

            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.QueryFirst<RequestStatus>(ScriptDataBase.UDP_tbPaquetePredeterminado_Insert, parameters, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<VW_tbPaquetePredeterminados> List()
        {
            return DB.VW_tbPaquetePredeterminados.AsList();
        }

        public RequestStatus Update(tbPaquetePredeterminados item, int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Paqu_ID", id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Paqu_Nombre", item.Paqu_Nombre, DbType.String, ParameterDirection.Input);
            parameters.Add("@Paqu_Descripcion", item.Paqu_Descripcion, DbType.String, ParameterDirection.Input);
            parameters.Add("@Paqu_Duracion", item.Paqu_Duracion, DbType.String, ParameterDirection.Input);
            parameters.Add("@Hote_ID", item.Hote_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Rest_ID", item.Rest_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Paqu_CantPer", item.Paqu_CantPersonas, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Paqu_Precio", item.Paqu_Precio, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Paqu_Url", item.Paqu_Url, DbType.String, ParameterDirection.Input);
            parameters.Add("@Paqu_UsuarioModifica", item.Paqu_UsuarioModifica, DbType.Int32, ParameterDirection.Input);
            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.QueryFirst<RequestStatus>(ScriptDataBase.UDP_tbPaquetePredeterminado_Update, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}

