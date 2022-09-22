using AHM.Total.Travel.DataAccess.Repositories;
using AHM.Total.Travel.Entities.Entities;
using ConciertosProyecto.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Text;

namespace AHM.Total.Travel.BusinessLogic.Services
{
    public class HotelServices
    {
        private readonly HotelesRepository _hotelesRepository;
        private readonly HotelesActividadesRepository _hotelesActividadesRepository;

    public HotelServices(HotelesRepository hotelesRepository,HotelesActividadesRepository hotelesActividadesRepository)
        {
            _hotelesRepository = hotelesRepository;
            _hotelesActividadesRepository = hotelesActividadesRepository;
        }

        #region Hoteles
        public ServiceResult ListHotel()
        {
            var result = new ServiceResult();
            try
            {
                var list = _hotelesRepository.List();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        //CREAR
        public ServiceResult CreateHotel(tbHoteles item)
        {

            var result = new ServiceResult();
            try
            {
                var map = _hotelesRepository.Insert(item);
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
        public ServiceResult UpdateHotel(int id, tbHoteles tbHoteles)
        {
            var result = new ServiceResult();
            try
            {
                var itemID = _hotelesRepository.Find(id);
                if (itemID != null)
                {
                    var list = _hotelesRepository.Update(tbHoteles, id);
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
        public ServiceResult DeleteHotel(int id, int Mod)
        {
            var result = new ServiceResult();
            try
            {
                var itemID = _hotelesRepository.Find(id);
                if (itemID != null)
                {
                    var listado = _hotelesRepository.Delete(id, Mod);
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
        public ServiceResult FindHotel(int id)
        {
            var result = new ServiceResult();
            var hotel = new VW_tbHoteles();
            try
            {
                hotel = _hotelesRepository.Find(id);
                return result.Ok(hotel);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }

        }

        #endregion
        #region HotelesActividades
        public ServiceResult ListHotelActivities()
        {
            var result = new ServiceResult();
            try
            {
                var list = _hotelesActividadesRepository.List();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        //CREAR
        public ServiceResult CreateHotelActivities(tbHoteles item)
        {

            var result = new ServiceResult();
            try
            {
                var map = _hotelesActividadesRepository.Insert(item);
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
        public ServiceResult UpdateHotelActivities(int id, tbHotelesActividades tbHotelesActividades)
        {
            var result = new ServiceResult();
            try
            {
                var itemID = _hotelesActividadesRepository.Find(id);
                if (itemID != null)
                {
                    var list = _hotelesActividadesRepository.Update(tbHotelesActividades, id);
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
        public ServiceResult DeleteHotelActivities(int id, int Mod)
        {
            var result = new ServiceResult();
            try
            {
                var itemID = _hotelesActividadesRepository.Find(id);
                if (itemID != null)
                {
                    var listado = _hotelesActividadesRepository.Delete(id, Mod);
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
        public ServiceResult FindHotelActivities(int id)
        {
            var result = new ServiceResult();
            var hotelactivities = new VW_tbHotelesActividades();
            try
            {
                hotelactivities = _hotelesActividadesRepository.Find(id);
                return result.Ok(hotelactivities);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }

        }

        #endregion
    }
}
