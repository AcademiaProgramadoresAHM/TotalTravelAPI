using AHM.Total.Travel.Common.Models;
using MailKit.Net.Imap;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;

namespace AHM.Total.Travel.BusinessLogic.Services
{
    public class ImagesService: ControllerBase
    {
        public readonly IHttpContextAccessor _httpContext;
        private readonly string _ImagesPath =Path.Combine(Directory.GetCurrentDirectory(), "ImagesAPI") ;
        public ImagesService(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }

        //Regresa una routa de acceso a la imagen en el servidor
        private string createImageUrlRoute(params string[] routes)
        {
            string baseUrl = Path.Combine("https://", _httpContext.HttpContext.Request.Host.Value, "API", "Images");
            foreach (var item in routes)
            {
                baseUrl = Path.Combine(baseUrl, item);
            }
            return baseUrl.Replace("\\", "/");
        }
        

        //Ingresa una o varias imagenes nuevas a la carpeta que se especifica, en caso de que no exista la carpeta, la crea
        public async Task<ServiceResult> saveImages(string folderName, string _fileName,  List<IFormFile> files)
        {
            ServiceResult result = new ServiceResult();
            if (folderName == null)
            {
                folderName = "Unspecified";
            }
            

            if (files != null)
            {
                var ImagesPath = "";
                var path = Path.Combine(_ImagesPath, folderName);

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                var i = 1;
                foreach (var item in files)
                {
                    if (item.Length > 0)
                    {
                 
                        var fileName = string.Concat(_fileName, "_photo-", i, ".jpg");


                        var filePath = Path.Combine(path, fileName);
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await item.CopyToAsync(stream);
                        }
                        ImagesPath += (Path.Combine(folderName, fileName) + ",");
                    }
                    i++;
                }

                return result.Ok(data: ImagesPath);
            }
            else
            {
                var path = Path.Combine(_ImagesPath, folderName);

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                string pathdefault = Path.GetFullPath("ImagesAPI/Default/DefaultPhoto.jpg");
                byte[] byteFile = System.IO.File.ReadAllBytes(pathdefault);
                var imageDefault = new MemoryStream(byteFile);


                var fileName = _fileName + ".jpg";
                var filePath = Path.Combine(path, fileName);
               
    
                using (var streamDefault = new FileStream(filePath, FileMode.Create))
                {
                    await imageDefault.CopyToAsync(streamDefault);
                }

                return result.Ok(data: Path.Combine("ImagesAPI",folderName, fileName));
            }
        
        }

        //Elimina las imagenes anteriores y las actualiza con las que se ingresan en el update
        public ServiceResult deleteImage(string imageroute)
        {
            var path = Path.Combine(_ImagesPath, imageroute);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
                
                return (new ServiceResult()).Ok(message: "Se ha eliminado la imagen");
            }
            else
            {
                return (new ServiceResult()).BadRequest(message: "No se encontró la imagen");
            }
        }

        //Obtiene la imagen que se solicita por medio de la ruta guardada en la DB
        public ServiceResult getImagesFilesByRoute(string imagesRoutes)
        {
            ServiceResult result = new ServiceResult();
            List<ImagesDetails> imageFiles = new List<ImagesDetails>();

            if (string.IsNullOrEmpty(imagesRoutes))
            { return result.BadRequest("No se ha ingresado ningun valor como argumento"); }
            
            List<string> listOfImages = imagesRoutes.Split(",").ToList();
            listOfImages.Remove("");
            foreach (var image in listOfImages)
            {
                List<string> routeComponents = image.Split("\\").ToList();

                ServiceResult response = getImage(routeComponents.ToArray());

                if (response.Code == 404 || response.Code == 400)
                {
                    imageFiles.Add(new ImagesDetails { FileName = "NotFound", ImageUrl = "NotFound" });
                }
                else
                {
                    imageFiles.Add(response.Data);
                }
                
            }
            if (listOfImages.Count == 1)
                return result.Ok(data: imageFiles[0]);
            else
                return result.Ok(data:imageFiles);
        }



        //Obtiene la imagen con el nombre y la carpeta que se le pasa
        public ServiceResult getImage(params string[] routes)
        {
            ServiceResult result = new ServiceResult();

            if (routes.Length == 0)
            {
                return result.BadRequest("No se ha ingresado ningun valor como argumento");
            }
            string path = _ImagesPath;

            foreach (var route in routes)
            {
                path = Path.Combine(path, route);
            }
            
            if (System.IO.File.Exists(path))
            {
                string imageName = Path.GetFileName(path);
                string imageUrl = createImageUrlRoute(routes);

                return result.Ok(data: new ImagesDetails { FileName = imageName, ImageRoute = path, ImageUrl = imageUrl });
            }
            else
            {
                return result.NotFound("La imagen no fue encontrada");
            }
        }

        //Obtiene todas las rutas del URL de las imagenes dentro de cualquier folder
        public ServiceResult getAllImagesFromFolder(string folderName, HttpContext context)
        {
            string path;
            ServiceResult result = new ServiceResult();
            
            if (string.IsNullOrEmpty(folderName))
            { path = _ImagesPath; }
            else 
            { path = Path.Combine(_ImagesPath, folderName); }
            
            var files = Directory.GetFiles(path);
            List<ImagesDetails> images = new List<ImagesDetails>();
            foreach (var item in files)
            {
                string route = item;
                var imageName = Path.GetFileName(item);
                string imgUrl = createImageUrlRoute(folderName, imageName);
                images.Add(new ImagesDetails { FileName = imageName, ImageRoute = route, ImageUrl = imgUrl });
            }
               return result.Ok(data: images);
        }


        public class ImagesDetails
        {
            public string FileName { get; set; }
            [JsonIgnore]
            public string ImageRoute { get; set; }
            public string ImageUrl { get; set; }
        }
    }
}
