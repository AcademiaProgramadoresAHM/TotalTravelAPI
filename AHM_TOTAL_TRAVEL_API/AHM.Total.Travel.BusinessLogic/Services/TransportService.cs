using AHM.Total.Travel.DataAccess.Repositories;
using AHM.Total.Travel.Entities.Entities;
using ConciertosProyecto.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Text;

namespace AHM.Total.Travel.BusinessLogic.Services
{
    public class TransportService
    {
        private readonly TransportesRepository _transportesRepository;
        private readonly TiposTransportesRepository _tiposTransportesRepository;
        private readonly HorariosTransportesRepository _horariosTransportesRepository;
        private readonly DetallesTransportesRepository _detallesTransportesRepository;
        private readonly DestinosTransportesRepository _destinosTransportesRepository;


        public TransportService(TransportesRepository transportes, 
                                TiposTransportesRepository tipoTransportes,
                                HorariosTransportesRepository horariosTransportes,
                                DetallesTransportesRepository detallesTransportes,
                                DestinosTransportesRepository destinosTransportes)
        {
            _transportesRepository = transportes;
            _tiposTransportesRepository = tipoTransportes;
            _horariosTransportesRepository = horariosTransportes;
            _detallesTransportesRepository = detallesTransportes;
            _destinosTransportesRepository = destinosTransportes;
        }


        #region TiposTransportes
        //LISTADO
        public ServiceResult ListTipoTransports()
        {
            var result = new ServiceResult();
            try
            {
                var list = _tiposTransportesRepository.List();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        //CREAR
        public ServiceResult CreateTipoTransports(tbTiposTransportes item)
        {

            var result = new ServiceResult();
            try
            {
                var map = _tiposTransportesRepository.Insert(item);
                if (map.CodeStatus > 0)
                {

                    return result.Ok(map);
                }
                else
                {
                    map.MessageStatus = (map.CodeStatus == 0) ? "401 Error de consulta" : map.MessageStatus;
                    return result.Error(map);
                }
            }
            catch (Exception ex)
            {

                return result.Error(ex.Message);
            }
        }
        //ACTUALIZAR
        public ServiceResult UpdateTipoTransports(int id, tbTiposTransportes tbTiposTransportes)
        {
            var result = new ServiceResult();
            try
            {
                var itemID = _tiposTransportesRepository.Find(id);
                if (itemID != null)
                {
                    var map = _tiposTransportesRepository.Update(tbTiposTransportes, id);
                    if (map.CodeStatus > 0)
                    {

                        return result.Ok(map);
                    }
                    else
                    {
                        map.MessageStatus = (map.CodeStatus == 0) ? "401 Error de consulta" : map.MessageStatus;
                        return result.Error(map);
                    }


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
        public ServiceResult DeleteTipoTransports(int id, int Mod)
        {
            var result = new ServiceResult();
            try
            {
                var itemID = _tiposTransportesRepository.Find(id);
                if (itemID != null)
                {
                    var map = _tiposTransportesRepository.Delete(id, Mod);
                    if (map.CodeStatus > 0)
                    {

                        return result.Ok(map);
                    }
                    else
                    {
                        map.MessageStatus = (map.CodeStatus == 0) ? "401 Error de consulta" : map.MessageStatus;
                        return result.Error(map);
                    }


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
        public ServiceResult FindTipoTransports(int id)
        {
            var result = new ServiceResult();
            var Tipotransports = new VW_tbTiposTransportes();
            try
            {
                Tipotransports = _tiposTransportesRepository.Find(id);
                return result.Ok(Tipotransports);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }

        }

        #endregion

        #region Transportes
        //LISTADO
        public ServiceResult ListTransports()
        {
            var result = new ServiceResult();
            try
            {
                var list = _transportesRepository.List();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        //LISTADO COMPLETO
        public ServiceResult ListTransportsComplete()
        {
            var result = new ServiceResult();
            try
            {
                var list = _transportesRepository.ListComplete();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        //CREAR
        public ServiceResult CreateTransports(tbTransportes item)
        {

            var result = new ServiceResult();
            try
            {
                var map = _transportesRepository.Insert(item);
                if (map.CodeStatus > 0)
                {

                    return result.Ok(map);
                }
                else
                {
                    map.MessageStatus = (map.CodeStatus == 0) ? "401 Error de consulta" : map.MessageStatus;
                    return result.Error(map);
                }
            }
            catch (Exception ex)
            {

                return result.Error(ex.Message);
            }
        }
        //ACTUALIZAR
        public ServiceResult UpdateTransports(int id, tbTransportes tbTransportes)
        {
            var result = new ServiceResult();
            try
            {
                var itemID = _transportesRepository.Find(id);
                if (itemID != null)
                {
                    var map = _transportesRepository.Update(tbTransportes, id);
                    if (map.CodeStatus > 0)
                    {

                        return result.Ok(map);
                    }
                    else
                    {
                        map.MessageStatus = (map.CodeStatus == 0) ? "401 Error de consulta" : map.MessageStatus;
                        return result.Error(map);
                    }

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
        public ServiceResult DeleteTransports(int id, int Mod)
        {
            var result = new ServiceResult();
            try
            {
                var itemID = _transportesRepository.Find(id);
                if (itemID != null)
                {
                    var map = _transportesRepository.Delete(id, Mod);
                    if (map.CodeStatus > 0)
                    {

                        return result.Ok(map);
                    }
                    else
                    {
                        map.MessageStatus = (map.CodeStatus == 0) ? "401 Error de consulta" : map.MessageStatus;
                        return result.Error(map);
                    }

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
        public ServiceResult FindTransports(int id)
        {
            var result = new ServiceResult();
            var transports = new VW_tbTransportes();
            try
            {
                transports = _transportesRepository.Find(id);
                return result.Ok(transports);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }

        }

        #endregion

        #region DestinosTransportes
        //LISTADO
        public ServiceResult ListDestinosTransports()
        {
            var result = new ServiceResult();
            try
            {
                var list = _destinosTransportesRepository.List();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        //CREAR
        public ServiceResult CreateDestinosTransports(tbDestinosTransportes item)
        {

            var result = new ServiceResult();
            try
            {
                var map = _destinosTransportesRepository.Insert(item);
                if (map.CodeStatus > 0)
                {

                    return result.Ok(map);
                }
                else
                {
                    map.MessageStatus = (map.CodeStatus == 0) ? "401 Error de consulta" : map.MessageStatus;
                    return result.Error(map);
                }
            }
            catch (Exception ex)
            {

                return result.Error(ex.Message);
            }
        }
        //ACTUALIZAR
        public ServiceResult UpdateDestinosTransports(int id, tbDestinosTransportes tbDestinosTransportes)
        {
            var result = new ServiceResult();
            try
            {
                var itemID = _destinosTransportesRepository.Find(id);
                if (itemID != null)
                {
                    var map = _destinosTransportesRepository.Update(tbDestinosTransportes, id);
                    if (map.CodeStatus > 0)
                    {

                        return result.Ok(map);
                    }
                    else
                    {
                        map.MessageStatus = (map.CodeStatus == 0) ? "401 Error de consulta" : map.MessageStatus;
                        return result.Error(map);
                    }

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
        public ServiceResult DeleteDestinosTransports(int id, int Mod)
        {
            var result = new ServiceResult();
            try
            {
                var itemID = _destinosTransportesRepository.Find(id);
                if (itemID != null)
                {
                    var map = _destinosTransportesRepository.Delete(id, Mod);
                    if (map.CodeStatus > 0)
                    {

                        return result.Ok(map);
                    }
                    else
                    {
                        map.MessageStatus = (map.CodeStatus == 0) ? "401 Error de consulta" : map.MessageStatus;
                        return result.Error(map);
                    }


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
        public ServiceResult FindDestinosTransports(int id)
        {
            var result = new ServiceResult();
            var Destinostransports = new VW_tbDestinosTransportes();
            try
            {
                Destinostransports = _destinosTransportesRepository.Find(id);
                return result.Ok(Destinostransports);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }

        }

        #endregion

        #region HorariosTransportes
        //LISTADO
        public ServiceResult ListHorariosTransports()
        {
            var result = new ServiceResult();
            try
            {
                var list = _horariosTransportesRepository.List();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        //CREAR
        public ServiceResult CreateHorariosTransports(tbHorariosTransportes item)
        {

            var result = new ServiceResult();
            try
            {
                var map = _horariosTransportesRepository.Insert(item);
                if (map.CodeStatus > 0)
                {

                    return result.Ok(map);
                }
                else
                {
                    map.MessageStatus = (map.CodeStatus == 0) ? "401 Error de consulta" : map.MessageStatus;
                    return result.Error(map);
                }
            }
            catch (Exception ex)
            {

                return result.Error(ex.Message);
            }
        }
        //ACTUALIZAR
        public ServiceResult UpdateHorariosTransports(int id, tbHorariosTransportes tbHorariosTransportes)
        {
            var result = new ServiceResult();
            try
            {
                var itemID = _horariosTransportesRepository.Find(id);
                if (itemID != null)
                {
                    var map = _horariosTransportesRepository.Update(tbHorariosTransportes, id);
                    if (map.CodeStatus > 0)
                    {

                        return result.Ok(map);
                    }
                    else
                    {
                        map.MessageStatus = (map.CodeStatus == 0) ? "401 Error de consulta" : map.MessageStatus;
                        return result.Error(map);
                    }

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
        public ServiceResult DeleteHorariosTransports(int id, int Mod)
        {
            var result = new ServiceResult();
            try
            {
                var itemID = _horariosTransportesRepository.Find(id);
                if (itemID != null)
                {
                    var map = _horariosTransportesRepository.Delete(id, Mod);
                    if (map.CodeStatus > 0)
                    {

                        return result.Ok(map);
                    }
                    else
                    {
                        map.MessageStatus = (map.CodeStatus == 0) ? "401 Error de consulta" : map.MessageStatus;
                        return result.Error(map);
                    }

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
        public ServiceResult FindHorariosTransports(int id)
        {
            var result = new ServiceResult();
            var Horariostransports = new VW_tbHorariosTransportes();
            try
            {
                Horariostransports = _horariosTransportesRepository.Find(id);
                return result.Ok(Horariostransports);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }

        }

        #endregion

        #region DetallesTransportes
        //LISTADO
        public ServiceResult ListDetallesTransports()
        {
            var result = new ServiceResult();
            try
            {
                var list = _detallesTransportesRepository.List();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        //CREAR
        public ServiceResult CreateDetallesTransports(tbDetallesTransportes item)
        {

            var result = new ServiceResult();
            try
            {
                var map = _detallesTransportesRepository.Insert(item);
                if (map.CodeStatus > 0)
                {

                    return result.Ok(map);
                }
                else
                {
                    map.MessageStatus = (map.CodeStatus == 0) ? "401 Error de consulta" : map.MessageStatus;
                    return result.Error(map);
                }
            }
            catch (Exception ex)
            {

                return result.Error(ex.Message);
            }
        }
        //ACTUALIZAR
        public ServiceResult UpdateDetallesTransports(int id, tbDetallesTransportes tbDetallesTransportes)
        {
            var result = new ServiceResult();
            try
            {
                var itemID = _detallesTransportesRepository.Find(id);
                if (itemID != null)
                {
                    var map = _detallesTransportesRepository.Update(tbDetallesTransportes, id);
                    if (map.CodeStatus > 0)
                    {

                        return result.Ok(map);
                    }
                    else
                    {
                        map.MessageStatus = (map.CodeStatus == 0) ? "401 Error de consulta" : map.MessageStatus;
                        return result.Error(map);
                    }

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
        public ServiceResult DeleteDetallesTransports(int id, int Mod)
        {
            var result = new ServiceResult();
            try
            {
                var itemID = _detallesTransportesRepository.Find(id);
                if (itemID != null)
                {
                    var map = _detallesTransportesRepository.Delete(id, Mod);
                    if (map.CodeStatus > 0)
                    {

                        return result.Ok(map);
                    }
                    else
                    {
                        map.MessageStatus = (map.CodeStatus == 0) ? "401 Error de consulta" : map.MessageStatus;
                        return result.Error(map);
                    }

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
        public ServiceResult FindDetallesTransports(int id)
        {
            var result = new ServiceResult();
            var Detallestransports = new VW_tbDetallesTransportes();
            try
            {
                Detallestransports = _detallesTransportesRepository.Find(id);
                return result.Ok(Detallestransports);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }

        }

        #endregion

    }
}
