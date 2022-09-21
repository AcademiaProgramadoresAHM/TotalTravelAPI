using AHM.Total.Travel.DataAccess.Repositories;
using AHM.Total.Travel.Entities.Entities;
using ConciertosProyecto.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Text;

namespace AHM.Total.Travel.BusinessLogic.Services
{
    public class SaleService
    {
        private readonly PaquetePredeterminadosRepository _paquetepredeterminadosRepository;
        private readonly TiposPagosRepository _tipospagosRepository;
        private readonly PaquetePredeterminadosDetallesRepository _paquetePredeterminadosDetallesRepository;

        public SaleService(PaquetePredeterminadosRepository paquetepredeterminados,
            TiposPagosRepository tipospagos, PaquetePredeterminadosDetallesRepository paquetePredeterminadosDetalles)
        {
            _paquetepredeterminadosRepository = paquetepredeterminados;
            _tipospagosRepository = tipospagos;
            _paquetePredeterminadosDetallesRepository = paquetePredeterminadosDetalles;
        }

        #region PaquetesPredeterminados
        //LISTADO
        public ServiceResult ListCities()
        {
            var result = new ServiceResult();
            try
            {
                var list = _paquetepredeterminadosRepository.List();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        //CREAR
        public ServiceResult CreatePaquetes(tbPaquetePredeterminados item)
        {

            var result = new ServiceResult();
            try
            {
                var map = _paquetepredeterminadosRepository.Insert(item);
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
        public ServiceResult UpdatePaquetes(int id, tbPaquetePredeterminados tbPaquetePredeterminados)
        {
            var result = new ServiceResult();
            try
            {
                var itemID = _paquetepredeterminadosRepository.Find(id);
                if (itemID != null)
                {
                    var list = _paquetepredeterminadosRepository.Update(tbPaquetePredeterminados, id);
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
        public ServiceResult DeletePaquetes(int id, int Mod)
        {
            var result = new ServiceResult();
            try
            {
                var itemID = _paquetepredeterminadosRepository.Find(id);
                if (itemID != null)
                {
                    var listado = _paquetepredeterminadosRepository.Delete(id, Mod);
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
        public ServiceResult FindPaquetes(int id)
        {
            var result = new ServiceResult();
            var city = new VW_tbPaquetePredeterminados();
            try
            {
                city = _paquetepredeterminadosRepository.Find(id);
                return result.Ok(city);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }

        }

        #endregion

        #region TipoPagos
        //LISTADO
        public ServiceResult ListCitive()
        {
            var result = new ServiceResult();
            try
            {
                var list = _tipospagosRepository.List();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        //CREAR
        public ServiceResult CreateTipopago(tbTiposPagos item)
        {

            var result = new ServiceResult();
            try
            {
                var map = _tipospagosRepository.Insert(item);
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
        public ServiceResult UpdateTipopago(int id, tbTiposPagos tbTiposPagos)
        {
            var result = new ServiceResult();
            try
            {
                var itemID = _tipospagosRepository.Find(id);
                if (itemID != null)
                {
                    var list = _tipospagosRepository.Update(tbTiposPagos, id);
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
        public ServiceResult DeleteTipopago(int id, int Mod)
        {
            var result = new ServiceResult();
            try
            {
                var itemID = _tipospagosRepository.Find(id);
                if (itemID != null)
                {
                    var listado = _paquetepredeterminadosRepository.Delete(id, Mod);
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
        public ServiceResult FindTipoPago(int id)
        {
            var result = new ServiceResult();
            var city = new VW_tbTiposPagos();
            try
            {
                city = _tipospagosRepository.Find(id);
                return result.Ok(city);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }

        }

        #endregion

        #region PaquetesPredeterminadosDetalles
        //LISTADO
        public ServiceResult ListPackage()
        {
            var result = new ServiceResult();
            try
            {
                var list = _paquetePredeterminadosDetallesRepository.List();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        //CREAR
        public ServiceResult CreatePaquetesDetalles(tbPaquetePredeterminadosDetalles item)
        {

            var result = new ServiceResult();
            try
            {
                var map = _paquetePredeterminadosDetallesRepository.Insert(item);
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
        public ServiceResult UpdatePaquetesDetalles(int id, tbPaquetePredeterminadosDetalles paquetePredeterminadosDetalles)
        {
            var result = new ServiceResult();
            try
            {
                var itemID = _paquetePredeterminadosDetallesRepository.Find(id);
                if (itemID != null)
                {
                    var list = _paquetePredeterminadosDetallesRepository.Update(paquetePredeterminadosDetalles, id);
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
        public ServiceResult DeletePaquetesDetalles(int id, int Mod)
        {
            var result = new ServiceResult();
            try
            {
                var itemID = _paquetePredeterminadosDetallesRepository.Find(id);
                if (itemID != null)
                {
                    var listado = _paquetePredeterminadosDetallesRepository.Delete(id, Mod);
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
        public ServiceResult FindPaquetesDetalles(int id)
        {
            var result = new ServiceResult();
            var city = new VW_tbPaquetePredeterminadosDetalles();
            try
            {
                city = _paquetePredeterminadosDetallesRepository.Find(id);
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
