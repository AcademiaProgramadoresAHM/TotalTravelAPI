using AHM.Total.Travel.Common.SecurityModels;
using AHM.Total.Travel.DataAccess.Repositories;
using AHM.Total.Travel.Entities.Entities;
using ConciertosProyecto.BusinessLogic;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace AHM.Total.Travel.BusinessLogic.Services
{
    public class AccessService
    {
        private readonly RolesRepository _rolesRepository;
        private readonly PermisosRepository _permisosRepository;
        private readonly RolesPermisosRepository _rolesPermisosRepository;
        private readonly UsuariosRepository _usuariosRepository;
        private readonly UsuariosLoginsRepository _usuariosLoginsRepository;
        private readonly UploaderImageRepository _uploaderImageRepository;

        public AccessService(RolesRepository rolesRepository, UploaderImageRepository uploaderImageRepository, PermisosRepository permisosRepository, RolesPermisosRepository rolesPermisosRepository, UsuariosRepository usuariosRepository, UsuariosLoginsRepository usuariosLoginsRepository)
        {
            _rolesRepository = rolesRepository;
            _permisosRepository = permisosRepository;
            _rolesPermisosRepository = rolesPermisosRepository;
            _usuariosRepository = usuariosRepository;
            _usuariosLoginsRepository = usuariosLoginsRepository;
            _uploaderImageRepository = uploaderImageRepository;
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

                return result.BadRequest(message:"No se pudo autenticar la sesión");
                
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
                if(itemID != null)
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
                if(itemID != null)
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
                if(itemID != null)
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
                if(itemID != null)
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
                var list = _usuariosRepository.List();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        //CREAR
        public ServiceResult CreateUsers(tbUsuarios item, IFormFile file)
        {
            var result = new ServiceResult();
            try
            {
                var map = _usuariosRepository.Insert(item);
                if (map.CodeStatus > 0)
                {
                    FileModel img = new FileModel();
                    img.FileName = "User-" + map.CodeStatus + ".jpg";
                    img.path = "ImagesAPI/Profile_Photos/Users";
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
        public ServiceResult UpdateUsers(int id, tbUsuarios tbUsuarios)
        {
            var result = new ServiceResult();
            try
            {
                var itemID = _usuariosRepository.Find(id);
                if (itemID != null)
                {
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
                var user = _usuariosRepository.Find(id);
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
