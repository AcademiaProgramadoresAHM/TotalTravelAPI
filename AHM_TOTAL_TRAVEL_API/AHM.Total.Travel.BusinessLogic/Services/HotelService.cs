﻿using AHM.Total.Travel.DataAccess.Repositories;
using AHM.Total.Travel.Entities.Entities;
using ConciertosProyecto.BusinessLogic;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using static AHM.Total.Travel.BusinessLogic.Services.ImagesService;

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
        private readonly ImagesService _imagesService;
        private string _defaultImageRoute = "\\ImagesAPI\\Default\\DefaultPhoto.jpg";
        private string _defaultAlbumRoute = "Hotels\\Hotel-";

        public HotelService(HotelesRepository hotelesRepository,
           HotelesActividadesRepository hotelesActividadesRepository, 
           HabitacionesRepository habitacionesRepository, 
           HotelesMenusRepository hotelesMenusRepository, 
           CategoriasHabitacionesRepository categoriasHabitacionesRepository,
           UploaderImageRepository uploaderImageRepository,
           ImagesService imagesService)
        {
            _hotelesRepository = hotelesRepository;
            _hotelesActividadesRepository = hotelesActividadesRepository;
            _habitacionesRepository = habitacionesRepository;
            _hotelesMenusRepository = hotelesMenusRepository;
            _categoriasHabitacionesRepository = categoriasHabitacionesRepository;
            _uploaderImageRepository = uploaderImageRepository;
            _imagesService = imagesService;
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
        public ServiceResult CreateHotels(tbHoteles item, List<IFormFile> file)
        {

            var result = new ServiceResult();
            try
            {
                var map = _hotelesRepository.Insert(item);
                if (map.CodeStatus > 0)
                {
                    try
                    {
                        UpdateHotels(map.CodeStatus, item, file);
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
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
        public ServiceResult UpdateHotels(int id, tbHoteles tbHoteles, List<IFormFile> file)
        {
            var result = new ServiceResult();
            try
            {
                var itemID = _hotelesRepository.Find(id);
                if (itemID != null)
                {
                    if (itemID.Image_URL != null)
                    {
                        if (!string.IsNullOrEmpty(itemID.Image_URL))
                        {
                            try
                            {
                                ServiceResult response = _imagesService.deleteImage(itemID.Image_URL);
                            }
                            catch (Exception e)
                            {
                                throw e;
                            }

                        }
                    }
                    var _fileName = "Hotel-";
                    _defaultImageRoute = _imagesService.saveImages(string.Concat(_defaultAlbumRoute, itemID.ID, "\\Place"), string.Concat(_fileName, itemID.ID), file).Result.Data;
                    tbHoteles.Hote_Url = _defaultImageRoute;

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
                hotel.Image_URL = ((ImagesDetails)_imagesService.getImagesFilesByRoute(hotel.Image_URL).Data).ImageUrl;
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
        public ServiceResult CreateHotelsActivity(tbHotelesActividades item, List<IFormFile> file)
        {

            var result = new ServiceResult();
            try
            {
                var map = _hotelesActividadesRepository.Insert(item);
                if (map.CodeStatus > 0)
                {
                    try
                    {
                        UpdateHotelsActivity(map.CodeStatus, item, file);
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
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
        public ServiceResult UpdateHotelsActivity(int id, tbHotelesActividades tbHotelesActividades, List<IFormFile> file)
        {
            var result = new ServiceResult();
            try
            {
                var itemID = _hotelesActividadesRepository.Find(id);
                if (itemID != null)
                {
                    if (itemID.Image_URL != null)
                    {
                        if (!string.IsNullOrEmpty(itemID.Image_URL))
                        {
                            try
                            {
                                ServiceResult response = _imagesService.deleteImage(itemID.Image_URL);
                            }
                            catch (Exception e)
                            {
                                throw e;
                            }

                        }
                    }
                    var _fileName = "Hotel_Activity-";
                    _defaultImageRoute = _imagesService.saveImages(
                        string.Concat(_defaultAlbumRoute, tbHotelesActividades.Hote_ID, "\\Activities\\Hotel_Activity-", itemID.ID), 
                        string.Concat(_fileName, itemID.ID), 
                        file
                    ).Result.Data;
                    tbHotelesActividades.HoAc_Url = _defaultImageRoute;

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
                hotelactivities.Image_URL = ((ImagesDetails)_imagesService.getImagesFilesByRoute(hotelactivities.Image_URL).Data).ImageUrl;
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
        public ServiceResult CreateHabitaciones(tbHabitaciones item, List<IFormFile> file)
        {

            var result = new ServiceResult();
            try
            {
                var map = _habitacionesRepository.Insert(item);
                if (map.CodeStatus > 0)
                {
                    try
                    {
                        UpdateHabitaciones(map.CodeStatus, item, file);
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
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
        public ServiceResult UpdateHabitaciones(int id, tbHabitaciones tbHabitaciones, List<IFormFile> files)
        {
            var result = new ServiceResult();
            try
            {
                var itemID = _habitacionesRepository.Find(id);
                if (itemID != null)
                {
                    if (itemID.Urls != null)
                    {
                        if (!string.IsNullOrEmpty(itemID.Urls))
                        {
                            try
                            {
                                ServiceResult response = _imagesService.deleteImage(itemID.Urls);
                            }
                            catch (Exception e)
                            {
                                throw e;
                            }

                        }
                    }
                    var _fileName = "Hotel_Room-";
                    _defaultImageRoute = _imagesService.saveImages(
                        string.Concat(_defaultAlbumRoute, tbHabitaciones.Hote_ID, "\\Rooms\\Hotel_Room-", itemID.ID),
                        string.Concat(_fileName, itemID.ID),
                        files
                    ).Result.Data;
                    tbHabitaciones.Habi_url = _defaultImageRoute;

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
                habitaciones.Urls = ((ImagesDetails)_imagesService.getImagesFilesByRoute(habitaciones.Urls).Data).ImageUrl;
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
        public ServiceResult CreateHotelsMenu(tbHotelesMenus item, List<IFormFile> file)
        {

            var result = new ServiceResult();
            try
            {
                var map = _hotelesMenusRepository.Insert(item);
                if (map.CodeStatus > 0)
                {
                    try
                    {
                        UpdateHotelsMenu(map.CodeStatus, item, file);
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
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
        public ServiceResult UpdateHotelsMenu(int id, tbHotelesMenus tbHotelesMenus, List<IFormFile> files)
        {
            var result = new ServiceResult();
            try
            {
                var itemID = _hotelesMenusRepository.Find(id);
                if (itemID != null)
                {
                    if (itemID.Image_Url != null)
                    {
                        if (!string.IsNullOrEmpty(itemID.Image_Url))
                        {
                            try
                            {
                                ServiceResult response = _imagesService.deleteImage(itemID.Image_Url);
                            }
                            catch (Exception e)
                            {
                                throw e;
                            }

                        }
                    }
                    var _fileName = "Hotel_Menu-";
                    _defaultImageRoute = _imagesService.saveImages(
                        string.Concat(_defaultAlbumRoute, tbHotelesMenus.Hote_ID, "\\Food\\Hotel_Menu-", itemID.ID),
                        string.Concat(_fileName, itemID.ID),
                        files
                    ).Result.Data;
                    tbHotelesMenus.HoMe_Url = _defaultImageRoute;

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
                hotelesmenus.Image_Url = ((ImagesDetails)_imagesService.getImagesFilesByRoute(hotelesmenus.Image_Url).Data).ImageUrl;
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
