﻿using AHM.Total.Travel.DataAccess.Repositories;
using AHM.Total.Travel.Entities.Entities;
using ConciertosProyecto.BusinessLogic;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static AHM.Total.Travel.BusinessLogic.Services.ImagesService;
using static System.Net.Mime.MediaTypeNames;

namespace AHM.Total.Travel.BusinessLogic.Services
{
    public class RestaurantService
    {
        private readonly MenusRepository _menusRepository;
        private readonly MenuTypesRepository _tiposMenusRepository;
        private readonly RestaurantesRepository _restaurantesRepository;
        private readonly ImagesService _imagesService;
        private string _defaultImageRoute = "Default\\DefaultPhoto.jpg";
        private readonly string _defaultAlbumRoute = "Restaurants\\Restaurant-";
        public RestaurantService(MenusRepository menusRepository,
                              MenuTypesRepository tiposMenusRepository,
                              RestaurantesRepository restaurantesRepository,
                              ImagesService imagesService)
        {
            _menusRepository = menusRepository;
            _tiposMenusRepository = tiposMenusRepository;
            _restaurantesRepository = restaurantesRepository;
            _imagesService = imagesService;

        }

        #region Restaurantes
        //LISTADO
        public ServiceResult ListRestaurants()
        {
            var result = new ServiceResult();
            try
            {
                List<VW_tbRestaurantes> list = _restaurantesRepository.List().ToList();
                list.ForEach(item => {
                    ServiceResult imageResult = _imagesService.getImagesFilesByRoute(item.Image_URL);
                    if (!imageResult.Success)
                    {
                        item.Image_URL = ((ImagesDetails)(imageResult.Data)).ImageUrl;
                    }
                    else
                    {
                        List<ImagesDetails> images = ((List<ImagesDetails>)(imageResult.Data));
                        string url = "";
                        foreach (var routes in images)
                        {
                            url = string.Concat(url, routes.ImageUrl, ",");
                        }
                        item.Image_URL = url;
                    }
                });
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        //CREAR
        public ServiceResult CreateRestaurants(tbRestaurantes item, List<IFormFile> file)
        {
            var result = new ServiceResult();
            try
            {
                item.Rest_Url = _defaultImageRoute;
                var map = _restaurantesRepository.Insert(item);
                if (map.CodeStatus > 0)
                {
                    try
                    {
                        UpdateRestaurants(map.CodeStatus, item, file);
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
        public ServiceResult UpdateRestaurants(int id, tbRestaurantes tbRestaurantes, List<IFormFile> file)
        {
            var result = new ServiceResult();
            try
            {
                var itemID = _restaurantesRepository.Find(id);

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
                        var _fileName = "Restaurant-";
                        _defaultImageRoute = _imagesService.saveImages(string.Concat(_defaultAlbumRoute, itemID.ID, "\\Place"), string.Concat(_fileName, itemID.ID), file).Result.Data;
                        tbRestaurantes.Rest_Url = _defaultImageRoute;
                    }
                    else
                    {
                        tbRestaurantes.Rest_Url = itemID.Image_URL;
                    }

                    if (string.IsNullOrEmpty(tbRestaurantes.Rest_Url) || itemID.Image_URL == _defaultImageRoute)
                    {
                        tbRestaurantes.Rest_Url = _defaultImageRoute;
                    }
                    tbRestaurantes.Rest_Url = _defaultImageRoute;

                    var map = _restaurantesRepository.Update(tbRestaurantes, id);
                    
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
                    return result.Error("Los datos son incorrectos");
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        //ELIMINAR
        public ServiceResult DeleteRestaurants(int id, int Mod)
        {
            var result = new ServiceResult();
            try
            {
                var itemID = _restaurantesRepository.Find(id);
                if (itemID != null)
                {
                    var map = _restaurantesRepository.Delete(id, Mod);
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
        public ServiceResult FindRestaurants(int id)
        {
            var result = new ServiceResult();
            
            try
            {
                VW_tbRestaurantes restaurantes = _restaurantesRepository.Find(id);
                if (restaurantes != null)
                {
                    ServiceResult imageResult = _imagesService.getImagesFilesByRoute(restaurantes.Image_URL);
                    if (!imageResult.Success)
                    {
                        restaurantes.Image_URL = ((ImagesDetails)(imageResult.Data)).ImageUrl;
                    }
                    else
                    {
                        List<ImagesDetails> images = ((List<ImagesDetails>)(imageResult.Data));
                        string url = "";
                        foreach (var item in images)
                        {
                            url = string.Concat(url, item.ImageUrl, ",");
                        }
                        restaurantes.Image_URL = url;
                    }
                }
                return result.Ok(restaurantes);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }

        }

        #endregion

        #region Tipo Menus
        //LISTADO
        public ServiceResult ListTipoMenus()
        {
            var result = new ServiceResult();
            try
            {
                var list = _tiposMenusRepository.List();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        //CREAR
        public ServiceResult CreateTipoMenus(tbTipoMenus item)
        {

            var result = new ServiceResult();
            try
            {
                var map = _tiposMenusRepository.Insert(item);
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
        public ServiceResult UpdateTipoMenus(int id, tbTipoMenus tbTipoMenus)
        {
            var result = new ServiceResult();
            try
            {
                var itemID = _tiposMenusRepository.Find(id);
                if (itemID != null)
                {
                    var map = _tiposMenusRepository.Update(tbTipoMenus, id);
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
        public ServiceResult DeleteTipoMenus(int id, int Mod)
        {
            var result = new ServiceResult();
            try
            {
                var itemID = _tiposMenusRepository.Find(id);
                if (itemID != null)
                {
                    var map = _tiposMenusRepository.Delete(id, Mod);
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
        public ServiceResult FindTipoMenus(int id)
        {
            var result = new ServiceResult();
            var tipoMenus = new VW_tbTiposMenus();
            try
            {
                tipoMenus = _tiposMenusRepository.Find(id);
                return result.Ok(tipoMenus);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }

        }

        #endregion

        #region Menus
        //LISTADO
        public ServiceResult ListMenus()
        {
            var result = new ServiceResult();
            try
            {
                List<VW_tbMenus> list = _menusRepository.List().ToList();
                list.ForEach(item =>
                {
                    item.Image_Url = ((ImagesDetails)_imagesService.getImagesFilesByRoute(item.Image_Url).Data).ImageUrl;
                });
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        //CREAR
        public ServiceResult CreateMenus(tbMenus item, List<IFormFile> file)
        {

            var result = new ServiceResult();
            try
            {
                item.Menu_Url = _defaultImageRoute;
                var map = _menusRepository.Insert(item);
                if (map.CodeStatus > 0)
                {
                    if (file != null)
                    {
                        if (file.Count > 1)
                            return result.BadRequest("You have inserted multiple images on a single image field");

                        try
                        {
                            UpdateMenus(map.CodeStatus, item, file);
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
        public ServiceResult UpdateMenus(int id, tbMenus tbMenus, List<IFormFile> file)
        {
            var result = new ServiceResult();
            try
            {
                var itemID = _menusRepository.Find(id);

                if (itemID != null)
                {
                    if (file != null)
                    {
                        if (file.Count > 1)
                            return result.BadRequest("You have inserted multiple images on a single image field");

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

                        var _fileName = "Menu-";
                        _defaultImageRoute = _imagesService.saveImages(
                            string.Concat(_defaultAlbumRoute, itemID.ID_Restaurante, "\\Food"),
                            string.Concat(_fileName, itemID.ID),
                            file).Result.Data;

                        tbMenus.Menu_Url = _defaultImageRoute;
                    }
                    else
                    {
                        tbMenus.Menu_Url = _defaultImageRoute;
                    }

                    if (string.IsNullOrEmpty(itemID.Image_Url) || itemID.Image_Url == _defaultImageRoute)
                    {
                        tbMenus.Menu_Url = _defaultImageRoute;
                    }


                    var map = _menusRepository.Update(tbMenus, id);
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
                    return result.Error("Los datos son incorrectos");
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        //ELIMINAR
        public ServiceResult DeleteMenus(int id, int Mod)
        {
            var result = new ServiceResult();
            try
            {
                var itemID = _menusRepository.Find(id);
                if (itemID != null)
                {
                    var map = _menusRepository.Delete(id, Mod);
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
        public ServiceResult FindMenus(int id)
        {
            var result = new ServiceResult();
            
            try
            {
                VW_tbMenus menus = _menusRepository.Find(id);
                if (menus != null)
                {
                    try
                    {
                        menus.Image_Url = ((ImagesDetails)_imagesService.getImagesFilesByRoute(menus.Image_Url).Data).ImageUrl;

                    }
                    catch (Exception)
                    {

                        return result.BadRequest("You have inserted multiple images on a single image field");
                    }
                }
                return result.Ok(menus);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }

        }

        #endregion



    }
}
