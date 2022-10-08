using AHM.Total.Travel.DataAccess.Repositories;
using AHM.Total.Travel.Entities.Entities;
using ConciertosProyecto.BusinessLogic;
using Microsoft.AspNetCore.Http;
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
        private readonly UploaderImageRepository _uploaderImageRepository;

        public HotelService(HotelesRepository hotelesRepository,
           HotelesActividadesRepository hotelesActividadesRepository, 
           HabitacionesRepository habitacionesRepository, 
           HotelesMenusRepository hotelesMenusRepository, 
           CategoriasHabitacionesRepository categoriasHabitacionesRepository,
           UploaderImageRepository uploaderImageRepository)
        {
            _hotelesRepository = hotelesRepository;
            _hotelesActividadesRepository = hotelesActividadesRepository;
            _habitacionesRepository = habitacionesRepository;
            _hotelesMenusRepository = hotelesMenusRepository;
            _categoriasHabitacionesRepository = categoriasHabitacionesRepository;
            _uploaderImageRepository = uploaderImageRepository;
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
        public ServiceResult CreateHotels(tbHoteles item, IFormFile file)
        {

            var result = new ServiceResult();
            try
            {
                var map = _hotelesRepository.Insert(item);
                if (map.CodeStatus > 0)
                {
                    FileModel img = new FileModel();
                    img.FileName = "Hotel-" + item.Hote_Nombre + ".jpg";
                    img.path = "ImagesAPI/Hotels/Hotel-" + map.CodeStatus + "/Place";
                    img.file = file;

                    var map2 = _uploaderImageRepository.UploaderFile(img);
                    map.MessageStatus = map.MessageStatus + ", " + map2.MessageStatus;
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
        public ServiceResult UpdateHotels(int id, tbHoteles tbHoteles)
        {
            var result = new ServiceResult();
            try
            {
                var itemID = _hotelesRepository.Find(id);
                if (itemID != null)
                {
                    var map = _hotelesRepository.Update(tbHoteles, id);
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
        public ServiceResult DeleteHotels(int id, int Mod)
        {
            var result = new ServiceResult();
            try
            {
                var itemID = _hotelesRepository.Find(id);
                if (itemID != null)
                {
                    var map = _hotelesRepository.Delete(id, Mod);
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
        public ServiceResult FindHotels(int id)
        {
            var result = new ServiceResult();
            try
            {
                var hotel = _hotelesRepository.Find(id);
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
        public ServiceResult CreateHotelsActivity(tbHotelesActividades item, IFormFile file)
        {

            var result = new ServiceResult();
            try
            {
                var map = _hotelesActividadesRepository.Insert(item);
                if (map.CodeStatus > 0)
                {
                    FileModel img = new FileModel();
                    img.FileName = item.HoAc_ID + "-" + item.HoAc_Descripcion + ".jpg";
                    img.path = "ImagesAPI/Hotels/Hotel-" + item.Hote_ID + "/Activities";
                    img.file = file;

                    var map2 = _uploaderImageRepository.UploaderFile(img);
                    map.MessageStatus = map.MessageStatus + ", " + map2.MessageStatus;
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
        public ServiceResult UpdateHotelsActivity(int id, tbHotelesActividades tbHotelesActividades)
        {
            var result = new ServiceResult();
            try
            {
                var itemID = _hotelesActividadesRepository.Find(id);
                if (itemID != null)
                {
                    var map = _hotelesActividadesRepository.Update(tbHotelesActividades, id);
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
        public ServiceResult DeleteHotelsActivity(int id, int Mod)
        {
            var result = new ServiceResult();
            try
            {
                var itemID = _hotelesActividadesRepository.Find(id);
                if (itemID != null)
                {
                    var map = _hotelesActividadesRepository.Delete(id, Mod);
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
        public ServiceResult FindHotelsActivity(int id)
        {
            var result = new ServiceResult();
            try
            {
                var hotelactivities = _hotelesActividadesRepository.Find(id);
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
        public ServiceResult CreateHabitaciones(tbHabitaciones item, IFormFile file)
        {

            var result = new ServiceResult();
            try
            {
                var map = _habitacionesRepository.Insert(item);
                if (map.CodeStatus > 0)
                {
                    FileModel img = new FileModel();
                    img.FileName =  "Habi-" + item.Habi_ID + ".jpg";
                    img.path = "ImagesAPI/Hotels/Hotel-" + item.Hote_ID + "/Rooms";
                    img.file = file;

                    var map2 = _uploaderImageRepository.UploaderFile(img);
                    map.MessageStatus = map.MessageStatus + ", " + map2.MessageStatus;
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
        public ServiceResult UpdateHabitaciones(int id, tbHabitaciones tbHabitaciones)
        {
            var result = new ServiceResult();
            try
            {
                var itemID = _habitacionesRepository.Find(id);
                if (itemID != null)
                {
                    var map = _habitacionesRepository.Update(tbHabitaciones, id);
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
        public ServiceResult DeleteHabitaciones(int id, int Mod)
        {
            var result = new ServiceResult();
            try
            {
                var itemID = _habitacionesRepository.Find(id);
                if (itemID != null)
                {
                    var map = _habitacionesRepository.Delete(id, Mod);
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
        public ServiceResult FindHabitaciones(int id)
        {
            var result = new ServiceResult();
            try
            {
                var habitaciones = _habitacionesRepository.Find(id);
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
        public ServiceResult CreateHotelsMenu(tbHotelesMenus item, IFormFile file)
        {

            var result = new ServiceResult();
            try
            {
                var map = _hotelesMenusRepository.Insert(item);
                if (map.CodeStatus > 0)
                {
                    FileModel img = new FileModel();
                    img.FileName = item.HoMe_ID+"-"+item.HoMe_Descripcion + ".jpg";
                    img.path = "ImagesAPI/Hotels/Hotel-" + item.Hote_ID + "/Food";
                    img.file = file;

                    var map2 = _uploaderImageRepository.UploaderFile(img);
                    map.MessageStatus = map.MessageStatus + ", " + map2.MessageStatus;
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
        public ServiceResult UpdateHotelsMenu(int id, tbHotelesMenus tbHotelesMenus)
        {
            var result = new ServiceResult();
            try
            {
                var itemID = _hotelesMenusRepository.Find(id);
                if (itemID != null)
                {
                    var map = _hotelesMenusRepository.Update(tbHotelesMenus, id);
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
        public ServiceResult DeleteHotelsMenu(int id, int Mod)
        {
            var result = new ServiceResult();
            try
            {
                var itemID = _hotelesMenusRepository.Find(id);
                if (itemID != null)
                {
                    var map = _hotelesMenusRepository.Delete(id, Mod);
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
        public ServiceResult FindHotelsMenu(int id)
        {
            var result = new ServiceResult();
            try
            {
                var hotelesmenus = _hotelesMenusRepository.Find(id);
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
        public ServiceResult UpdateCategoriesRooms(int id, tbCategoriasHabitaciones tbcategoriasHabitaciones)
        {
            var result = new ServiceResult();
            try
            {
                var itemID = _categoriasHabitacionesRepository.Find(id);
                if (itemID != null)
                {
                    var map = _categoriasHabitacionesRepository.Update(tbcategoriasHabitaciones, id);
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
        public ServiceResult DeleteCategoriesRooms(int id, int Mod)
        {
            var result = new ServiceResult();
            try
            {
                var itemID = _categoriasHabitacionesRepository.Find(id);
                if (itemID != null)
                {
                    var map = _categoriasHabitacionesRepository.Delete(id, Mod);
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
        public ServiceResult FindCategoriesRooms(int id)
        {
            var result = new ServiceResult();
            try
            {
                var hotelesmenus = _categoriasHabitacionesRepository.Find(id);
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
