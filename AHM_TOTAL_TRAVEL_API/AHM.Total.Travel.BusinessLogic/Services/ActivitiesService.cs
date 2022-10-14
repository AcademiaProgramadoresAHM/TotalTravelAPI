using AHM.Total.Travel.DataAccess.Repositories;
using AHM.Total.Travel.Entities.Entities;
using ConciertosProyecto.BusinessLogic;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace AHM.Total.Travel.BusinessLogic.Services
{
    public class ActivitiesService
    {
        private readonly ActividadesRepository _actividadesRepository;
        private readonly ActividadesExtrasRepository _actividadesExtrasRepository;
        private readonly TiposActividadesRepository _tiposActividadesRepository;
        private readonly UploaderImageRepository _uploaderImageRepository;
        private readonly ImagesService _imagesService;
        private string _defaultImageRoute = "\\ImagesAPI\\Default\\DefaultPhoto.jpg";
        private string _defaultAlbumRoute = "Activities_Extra\\ActivitiesExtra-";
        public ActivitiesService(UploaderImageRepository uploaderImageRepository, 
            ActividadesRepository actividades, 
            ActividadesExtrasRepository actividadesExtras, 
            TiposActividadesRepository tiposActividades,
            ImagesService imagesService)
        {
            _actividadesRepository = actividades;
            _actividadesExtrasRepository = actividadesExtras;
            _tiposActividadesRepository = tiposActividades;
            _uploaderImageRepository = uploaderImageRepository;
            _imagesService = imagesService;
        }
      
        #region Actividades
        //LISTADO
        public ServiceResult ListActivities()
        {
            var result = new ServiceResult();
            try
            {
                var list = _actividadesRepository.List();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        //CREAR
        public ServiceResult CreateActivity(tbActividades item)
        {

            var result = new ServiceResult();
            try
            {
                var map = _actividadesRepository.Insert(item);
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
        public ServiceResult UpdateActivity(int id, tbActividades tbActividades)
        {
            var result = new ServiceResult();
            try
            {
                var itemID = _actividadesRepository.Find(id);
                if (itemID != null)
                {
                    var map = _actividadesRepository.Update(tbActividades, id);
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
        public ServiceResult DeleteActivity(int id, int Mod)
        {
            var result = new ServiceResult();
            try
            {
                var itemID = _actividadesRepository.Find(id);
                if (itemID != null)
                {
                    var map = _actividadesRepository.Delete(id, Mod);
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
        public ServiceResult FindActivity(int id)
        {
            var result = new ServiceResult();
            try
            {
                var activity = _actividadesRepository.Find(id);
                return result.Ok(activity);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }

        }

        #endregion

        #region ActividadesExtras
        //LISTADO
        public ServiceResult ListActiExt()
        {
            var result = new ServiceResult();
            try
            {
                var list = _actividadesExtrasRepository.List();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        //CREAR
        public ServiceResult CreateActiExt(tbActividadesExtras item, List<IFormFile> file)
        {

            var result = new ServiceResult();
            try
            {
                item.AcEx_Url = _defaultImageRoute;
                var map = _actividadesExtrasRepository.Insert(item);
                if (map.CodeStatus > 0)
                {
                    try
                    {
                        UpdateActiExt(map.CodeStatus, item, file);
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
        public ServiceResult UpdateActiExt(int id, tbActividadesExtras tbActividadesExtras, List<IFormFile> file)
        {
            var result = new ServiceResult();
            try
            {
                var itemID = _actividadesExtrasRepository.Find(id);
                if (itemID != null)
                {
                    if (itemID.ImageURL != null)
                    {
                        if (!string.IsNullOrEmpty(itemID.ImageURL))
                        {
                            try
                            {
                                ServiceResult response = _imagesService.deleteImage(itemID.ImageURL);
                            }
                            catch (Exception e)
                            {
                                throw e;
                            }

                        }
                    }
                    var _fileName = "Activities_Extra-";
                    _defaultImageRoute = _imagesService.saveImages(string.Concat(_defaultAlbumRoute, itemID.ID), string.Concat(_fileName, itemID.ID), file).Result.Data;


                    tbActividadesExtras.AcEx_Url = _defaultImageRoute;

                    var map = _actividadesExtrasRepository.Update(tbActividadesExtras, id);
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
        public ServiceResult DeleteActiExt(int id, int Mod)
        {
            var result = new ServiceResult();
            try
            {
                var itemID = _actividadesExtrasRepository.Find(id);
                if (itemID != null)
                {
                    var map = _actividadesExtrasRepository.Delete(id, Mod);
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
        public ServiceResult FindActiExt(int id)
        {
            var result = new ServiceResult();
            try
            {
                var actExt = _actividadesExtrasRepository.Find(id);
                return result.Ok(actExt);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }

        }

        #endregion
      
        #region TiposActividades
        //LISTADO
        public ServiceResult ListActTyp()
        {
            var result = new ServiceResult();
            try
            {
                var list = _tiposActividadesRepository.List();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        //CREAR
        public ServiceResult CreateActTyp(tbTiposActividades item)
        {

            var result = new ServiceResult();
            try
            {
                var map = _tiposActividadesRepository.Insert(item);
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
        public ServiceResult UpdateActTyp(int id, tbTiposActividades tbTiposActividades)
        {
            var result = new ServiceResult();
            try
            {
                var itemID = _tiposActividadesRepository.Find(id);
                if (itemID != null)
                {
                    var map = _tiposActividadesRepository.Update(tbTiposActividades, id);
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
        public ServiceResult DeleteActTyp(int id, int Mod)
        {
            var result = new ServiceResult();
            try
            {
                var itemID = _tiposActividadesRepository.Find(id);
                if (itemID != null)
                {
                    var map = _tiposActividadesRepository.Delete(id, Mod);
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
        public ServiceResult FindActTyp(int id)
        {
            var result = new ServiceResult();
            try
            {
                var actTyp = _tiposActividadesRepository.Find(id);
                return result.Ok(actTyp);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }

        }

        #endregion
    }
}
