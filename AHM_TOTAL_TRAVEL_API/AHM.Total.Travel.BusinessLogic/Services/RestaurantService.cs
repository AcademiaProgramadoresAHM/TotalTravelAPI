﻿using AHM.Total.Travel.DataAccess.Repositories;
using AHM.Total.Travel.Entities.Entities;
using ConciertosProyecto.BusinessLogic;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace AHM.Total.Travel.BusinessLogic.Services
{
    public class RestaurantService
    {
        private readonly MenusRepository _menusRepository;
        private readonly MenuTypesRepository _tiposMenusRepository;
        private readonly RestaurantesRepository _restaurantesRepository;
        private readonly UploaderImageRepository _uploaderImageRepository;
        public RestaurantService(MenusRepository menusRepository,
                              MenuTypesRepository tiposMenusRepository,
                              RestaurantesRepository restaurantesRepository,
                              UploaderImageRepository uploaderImageRepository)
        {
            _menusRepository = menusRepository;
            _tiposMenusRepository = tiposMenusRepository;
            _restaurantesRepository = restaurantesRepository;
            _uploaderImageRepository = uploaderImageRepository;

        }

        #region Restaurantes
        //LISTADO
        public ServiceResult ListRestaurants()
        {
            var result = new ServiceResult();
            try
            {
                var list = _restaurantesRepository.List();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        //CREAR
        public ServiceResult CreateRestaurants(tbRestaurantes item, IFormFile file)
        {

            var result = new ServiceResult();
            try
            {
                var map = _restaurantesRepository.Insert(item);
                if (map.CodeStatus > 0) 
                {
                    FileModel img = new FileModel();
                    img.FileName = "Restaurantplace.jpg";
                    img.path = "ImagesAPI/Restaurants/Rest-" + map.CodeStatus + "/Place";
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
        public ServiceResult UpdateRestaurants(int id, tbRestaurantes tbRestaurantes)
        {
            var result = new ServiceResult();
            try
            {
                var itemID = _restaurantesRepository.Find(id);
                if (itemID != null)
                {
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
            var restaurantes = new VW_tbRestaurantes();
            try
            {
                restaurantes = _restaurantesRepository.Find(id);
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
                var list = _menusRepository.List();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        //CREAR
        public ServiceResult CreateMenus(tbMenus item, IFormFile file)
        {

            var result = new ServiceResult();
            try
            {
                var map = _menusRepository.Insert(item);
                if (map.CodeStatus > 0)
                {
                    FileModel img = new FileModel();
                    img.FileName = map.CodeStatus + "-" + item.Menu_Nombre +   ".jpg";
                    img.path = "ImagesAPI/Restaurants/Rest-"+item.Rest_ID+"/Food";
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
        public ServiceResult UpdateMenus(int id, tbMenus tbMenus)
        {
            var result = new ServiceResult();
            try
            {
                var itemID = _menusRepository.Find(id);
                if (itemID != null)
                {
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
            var menus = new VW_tbMenus();
            try
            {
                menus = _menusRepository.Find(id);
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
