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
    public class TipoPartnersRepository : IRepository<tbTipoPartners, VW_tbTipoPartners>
    {
        TotalTravelContext db = new TotalTravelContext();
        public RequestStatus Delete(int Id, int Mod)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@TiPar_Id", Id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@TiPar_UsuarioModifica", Mod, DbType.Int32, ParameterDirection.Input);

            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.QueryFirst<RequestStatus>(ScriptDataBase.UDP_tbTipoPartners_DELETE, parameters, commandType: CommandType.StoredProcedure);
        }

        public VW_tbTipoPartners Find(int? id)
        {
            return db.VW_tbTipoPartners.Where(x => x.ID == id).FirstOrDefault();
        }

        public RequestStatus Insert(tbTipoPartners item)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@TiPar_Descripcion", item.TiPar_Descripcion, DbType.String, ParameterDirection.Input);
            parameters.Add("@TiPar_UsuarioCreacion", item.TiPar_UsuarioCreacion, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Role_Id", item.Rol_Id, DbType.Int32, ParameterDirection.Input);

            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.QueryFirst<RequestStatus>(ScriptDataBase.UDP_tbTipoPartners_INSERT, parameters, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<VW_tbTipoPartners> List()
        {
            return db.VW_tbTipoPartners.ToList();
        }

        public RequestStatus Update(tbTipoPartners item, int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@TiPar_Id", id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@TiPar_Descripcion", item.TiPar_Descripcion, DbType.String, ParameterDirection.Input);
            parameters.Add("@TiPar_UsuarioModifica", item.TiPar_UsuarioModifica, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Role_Id", item.Rol_Id, DbType.Int32, ParameterDirection.Input);

            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.QueryFirst<RequestStatus>(ScriptDataBase.UDP_tbTipoPartners_UPDATE, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
