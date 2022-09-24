using AHM.Total.Travel.DataAccess.Repositories;
using AHM.Total.Travel.Entities.Entities;
using ConciertosProyecto.BusinessLogic;
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

        public RestaurantService(MenusRepository menusRepository,
                              MenuTypesRepository tiposMenusRepository,
                              RestaurantesRepository restaurantesRepository)
        {
            _menusRepository = menusRepository;
            _tiposMenusRepository = tiposMenusRepository;
            _restaurantesRepository = restaurantesRepository;

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
        public ServiceResult CreateRestaurants(tbRestaurantes item)
        {

            var result = new ServiceResult();
            try
            {
                var map = _restaurantesRepository.Insert(item);
                if (map.CodeStatus > 0)
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
        public ServiceResult UpdateRestaurants(int id, tbRestaurantes tbRestaurantes)
        {
            var result = new ServiceResult();
            try
            {
                var itemID = _restaurantesRepository.Find(id);
                if (itemID != null)
                {
                    var list = _restaurantesRepository.Update(tbRestaurantes, id);
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
        public ServiceResult DeleteRestaurants(int id, int Mod)
        {
            var result = new ServiceResult();
            try
            {
                var itemID = _restaurantesRepository.Find(id);
                if (itemID != null)
                {
                    var listado = _restaurantesRepository.Delete(id, Mod);
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
                    return result.Error();
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
                    var list = _tiposMenusRepository.Update(tbTipoMenus, id);
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
        public ServiceResult DeleteTipoMenus(int id, int Mod)
        {
            var result = new ServiceResult();
            try
            {
                var itemID = _tiposMenusRepository.Find(id);
                if (itemID != null)
                {
                    var listado = _tiposMenusRepository.Delete(id, Mod);
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
        public ServiceResult CreateMenus(tbMenus item)
        {

            var result = new ServiceResult();
            try
            {
                var map = _menusRepository.Insert(item);
                if (map.CodeStatus > 0)
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
        public ServiceResult UpdateMenus(int id, tbMenus tbMenus)
        {
            var result = new ServiceResult();
            try
            {
                var itemID = _menusRepository.Find(id);
                if (itemID != null)
                {
                    var list = _menusRepository.Update(tbMenus, id);
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
        public ServiceResult DeleteMenus(int id, int Mod)
        {
            var result = new ServiceResult();
            try
            {
                var itemID = _menusRepository.Find(id);
                if (itemID != null)
                {
                    var listado = _menusRepository.Delete(id, Mod);
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
