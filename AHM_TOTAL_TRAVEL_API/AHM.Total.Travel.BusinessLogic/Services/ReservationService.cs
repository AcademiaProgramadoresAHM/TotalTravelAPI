using AHM.Total.Travel.Common.Models;
using AHM.Total.Travel.DataAccess.Repositories;
using AHM.Total.Travel.Entities.Entities;
using ConciertosProyecto.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        private readonly HotelService _hotelService;
        private readonly TransportService _transportService;


        public ReservationService(
            ReservacionesActividadesExtraRepository reservacionesActividadesExtra,
            RegistrosPagosRepository registrosPagosRepository,
            ReservacionesRepository reservacionesRepository,
            ReservacionesActividadesHotelesRepository reservacionesActividadesHoteles,

            ReservacionesDetallesRepository reservacionesDetallesRepository,
            ReservacionRestaurantesRepository reservacionRestaurantesRepository,
            ReservacionTransporteRepository reservacionTransporteRepository,
            ReservacionesHotelesRepository reservacionesHotelesRepository,

            HotelService hotelService,
            TransportService transportService
        )
        {
            _reservacionesActividadesExtraRepository = reservacionesActividadesExtra;
            _registrosPagosRepository = registrosPagosRepository;
            _reservacionesRepository = reservacionesRepository;
            _reservacionesActividadesHotelesRepository = reservacionesActividadesHoteles;
            _reservacionesDetallesRepository = reservacionesDetallesRepository;
            _reservacionesHotelesRepository = reservacionesHotelesRepository;
            _reservacionRestaurantesRepository = reservacionRestaurantesRepository;
            _reservacionTransporteRepository = reservacionTransporteRepository;
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
                var transporteInfo = (VW_tbTransportesCompleto)_transportService.FindTransports(transporte.Id_Transportes).Data;
                LineaTiempoTransportesViewModel lineaTiempoTransportes = new LineaTiempoTransportesViewModel();
                lineaTiempoTransportes.ID_Transporte = transporte.Id;
                lineaTiempoTransportes.Transporte = transporteInfo.NombrePartner;
                lineaTiempoTransportes.HoraSalida = transporteInfo.HoraSalida;
                lineaTiempoTransportes.HoraLlegada = transporteInfo.HoraLlegada;

                //Rellena cliente
                var listUsuarios = (IEnumerable<VW_tbReservaciones>)ListReservation().Data;
                var usuario = listUsuarios.Where(x => x.ID == id_reservation).ToList()[0];
                LineaTiempoUsuariosViewModel lineaTiempoUsuarios = new LineaTiempoUsuariosViewModel();
                lineaTiempoUsuarios.ID_Usuario = usuario.Id_Cliente;
                lineaTiempoUsuarios.Nombre = usuario.Nombre;
                lineaTiempoUsuarios.Apellido = usuario.Apellido;

                //Rellena view mdoel de linea de tiempo
                lineaTiempo.Actividades = actividades.GroupBy(x => x.Fecha).ToList();
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
