using AHM.Total.Travel.Common.Models;
using AHM.Total.Travel.DataAccess.Repositories;
using AHM.Total.Travel.Common.Models;
using ConciertosProyecto.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Org.BouncyCastle.Crypto;
using System.Linq;
using Org.BouncyCastle.Utilities;
using Newtonsoft.Json.Serialization;
using AHM.Total.Travel.Entities.Entities;

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

                        VW_tbPaquetePredeterminadosDetalles packageDetails = _paquetesDetallesRepository.Find(packID);
                        if (packageDetails == null)
                        {
                            return result.Error("No se encontró los detalles del paquete");
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
                                List<VW_tbPaquetePredeterminadosDetalles> packageExtraActivities = (List<VW_tbPaquetePredeterminadosDetalles>)_saleService.ListPackagesdetail().Data;
                                List<VW_tbPaquetePredeterminadosDetalles> filteredPackageExtraActivities = packageExtraActivities.Where(x => x.PaqueteID == packID).ToList();
                                foreach (var actvExtra in filteredPackageExtraActivities)
                                {

                                    tbReservacionesActividadesExtras reservacionesActividadesExtras = new tbReservacionesActividadesExtras
                                    {
                                        Resv_ID = ResvIDInt,
                                        AcEx_ID = actvExtra.ActividadID,
                                        ReAE_Precio = actvExtra.Precio,
                                        ReAE_Cantidad = actvExtra.Cantidad,
                                        ReAE_FechaReservacion = itemViewModel.ActividadesExtras.Find(x => x.ReAE_ID == actvExtra.ActividadID).ReAE_FechaReservacion,
                                        ReAE_HoraReservacion = itemViewModel.ActividadesExtras.Find(x => x.ReAE_ID == actvExtra.ActividadID).ReAE_HoraReservacion,
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
                                catch (Exception e)
                                {

                                    return result.Error("Error al ingresar la reservacion de habitacion");
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
                LineaTiempoHotelesViewModel lineaTiempoHoteles = new LineaTiempoHotelesViewModel();
                lineaTiempoHoteles.ID_Hotel = (int)hotel.Hotel_ID;
                lineaTiempoHoteles.Hotel = hotelInfo.Hotel;
                lineaTiempoHoteles.Fecha_Entrada = hotel.Fecha_Entrada;
                lineaTiempoHoteles.Fecha_Salida = hotel.Fecha_Salida;

                //Rellena transportes
                var listTransportes = (IEnumerable<VW_tbReservacionTransporteCompleto>)ListReservationTransport().Data;
                var transporte = listTransportes.Where(x => x.Reservacion == id_reservation).ToList()[0];
                LineaTiempoTransportesViewModel lineaTiempoTransportes = new LineaTiempoTransportesViewModel();
                lineaTiempoTransportes.ID_Transporte = transporte.Id;
                lineaTiempoTransportes.Transporte = transporte.Partner_Nombre;
                lineaTiempoTransportes.HoraSalida = transporte.Hora_Salida;
                lineaTiempoTransportes.HoraLlegada = transporte.Hora_Llegada;

                //Rellena cliente
                var listUsuarios = (IEnumerable<VW_tbReservaciones>)ListReservation().Data;
                var usuario = listUsuarios.Where(x => x.ID == id_reservation).ToList()[0];
                LineaTiempoUsuariosViewModel lineaTiempoUsuarios = new LineaTiempoUsuariosViewModel();
                lineaTiempoUsuarios.ID_Usuario = usuario.Id_Cliente;
                lineaTiempoUsuarios.Nombre = usuario.Nombre;
                lineaTiempoUsuarios.Apellido = usuario.Apellido;

                //Rellena view mdoel de linea de tiempo
                //alineamiento por fechas GroupBy(x => x.Fecha).
                lineaTiempo.Actividades = actividades.OrderBy(x => x.Fecha).ToList();
                lineaTiempo.Hotel_Info = lineaTiempoHoteles;
                lineaTiempo.Transporte_Info = lineaTiempoTransportes;
                lineaTiempo.Cliente_Info = lineaTiempoUsuarios;

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
