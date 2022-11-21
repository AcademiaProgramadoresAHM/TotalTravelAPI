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
    public class ModulosRepository : IRepository<tbModulos, VW_tbModulos>
    {
        TotalTravelContext DB = new TotalTravelContext();
        public RequestStatus Delete(int Id, int Mod)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Modu_ID", Id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Usuario_Modifica", Mod, DbType.Int32, ParameterDirection.Input);

            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.QueryFirst<RequestStatus>(ScriptDataBase.UDP_tbModulos_Delete, parameters, commandType: CommandType.StoredProcedure);
        }

        public VW_tbModulos Find(int? id)
        {
            return DB.VW_tbModulos.Where(x => x.id_modulo == id).FirstOrDefault();
        }

        public RequestStatus Insert(tbModulos item)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Modu_Descripcion", item.Modu_Descripcion, DbType.String, ParameterDirection.Input);
            parameters.Add("@UsuarioCreacion", item.Modu_UsuarioCreacion, DbType.Int32, ParameterDirection.Input);

            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.QueryFirst<RequestStatus>(ScriptDataBase.UDP_tbModulos_Insert, parameters, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<VW_tbModulos> List()
        {
            return DB.VW_tbModulos.AsList();
        }

        public RequestStatus Update(tbModulos item, int id)
        {

            var parameters = new DynamicParameters();
            parameters.Add("@Modu_ID", item.Modu_Id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Modu_Descripcion", item.Modu_Descripcion, DbType.String, ParameterDirection.Input);
            parameters.Add("@Usuario_Modifica", item.Modu_UsuarioModifica, DbType.Int32, ParameterDirection.Input);

            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.QueryFirst<RequestStatus>(ScriptDataBase.UDP_tbModulos_Update, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
