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
        private readonly DireccionesRepository _direccionesRepository;
        private readonly PaisesRepository _paisesRepository;
        private readonly PartnersRepository _partnersRepository;

        public GeneralService(CiudadesRepository ciudadesRepository, DireccionesRepository direccionesRepository, PaisesRepository paisesRepository, PartnersRepository partnersRepository)
        {
            _ciudadesRepository = ciudadesRepository;
            _direccionesRepository = direccionesRepository;
            _paisesRepository = paisesRepository;
            _partnersRepository = partnersRepository;
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
        #region Direcciones
        //LISTADO
        public ServiceResult ListAddress()
        {
            var result = new ServiceResult();
            try
            {
                var list = _direccionesRepository.List();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        //CREAR
        public ServiceResult CreateAddress(tbDirecciones item)
        {

            var result = new ServiceResult();
            try
            {
                var map = _direccionesRepository.Insert(item);
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
        public ServiceResult UpdateAddress(int id, tbDirecciones item)
        {
            var result = new ServiceResult();
            try
            {
                var itemID = _paisesRepository.Find(id);
                if (itemID != null)
                {
                    var list = _direccionesRepository.Update(item, id);
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
        public ServiceResult DeleteAddress(int id, int Mod)
        {
            var result = new ServiceResult();
            try
            {
                var itemID = _direccionesRepository.Find(id);
                if (itemID != null)
                {
                    var listado = _direccionesRepository.Delete(id, Mod);
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
        public ServiceResult FindAddress(int id)
        {
            var result = new ServiceResult();            
            try
            {
                VW_tbDirecciones direction = _direccionesRepository.Find(id);
                return result.Ok(direction);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }

        }

        #endregion
        #region Paises
        //LISTADO
        public ServiceResult ListCountries()
        {
            var result = new ServiceResult();
            try
            {
                var list = _paisesRepository.List();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        //CREAR
        public ServiceResult CreateCountry(tbPaises item)
        {

            var result = new ServiceResult();
            try
            {
                var map = _paisesRepository.Insert(item);
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
        public ServiceResult UpdateCountry(int id, tbPaises item)
        {
            var result = new ServiceResult();
            try
            {
                var itemID = _paisesRepository.Find(id);
                if (itemID != null)
                {
                    var list = _paisesRepository.Update(item, id);
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
        public ServiceResult DeleteCountry(int id, int Mod)
        {
            var result = new ServiceResult();
            try
            {
                var itemID = _paisesRepository.Find(id);
                if (itemID != null)
                {
                    var listado = _paisesRepository.Delete(id, Mod);
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
        public ServiceResult FindCountry(int id)
        {
            var result = new ServiceResult();
            try
            {
                VW_tbPaises country = _paisesRepository.Find(id);
                return result.Ok(country);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }

        }

        #endregion
        #region Partners
        //LISTADO
        public ServiceResult ListPartners()
        {
            var result = new ServiceResult();
            try
            {
                var list = _partnersRepository.List();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        //CREAR
        public ServiceResult CreatePartner(tbPartners item)
        {

            var result = new ServiceResult();
            try
            {
                var map = _partnersRepository.Insert(item);
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
        public ServiceResult UpdatePartner(int id, tbPartners item)
        {
            var result = new ServiceResult();
            try
            {
                var itemID = _partnersRepository.Find(id);
                if (itemID != null)
                {
                    var list = _partnersRepository.Update(item, id);
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
        public ServiceResult DeletePartner(int id, int Mod)
        {
            var result = new ServiceResult();
            try
            {
                var itemID = _partnersRepository.Find(id);
                if (itemID != null)
                {
                    var listado = _partnersRepository.Delete(id, Mod);
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
        public ServiceResult FindPartner(int id)
        {
            var result = new ServiceResult();
            try
            {
                VW_tbPartners partner = _partnersRepository.Find(id);
                return result.Ok(partner);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }

        }

        #endregion
    }
}
