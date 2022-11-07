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
    public class PaquetesPredeterminadosActividadesHotelesRepository : IRepository<tbPaquetePredeterminadosActividadesHoteles, VW_tbPaquetePredeterminadosActividadesHoteles>
    {
        TotalTravelContext DB = new TotalTravelContext();

        public RequestStatus Delete(int Id, int Mod)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@PaAc_ID", Id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@UsuarioModifica", Mod, DbType.Int32, ParameterDirection.Input);

            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.QueryFirst<RequestStatus>(ScriptDataBase.UDP_PaquetesPredeterminadosHotelesActividades_Delete, parameters, commandType: CommandType.StoredProcedure);
        }

        public VW_tbPaquetePredeterminadosActividadesHoteles Find(int? id)
        {
            return DB.VW_tbPaquetePredeterminadosActividadesHoteles.Where(x => x.ID == id).FirstOrDefault();
        }

        public RequestStatus Insert(tbPaquetePredeterminadosActividadesHoteles item)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Paqu_ID", item.Paqu_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@HoAc_ID", item.HoAc_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@UsuarioCrea", item.PaAc_UsuarioCreacion, DbType.Int32, ParameterDirection.Input);
            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.QueryFirst<RequestStatus>(ScriptDataBase.UDP_PaquetesPredeterminadosHotelesActividades_Insert, parameters, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<VW_tbPaquetePredeterminadosActividadesHoteles> List()
        {
            return DB.VW_tbPaquetePredeterminadosActividadesHoteles.AsList();
        }

        public RequestStatus Update(tbPaquetePredeterminadosActividadesHoteles item, int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@PaAc_ID", id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Paqu_ID", item.Paqu_ID, DbType.String, ParameterDirection.Input);
            parameters.Add("@HoAc_ID", item.HoAc_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@UsuarioModifica", item.PaAc_UsuarioModifica, DbType.Int32, ParameterDirection.Input);
            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.QueryFirst<RequestStatus>(ScriptDataBase.UDP_PaquetesPredeterminadosHotelesActividades_Update, parameters, commandType: CommandType.StoredProcedure);
        }



       
    }
}

