﻿using AHM.Total.Travel.Common.SecurityModels;
using AHM.Total.Travel.DataAccess.Repositories;
using AHM.Total.Travel.Entities.Entities;
using ConciertosProyecto.BusinessLogic;
using Microsoft.AspNetCore.Http;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using static AHM.Total.Travel.BusinessLogic.Services.ImagesService;

namespace AHM.Total.Travel.BusinessLogic.Services
{
    public class AccessService
    {
        private readonly RolesRepository _rolesRepository;
        private readonly ModulosRepository _modulosRepository;
        private readonly PermisosRepository _permisosRepository;
        private readonly RolesPermisosRepository _rolesPermisosRepository;
        private readonly UsuariosRepository _usuariosRepository;
        private readonly UsuariosLoginsRepository _usuariosLoginsRepository;
        private readonly NavbarRepository _navbarRepository;
        private readonly ImagesService _imagesService;
        private string _defaultImageRoute = "Default\\DefaultPhoto.jpg";
        private string _defaultAlbumRoute = "UsersProfilePics\\User-";


            public AccessService(NavbarRepository navbarRepository,RolesRepository rolesRepository, ModulosRepository modulosRepository, PermisosRepository permisosRepository, RolesPermisosRepository rolesPermisosRepository, UsuariosRepository usuariosRepository, UsuariosLoginsRepository usuariosLoginsRepository, ImagesService imagesService)
            {
                _rolesRepository = rolesRepository;
                _modulosRepository = modulosRepository;
                _permisosRepository = permisosRepository;
                _rolesPermisosRepository = rolesPermisosRepository;
                _usuariosRepository = usuariosRepository;
                _navbarRepository = navbarRepository;
                _usuariosLoginsRepository = usuariosLoginsRepository;
                _imagesService = imagesService;
            }




            #region UsuariosLogins

            //CREAR
            public ServiceResult CreateLogin(tbUsuariosLogins item)
            {
                var result = new ServiceResult();
                try
                {

                    var map = _usuariosLoginsRepository.Insert(item);
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
            public ServiceResult UpdateLogin(int id, tbUsuariosLogins tbUsuariosLogins)
            {
                var result = new ServiceResult();
                try
                {
                    var itemID = _usuariosLoginsRepository.Find(id);
                    if (itemID != null)
                    {
                        var map = _usuariosLoginsRepository.Update(tbUsuariosLogins, id);
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
                        return result.Error("No se pudo encontrar el registro");
                    }
                }
                catch (Exception ex)
                {
                    return result.Error(ex.Message);
                }
            }


            //BUSCAR
            public ServiceResult FindLogin(int id)
            {
                var result = new ServiceResult();
                try
                {
                    var role = _usuariosLoginsRepository.Find(id);
                    return result.Ok(role);
                }
                catch (Exception ex)
                {
                    return result.Error(ex.Message);
                }
            }

            //BUSCAR POR TOKEN
            public ServiceResult AuthenticateTokenExistence(string token)
            {
                var result = new ServiceResult();
                try
                {
                    var logins = _usuariosLoginsRepository.FindByToken(token);
                    if (logins != null)
                    {
                        return result.Ok(logins);
                    }

                    return result.BadRequest(message: "No se pudo autenticar la sesión");

                }
                catch (Exception ex)
                {
                    return result.Error(ex.Message);
                }
            }
            #endregion


            #region Roles
            //LISTADO
            public ServiceResult ListRole()
            {
                var result = new ServiceResult();
                try
                {
                    var list = _rolesRepository.List();
                    return result.Ok(list);
                }
                catch (Exception ex)
                {
                    return result.Error(ex.Message);
                }
            }

            //CREAR
            public ServiceResult CreateRole(tbRoles item)
            {
                var result = new ServiceResult();
                try
                {

                    var map = _rolesRepository.Insert(item);
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
            public ServiceResult UpdateRole(int id, tbRoles tbRoles)
            {
                var result = new ServiceResult();
                try
                {
                    var itemID = _rolesRepository.Find(id);
                    if (itemID != null)
                    {
                        var map = _rolesRepository.Update(tbRoles, id);
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
            public ServiceResult DeleteRole(int id, int Mod)
            {
                var result = new ServiceResult();
                try
                {
                    var itemID = _rolesRepository.Find(id);
                    if (itemID != null)
                    {
                        var map = _rolesRepository.Delete(id, Mod);
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
                        return result.Error("Los datos ingresados son incorrectos");

                }
                catch (Exception ex)
                {
                    return result.Error(ex.Message);
                }
            }

            //BUSCAR
            public ServiceResult FindRole(int id)
            {
                var result = new ServiceResult();
                try
                {
                    var role = _rolesRepository.Find(id);
                    return result.Ok(role);
                }
                catch (Exception ex)
                {
                    return result.Error(ex.Message);
                }
            }

        #endregion


        #region Navbar
        //LISTADO
        public ServiceResult ListNavbarGroups()
        {
            var result = new ServiceResult();
            try
            {
                var list = _navbarRepository.List();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        //CREAR
        public ServiceResult CreateNavbarGroups(tblGruposElementosNavbar item)
        {
            var result = new ServiceResult();
            try
            {

                var map = _navbarRepository.Insert(item);
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
        public ServiceResult UpdateNavbarGroups(int id, tblGruposElementosNavbar item)
        {
            var result = new ServiceResult();
            try
            {
                var itemID = _navbarRepository.Find(id);
                if (itemID != null)
                {
                    var map = _navbarRepository.Update(item, id);
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
        public ServiceResult DeleteNavbarGroups(int id, int Mod)
        {
            var result = new ServiceResult();
            try
            {
                var itemID = _navbarRepository.Find(id);
                if (itemID != null)
                {
                    var map = _navbarRepository.Delete(id, Mod);
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
                    return result.Error("Los datos ingresados son incorrectos");

            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        //BUSCAR
        public ServiceResult FindNavbarGroups(int id)
        {
            var result = new ServiceResult();
            try
            {
                var role = _navbarRepository.Find(id);
                return result.Ok(role);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        #endregion

        #region Permisos
        //LISTADO
        public ServiceResult ListPermission()
            {
                var result = new ServiceResult();
                try
                {
                    var list = _permisosRepository.List();
                    return result.Ok(list);
                }
                catch (Exception ex)
                {
                    return result.Error(ex.Message);
                }
            }

            //CREAR
            public ServiceResult CreatePermission(tbPermisos item)
            {
                var result = new ServiceResult();
                try
                {
                    var map = _permisosRepository.Insert(item);
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
            public ServiceResult UpdatePermission(int id, tbPermisos tbPermisos)
            {
                var result = new ServiceResult();
                try
                {
                    var itemID = _permisosRepository.Find(id);
                    if (itemID != null)
                    {
                        var map = _permisosRepository.Update(tbPermisos, id);
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
                    throw;
                }
            }

            //ELIMINAR
            public ServiceResult DeletePermission(int id, int Mod)
            {
                var result = new ServiceResult();
                try
                {
                    var itemID = _permisosRepository.Find(id);
                    if (itemID != null)
                    {
                        var map = _permisosRepository.Delete(id, Mod);
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
            public ServiceResult FindPermission(int id)
            {
                var result = new ServiceResult();
                try
                {
                    var permission = _permisosRepository.Find(id);
                    return result.Ok(permission);
                }
                catch (Exception ex)
                {
                    return result.Error(ex.Message);
                }
            }
            #endregion


            #region Modulos
            //LISTADO
            public ServiceResult ListModules()
            {
                var result = new ServiceResult();
                try
                {
                    var list = _modulosRepository.List();
                    return result.Ok(list);
                }
                catch (Exception ex)
                {
                    return result.Error(ex.Message);
                }
            }

            //CREAR
            public ServiceResult CreateModules(tbModulos item)
            {
                var result = new ServiceResult();
                try
                {
                    var map = _modulosRepository.Insert(item);
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
            public ServiceResult UpdateModulos(int id, tbModulos tbModulos)
            {
                var result = new ServiceResult();
                try
                {
                    var itemID = _modulosRepository.Find(id);
                    if (itemID != null)
                    {
                        var map = _modulosRepository.Update(tbModulos, id);
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
                    throw;
                }
            }

            //ELIMINAR
            public ServiceResult DeleteModulos(int id, int Mod)
            {
                var result = new ServiceResult();
                try
                {
                    var itemID = _modulosRepository.Find(id);
                    if (itemID != null)
                    {
                        var map = _modulosRepository.Delete(id, Mod);
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
            public ServiceResult FindModulos(int id)
            {
                var result = new ServiceResult();
                try
                {
                    var permission = _modulosRepository.Find(id);
                    return result.Ok(permission);
                }
                catch (Exception ex)
                {
                    return result.Error(ex.Message);
                }
            }
            #endregion

            #region RolesPermisos
            //LISTADO
            public ServiceResult ListRolePermission()
            {
                var result = new ServiceResult();
                try
                {
                    var list = _rolesPermisosRepository.List();
                    return result.Ok(list);
                }
                catch (Exception ex)
                {
                    return result.Error(ex.Message);
                }

            }
            //CREAR
            public ServiceResult CreateRolePermission(tbRolesPermisos item)
            {
                var result = new ServiceResult();
                try
                {
                    var map = _rolesPermisosRepository.Insert(item);
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
            public ServiceResult UpdateRolePermission(int id, tbRolesPermisos tbRolesPermisos)
            {
                var result = new ServiceResult();
                try
                {
                    var itemID = _rolesPermisosRepository.Find(id);
                    if (itemID != null)
                    {
                        var map = _rolesPermisosRepository.Update(tbRolesPermisos, id);
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
                        return result.Error("Los datos ingresados son incorrectos");
                }
                catch (Exception ex)
                {
                    return result.Error(ex.Message);
                }
            }

            //ELIMINAR
            public ServiceResult DeleteRolePermission(int id, int Mod)
            {
                var result = new ServiceResult();
                try
                {
                    var itemID = _rolesPermisosRepository.Find(id);
                    if (itemID != null)
                    {
                        var map = _rolesPermisosRepository.Delete(id, Mod);
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
                        return result.Error("Los datos ingresados son incorrectos");
                }
                catch (Exception ex)
                {
                    return result.Error(ex.Message);
                }
            }

            //BUSCAR
            public ServiceResult FindRolePermission(int id)
            {
                var result = new ServiceResult();
                try
                {
                    var rolper = _rolesPermisosRepository.Find(id);
                    return result.Ok(rolper);
                }
                catch (Exception ex)
                {
                    return result.Error(ex.Message);
                }
            }
            #endregion


            #region Usuarios
            //LISTADO
            public ServiceResult ListUsers()
            {
                var result = new ServiceResult();
                try
                {
                    List<VW_tbUsuarios> list = _usuariosRepository.List().ToList();
                    list.ForEach(item =>
                    {
                        item.Image_URL = ((ImagesDetails)_imagesService.getImagesFilesByRoute(item.Image_URL).Data).ImageUrl;
                    });
                    return result.Ok(list);
                }
                catch (Exception ex)
                {
                    return result.Error(ex.Message);
                }
            }

            //CREAR
            public ServiceResult CreateUsers(tbUsuarios item, List<IFormFile> file)
            {
                var result = new ServiceResult();


                try
                {
                    item.Usua_Url = _defaultImageRoute;
                    var map = _usuariosRepository.Insert(item);
                if (map.CodeStatus > 0)
                {
                    if (file != null)
                    {
                        if (file.Count > 1)
                            return result.BadRequest("You have inserted multiple images on a single image field");


                        try
                        {
                            UpdateUsers(map.CodeStatus, item, file);
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
                    var message = map.MessageStatus;
                    message = message.Substring(0, 23);
                    if (message == "Violation of UNIQUE KEY")
                    {
                        var Unique = map.MessageStatus.Substring(36,11);
                        if (Unique == "UK_Usua_DNI")
                        {
                            map.MessageStatus = (map.CodeStatus == 0) ? "El DNI ya existe." : map.MessageStatus;
                        }
                        else
                        {
                            map.MessageStatus = (map.CodeStatus == 0) ? "El EMAIL ya existe." : map.MessageStatus;
                        }

                    }
                    else
                    {
                        map.MessageStatus = (map.CodeStatus == 0) ? "401 Error de consulta" : map.MessageStatus;
                    }
                        
                       
                        return result.Error(map);
                    }
                }
                catch (Exception ex)
                {
                    return result.Error(ex.Message);
                }
            }

            //ACTUALIZAR
            public ServiceResult UpdateUsers(int id, tbUsuarios tbUsuarios, List<IFormFile> file)
            {
                var result = new ServiceResult();
                try
                {
                    var itemID = _usuariosRepository.Find(id);

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
                            string _fileName = "User-";
                            _defaultImageRoute = _imagesService.saveImages(
                                string.Concat(_defaultAlbumRoute, itemID.ID),
                                string.Concat(_fileName, itemID.ID),
                                file).Result.Data;

                            tbUsuarios.Usua_Url = _defaultImageRoute;
                        }
                        else
                        {
                            tbUsuarios.Usua_Url = itemID.Image_URL;
                        }

                        if (string.IsNullOrEmpty(itemID.Image_URL) || itemID.Image_URL == _defaultImageRoute)
                        {
                            tbUsuarios.Usua_Url = _defaultImageRoute;
                        }


                        var map = _usuariosRepository.Update(tbUsuarios, id);
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


            //ACTUALIZAR CONTRASEÑA
            public ServiceResult UpdatePassword(tbUsuarios tbUsuarios)
            {
                var result = new ServiceResult();
                try
                {
                    var map = _usuariosRepository.ChangePassword(tbUsuarios);
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
            //ELIMINAR
            public ServiceResult DeleteUsers(int id, int Mod)
            {
                var result = new ServiceResult();
                try
                {
                    var itemID = _usuariosRepository.Find(id);
                    if (itemID != null)
                    {
                        var map = _usuariosRepository.Delete(id, Mod);
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

            //BUSCAR
            public ServiceResult FindUsers(int id)
            {
                var result = new ServiceResult();
                try
                {
                    VW_tbUsuarios user = _usuariosRepository.Find(id);
                    if (user != null)
                    {
                        try
                        {
                            user.Image_URL = ((ImagesDetails)_imagesService.getImagesFilesByRoute(user.Image_URL).Data).ImageUrl;
                        }
                        catch (Exception)
                        {

                            return result.BadRequest("You have inserted multiple images on a single image field");
                        }

                    }

                    return result.Ok(user);
                }
                catch (Exception ex)
                {
                    return result.Error(ex.Message);
                }
            }

            #endregion

        }
    } 

