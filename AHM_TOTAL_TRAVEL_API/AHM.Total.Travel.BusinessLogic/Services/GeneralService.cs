using AHM.Total.Travel.DataAccess.Repositories;
using AHM.Total.Travel.Entities.Entities;
using ConciertosProyecto.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Text;

namespace AHM.Total.Travel.BusinessLogic.Services
{
    public class GeneralService
    {
        private readonly CiudadesRepository _ciudadesRepository;

        public GeneralService(CiudadesRepository ciudades)
        {
            _ciudadesRepository = ciudades;
        }

        #region Ciudades
        //LISTADO
        public ServiceResult ListCities()
        {
            var result = new ServiceResult();
            try
            {
                var list = _ciudadesRepository.List();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        //CREAR
        public ServiceResult CreateCity(tbCiudades item)
        {

            var result = new ServiceResult();
            try
            {
                var map = _ciudadesRepository.Insert(item);
                if (map > 0)
                {

                    return result.Ok(map);
                }
                else
                    return result.Error();
            }
            catch (Exception ex)
            {

                return result.Error(ex.Message);
            }
        }
        //ACTUALIZAR
        public ServiceResult UpdateCity(int id, tbCiudades tbCiudades)
        {
            var result = new ServiceResult();
            try
            {
                var itemID = _ciudadesRepository.Find(id);
                if (itemID != null)
                {
                    var list = _ciudadesRepository.Update(tbCiudades, id);
                    return result.Ok(list);

                }
                else
                {
                    return result.Error("Los datos ingresados son incorrectos");
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        //ELIMINAR
        public ServiceResult DeleteCity(int id, int Mod)
        {
            var result = new ServiceResult();
            try
            {
                var itemID = _ciudadesRepository.Find(id);
                if (itemID != null)
                {
                    var listado = _ciudadesRepository.Delete(id, Mod);
                    return result.Ok(listado);

                }
                else
                {
                    return result.Error("Los datos ingresados son incorrectos");
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        //BUSCAR
        public ServiceResult FindCity(int id)
        {
            var result = new ServiceResult();
            var city = new VW_tbCiudades();
            try
            {
                city = _ciudadesRepository.Find(id);
                return result.Ok(city);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
            
        }

        #endregion
    }
}
