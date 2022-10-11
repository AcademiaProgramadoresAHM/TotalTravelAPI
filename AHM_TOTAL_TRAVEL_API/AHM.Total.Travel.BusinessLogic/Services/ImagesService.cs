using AHM.Total.Travel.Common.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace AHM.Total.Travel.BusinessLogic.Services
{
    public class ImagesService: ControllerBase
    {
        private readonly string _ImagesPath = "C:\\Users\\andre\\OneDrive\\Documentos\\GitHub\\TotalTravelAPI\\AHM_TOTAL_TRAVEL_API\\AHM.Total.Travel.Api\\";
        public ServiceResult saveImages(List<IFormFile> files, string folderName)
        {
            if (folderName == null)
            {
                folderName = "Default";
            }
            ServiceResult result = new ServiceResult();
            if (files.Count > 0)
            {
                var ImagesPath = "";
                var path = Path.Combine(_ImagesPath, "ImagesAPI", folderName);

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                foreach (var item in files)
                {
                    if (item.Length > 0)
                    {
                        var fileName = Path.GetFileName(item.FileName);
                        var filePath = Path.Combine(path, fileName);
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            item.CopyToAsync(stream);
                        }
                        ImagesPath += (Path.Combine("ImagesAPI", folderName, fileName) + ",");
                    }
                }

                return result.Ok(data: ImagesPath);
            }
            else
            {
                return result.BadRequest(message: "\\ImagesAPI\\Default\\DefaultPhoto.jpg");
            }
        }
        //Elimina las imagenes anteriores y las actualiza con las que se ingresan en el update
        public IActionResult deleteImage(string imageroute)
        {
            var path = Path.Combine(_ImagesPath, imageroute);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
                return Ok("Se ha eliminado");
            }
            else
            {
                return BadRequest("No se encontro la imagen");
            }
        }


        //Obtiene la imagen con el nombre y la carpeta que se le pasa
        public IActionResult getImage(string folderName, string imageName)
        {
            var path = Path.Combine(_ImagesPath, "ImagesAPI", folderName, imageName);
            var stream = System.IO.File.OpenRead(path);
            return File(stream, "image/jpeg");
        }

        public ServiceResult getAllImagesAsBase64(string folderName)
        {
            ServiceResult result = new ServiceResult();
            var path = Path.Combine(_ImagesPath, "ImagesAPI", folderName);
            var files = Directory.GetFiles(path);
            List<ImagesDetails> images = new List<ImagesDetails>();
            foreach (var item in files)
            {
                var image = Convert.ToBase64String(System.IO.File.ReadAllBytes(item));
                var imageName = Path.GetFileName(item);
                images.Add(new ImagesDetails { FileName = imageName, ImageAsBase64 = image });

            }
            return result.Ok(data: images);
        }
        public class ImagesDetails
        {
            public string FileName { get; set; }
            public string ImageAsBase64 { get; set; }
        }
    }
}
