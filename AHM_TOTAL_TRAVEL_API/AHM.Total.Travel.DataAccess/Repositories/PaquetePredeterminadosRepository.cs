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
    public class PaquetePredeterminadosRepository : IRepository<tbPaquetePredeterminados, VW_PaquetePredeterminados>
    {
        TotalTravelContext DB = new TotalTravelContext();

        public int Delete(int ID, int Mod)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Paqu_ID", ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Paqu_UsuarioModifica", Mod, DbType.Int32, ParameterDirection.Input);

            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.ExecuteScalar<int>(ScriptDataBase.UDP_tbCiudades_Delete, parameters, commandType: CommandType.StoredProcedure);
        }

        public VW_PaquetePredeterminados Find(int? id)
        {
            return DB.VW_PaquetePredeterminados.Where(x => x.Id == id).FirstOrDefault();
        }

        public int Insert(tbPaquetePredeterminados item)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Paqu_Nombre", item.Paqu_Nombre, DbType.String, ParameterDirection.Input);
            parameters.Add("@Paqu_Descripcion", item.Paqu_Descripcion, DbType.String, ParameterDirection.Input);
            parameters.Add("@Paqu_Duracion", item.Paqu_Duracion, DbType.String, ParameterDirection.Input);
            parameters.Add("@Hote_ID", item.Hote_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Rest_ID", item.Rest_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Paqu_UsuarioCreacion", item.Paqu_UsuarioCreacion, DbType.Int32, ParameterDirection.Input);

            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.ExecuteScalar<int>(ScriptDataBase.UDP_tbCiudades_Insert, parameters, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<VW_PaquetePredeterminados> List()
        {
            return DB.VW_PaquetePredeterminados.AsList();
        }

        public int Update(tbPaquetePredeterminados item, int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Paqu_ID", item.Paqu_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Paqu_Nombre", item.Paqu_Nombre, DbType.String, ParameterDirection.Input);
            parameters.Add("@Paqu_Descripcion", item.Paqu_Descripcion, DbType.String, ParameterDirection.Input);
            parameters.Add("@Paqu_Duracion", item.Paqu_Duracion, DbType.String, ParameterDirection.Input);
            parameters.Add("@Hote_ID", item.Hote_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Rest_ID", item.Rest_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Paqu_UsuarioModifica", item.Paqu_UsuarioModifica, DbType.Int32, ParameterDirection.Input);
            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.ExecuteScalar<int>(ScriptDataBase.UDP_tbCiudades_Update, parameters, commandType: CommandType.StoredProcedure);
        }

    }
}
