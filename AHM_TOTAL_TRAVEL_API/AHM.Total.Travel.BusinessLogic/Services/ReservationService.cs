using AHM.Total.Travel.Common.Models;
using AHM.Total.Travel.DataAccess.Repositories;
using ConciertosProyecto.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Utilities;
using Newtonsoft.Json.Serialization;
using AHM.Total.Travel.Entities.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Runtime.CompilerServices;

namespace AHM.Total.Travel.BusinessLogic.Services
{
    public class ReservationService
    {
        private readonly ReservacionesActividadesExtraRepository _reservacionesActividadesExtraRepository;
        private readonly RegistrosPagosRepository _registrosPagosRepository;
        private readonly ReservacionesRepository _reservacionesRepository;
        private readonly ReservacionesActividadesHotelesRepository _reservacionesActividadesHotelesRepository;
        private readonly ReservacionesDetallesRepository _reservacionesDetallesRepository;
        private readonly ReservacionesHotelesRepository _reservacionesHotelesRepository;
        private readonly ReservacionRestaurantesRepository _reservacionRestaurantesRepository;
        private readonly ReservacionTransporteRepository _reservacionTransporteRepository;
        private readonly PaquetesPredeterminadosActividadesHotelesRepository _actividadesHotelesRepository;
        private readonly SaleService _saleService;
        private readonly PaquetePredeterminadosRepository _predeterminadosRepository;
        private readonly PaquetePredeterminadosDetallesRepository _paquetesDetallesRepository;

        private readonly HotelService _hotelService;
        private readonly TransportService _transportService;

        public ReservationService(ReservacionesActividadesExtraRepository reservacionesActividadesExtraRepository, RegistrosPagosRepository registrosPagosRepository, ReservacionesRepository reservacionesRepository, ReservacionesActividadesHotelesRepository reservacionesActividadesHotelesRepository, ReservacionesDetallesRepository reservacionesDetallesRepository, ReservacionesHotelesRepository reservacionesHotelesRepository, ReservacionRestaurantesRepository reservacionRestaurantesRepository, ReservacionTransporteRepository reservacionTransporteRepository, PaquetesPredeterminadosActividadesHotelesRepository actividadesHotelesRepository, SaleService saleService, PaquetePredeterminadosRepository predeterminadosRepository, PaquetePredeterminadosDetallesRepository paquetesDetallesRepository, HotelService hotelService, TransportService transportService)
        {
            _reservacionesActividadesExtraRepository = reservacionesActividadesExtraRepository;
            _registrosPagosRepository = registrosPagosRepository;
            _reservacionesRepository = reservacionesRepository;
            _reservacionesActividadesHotelesRepository = reservacionesActividadesHotelesRepository;
            _reservacionesDetallesRepository = reservacionesDetallesRepository;
            _reservacionesHotelesRepository = reservacionesHotelesRepository;
            _reservacionRestaurantesRepository = reservacionRestaurantesRepository;
            _reservacionTransporteRepository = reservacionTransporteRepository;
            _actividadesHotelesRepository = actividadesHotelesRepository;
            _saleService = saleService;
            _predeterminadosRepository = predeterminadosRepository;
            _paquetesDetallesRepository = paquetesDetallesRepository;
            _hotelService = hotelService;
            _transportService = transportService;
        }





        #region ReservacionesDetalles

        //LISTADO
        public ServiceResult ListReservationDetails()
        {
            var result = new ServiceResult();
            try
            {
                var list = _reservacionesDetallesRepository.List();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        //CREAR
        public ServiceResult CreateReservationDetails(tbReservacionesDetalles item)
        {

            var result = new ServiceResult();
            try
            {
                var map = _reservacionesDetallesRepository.Insert(item);
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
        public ServiceResult UpdateReservationDetails(int id, tbReservacionesDetalles tbReservacionesDetalles)
        {
            var result = new ServiceResult();
            try
            {
                var itemID = _reservacionesDetallesRepository.Find(id);
                if (itemID != null)
                {
                    var map = _reservacionesDetallesRepository.Update(tbReservacionesDetalles, id);
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
        public ServiceResult DeleteReservationDetails(int id, int Mod)
        {
            var result = new ServiceResult();
            try
            {
                var itemID = _reservacionesDetallesRepository.Find(id);
                if (itemID != null)
                {
                    var map = _reservacionesDetallesRepository.Delete(id, Mod);
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
        public ServiceResult FindReservationDetails(int id)
        {
            var result = new ServiceResult();
            try
            {
                var city = _reservacionesDetallesRepository.Find(id);
                return result.Ok(city);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        #endregion

        #region ReservacionRestaurante

            //LISTADO
            public ServiceResult ListReservationRestaurant()
            {
                var result = new ServiceResult();
                try
                {
                    var list = _reservacionRestaurantesRepository.List();
                    return result.Ok(list);
                }
                catch (Exception ex)
                {
                    return result.Error(ex.Message);
                }
            }

            //CREAR
            public ServiceResult CreateReservationRestaurant(tbReservacionRestaurantes item)
            {

                var result = new ServiceResult();
                try
                {
                    var map = _reservacionRestaurantesRepository.Insert(item);
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
            public ServiceResult UpdateReservationRestaurant(int id, tbReservacionRestaurantes tbReservacionRestaurantes)
            {
                var result = new ServiceResult();
                try
                {
                    var itemID = _reservacionRestaurantesRepository.Find(id);
                    if (itemID != null)
                    {
                        var map = _reservacionRestaurantesRepository.Update(tbReservacionRestaurantes, id);
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
            public ServiceResult DeleteReservationRestaurant(int id, int Mod)
            {
                var result = new ServiceResult();
                try
                {
                    var itemID = _reservacionRestaurantesRepository.Find(id);
                    if (itemID != null)
                    {
                        var map = _reservacionRestaurantesRepository.Delete(id, Mod);
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
            public ServiceResult FindReservationRestaurant(int id)
            {
                var result = new ServiceResult();
                try
                {
                    var city = _reservacionRestaurantesRepository.Find(id);
                    return result.Ok(city);
                }
                catch (Exception ex)
                {
                    return result.Error(ex.Message);
                }
            }
        #endregion

        #region ReservacionTransporte
            //LISTADO
            public ServiceResult ListReservationTransport()
            {
                var result = new ServiceResult();
                try
                {
                    var list = _reservacionTransporteRepository.List();
                    return result.Ok(list);
                }
                catch (Exception ex)
                {
                    return result.Error(ex.Message);
                }
            }

            //CREAR
            public ServiceResult CreateReservationTransport(tbReservacionTransporte item)
            {

                var result = new ServiceResult();
                try
                {
                    var map = _reservacionTransporteRepository.Insert(item);
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
            public ServiceResult UpdateReservationTransport(int id, tbReservacionTransporte tbReservacionTransporte)
            {
                var result = new ServiceResult();
                try
                {
                    var itemID = _reservacionTransporteRepository.Find(id);
                    if (itemID != null)
                    {
                        var map = _reservacionTransporteRepository.Update(tbReservacionTransporte, id);
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
            public ServiceResult DeleteReservationTransport(int id, int Mod)
            {
                var result = new ServiceResult();
                try
                {
                    var itemID = _reservacionTransporteRepository.Find(id);
                    if (itemID != null)
                    {
                        var map = _reservacionTransporteRepository.Delete(id, Mod);
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
            public ServiceResult FindReservationTransport(int id)
            {
                var result = new ServiceResult();
                try
                {
                    var city = _reservacionTransporteRepository.Find(id);
                    return result.Ok(city);
                }
                catch (Exception ex)
                {
                    return result.Error(ex.Message);
                }
            }
        #endregion

        #region ReservacionesHoteles
            //LISTADO
            public ServiceResult ListReservationHotel()
            {
                var result = new ServiceResult();
                try
                {
                    var list = _reservacionesHotelesRepository.List();
                    return result.Ok(list);
                }
                catch (Exception ex)
                {
                    return result.Error(ex.Message);
                }
            }

            //CREAR
            public ServiceResult CreateReservationHotel(tbReservacionesHoteles item)
            {

                var result = new ServiceResult();
                try
                {
                    var map = _reservacionesHotelesRepository.Insert(item);
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
            public ServiceResult UpdateReservationHotel(int id, tbReservacionesHoteles tbReservacionesHoteles)
            {
                var result = new ServiceResult();
                try
                {
                    var itemID = _reservacionesHotelesRepository.Find(id);
                    if (itemID != null)
                    {
                        var map = _reservacionesHotelesRepository.Update(tbReservacionesHoteles, id);
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
            public ServiceResult DeleteReservationHotel(int id, int Mod)
            {
                var result = new ServiceResult();
                try
                {
                    var itemID = _reservacionesHotelesRepository.Find(id);
                    if (itemID != null)
                    {
                        var map = _reservacionesHotelesRepository.Delete(id, Mod);
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
            public ServiceResult FindReservationHotel(int id)
            {
                var result = new ServiceResult();
                try
                {
                    var city = _reservacionesHotelesRepository.Find(id);
                    return result.Ok(city);
                }
                catch (Exception ex)
                {
                    return result.Error(ex.Message);
                }
            }
        #endregion

        #region ReservacionesActividadesExtra

        //LISTADO
        public ServiceResult ListReservationActivitiesExtra()
        {
            var result = new ServiceResult();
            try
            {
                var list = _reservacionesActividadesExtraRepository.List();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        //CREAR
        public ServiceResult CreateReservationActivitiesExtra(tbReservacionesActividadesExtras item)
        {

            var result = new ServiceResult();
            try
            {
                var map = _reservacionesActividadesExtraRepository.Insert(item);
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
        public ServiceResult UpdateReservationActivitiesExtra(int id, tbReservacionesActividadesExtras tbReservacionesActividadesExtras)
        {
            var result = new ServiceResult();
            try
            {
                var itemID = _reservacionesActividadesExtraRepository.Find(id);
                if (itemID != null)
                {
                    var map = _reservacionesActividadesExtraRepository.Update(tbReservacionesActividadesExtras, id);
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
        public ServiceResult DeleteReservationActivitiesExtra(int id, int Mod)
        {
            var result = new ServiceResult();
            try
            {
                var itemID = _reservacionesActividadesExtraRepository.Find(id);
                if (itemID != null)
                {
                    var map = _reservacionesActividadesExtraRepository.Delete(id, Mod);
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
        public ServiceResult FindReservationActivitiesExtra(int id)
        {
            var result = new ServiceResult();
            var city = new VW_tbReservacionesActividadesExtras();
            try
            {
                city = _reservacionesActividadesExtraRepository.Find(id);
                return result.Ok(city);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        #endregion

        #region ReservacionesActividadesHoteles

        //LISTADO
        public ServiceResult ListReservationActivitiesHotels()
        {
            var result = new ServiceResult();
            try
            {
                var list = _reservacionesActividadesHotelesRepository.List();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        //CREAR
        public ServiceResult CreateReservationActivitiesHotels(tbReservacionesActividadesHoteles item)
        {

            var result = new ServiceResult();
            try
            {
                var map = _reservacionesActividadesHotelesRepository.Insert(item);
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
        public ServiceResult UpdateReservationActivitiesHotels(int id, tbReservacionesActividadesHoteles tbReservacionesActividadesHoteles)
        {
            var result = new ServiceResult();
            try
            {
                var itemID = _reservacionesActividadesHotelesRepository.Find(id);
                if (itemID != null)
                {
                    var map = _reservacionesActividadesHotelesRepository.Update(tbReservacionesActividadesHoteles, id);
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
        public ServiceResult DeleteReservationActivitiesHotels(int id, int Mod)
        {
            var result = new ServiceResult();
            try
            {
                var itemID = _reservacionesActividadesHotelesRepository.Find(id);
                if (itemID != null)
                {
                    var map = _reservacionesActividadesHotelesRepository.Delete(id, Mod);
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
        public ServiceResult FindReservationActivitiesHotels(int id)
        {
            var result = new ServiceResult();
            var city = new VW_tbReservacionesActividadesHoteles();
            try
            {
                city = _reservacionesActividadesHotelesRepository.Find(id);
                return result.Ok(city);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        #endregion

        #region Reservaciones
        //LISTADO
        public ServiceResult ListReservation()
        {
            var result = new ServiceResult();
            try
            {
                var list = _reservacionesRepository.List();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        //CREAR
        public ServiceResult CreateReservation(tbReservaciones item)
        {

            var result = new ServiceResult();
            try
            {
                var map = _reservacionesRepository.Insert(item);
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
        public ServiceResult InsertReservation(tbReservaciones item, ReservacionesViewModel itemViewModel)
        {
            var result = new ServiceResult();
            try
            {
                if (itemViewModel.Resv_esPersonalizado)
                {
                    item.Paqu_ID = 1;
                };

                var ResvID = _reservacionesRepository.Insert(item);
                int ResvIDInt = ResvID.CodeStatus;
                if (ResvIDInt > 0)
                {
                    if (!itemViewModel.Resv_esPersonalizado)
                    {
                        
                        int packID = item.Paqu_ID.Value;

                        VW_tbPaquetePredeterminados package = _predeterminadosRepository.Find(packID);
                        if (package == null)
                        {
                            return result.Error("No se encontró el paquete");
                        }


                        //Create the reservation of the hotel
                        tbReservacionesHoteles resvHotel = new tbReservacionesHoteles
                        {
                            ReHo_FechaEntrada = itemViewModel.ReHo_FechaEntrada,
                            ReHo_FechaSalida = itemViewModel.ReHo_FechaSalida,
                            Hote_ID = package.ID_Hotel,
                            Resv_ID = ResvIDInt,
                            ReHo_UsuarioCreacion = itemViewModel.Resv_UsuarioCreacion
                        };

                        RequestStatus ResvHotelID = _reservacionesHotelesRepository.Insert(resvHotel);
                        int ResvHotelIDInt = ResvHotelID.CodeStatus;
                        if (ResvHotelIDInt > 0)
                        {
                            //Create the reservation of the rooms
                            
                            List<VW_tbPaquetesHabitaciones> packageRooms = (List<VW_tbPaquetesHabitaciones>)_saleService.ListPackageRooms().Data;
                            List<VW_tbPaquetesHabitaciones> filteredPackageRooms = packageRooms.Where(x => x.Paquete_Id == packID).ToList();
                            foreach (var room in filteredPackageRooms)
                            {
                                tbReservacionesDetalles reservacionesDetalles = new tbReservacionesDetalles();

                                reservacionesDetalles.Habi_ID = room.Habitacion_Id;
                                reservacionesDetalles.ReHo_ID = ResvHotelIDInt;
                                reservacionesDetalles.ReDe_UsuarioCreacion = itemViewModel.Resv_UsuarioCreacion;

                                var resultDetails = _reservacionesDetallesRepository.Insert(reservacionesDetalles);
                            }


                            if (itemViewModel.ActividadesExtras != null)
                            {
                                //Creates a reservation for the extra activities
                                List<VW_tbPaquetePredeterminadosDetalles> packageExtraActivities = _paquetesDetallesRepository.List().ToList();
                                List<VW_tbPaquetePredeterminadosDetalles> filteredPackageExtraActivities = packageExtraActivities.Where(x => x.PaqueteID == packID).ToList();
                                foreach (var actvExtra in filteredPackageExtraActivities)
                                {
                                    try
                                    {
                                        tbReservacionesActividadesExtras reservacionesActividadesExtras = new tbReservacionesActividadesExtras
                                        {
                                            Resv_ID = ResvIDInt,
                                            AcEx_ID = actvExtra.ActividadID,
                                            ReAE_Precio = actvExtra.Precio,
                                            ReAE_Cantidad = actvExtra.Cantidad,
                                            ReAE_FechaReservacion = itemViewModel.ActividadesExtras.Find(x => x.AcEx_ID == actvExtra.ActividadID).ReAE_FechaReservacion,
                                            ReAE_HoraReservacion = itemViewModel.ActividadesExtras.Find(x => x.AcEx_ID == actvExtra.ActividadID).ReAE_HoraReservacion,
                                            ReAE_UsuarioCreacion = itemViewModel.Resv_UsuarioCreacion

                                        };
                                        var resultDetails = _reservacionesActividadesExtraRepository.Insert(reservacionesActividadesExtras);
                                    }
                                    catch (Exception)
                                    {

                                        continue;
                                    } 
                                    
                                }

                                foreach (var actvExtra in itemViewModel.ActividadesExtras)
                                {
                                    tbReservacionesActividadesExtras reservacionesActividadesExtras = new tbReservacionesActividadesExtras
                                    {
                                        Resv_ID = ResvIDInt,
                                        AcEx_ID = actvExtra.AcEx_ID,
                                        ReAE_Precio = actvExtra.ReAE_Precio,
                                        ReAE_Cantidad = actvExtra.ReAE_Cantidad,
                                        ReAE_FechaReservacion = actvExtra.ReAE_FechaReservacion,
                                        ReAE_HoraReservacion = actvExtra.ReAE_HoraReservacion,
                                        ReAE_UsuarioCreacion = itemViewModel.Resv_UsuarioCreacion
                                    };
                                    _reservacionesActividadesExtraRepository.Insert(reservacionesActividadesExtras);
                                }
                            }

                            if (itemViewModel.ActividadesHoteles != null)
                            {

                                //Create a reservation of the extra activities in the hotel
                                List<VW_tbPaquetePredeterminadosActividadesHoteles> hotelsActivities = (List<VW_tbPaquetePredeterminadosActividadesHoteles>)_saleService.ListPackagesHotelsActivities().Data;
                                List<VW_tbPaquetePredeterminadosActividadesHoteles> filteredhotelsActivities = hotelsActivities.Where(x => x.ID_Paque == packID).ToList();

                                foreach (var actvHotel in filteredhotelsActivities)
                                {
                                    tbReservacionesActividadesHoteles actividadesHoteles = new tbReservacionesActividadesHoteles
                                    {
                                        Resv_ID = ResvIDInt,
                                        HoAc_ID = actvHotel.ID_HoAc,
                                        ReAH_Cantidad = itemViewModel.ActividadesHoteles.Find(x => x.HoAc_ID == actvHotel.ID_HoAc).ReAH_Cantidad,
                                        ReAH_Precio = itemViewModel.ActividadesHoteles.Find(x => x.HoAc_ID == actvHotel.ID_HoAc).ReAH_Precio,
                                        ReAH_FechaReservacion = itemViewModel.ActividadesHoteles.Find(x => x.HoAc_ID == actvHotel.ID_HoAc).ReAH_FechaReservacion,
                                        ReAH_HoraReservacion = itemViewModel.ActividadesHoteles.Find(x => x.HoAc_ID == actvHotel.ID_HoAc).ReAH_HoraReservacion,
                                        ReAH_UsuarioCreacion = itemViewModel.Resv_UsuarioCreacion

                                    };
                                    var hotelActivities = _reservacionesActividadesHotelesRepository.Insert(actividadesHoteles);
                                }
                                foreach (var actvHotel in itemViewModel.ActividadesHoteles)
                                {
                                    tbReservacionesActividadesHoteles actividadesHoteles = new tbReservacionesActividadesHoteles
                                    {
                                        Resv_ID = ResvIDInt,
                                        HoAc_ID = actvHotel.HoAc_ID,
                                        ReAH_Cantidad = actvHotel.ReAH_Cantidad,
                                        ReAH_Precio = actvHotel.ReAH_Precio,
                                        ReAH_FechaReservacion = actvHotel.ReAH_FechaReservacion,
                                        ReAH_HoraReservacion = actvHotel.ReAH_HoraReservacion,
                                        ReAH_UsuarioCreacion = itemViewModel.Resv_UsuarioCreacion

                                    };
                                    var hotelActivities = _reservacionesActividadesHotelesRepository.Insert(actividadesHoteles);
                                }
                            }
                            
                        }
                        else
                        {
                            ResvHotelID.MessageStatus = (ResvHotelID.CodeStatus == 0) ? "401 Error de consulta a la hora de ingresar una reservacion de hotel" : ResvHotelID.MessageStatus + " (Reservacion de hotel)";
                            return result.Error(ResvHotelID);
                        }
                    }
                    else
                    {
                        //CUSTOM PACKAGE

                        //Create the reservation of the hotel
                        tbReservacionesHoteles resvHotel = new tbReservacionesHoteles
                        {
                            ReHo_FechaEntrada = itemViewModel.ReHo_FechaEntrada,
                            ReHo_FechaSalida = itemViewModel.ReHo_FechaSalida,
                            Hote_ID = itemViewModel.Hote_ID,
                            Resv_ID = ResvIDInt,
                            ReHo_UsuarioCreacion = itemViewModel.Resv_UsuarioCreacion
                        };

                        RequestStatus ResvHotelID = _reservacionesHotelesRepository.Insert(resvHotel);
                        int ResvHotelIDInt = ResvHotelID.CodeStatus;
                        
                        if (ResvHotelIDInt > 0)
                        {
                            if (itemViewModel.Resv_Habitaciones != null)
                            {
                                //Create the reservation of the rooms
                                foreach (var room in itemViewModel.Resv_Habitaciones)
                                {
                                    tbReservacionesDetalles reservacionesDetalles = new tbReservacionesDetalles();

                                    for (var cantidad = 0; cantidad < room.Habi_Cantidad; cantidad++)
                                    {
                                        reservacionesDetalles.Habi_ID = room.Habi_ID;
                                        reservacionesDetalles.ReHo_ID = ResvHotelIDInt;
                                        reservacionesDetalles.ReDe_UsuarioCreacion = itemViewModel.Resv_UsuarioCreacion;

                                        var resultDetails = _reservacionesDetallesRepository.Insert(reservacionesDetalles);
                                    }
                                }
                            }
                            //Create the reservation of the rooms
                            for (int i = 0; i < itemViewModel.Habi_Cantidad; i++)
                            {
                                tbReservacionesDetalles reservacionesDetalles = new tbReservacionesDetalles();

                                reservacionesDetalles.Habi_ID = itemViewModel.Habi_ID;
                                reservacionesDetalles.ReHo_ID = ResvHotelIDInt;
                                reservacionesDetalles.ReDe_UsuarioCreacion = itemViewModel.Resv_UsuarioCreacion;

                                try
                                {
                                    var resultDetails = _reservacionesDetallesRepository.Insert(reservacionesDetalles);
                                }
                                catch (Exception)
                                {

                                    return result.Error("Error al ingresar la reservacion de habitación");
                                }
                            }


                            if (itemViewModel.ActividadesExtras != null)
                            {
                                //Create the reservation of the extra activities
                                foreach (var actividad in itemViewModel.ActividadesExtras)
                                {
                                    tbReservacionesActividadesExtras reservacionesActividadesExtras = new tbReservacionesActividadesExtras
                                    {
                                        Resv_ID = ResvIDInt,
                                        AcEx_ID = actividad.AcEx_ID,
                                        ReAE_Precio = actividad.ReAE_Precio,
                                        ReAE_Cantidad = actividad.ReAE_Cantidad,
                                        ReAE_FechaReservacion = actividad.ReAE_FechaReservacion,
                                        ReAE_HoraReservacion = actividad.ReAE_HoraReservacion,
                                        ReAE_UsuarioCreacion = itemViewModel.Resv_UsuarioCreacion
                                    };


                                    var resultActivitiesExtra = _reservacionesActividadesExtraRepository.Insert(reservacionesActividadesExtras);
                                }

                            }

                            if (itemViewModel.ActividadesHoteles != null)
                            {
                                //Create the reservation of the extra activities in the hotel
                                foreach (var actividadesHoteles in itemViewModel.ActividadesHoteles)
                                {
                                    tbReservacionesActividadesHoteles reservacionesActividadesHoteles = new tbReservacionesActividadesHoteles
                                    {
                                        Resv_ID = ResvIDInt,
                                        HoAc_ID = actividadesHoteles.HoAc_ID,
                                        ReAH_Precio = actividadesHoteles.ReAH_Precio,
                                        ReAH_Cantidad = actividadesHoteles.ReAH_Cantidad,
                                        ReAH_FechaReservacion = actividadesHoteles.ReAH_FechaReservacion,
                                        ReAH_HoraReservacion = actividadesHoteles.ReAH_HoraReservacion,
                                        ReAH_UsuarioCreacion = itemViewModel.Resv_UsuarioCreacion

                                    };
                                    var resultActivitiesHotels = _reservacionesActividadesHotelesRepository.Insert(reservacionesActividadesHoteles);
                                }
                            }


                            if (itemViewModel.Restaurantes != null)
                            {
                                //Create the reservation of the restaurants
                                foreach (var restaurantes in itemViewModel.Restaurantes)
                                {
                                    tbReservacionRestaurantes reservacionRestaurantes = new tbReservacionRestaurantes
                                    {
                                        Resv_ID = ResvIDInt,
                                        Rest_ID = restaurantes.Rest_ID,
                                        ReRe_FechaReservacion = restaurantes.ReRe_FechaReservacion,
                                        ReRe_HoraReservacion = restaurantes.ReRe_HoraReservacion,
                                        ReRe_UsuarioCreacion = itemViewModel.Resv_UsuarioCreacion
                                    };

                                    var resultRestaurants = _reservacionRestaurantesRepository.Insert(reservacionRestaurantes);
                                }
                            }


                            if (itemViewModel.reservacionTransportes != null)
                            {
                                //Creates a reservation for a transport
                                foreach (var transportes in itemViewModel.reservacionTransportes)
                                {
                                    tbReservacionTransporte reservacionTransporte = new tbReservacionTransporte
                                    {
                                        Detr_ID = transportes.Detr_ID,
                                        Resv_ID = ResvIDInt,
                                        ReTr_CantidadAsientos = transportes.ReTr_CantidadAsientos,
                                        ReTr_FechaCancelado = transportes.ReTr_FechaCancelado,
                                        ReTr_Cancelado = transportes.ReTr_Cancelado,
                                        ReTr_UsuarioCreacion = itemViewModel.Resv_UsuarioCreacion
                                    };
                                }
                            }
                            
                        }
                        else
                        {
                            ResvHotelID.MessageStatus = (ResvHotelID.CodeStatus == 0) ? "401 Error de consulta a la hora de ingresar una reservacion de hotel" : ResvHotelID.MessageStatus + " (Reservacion de hotel)";
                            return result.Error(ResvHotelID);
                        }
                    }
                    return result.Ok(ResvID);
                }
                else
                {
                    ResvID.MessageStatus = (ResvID.CodeStatus == 0) ? "401 Error de consulta" : ResvID.MessageStatus;
                    return result.Error(ResvID);
                }
            }
            catch (Exception ex)
            {

                return result.Error(ex.Message);
            }
        }

        //ACTUALIZAR
        public ServiceResult EditReservation(int id, tbReservaciones tbReservaciones, ReservacionesViewModel reservacionesView)
        {
            var result = new ServiceResult();
            try
            {
                if (reservacionesView.Resv_esPersonalizado)
                {
                    tbReservaciones.Paqu_ID = 1;
                };
                //Esto va al final para asignarle el precio
                var ResvID = _reservacionesRepository.Update(tbReservaciones, id);
                int ResvIDInt = ResvID.CodeStatus;
                if (ResvIDInt > 0)
                {
                    if (reservacionesView.JustConfirmation)
                        return result.Ok(ResvID);

                    if (!reservacionesView.Resv_esPersonalizado)
                    {

                        int packID = tbReservaciones.Paqu_ID.GetValueOrDefault();
                        if (!packID.Equals(null))
                        {
                            VW_tbPaquetePredeterminados package = _predeterminadosRepository.Find(packID);
                            if (package == null)
                            {
                                return result.Error("No se encontró el paquete");
                            }

                            //Update the reservation of the hotel
                            int ResvHotelIDInt = _reservacionesHotelesRepository.List().Where(x => x.ReservacionID == id).Select(x => x.ID).FirstOrDefault();
                            tbReservacionesHoteles resvHotel = new tbReservacionesHoteles
                            {
                                ReHo_FechaEntrada = reservacionesView.ReHo_FechaEntrada,
                                ReHo_FechaSalida = reservacionesView.ReHo_FechaSalida,
                                Hote_ID = package.ID_Hotel,
                                Resv_ID = id,
                                ReHo_UsuarioModifica = reservacionesView.Resv_UsuarioModifica
                            };
                            
                            RequestStatus ResvHotelID = _reservacionesHotelesRepository.Update(resvHotel, ResvHotelIDInt);
                            ResvHotelIDInt = ResvHotelID.CodeStatus;
                            
                            if (ResvHotelIDInt > 0)
                            {
                                //Update the reservation of the rooms
                                List<VW_tbPaquetesHabitaciones> packageRooms = (List<VW_tbPaquetesHabitaciones>)_saleService.ListPackageRooms().Data;
                                List<VW_tbPaquetesHabitaciones> filteredPackageRooms = packageRooms.Where(x => x.Paquete_Id == packID).ToList();
                                List<int> ResvDetID = _reservacionesDetallesRepository.List().Where(x => x.ReservacionHotelID == ResvHotelIDInt).Select(x => x.ID).ToList();
                                foreach (var item in ResvDetID)
                                {
                                    _reservacionesDetallesRepository.Delete(item, reservacionesView.Resv_UsuarioModifica.GetValueOrDefault());
                                }

                                foreach (var room in filteredPackageRooms)
                                {
                                    
                                    tbReservacionesDetalles reservacionesDetalles = new tbReservacionesDetalles();
                                        
                                    reservacionesDetalles.Habi_ID = room.Habitacion_Id;
                                    reservacionesDetalles.ReHo_ID = ResvHotelIDInt;
                                    reservacionesDetalles.ReDe_UsuarioCreacion = reservacionesView.Resv_UsuarioCreacion;
                                        
                                    var resultDetails = _reservacionesDetallesRepository.Insert(reservacionesDetalles);
                                }


                                if (reservacionesView.ActividadesExtras != null)
                                {
                                    //Creates a reservation for the extra activities
                                    List<VW_tbPaquetePredeterminadosDetalles> packageExtraActivities = _paquetesDetallesRepository.List().ToList();
                                    List<VW_tbPaquetePredeterminadosDetalles> filteredPackageExtraActivities = packageExtraActivities.Where(x => x.PaqueteID == packID).ToList();
                                    List<int> actvExtraID = _reservacionesActividadesExtraRepository.List().Where(x => x.Reservacion == ResvIDInt).Select(x => x.ID).ToList();
                                    foreach (var item in actvExtraID)
                                    {
                                        _reservacionesActividadesExtraRepository.Delete(item, reservacionesView.Resv_UsuarioModifica.GetValueOrDefault());
                                    }
                                    foreach (var actvExtra in filteredPackageExtraActivities)
                                    {

                                        tbReservacionesActividadesExtras reservacionesActividadesExtras = new tbReservacionesActividadesExtras
                                        {
                                            Resv_ID = ResvIDInt,
                                            AcEx_ID = actvExtra.ActividadID,
                                            ReAE_Precio = actvExtra.Precio,
                                            ReAE_Cantidad = actvExtra.Cantidad,
                                            ReAE_FechaReservacion = reservacionesView.ActividadesExtras.Find(x => x.ReAE_ID == actvExtra.ActividadID).ReAE_FechaReservacion,
                                            ReAE_HoraReservacion = reservacionesView.ActividadesExtras.Find(x => x.ReAE_ID == actvExtra.ActividadID).ReAE_HoraReservacion,
                                            ReAE_UsuarioCreacion = reservacionesView.Resv_UsuarioCreacion

                                        };
                                        _reservacionesActividadesExtraRepository.Insert(reservacionesActividadesExtras);
                                    }
                                }


                                if (reservacionesView.ActividadesHoteles != null)
                                {

                                    //Create a reservation of the extra activities in the hotel
                                    List<VW_tbPaquetePredeterminadosActividadesHoteles> hotelsActivities = (List<VW_tbPaquetePredeterminadosActividadesHoteles>)_saleService.ListPackagesHotelsActivities().Data;
                                    List<VW_tbPaquetePredeterminadosActividadesHoteles> filteredhotelsActivities = hotelsActivities.Where(x => x.ID_Paque == packID).ToList();
                                    List<int> actvHotelID = _reservacionesActividadesHotelesRepository.List().Where(x => x.ReservacionID.Equals(ResvIDInt)).Select(x => x.ID).ToList();
                                    foreach (var item in actvHotelID)
                                    {
                                        _reservacionesActividadesHotelesRepository.Delete(item, reservacionesView.Resv_UsuarioModifica.GetValueOrDefault());
                                    }
                                    foreach (var actvHotel in filteredhotelsActivities)
                                    {
                                        tbReservacionesActividadesHoteles actividadesHoteles = new tbReservacionesActividadesHoteles
                                        {
                                            Resv_ID = ResvIDInt,
                                            HoAc_ID = actvHotel.ID_HoAc,
                                            ReAH_Cantidad = reservacionesView.ActividadesHoteles.Find(x => x.HoAc_ID == actvHotel.ID_HoAc).ReAH_Cantidad,
                                            ReAH_Precio = reservacionesView.ActividadesHoteles.Find(x => x.HoAc_ID == actvHotel.ID_HoAc).ReAH_Precio,
                                            ReAH_FechaReservacion = reservacionesView.ActividadesHoteles.Find(x => x.HoAc_ID == actvHotel.ID_HoAc).ReAH_FechaReservacion,
                                            ReAH_HoraReservacion = reservacionesView.ActividadesHoteles.Find(x => x.HoAc_ID == actvHotel.ID_HoAc).ReAH_HoraReservacion,
                                            ReAH_UsuarioCreacion = reservacionesView.Resv_UsuarioCreacion

                                        };
                                        var hotelActivities = _reservacionesActividadesHotelesRepository.Insert(actividadesHoteles);
                                    }
                                }
                                if (!reservacionesView.ActividadesExtras.Equals(null))
                                {
                                    if (reservacionesView.ActividadesExtras != null)
                                    {
                                        //Create the reservation of the extra activities
                                        foreach (var actividad in reservacionesView.ActividadesExtras)
                                        {
                                            tbReservacionesActividadesExtras reservacionesActividadesExtras = new tbReservacionesActividadesExtras
                                            {
                                                Resv_ID = ResvIDInt,
                                                AcEx_ID = actividad.AcEx_ID,
                                                ReAE_Precio = actividad.ReAE_Precio,
                                                ReAE_Cantidad = actividad.ReAE_Cantidad,
                                                ReAE_FechaReservacion = actividad.ReAE_FechaReservacion,
                                                ReAE_HoraReservacion = actividad.ReAE_HoraReservacion,
                                                ReAE_UsuarioCreacion = reservacionesView.Resv_UsuarioCreacion
                                            };


                                            var resultActivitiesExtra = _reservacionesActividadesExtraRepository.Insert(reservacionesActividadesExtras);
                                        }

                                    }
                                }
                                if (!reservacionesView.Equals(null))
                                {

                                }
                            }
                            else
                            {
                                ResvHotelID.MessageStatus = (ResvHotelID.CodeStatus == 0) ? "401 Error de consulta a la hora de ingresar una reservacion de hotel" : ResvHotelID.MessageStatus + " (Reservacion de hotel)";
                                return result.Error(ResvHotelID);
                            }
                        }
                    }
                    else
                    {
                        //CUSTOM PACKAGE

                        //Create the reservation of the hotel
                        tbReservacionesHoteles resvHotel = new tbReservacionesHoteles
                        {
                            ReHo_FechaEntrada = reservacionesView.ReHo_FechaEntrada,
                            ReHo_FechaSalida = reservacionesView.ReHo_FechaSalida,
                            Hote_ID = reservacionesView.Hote_ID,
                            Resv_ID = ResvIDInt,
                            ReHo_UsuarioModifica = reservacionesView.Resv_UsuarioModifica
                        };

                        RequestStatus ResvHotelID = _reservacionesHotelesRepository.Update(resvHotel, reservacionesView.Resv_UsuarioModifica.GetValueOrDefault());
                        int ResvHotelIDInt = ResvHotelID.CodeStatus;

                        if (ResvHotelIDInt > 0)
                        {
                            if (reservacionesView.Resv_Habitaciones != null)
                            {
                                List<int> ResvHabID = _reservacionesDetallesRepository.List().Where(x => x.ReservacionHotelID == ResvHotelIDInt).Select(x => x.ID).ToList();
                                foreach (var item in ResvHabID)
                                {
                                    _reservacionesDetallesRepository.Delete(item, reservacionesView.Resv_UsuarioModifica.GetValueOrDefault());
                                }
                                //Create the reservation of the rooms
                                foreach (var room in reservacionesView.Resv_Habitaciones)
                                {
                                    tbReservacionesDetalles reservacionesDetalles = new tbReservacionesDetalles();

                                    for (var cantidad = 0; cantidad < room.Habi_Cantidad; cantidad++)
                                    {
                                        reservacionesDetalles.Habi_ID = room.Habi_ID;
                                        reservacionesDetalles.ReHo_ID = ResvHotelIDInt;
                                        reservacionesDetalles.ReDe_UsuarioCreacion = reservacionesView.Resv_UsuarioCreacion;

                                        var resultDetails = _reservacionesDetallesRepository.Insert(reservacionesDetalles);
                                    }
                                }
                            }
                            //Create the reservation of the rooms
                            for (int i = 0; i < reservacionesView.Habi_Cantidad; i++)
                            {
                                tbReservacionesDetalles reservacionesDetalles = new tbReservacionesDetalles();

                                reservacionesDetalles.Habi_ID = reservacionesView.Habi_ID;
                                reservacionesDetalles.ReHo_ID = ResvHotelIDInt;
                                reservacionesDetalles.ReDe_UsuarioCreacion = reservacionesView.Resv_UsuarioCreacion;

                                try
                                {
                                    var resultDetails = _reservacionesDetallesRepository.Insert(reservacionesDetalles);
                                }
                                catch (Exception)
                                {

                                    return result.Error("Error al ingresar la reservacion de habitacion");
                                }
                            }


                            if (reservacionesView.ActividadesExtras != null)
                            {
                                List<int> ActvExtraID = _reservacionesActividadesExtraRepository.List().Where(x => x.Reservacion.Equals(ResvIDInt)).Select(x => x.ID).ToList();

                                foreach (var item in ActvExtraID)
                                {
                                    _reservacionesActividadesExtraRepository.Delete(item, reservacionesView.Resv_UsuarioModifica.GetValueOrDefault());
                                }
                                //Create the reservation of the extra activities
                                foreach (var actividad in reservacionesView.ActividadesExtras)
                                {
                                    tbReservacionesActividadesExtras reservacionesActividadesExtras = new tbReservacionesActividadesExtras
                                    {
                                        Resv_ID = ResvIDInt,
                                        AcEx_ID = actividad.AcEx_ID,
                                        ReAE_Precio = actividad.ReAE_Precio,
                                        ReAE_Cantidad = actividad.ReAE_Cantidad,
                                        ReAE_FechaReservacion = actividad.ReAE_FechaReservacion,
                                        ReAE_HoraReservacion = actividad.ReAE_HoraReservacion,
                                        ReAE_UsuarioCreacion = reservacionesView.Resv_UsuarioCreacion
                                    };


                                    var resultActivitiesExtra = _reservacionesActividadesExtraRepository.Insert(reservacionesActividadesExtras);
                                }

                            }

                            if (reservacionesView.ActividadesHoteles != null)
                            {

                                List<int> ActvHotelID = _reservacionesActividadesHotelesRepository.List().Where(x => x.ReservacionID.Equals(ResvIDInt)).Select(x => x.ID).ToList();
                                foreach (var item in ActvHotelID)
                                {
                                    _reservacionesActividadesHotelesRepository.Delete(item, reservacionesView.Resv_UsuarioModifica.GetValueOrDefault());
                                }
                                //Create the reservation of the extra activities in the hotel
                                foreach (var actividadesHoteles in reservacionesView.ActividadesHoteles)
                                {
                                    tbReservacionesActividadesHoteles reservacionesActividadesHoteles = new tbReservacionesActividadesHoteles
                                    {
                                        Resv_ID = ResvIDInt,
                                        HoAc_ID = actividadesHoteles.HoAc_ID,
                                        ReAH_Precio = actividadesHoteles.ReAH_Precio,
                                        ReAH_Cantidad = actividadesHoteles.ReAH_Cantidad,
                                        ReAH_FechaReservacion = actividadesHoteles.ReAH_FechaReservacion,
                                        ReAH_HoraReservacion = actividadesHoteles.ReAH_HoraReservacion,
                                        ReAH_UsuarioCreacion = reservacionesView.Resv_UsuarioCreacion

                                    };
                                    var resultActivitiesHotels = _reservacionesActividadesHotelesRepository.Insert(reservacionesActividadesHoteles);
                                }
                            }


                            if (reservacionesView.Restaurantes != null)
                            {
                                List<int> ResvRestID = _reservacionRestaurantesRepository.List().Where(x => x.Resv_ID.Equals(ResvIDInt)).Select(x => x.Id).ToList();
                                foreach (var item in ResvRestID)
                                {
                                    _reservacionRestaurantesRepository.Delete(item, reservacionesView.Resv_UsuarioModifica.GetValueOrDefault());
                                }
                                //Create the reservation of the restaurants
                                foreach (var restaurantes in reservacionesView.Restaurantes)
                                {
                                    tbReservacionRestaurantes reservacionRestaurantes = new tbReservacionRestaurantes
                                    {
                                        Resv_ID = ResvIDInt,
                                        Rest_ID = restaurantes.Rest_ID,
                                        ReRe_FechaReservacion = restaurantes.ReRe_FechaReservacion,
                                        ReRe_HoraReservacion = restaurantes.ReRe_HoraReservacion,
                                        ReRe_UsuarioCreacion = reservacionesView.Resv_UsuarioCreacion
                                    };

                                    var resultRestaurants = _reservacionRestaurantesRepository.Insert(reservacionRestaurantes);
                                }
                            }


                            if (reservacionesView.reservacionTransportes != null)
                            {
                                List<int> ResvTrptID = _reservacionTransporteRepository.List().Where(x => x.Reservacion.Equals(ResvIDInt)).Select(x => x.Id).ToList();
                                foreach (var item in ResvTrptID)
                                {
                                    _reservacionRestaurantesRepository.Delete(item,reservacionesView.Resv_UsuarioModifica.GetValueOrDefault());
                                }
                                //Creates a reservation for a transport
                                foreach (var transportes in reservacionesView.reservacionTransportes)
                                {
                                    tbReservacionTransporte reservacionTransporte = new tbReservacionTransporte
                                    {
                                        Detr_ID = transportes.Detr_ID,
                                        Resv_ID = ResvIDInt,
                                        ReTr_CantidadAsientos = transportes.ReTr_CantidadAsientos,
                                        ReTr_FechaCancelado = transportes.ReTr_FechaCancelado,
                                        ReTr_Cancelado = transportes.ReTr_Cancelado,
                                        ReTr_UsuarioCreacion = reservacionesView.Resv_UsuarioCreacion
                                    };
                                }
                            }

                        }
                        else
                        {
                            ResvHotelID.MessageStatus = (ResvHotelID.CodeStatus == 0) ? "401 Error de consulta a la hora de ingresar una reservacion de hotel" : ResvHotelID.MessageStatus + " (Reservacion de hotel)";
                            return result.Error(ResvHotelID);
                        }
                    }
                    return result.Ok(ResvID);
                }
                else
                {
                    ResvID.MessageStatus = (ResvID.CodeStatus == 0) ? "401 Error de consulta" : ResvID.MessageStatus;
                    return result.Error(ResvID);
                }
            }
            catch (Exception ex)
            {

                return result.Error(ex.Message);
            }
        }
        public ServiceResult UpdateReservation(int id, tbReservaciones tbReservaciones)
        {
            var result = new ServiceResult();
            try
            {
                var itemID = _reservacionesRepository.Find(id);
                if (itemID != null)
                {
                    var map = _reservacionesRepository.Update(tbReservaciones, id);

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
        public ServiceResult DeleteReservation(int id, int Mod)
        {
            var result = new ServiceResult();
            try
            {
                var itemID = _reservacionesRepository.Find(id);
                if (itemID != null)
                {
                    var map = _reservacionesRepository.Delete(id, Mod);
                    int ResvID = map.CodeStatus;
                    if (map.CodeStatus > 0)
                    {
                        int ResvHotelID = _reservacionesHotelesRepository.List().Where(x => x.ReservacionID.Equals(id)).Select(x=>x.ID).ToList().FirstOrDefault();
                        _reservacionesHotelesRepository.Delete(ResvHotelID, Mod);
                        if (ResvHotelID > 0)
                        {
                            List<int> ResvHabiID = _reservacionesDetallesRepository.List().Where(x => x.ReservacionHotelID.Equals(ResvHotelID)).Select(x => x.ID).ToList();
                            foreach (var item in ResvHabiID)
                            {
                                _reservacionesDetallesRepository.Delete(item, Mod);

                            }

                            List<int> ResvActvExtraID = _reservacionesActividadesExtraRepository.List().Where(x => x.Reservacion.Equals(ResvID)).Select(x => x.ID).ToList();
                            foreach (var item in ResvActvExtraID)
                            {
                                _reservacionesActividadesExtraRepository.Delete(item, Mod);
                            }

                            List<int> ResvActvHotelID = _reservacionesActividadesHotelesRepository.List().Where(x => x.ReservacionID.Equals(ResvID)).Select(x => x.ID).ToList();
                            foreach (var item in ResvActvHotelID)
                            {
                                _reservacionesActividadesHotelesRepository.Delete(item, Mod);
                            }

                            List<int> ResvRestID = _reservacionRestaurantesRepository.List().Where(x => x.Resv_ID.Equals(ResvID)).Select(x => x.Id).ToList();
                            foreach (var item in ResvRestID)
                            {
                                _reservacionRestaurantesRepository.Delete(item, Mod);
                            }

                            List<int> ResvTrptID = _reservacionTransporteRepository.List().Where(x => x.Reservacion.Equals(ResvID)).Select(x => x.Id).ToList();
                            foreach (var item in ResvTrptID)
                            {
                                _reservacionTransporteRepository.Delete(item, Mod);
                            }
                        }
                        else
                        {
                            return result.Error("Ocurrió un error al intentar eliminar la reservación del hotel");
                        }

                        

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
        public ServiceResult FindReservation(int id)
        {
            var result = new ServiceResult();
            var city = new VW_tbReservaciones();
            try
            {
                city = _reservacionesRepository.Find(id);
                return result.Ok(city);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        #endregion

        #region RegistrosPagos
        //LISTADO
        public ServiceResult ListRecordPayments()
        {
            var result = new ServiceResult();
            try
            {
                var list = _registrosPagosRepository.List();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        //CREAR
        public ServiceResult CreateRecordPayments(tbRegistrosPagos item)
        {

            var result = new ServiceResult();
            try
            {
                var map = _registrosPagosRepository.Insert(item);
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
        public ServiceResult UpdateRecordPayments(int id, tbRegistrosPagos tbRegistrosPagos)
        {
            var result = new ServiceResult();
            try
            {
                var itemID = _registrosPagosRepository.Find(id);
                if (itemID != null)
                {
                    var map = _registrosPagosRepository.Update(tbRegistrosPagos, id);
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
        public ServiceResult DeleteRecordPayments(int id, int Mod)
        {
            var result = new ServiceResult();
            try
            {
                var itemID = _registrosPagosRepository.Find(id);
                if (itemID != null)
                {
                    var map = _registrosPagosRepository.Delete(id, Mod);
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
        public ServiceResult FindRecordPayments(int id)
        {
            var result = new ServiceResult();
            var city = new VW_tbRegistrosPagos();
            try
            {
                city = _registrosPagosRepository.Find(id);
                return result.Ok(city);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        #endregion

        #region LineaTiempoInfo
        public ServiceResult Timeline (int id_reservation)
        {
            LineaTiempoViewModel lineaTiempo = new LineaTiempoViewModel();
            var result = new ServiceResult();
            try
            {
                List<LineaTiempoActividadesViewModel> actividades = new List<LineaTiempoActividadesViewModel>();
                //Rellena las actividades extras
                var listActivities = (IEnumerable<VW_tbReservacionesActividadesExtras>)ListReservationActivitiesExtra().Data;
                listActivities = listActivities.Where(x => x.Reservacion == id_reservation).ToList();
                foreach (var item in listActivities)
                {
                    LineaTiempoActividadesViewModel lineaTiempoActividades = new LineaTiempoActividadesViewModel();
                    lineaTiempoActividades.ID = item.ID;
                    lineaTiempoActividades.Actividad = item.Actividad_Extra;
                    lineaTiempoActividades.Fecha = (DateTime)item.Fecha_Reservacion;

                    actividades.Add(lineaTiempoActividades);
                }

                
                //Rellena actividades de hoteles
                var lisActivitiestHoteles = (IEnumerable<VW_tbReservacionesActividadesHoteles>)ListReservationActivitiesHotels().Data;
                lisActivitiestHoteles = lisActivitiestHoteles.Where(x => x.ReservacionID == id_reservation).ToList();
                foreach (var item in lisActivitiestHoteles)
                {
                    LineaTiempoActividadesViewModel lineaTiempoActividadesHoteles = new LineaTiempoActividadesViewModel();
                    lineaTiempoActividadesHoteles.ID = item.ID;
                    lineaTiempoActividadesHoteles.Actividad = item.Nombre;
                    lineaTiempoActividadesHoteles.Fecha = (DateTime)item.Fecha_Reservacion;

                    //actividades.Add(lineaTiempoActividadesHoteles);
                }

                //Rellena hotel
                var listHoteles = (IEnumerable<VW_tbReservacionesHoteles>)ListReservationHotel().Data;
                var hotel = listHoteles.Where(x => x.ReservacionID == id_reservation).ToList()[0];
                var hotelInfo = (VW_tbHoteles)_hotelService.FindHotels((int)hotel.Hotel_ID).Data;
                lineaTiempo.ID_Hotel = (int)hotel.Hotel_ID;
                lineaTiempo.Hotel = hotelInfo.Hotel;
                lineaTiempo.Fecha_Entrada = hotel.Fecha_Entrada;
                lineaTiempo.Fecha_Salida = hotel.Fecha_Salida;

                //Rellena transportes
                var listTransportes = (IEnumerable<VW_tbReservacionTransporteCompleto>)ListReservationTransport().Data;
                var transporte = listTransportes.Where(x => x.Reservacion == id_reservation).ToList()[0];
                lineaTiempo.ID_Transporte = transporte.Id;
                lineaTiempo.Transporte = transporte.Partner_Nombre;
                lineaTiempo.TransporteFechaSalida = transporte.Transporte_FechaSalida;
                lineaTiempo.HoraSalida = transporte.Hora_Salida;
                lineaTiempo.HoraLlegada = transporte.Hora_Llegada;

                //Rellena cliente
                var listUsuarios = (IEnumerable<VW_tbReservaciones>)ListReservation().Data;
                var usuario = listUsuarios.Where(x => x.ID == id_reservation).ToList()[0];
                lineaTiempo.ID_Usuario = usuario.Id_Cliente;
                lineaTiempo.Nombre = usuario.Nombre;
                lineaTiempo.Apellido = usuario.Apellido;

                //Rellena view mdoel de linea de tiempo
                //alineamiento por fechas GroupBy(x => x.Fecha).
                lineaTiempo.Actividades = actividades.OrderBy(x => x.Fecha).ToList();
                //lineaTiempo.Hotel_Info = lineaTiempoHoteles;
                //lineaTiempo.Transporte_Info = lineaTiempoTransportes;
                //lineaTiempo.Cliente_Info = lineaTiempoUsuarios;

                return result.Ok(lineaTiempo);


            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        #endregion
    }
}
