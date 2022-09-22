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
                if (map > 0)
                    return result.Ok(map);
                else
                    return result.Error();
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
                    var list = _rolesRepository.Update(tbRoles, id);
                    return result.Ok(list);
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
                    var listado = _rolesRepository.Delete(id, Mod);
                    return result.Ok(listado);
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
            var role = new VW_tbRoles();
            try
            {
                role = _rolesRepository.Find(id);
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
                if (map > 0)
                    return result.Ok(map);
                else
                    return result.Error();
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
                    var list = _permisosRepository.Update(tbPermisos, id);
                    return result.Ok(list);
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
                    var list = _permisosRepository.Delete(id, Mod);
                    return result.Ok(list);
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
            var permission = new VW_tbPermisos();
            try
            {
                permission = _permisosRepository.Find(id);
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
                if (map > 0)
                    return result.Ok(map);
                else
                    return result.Error();
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
                    var list = _rolesPermisosRepository.Update(tbRolesPermisos, id);
                    return result.Ok(list);
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
                    var list = _rolesPermisosRepository.Delete(id, Mod);
                    return result.Ok(list);
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
            var rolper = new VW_tbRolesPermisos();
            try
            {
                rolper = _rolesPermisosRepository.Find(id);
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
                if (map > 0)
                    return result.Ok(map);
                else
                    return result.Error();
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
                    var list = _usuariosRepository.Update(tbUsuarios, id);
                    return result.Ok(list);
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
                    var list = _usuariosRepository.Delete(id, Mod);
                    return result.Ok(list);
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
            var user = new VW_tbUsuarios();
            try
            {
                user = _usuariosRepository.Find(id);
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
