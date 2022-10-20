using AHM.Total.Travel.Common.Models;
using AHM.Total.Travel.DataAccess.Repositories;
using AHM.Total.Travel.Entities.Entities;
using ConciertosProyecto.BusinessLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using static AHM.Total.Travel.BusinessLogic.Services.ImagesService;

namespace AHM.Total.Travel.BusinessLogic.Services
{
    public class GeneralService
    {
        private readonly CiudadesRepository _ciudadesRepository;
        private readonly DireccionesRepository _direccionesRepository;
        private readonly PaisesRepository _paisesRepository;
        private readonly PartnersRepository _partnersRepository;
        private readonly TipoPartnersRepository _tipoPartnersRepository;
        private readonly UploaderImageRepository _uploaderImageRepository;
        private readonly ColoniasRepository _coloniasRepository;
        private readonly ImagesService _imagesService;
        private string _defaultImageRoute = "Default\\DefaultPhoto.jpg";
        private string _defaultAlbumPartner = "UsersProfilePics\\Partner-";

        public GeneralService(CiudadesRepository ciudadesRepository, DireccionesRepository direccionesRepository, PaisesRepository paisesRepository, PartnersRepository partnersRepository,TipoPartnersRepository tipoPartnersRepository, UploaderImageRepository uploaderImageRepository, ColoniasRepository coloniasRepository, ImagesService imagesService)
        {
            _ciudadesRepository = ciudadesRepository;
            _direccionesRepository = direccionesRepository;
            _paisesRepository = paisesRepository;
            _partnersRepository = partnersRepository;
            _coloniasRepository = coloniasRepository;
            _tipoPartnersRepository = tipoPartnersRepository;
            _uploaderImageRepository = uploaderImageRepository;
            _imagesService = imagesService;
        }

        #region Ciudades
        //LISTADO
        public ServiceResult ListCities()
        {
            var result = new ServiceResult();
            try
            {
                var list = _ciudadesRepository.List();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        //CREAR
        public ServiceResult CreateCity(tbCiudades item)
        {

            var result = new ServiceResult();
            try
            {
                var map = _ciudadesRepository.Insert(item);
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
        public ServiceResult UpdateCity(int id, tbCiudades tbCiudades)
        {
            var result = new ServiceResult();
            try
            {
                var itemID = _ciudadesRepository.Find(id);
                if (itemID != null)
                {
                    var map = _ciudadesRepository.Update(tbCiudades, id);
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
        public ServiceResult DeleteCity(int id, int Mod)
        {
            var result = new ServiceResult();
            try
            {
                var itemID = _ciudadesRepository.Find(id);
                if (itemID != null)
                {
                    var map = _ciudadesRepository.Delete(id, Mod);
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
        public ServiceResult FindCity(int id)
        {
            var result = new ServiceResult();
            try
            {
                var city = _ciudadesRepository.Find(id);
                return result.Ok(city);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
            
        }

        #endregion
        #region Colonias
        //LISTADO
        public ServiceResult ListSuburbs()
        {
            var result = new ServiceResult();
            try
            {
                var list = _coloniasRepository.List();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        //CREAR
        public ServiceResult CreateSuburbs(tbColonias item)
        {

            var result = new ServiceResult();
            try
            {
                var map = _coloniasRepository.Insert(item);
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
        public ServiceResult UpdateSuburbs(int id, tbColonias item)
        {
            var result = new ServiceResult();
            try
            {
                var itemID = _coloniasRepository.Find(id);
                if (itemID != null)
                {
                    var map = _coloniasRepository.Update(item, id);
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
        public ServiceResult DeleteSuburbs(int id, int Mod)
        {
            var result = new ServiceResult();
            try
            {
                var itemID = _coloniasRepository.Find(id);
                if (itemID != null)
                {
                    var map = _coloniasRepository.Delete(id, Mod);
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
        public ServiceResult FindSuburbs(int id)
        {
            var result = new ServiceResult();
            try
            {
                VW_tbColonias suburb = _coloniasRepository.Find(id);
                return result.Ok(suburb);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }

        }

        #endregion

        #region Direcciones
        //LISTADO
        public ServiceResult ListAddress()
        {
            var result = new ServiceResult();
            try
            {
                var list = _direccionesRepository.List();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        //CREAR
        public ServiceResult CreateAddress(tbDirecciones item)
        {

            var result = new ServiceResult();
            try
            {
                var map = _direccionesRepository.Insert(item);
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
        public ServiceResult UpdateAddress(int id, tbDirecciones item)
        {
            var result = new ServiceResult();
            try
            {
                var itemID = _direccionesRepository.Find(id);
                if (itemID != null)
                {
                    var map = _direccionesRepository.Update2(item, id);
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
        public ServiceResult DeleteAddress(int id, int Mod)
        {
            var result = new ServiceResult();
            try
            {
                var itemID = _direccionesRepository.Find(id);
                if (itemID != null)
                {
                    var map = _direccionesRepository.Delete(id, Mod);
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
        public ServiceResult FindAddress(int id)
        {
            var result = new ServiceResult();            
            try
            {
                VW_tbDirecciones direction = _direccionesRepository.Find(id);
                return result.Ok(direction);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }

        }

        #endregion

        #region Paises
        //LISTADO
        public ServiceResult ListCountries()
        {
            var result = new ServiceResult();
            try
            {
                var list = _paisesRepository.List();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        //CREAR
        public ServiceResult CreateCountry(tbPaises item)
        {

            var result = new ServiceResult();
            try
            {
                var map = _paisesRepository.Insert(item);
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
        public ServiceResult UpdateCountry(int id, tbPaises item)
        {
            var result = new ServiceResult();
            try
            {
                var itemID = _paisesRepository.Find(id);
                if (itemID != null)
                {
                    var map = _paisesRepository.Update(item, id);
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
        public ServiceResult DeleteCountry(int id, int Mod)
        {
            var result = new ServiceResult();
            try
            {
                var itemID = _paisesRepository.Find(id);
                if (itemID != null)
                {
                    var map = _paisesRepository.Delete(id, Mod);
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
        public ServiceResult FindCountry(int id)
        {
            var result = new ServiceResult();
            try
            {
                VW_tbPaises country = _paisesRepository.Find(id);
                return result.Ok(country);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }

        }

        #endregion

        #region Partners
        //LISTADO
        public ServiceResult ListPartners()
        {
            var result = new ServiceResult();
            try
            {
                var list = _partnersRepository.List();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        //CREAR
        public ServiceResult CreatePartner(tbPartners item, List<IFormFile> file)
        {
            var result = new ServiceResult();
            try
            {
                item.Part_Url = _defaultImageRoute;
                var map = _partnersRepository.Insert(item);
                if (map.CodeStatus > 0)
                {
                    if (file != null)
                    {
                        if (file.Count > 1)
                            return result.BadRequest("You have inserted multiple images on a single image field");
                        try
                        {
                            UpdatePartner(map.CodeStatus, item, file);
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
        public ServiceResult UpdatePartner(int id, tbPartners tbPartners, List<IFormFile> file)
        {
            var result = new ServiceResult();

            try
            {
                var itemID = _partnersRepository.Find(id);

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

                        var _fileName = "Partner-";
                        _defaultImageRoute = _imagesService.saveImages(
                            string.Concat(_defaultAlbumPartner, itemID.ID),
                            string.Concat(_fileName, itemID.ID),
                            file).Result.Data;
                        tbPartners.Part_Url = _defaultImageRoute;
                    }
                    else
                    {
                        tbPartners.Part_Url = itemID.Image_Url;
                    }

                    if (string.IsNullOrEmpty(itemID.Image_Url) || itemID.Image_Url == _defaultImageRoute)
                    {
                        tbPartners.Part_Url = _defaultImageRoute;
                    }


                    var map = _partnersRepository.Update(tbPartners, id);
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
        public ServiceResult DeletePartner(int id, int Mod)
        {
            var result = new ServiceResult();
            try
            {
                var itemID = _partnersRepository.Find(id);
                if (itemID != null)
                {
                    var map = _partnersRepository.Delete(id, Mod);
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
        public ServiceResult FindPartner(int id)
        {
            var result = new ServiceResult();
            try
            {
                VW_tbPartners partner = _partnersRepository.Find(id);
                if (partner != null)
                {
                    try
                    {
                        partner.Image_Url = ((ImagesDetails)_imagesService.getImagesFilesByRoute(partner.Image_Url).Data).ImageUrl;

                    }
                    catch (Exception)
                    {

                        return result.BadRequest("You have inserted multiple images on a single image field");
                    }
                }
                return result.Ok(partner);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }

        }

        #endregion

        #region TipoPartners
        //LISTADO
        public ServiceResult ListPartnersType()
        {
            var result = new ServiceResult();
            try
            {
                var list = _tipoPartnersRepository.List();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        //CREAR
        public ServiceResult CreatePartnersType(tbTipoPartners item)
        {

            var result = new ServiceResult();
            try
            {
                var map = _tipoPartnersRepository.Insert(item);
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
        public ServiceResult UpdatePartnersType(int id, tbTipoPartners item)
        {
            var result = new ServiceResult();
            try
            {
                var itemID = _tipoPartnersRepository.Find(id);
                if (itemID != null)
                {
                    var map = _tipoPartnersRepository.Update(item, id);
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
        public ServiceResult DeletePartnersType(int id, int Mod)
        {
            var result = new ServiceResult();
            try
            {
                var itemID = _tipoPartnersRepository.Find(id);
                if (itemID != null)
                {
                    var map = _tipoPartnersRepository.Delete(id, Mod);
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
        public ServiceResult FindPartnersType(int id)
        {
            var result = new ServiceResult();
            try
            {
                var partnerType = _tipoPartnersRepository.Find(id);
                return result.Ok(partnerType);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }

        }
        #endregion
    }
}
