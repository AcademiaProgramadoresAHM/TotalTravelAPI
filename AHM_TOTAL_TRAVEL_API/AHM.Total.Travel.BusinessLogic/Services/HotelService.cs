using AHM.Total.Travel.DataAccess.Repositories;
using AHM.Total.Travel.Entities.Entities;
using ConciertosProyecto.BusinessLogic;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
        private string _defaultImageRoute = "Default\\DefaultPhoto.jpg";
        private string _defaultActivityAlbumRoute = "Activities\\Hotel_Activity-";
        private string _defaultMenuAlbumRoute = "Food\\Hotel_Menu-";
        private string _defaultRoomAlbumRoute = "Place\\Hotel_Room-";
        private string _defaultHotelAlbumRoute = "Place\\Hotel_Images-";

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
                item.Hote_Url = _defaultImageRoute;
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
                VW_tbHoteles itemID = _hotelesRepository.Find(id);
                if (itemID != null)
                {
                    if (file != null)
                    {
                        if (itemID.Image_URL != null)
                        {
                            if (!string.IsNullOrEmpty(itemID.Image_URL) && itemID.Image_URL != _defaultImageRoute)
                            {
                                try
                                {
                                    ServiceResult imagesResult = _imagesService.getImagesFilesByRoute(itemID.Image_URL);
                                    if (!imagesResult.Success)
                                    {
                                        ServiceResult response = _imagesService.deleteImage(itemID.Image_URL);

                                    }
                                    else
                                    {
                                        List<ImagesDetails> imagesRoute = (List<ImagesDetails>)imagesResult.Data;
                                        foreach (ImagesDetails image in imagesRoute)
                                        {
                                            ServiceResult response = _imagesService.deleteImage(image.ImageUrl);
                                        }
                                    }
                                }
                                catch (Exception e)
                                {
                                    throw e;
                                }

                            }
                        }
                        var _fileName = "Hotel-";
                        _defaultImageRoute = _imagesService.saveImages(
                            string.Concat("Hotels\\Hotel-", itemID.ID, "\\", _defaultHotelAlbumRoute, itemID.ID),
                            string.Concat(_fileName, itemID.ID), file).Result.Data;

                        tbHoteles.Hote_Url = _defaultImageRoute;
                    }
                    else
                    {
                        tbHoteles.Hote_Url = itemID.Image_URL;
                    }

                    if (string.IsNullOrEmpty(tbHoteles.Hote_Url) || itemID.Image_URL == _defaultImageRoute)
                    {
                        tbHoteles.Hote_Url = _defaultImageRoute;
                    }
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
                VW_tbHoteles hotel = _hotelesRepository.Find(id);

                if(hotel != null)
                {
                    ServiceResult imageResult = _imagesService.getImagesFilesByRoute(hotel.Image_URL);
                    if (!imageResult.Success)
                    {
                        hotel.Image_URL = ((ImagesDetails)(imageResult.Data)).ImageUrl;
                    }
                    else
                    {
                        List<ImagesDetails> images = ((List<ImagesDetails>)(imageResult.Data));
                        string url = "";
                        foreach (var item in images)
                        {
                            url = string.Concat(url, item.ImageUrl, ",");
                        }
                        hotel.Image_URL = url;
                    }
                }

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
                List<VW_tbHotelesActividades> list = _hotelesActividadesRepository.List().ToList();
                list.ForEach(item =>
                {
                    item.Image_URL = ((ImagesDetails)(_imagesService.getImagesFilesByRoute(item.Image_URL).Data)).ImageUrl;
                });
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
                item.HoAc_Url = _defaultImageRoute;
                var map = _hotelesActividadesRepository.Insert(item);
                if (map.CodeStatus > 0)
                {
                    if (file != null)
                    {
                        if (file.Count > 1)
                            return result.BadRequest("You have inserted multiple images on a single image field");

                        try
                        {
                            UpdateHotelsActivity(map.CodeStatus, item, file);
                        }
                        catch (Exception e)
                        {
                            throw e;
                        }
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
                    if (file != null)
                    {
                        if (file.Count > 1)
                            return result.BadRequest("You have inserted multiple images on a single image field");

                        if (!string.IsNullOrEmpty(itemID.Image_URL) && itemID.Image_URL != _defaultImageRoute)
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
                        var _fileName = "Hotel_Activity-";
                        _defaultImageRoute = _imagesService.saveImages(
                            string.Concat("Hotels\\Hotel-", itemID.ID_Hotel, "\\", _defaultActivityAlbumRoute, itemID.ID),
                            string.Concat(_fileName, itemID.ID),
                            file).Result.Data;

                        tbHotelesActividades.HoAc_Url = _defaultImageRoute;
                    }
                    else
                    {
                        tbHotelesActividades.HoAc_Url = itemID.Image_URL;
                    }

                    if (string.IsNullOrEmpty(itemID.Image_URL) || itemID.Image_URL == _defaultImageRoute)
                    {
                        tbHotelesActividades.HoAc_Url = _defaultImageRoute;
                    }

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
                if (hotelactivities != null)
                {

                    ServiceResult imageResult = _imagesService.getImagesFilesByRoute(hotelactivities.Image_URL);
                    if (!imageResult.Success)
                    {
                        hotelactivities.Image_URL = ((ImagesDetails)(imageResult.Data)).ImageUrl;
                    }
                    else
                    {
                        List<ImagesDetails> images = ((List<ImagesDetails>)(imageResult.Data));
                        string url = "";
                        foreach (var item in images)
                        {
                            url = string.Concat(url, item.ImageUrl, ",");
                        }
                        hotelactivities.Image_URL = url;
                    }

                }
               
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
                item.Habi_url = _defaultRoomAlbumRoute;
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
                    if (files != null)
                    {
                        if (itemID.ImageUrl != null)
                        {
                            if (!string.IsNullOrEmpty(itemID.ImageUrl) && itemID.ImageUrl != _defaultRoomAlbumRoute)
                            {
                                try
                                {
                                    ServiceResult imagesResult = _imagesService.getImagesFilesByRoute(itemID.ImageUrl);
                                    if (!imagesResult.Success)
                                    {
                                        ServiceResult response = _imagesService.deleteImage(((ImagesDetails)(imagesResult.Data)).ImageUrl);

                                    }
                                    else
                                    {
                                        List<ImagesDetails> imagesRoute = (List<ImagesDetails>)imagesResult.Data;
                                        foreach (ImagesDetails image in imagesRoute)
                                        {
                                            ServiceResult response = _imagesService.deleteImage(image.ImageUrl);
                                        }
                                    }

                                }
                                catch (Exception e)
                                {
                                    throw e;
                                }

                            }
                        }
                        var _fileName = "Hotel_Room-";
                        _defaultImageRoute = _imagesService.saveImages(
                            string.Concat("Hotel\\Hotel-", itemID.HotelID, "\\", _defaultRoomAlbumRoute, itemID.HotelID),
                            string.Concat(_fileName, itemID.ID),
                            files
                        ).Result.Data;
                        tbHabitaciones.Habi_url = _defaultImageRoute;

                    }
                    else
                    {
                        tbHabitaciones.Habi_url = itemID.ImageUrl;
                    }

                    if (string.IsNullOrEmpty(tbHabitaciones.Habi_url) || itemID.ImageUrl == _defaultImageRoute)
                    {
                        tbHabitaciones.Habi_url = _defaultImageRoute;
                    }
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
                VW_tbHabitaciones habitaciones = _habitacionesRepository.Find(id);

                if (habitaciones != null)
                {
                    ServiceResult imageResult = _imagesService.getImagesFilesByRoute(habitaciones.ImageUrl);
                    if (!imageResult.Success)
                    {
                        habitaciones.ImageUrl = ((ImagesDetails)_imagesService.getImagesFilesByRoute(habitaciones.ImageUrl).Data).ImageUrl;

                    }
                    else
                    {
                        List<ImagesDetails> images = ((List<ImagesDetails>)(imageResult.Data));
                        string url = "";
                        foreach (var item in images)
                        {
                            url = string.Concat(url, item.ImageUrl, ",");
                        }
                        habitaciones.ImageUrl = url;
                    }
                }
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
                item.HoMe_Url = _defaultImageRoute;
                var map = _hotelesMenusRepository.Insert(item);
                if (map.CodeStatus > 0)
                {
                    if (file != null)
                    {
                        if (file.Count > 1)
                            return result.BadRequest("You have inserted multiple images on a single image field");

                        try
                        {
                            UpdateHotelsMenu(map.CodeStatus, item, file);
                        }
                        catch (Exception e)
                        {
                            throw e;
                        }
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
                    if (files != null)
                    {
                        if (files.Count > 1)
                            return result.BadRequest("You have inserted multiple images on a single image field");

                        if (itemID.Image_Url != null)
                        {
                            if (!string.IsNullOrEmpty(itemID.Image_Url) && itemID.Image_Url != _defaultImageRoute)
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
                            string.Concat("Hotels\\Hotel-", itemID.ID_Hotel, "\\", _defaultMenuAlbumRoute, itemID.ID),
                            string.Concat(_fileName, itemID.ID),
                            files
                        ).Result.Data;

                        tbHotelesMenus.HoMe_Url = _defaultImageRoute;

                    }
                    else
                    {
                        tbHotelesMenus.HoMe_Url = itemID.Image_Url;
                    }

                    if (string.IsNullOrEmpty(itemID.Image_Url) || itemID.Image_Url == _defaultImageRoute)
                    {
                        tbHotelesMenus.HoMe_Url = _defaultImageRoute;
                    }

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
                if (hotelesmenus != null)
                {
                    try
                    {
                        hotelesmenus.Image_Url = ((ImagesDetails)_imagesService.getImagesFilesByRoute(hotelesmenus.Image_Url).Data).ImageUrl;
                    }
                    catch (Exception)
                    {
                        return result.BadRequest("You have inserted multiple images on a single image field");
                    }
                    
                }
                
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
