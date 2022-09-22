﻿using AHM.Total.Travel.DataAccess.Repositories;
using AHM.Total.Travel.Entities.Entities;
using ConciertosProyecto.BusinessLogic;
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

        public ActivitiesService( ActividadesRepository actividades, ActividadesExtrasRepository actividadesExtras, TiposActividadesRepository tiposActividades )
        {
            _actividadesRepository = actividades;
            _actividadesExtrasRepository = actividadesExtras;
            _tiposActividadesRepository = tiposActividades;
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
                if (map > 0)
                {

                    return result.Ok(map);
                }
                else
                    return result.Error();
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
                    var list = _actividadesRepository.Update(tbActividades, id);
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
        public ServiceResult DeleteActivity(int id, int Mod)
        {
            var result = new ServiceResult();
            try
            {
                var itemID = _actividadesRepository.Find(id);
                if (itemID != null)
                {
                    var listado = _actividadesRepository.Delete(id, Mod);
                    return result.Ok(listado);

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
            var activity = new VW_tbActividades();
            try
            {
                activity = _actividadesRepository.Find(id);
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
        public ServiceResult CreateActiExt(tbActividadesExtras item)
        {

            var result = new ServiceResult();
            try
            {
                var map = _actividadesExtrasRepository.Insert(item);
                if (map > 0)
                {

                    return result.Ok(map);
                }
                else
                    return result.Error();
            }
            catch (Exception ex)
            {

                return result.Error(ex.Message);
            }
        }
        //ACTUALIZAR
        public ServiceResult UpdateActiExt(int id, tbActividadesExtras tbActividadesExtras)
        {
            var result = new ServiceResult();
            try
            {
                var itemID = _actividadesExtrasRepository.Find(id);
                if (itemID != null)
                {
                    var list = _actividadesExtrasRepository.Update(tbActividadesExtras, id);
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
        public ServiceResult DeleteActiExt(int id, int Mod)
        {
            var result = new ServiceResult();
            try
            {
                var itemID = _actividadesExtrasRepository.Find(id);
                if (itemID != null)
                {
                    var listado = _actividadesExtrasRepository.Delete(id, Mod);
                    return result.Ok(listado);

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
            var actExt = new VW_tbActividadesExtras();
            try
            {
                actExt = _actividadesExtrasRepository.Find(id);
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
                if (map > 0)
                {

                    return result.Ok(map);
                }
                else
                    return result.Error();
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
                    var list = _tiposActividadesRepository.Update(tbTiposActividades, id);
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
        public ServiceResult DeleteActTyp(int id, int Mod)
        {
            var result = new ServiceResult();
            try
            {
                var itemID = _tiposActividadesRepository.Find(id);
                if (itemID != null)
                {
                    var listado = _tiposActividadesRepository.Delete(id, Mod);
                    return result.Ok(listado);

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
            var actTyp = new VW_tbTiposActividades();
            try
            {
                actTyp = _tiposActividadesRepository.Find(id);
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
