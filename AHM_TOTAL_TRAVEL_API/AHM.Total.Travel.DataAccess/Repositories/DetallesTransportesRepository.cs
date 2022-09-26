﻿using AHM.Total.Travel.Entities.Entities;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace AHM.Total.Travel.DataAccess.Repositories
{
    public class DetallesTransportesRepository : IRepository<tbDetallesTransportes, VW_tbDetallesTransportes>
    {
        TotalTravelContext DB = new TotalTravelContext();

        public RequestStatus Delete(int ID, int Mod)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@DeTr_ID", ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@DeTr_UsuarioModifica", Mod, DbType.Int32, ParameterDirection.Input);

            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.QueryFirst<RequestStatus>(ScriptDataBase.UDP_tbDetallesTransportes_Delete, parameters, commandType: CommandType.StoredProcedure);
        }

        public VW_tbDetallesTransportes Find(int? id)
        {
            return DB.VW_tbDetallesTransportes.Where(x => x.ID == id).FirstOrDefault();
        }

        public RequestStatus Insert(tbDetallesTransportes item)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Tprt_ID", item.Tprt_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@HoTr_ID", item.HoTr_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@DeTr_Capacidad", item.DeTr_Capacidad, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@DeTr_Precio", item.DeTr_Precio, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("@DeTr_Matricula", item.DeTr_Matricula, DbType.String, ParameterDirection.Input);
            parameters.Add("@DeTr_UsuarioCreacion", item.DeTr_UsuarioCreacion, DbType.Int32, ParameterDirection.Input);

            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.QueryFirst<RequestStatus>(ScriptDataBase.UDP_tbDetallesTransportes_Insert, parameters, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<VW_tbDetallesTransportes> List()
        {
            return DB.VW_tbDetallesTransportes.AsList();
        }

        public RequestStatus Update(tbDetallesTransportes item, int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@DeTr_ID", id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Tprt_ID", item.Tprt_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@HoTr_ID", item.HoTr_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@DeTr_Capacidad", item.DeTr_Capacidad, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@DeTr_Precio", item.DeTr_Precio, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("@DeTr_Matricula", item.DeTr_Matricula, DbType.String, ParameterDirection.Input);
            parameters.Add("@DeTr_UsuarioModifica", item.DeTr_UsuarioModifica, DbType.Int32, ParameterDirection.Input);
            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.QueryFirst<RequestStatus>(ScriptDataBase.UDP_tbDetallesTransportes_Update, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}

