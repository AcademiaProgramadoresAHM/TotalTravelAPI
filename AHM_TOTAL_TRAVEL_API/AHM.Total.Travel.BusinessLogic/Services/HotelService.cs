using AHM.Total.Travel.DataAccess.Repositories;
using AHM.Total.Travel.Entities.Entities;
using ConciertosProyecto.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Text;

namespace AHM.Total.Travel.BusinessLogic.Services
{
    public class HotelService
    {
        private readonly HotelesRepository _hotelesRepository;
        private readonly HotelesActividadesRepository _hotelesActividadesRepository;
        private readonly HabitacionesRepository _habitacionesRepository;
        private readonly HotelesMenusRepository _hotelesMenusRepository;
        private readonly CategoriasHabitacionesRepository _categoriasHabitacionesRepository;

    public HotelService(HotelesRepository hotelesRepository,
           HotelesActividadesRepository hotelesActividadesRepository, 
           HabitacionesRepository habitacionesRepository, 
           HotelesMenusRepository hotelesMenusRepository, 
           CategoriasHabitacionesRepository categoriasHabitacionesRepository)
        {
            _hotelesRepository = hotelesRepository;
            _hotelesActividadesRepository = hotelesActividadesRepository;
            _habitacionesRepository = habitacionesRepository;
            _hotelesMenusRepository = hotelesMenusRepository;
            _categoriasHabitacionesRepository = categoriasHabitacionesRepository;
        }

        #region Hoteles
        public ServiceResult ListHotels()
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
        public ServiceResult CreateHotels(tbHoteles item)
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
        public ServiceResult UpdateHotels(int id, tbHoteles tbHoteles)
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
        public ServiceResult DeleteHotels(int id, int Mod)
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
        public ServiceResult FindHotels(int id)
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
        public ServiceResult ListHotelsActivity()
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
        public ServiceResult CreateHotelsActivity(tbHotelesActividades item)
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
        public ServiceResult UpdateHotelsActivity(int id, tbHotelesActividades tbHotelesActividades)
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
        public ServiceResult DeleteHotelsActivity(int id, int Mod)
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
        public ServiceResult FindHotelsActivity(int id)
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
        #region Habitaciones
        public ServiceResult ListHabitaciones()
        {
            var result = new ServiceResult();
            try
            {
                var list = _habitacionesRepository.List();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        //CREAR
        public ServiceResult CreateHabitaciones(tbHabitaciones item)
        {

            var result = new ServiceResult();
            try
            {
                var map = _habitacionesRepository.Insert(item);
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
        public ServiceResult UpdateHabitaciones(int id, tbHabitaciones tbHabitaciones)
        {
            var result = new ServiceResult();
            try
            {
                var itemID = _habitacionesRepository.Find(id);
                if (itemID != null)
                {
                    var list = _habitacionesRepository.Update(tbHabitaciones, id);
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
        public ServiceResult DeleteHabitaciones(int id, int Mod)
        {
            var result = new ServiceResult();
            try
            {
                var itemID = _habitacionesRepository.Find(id);
                if (itemID != null)
                {
                    var listado = _habitacionesRepository.Delete(id, Mod);
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
        public ServiceResult FindHabitaciones(int id)
        {
            var result = new ServiceResult();
            var habitaciones = new VW_tbHabitaciones();
            try
            {
                habitaciones = _habitacionesRepository.Find(id);
                return result.Ok(habitaciones);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }

        }

        #endregion
        #region HotelesMenus
        public ServiceResult ListHotelsMenu()
        {
            var result = new ServiceResult();
            try
            {
                var list = _hotelesMenusRepository.List();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        //CREAR
        public ServiceResult CreateHotelsMenu(tbHotelesMenus item)
        {

            var result = new ServiceResult();
            try
            {
                var map = _hotelesMenusRepository.Insert(item);
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
        public ServiceResult UpdateHotelsMenu(int id, tbHotelesMenus tbHotelesMenus)
        {
            var result = new ServiceResult();
            try
            {
                var itemID = _hotelesMenusRepository.Find(id);
                if (itemID != null)
                {
                    var list = _hotelesMenusRepository.Update(tbHotelesMenus, id);
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
        public ServiceResult DeleteHotelsMenu(int id, int Mod)
        {
            var result = new ServiceResult();
            try
            {
                var itemID = _hotelesMenusRepository.Find(id);
                if (itemID != null)
                {
                    var listado = _hotelesMenusRepository.Delete(id, Mod);
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
        public ServiceResult FindHotelsMenu(int id)
        {
            var result = new ServiceResult();
            var hotelesmenus = new VW_tbHotelesMenus();
            try
            {
                hotelesmenus = _hotelesMenusRepository.Find(id);
                return result.Ok(hotelesmenus);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }

        }

        #endregion
        #region CategoriasHabitaciones
        public ServiceResult ListCategoriesRooms()
        {
            var result = new ServiceResult();
            try
            {
                var list = _categoriasHabitacionesRepository.List();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        //CREAR
        public ServiceResult CreateCategoriesRooms(tbCategoriasHabitaciones item)
        {

            var result = new ServiceResult();
            try
            {
                var map = _categoriasHabitacionesRepository.Insert(item);
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
        public ServiceResult UpdateCategoriesRooms(int id, tbCategoriasHabitaciones tbcategoriasHabitaciones)
        {
            var result = new ServiceResult();
            try
            {
                var itemID = _categoriasHabitacionesRepository.Find(id);
                if (itemID != null)
                {
                    var list = _categoriasHabitacionesRepository.Update(tbcategoriasHabitaciones, id);
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
        public ServiceResult DeleteCategoriesRooms(int id, int Mod)
        {
            var result = new ServiceResult();
            try
            {
                var itemID = _categoriasHabitacionesRepository.Find(id);
                if (itemID != null)
                {
                    var listado = _categoriasHabitacionesRepository.Delete(id, Mod);
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
        public ServiceResult FindCategoriesRooms(int id)
        {
            var result = new ServiceResult();
            var hotelesmenus = new VW_tbCategoriasHabitaciones();
            try
            {
                hotelesmenus = _categoriasHabitacionesRepository.Find(id);
                return result.Ok(hotelesmenus);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }

        }

        #endregion
    }
}
