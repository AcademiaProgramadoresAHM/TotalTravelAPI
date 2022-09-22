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

        public AccessService(RolesRepository roles, PermisosRepository permisos, RolesPermisosRepository rolesPermisos)
        {
            _rolesRepository = roles;
            _permisosRepository = permisos;
            _rolesPermisosRepository = rolesPermisos;
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
    }
}
