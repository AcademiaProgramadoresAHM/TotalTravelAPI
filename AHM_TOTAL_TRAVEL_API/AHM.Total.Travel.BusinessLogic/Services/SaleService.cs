using AHM.Total.Travel.DataAccess.Repositories;
using AHM.Total.Travel.Entities.Entities;
using ConciertosProyecto.BusinessLogic;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static AHM.Total.Travel.BusinessLogic.Services.ImagesService;

namespace AHM.Total.Travel.BusinessLogic.Services
{
    public class SaleService
    {
        private readonly PaquetePredeterminadosRepository _paquetepredeterminadosRepository;
        private readonly TiposPagosRepository _tipospagosRepository;
        private readonly PaquetePredeterminadosDetallesRepository _paquetePredeterminadosDetallesRepository;
        private readonly PaquetesHabitacionesRepository _paquetesHabitacionesRepository;
        private readonly PaquetesPredeterminadosActividadesHotelesRepository _actividadesHotelesRepository;
        private readonly ImagesService _imagesService;
        private string _defaultImageRoute = "Default\\DefaultPhoto.jpg";
        private readonly string _defaultAlbumRoute = "DefaultPackage\\DefaultPackage-";


        public SaleService(PaquetePredeterminadosRepository paquetepredeterminadosRepository,
            TiposPagosRepository tipospagosRepository, PaquetePredeterminadosDetallesRepository paquetePredeterminadosDetallesRepository,
            PaquetesHabitacionesRepository paquetesHabitacionesRepository,
            PaquetesPredeterminadosActividadesHotelesRepository actividadesHotelesRepository,
            ImagesService imagesService)
        {
            _paquetepredeterminadosRepository = paquetepredeterminadosRepository;
            _tipospagosRepository = tipospagosRepository;
            _paquetePredeterminadosDetallesRepository = paquetePredeterminadosDetallesRepository;
            _paquetesHabitacionesRepository = paquetesHabitacionesRepository;
            _actividadesHotelesRepository = actividadesHotelesRepository;
            _imagesService = imagesService;
        }

        #region PaquetesPredeterminados
        //LISTADO
        public ServiceResult Listpackages()
        {
            var result = new ServiceResult();
            try
            {
                List<VW_tbPaquetePredeterminados> list = _paquetepredeterminadosRepository.List().ToList();
                list.ForEach(item =>
                {
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
        public ServiceResult Createpackages(tbPaquetePredeterminados item, List<IFormFile> file)
        {

            var result = new ServiceResult();
            try
            {
                item.Paqu_Url = _defaultImageRoute;
                var map = _paquetepredeterminadosRepository.Insert(item);
                if (map.CodeStatus > 0)
                {
                    try
                    {
                        Updatepackages(map.CodeStatus, item, file);
                    }
                    catch (Exception e)
                    {

                        throw;
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
        public ServiceResult Updatepackages(int id, tbPaquetePredeterminados tbPaquetePredeterminados, List<IFormFile> file)
        {
            var result = new ServiceResult();
            try
            {
                var itemID = _paquetepredeterminadosRepository.Find(id);
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
                        var _fileName = "DefaultPackage-";
                        _defaultImageRoute = _imagesService.saveImages(string.Concat(_defaultAlbumRoute, itemID.Id, "\\Place"), string.Concat(_fileName, itemID.Id), file).Result.Data;
                        tbPaquetePredeterminados.Paqu_Url = _defaultImageRoute;
                    }
                    else
                    {
                        tbPaquetePredeterminados.Paqu_Url = itemID.Image_URL;
                    }

                    if (string.IsNullOrEmpty(tbPaquetePredeterminados.Paqu_Url) || itemID.Image_URL == _defaultImageRoute)
                    {
                        tbPaquetePredeterminados.Paqu_Url = _defaultImageRoute;
                    }
                    tbPaquetePredeterminados.Paqu_Url = _defaultImageRoute;

                    var map = _paquetepredeterminadosRepository.Update(tbPaquetePredeterminados, id);
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
        public ServiceResult Deletepackages(int id, int Mod)
        {
            var result = new ServiceResult();
            try
            {
                var itemID = _paquetepredeterminadosRepository.Find(id);
                if (itemID != null)
                {
                    var map = _paquetepredeterminadosRepository.Delete(id, Mod);
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
        public ServiceResult FindPackage(int id)
        {
            var result = new ServiceResult();
            try
            {
                VW_tbPaquetePredeterminados packge = _paquetepredeterminadosRepository.Find(id);
                if (packge != null)
                {
                    
                    ServiceResult imageResult = _imagesService.getImagesFilesByRoute(packge.Image_URL);
                    if (!imageResult.Success)
                    {
                        packge.Image_URL = ((ImagesDetails)(imageResult.Data)).ImageUrl;
                    }
                    else
                    {
                        List<ImagesDetails> images = ((List<ImagesDetails>)(imageResult.Data));
                        string url = "";
                        foreach (var item in images)
                        {
                            url = string.Concat(url, item.ImageUrl, ",");
                        }
                        packge.Image_URL = url;
                    
                    }
                    
                }
                return result.Ok(packge);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }

        }

        #endregion

        #region PaquetesPredeterminadosActividadesHoteles
        //LISTADO
        public ServiceResult ListPackagesHotelsActivities()
        {
            var result = new ServiceResult();
            try
            {
                var list = _actividadesHotelesRepository.List();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        //CREAR
        public ServiceResult CreatePackagesHotelsActivities(tbPaquetePredeterminadosActividadesHoteles item)
        {

            var result = new ServiceResult();
            try
            {
                var map = _actividadesHotelesRepository.Insert(item);
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
        public ServiceResult UpdatePackagesHotelsActivities(int id, tbPaquetePredeterminadosActividadesHoteles tbPaquetePredeterminados)
        {
            var result = new ServiceResult();
            try
            {
                var itemID = _actividadesHotelesRepository.Find(id);
                if (itemID != null)
                {
                    var map = _actividadesHotelesRepository.Update(tbPaquetePredeterminados, id);
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
        public ServiceResult DeletePackagesHotelsActivities(int id, int Mod)
        {
            var result = new ServiceResult();
            try
            {
                var itemID = _actividadesHotelesRepository.Find(id);
                if (itemID != null)
                {
                    var map = _actividadesHotelesRepository.Delete(id, Mod);
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
        public ServiceResult FindPackagesHotelsActivities(int id)
        {
            var result = new ServiceResult();
            var city = new VW_tbPaquetePredeterminadosActividadesHoteles();
            try
            {
                city = _actividadesHotelesRepository.Find(id);
                return result.Ok(city);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }

        }
        #endregion

        #region TipoPagos
        //LISTADO
        public ServiceResult Listpayment()
        {
            var result = new ServiceResult();
            try
            {
                var list = _tipospagosRepository.List();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        //CREAR
        public ServiceResult Createpayment(tbTiposPagos item)
        {

            var result = new ServiceResult();
            try
            {
                var map = _tipospagosRepository.Insert(item);
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
        public ServiceResult Updatepayment(int id, tbTiposPagos tbTiposPagos)
        {
            var result = new ServiceResult();
            try
            {
                var itemID = _tipospagosRepository.Find(id);
                if (itemID != null)
                {
                    var map = _tipospagosRepository.Update(tbTiposPagos, id);
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
        public ServiceResult Deletepayment(int id, int Mod)
        {
            var result = new ServiceResult();
            try
            {
                var itemID = _tipospagosRepository.Find(id);
                if (itemID != null)
                {
                    var map = _tipospagosRepository.Delete(id, Mod);
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
        public ServiceResult Findpayment(int id)
        {
            var result = new ServiceResult();
            var city = new VW_tbTiposPagos();
            try
            {
                city = _tipospagosRepository.Find(id);
                return result.Ok(city);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }

        }

        #endregion

        #region PaquetesPredeterminadosDetalles
        //LISTADO
        public ServiceResult ListPackagesdetail()
        {
            var result = new ServiceResult();
            try
            {
                var list = _paquetePredeterminadosDetallesRepository.List();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        //CREAR
        public ServiceResult CreatePackagesdetail(tbPaquetePredeterminadosDetalles item)
        {

            var result = new ServiceResult();
            try
            {
                var map = _paquetePredeterminadosDetallesRepository.Insert(item);
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
        public ServiceResult UpdatePackagesdetail(int id, tbPaquetePredeterminadosDetalles paquetePredeterminadosDetalles)
        {
            var result = new ServiceResult();
            try
            {
                var itemID = _paquetePredeterminadosDetallesRepository.Find(id);
                if (itemID != null)
                {
                    var map = _paquetePredeterminadosDetallesRepository.Update(paquetePredeterminadosDetalles, id);
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
        public ServiceResult DeletePackagesdetail(int id, int Mod)
        {
            var result = new ServiceResult();
            try
            {
                var itemID = _paquetePredeterminadosDetallesRepository.Find(id);
                if (itemID != null)
                {
                    var map = _paquetePredeterminadosDetallesRepository.Delete(id, Mod);
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
        public ServiceResult FindPackagesdetail(int id)
        {
            var result = new ServiceResult();
            var city = new VW_tbPaquetePredeterminadosDetalles();
            try
            {
                city = _paquetePredeterminadosDetallesRepository.Find(id);
                return result.Ok(city);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }

        }

        #endregion

        #region PaquetesHabitaciones
        //LISTADO
        public ServiceResult ListPackageRooms()
        {
            var result = new ServiceResult();
            try
            {
                var list = _paquetesHabitacionesRepository.List();
                return result.Ok(list);

            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        //CREAR
        public ServiceResult CreatePackageRooms(tbPaquetesHabitaciones item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _paquetesHabitacionesRepository.Insert(item);
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
        public ServiceResult UpdatePackageRooms(int id, tbPaquetesHabitaciones paquetesHabitaciones)
        {
            var result = new ServiceResult();
            try
            {
                var itemID = _paquetesHabitacionesRepository.Find(id);
                if (itemID != null)
                {
                    var map = _paquetesHabitacionesRepository.Update(paquetesHabitaciones, id);
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
        public ServiceResult DeletePackageRooms(int id, int Mod)
        {
            var result = new ServiceResult();
            try
            {
                var itemID = _paquetesHabitacionesRepository.Find(id);
                if (itemID != null)
                {
                    var map = _paquetesHabitacionesRepository.Delete(id, Mod);
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
        public ServiceResult FindPackagesRooms(int id)
        {
            var result = new ServiceResult();
            var package = new VW_tbPaquetesHabitaciones();
            try
            {
                package = _paquetesHabitacionesRepository.Find(id);
                return result.Ok(package);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }

        }

        #endregion


    }
}
