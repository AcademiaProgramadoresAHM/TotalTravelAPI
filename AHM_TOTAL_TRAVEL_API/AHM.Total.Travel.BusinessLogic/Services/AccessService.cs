using AHM.Total.Travel.Common.SecurityModels;
using AHM.Total.Travel.DataAccess.Repositories;
using AHM.Total.Travel.Entities.Entities;
using ConciertosProyecto.BusinessLogic;
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

        public AccessService(RolesRepository roles, PermisosRepository permisos, RolesPermisosRepository rolesPermisos, UsuariosRepository usuariosRepository)
        {
            _rolesRepository = roles;
            _permisosRepository = permisos;
            _rolesPermisosRepository = rolesPermisos;
            _usuariosRepository = usuariosRepository;
        }

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
        public ServiceResult CreateUsers(tbUsuarios item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _usuariosRepository.Insert(item);
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
        //BUSCAR POR EMAIL
        public ServiceResult ApiLogin(UserLoginModel userLogin)
        {
            var result = new ServiceResult();
            try
            {
                var user = _usuariosRepository.AuthenticateUser(userLogin.Email, userLogin.Password);
                if (user != null)
                {
                    return result.Ok(user);
                }
                return result.NotFound("No se pudo encontrar el usuario");
                
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        #endregion
    }
}
