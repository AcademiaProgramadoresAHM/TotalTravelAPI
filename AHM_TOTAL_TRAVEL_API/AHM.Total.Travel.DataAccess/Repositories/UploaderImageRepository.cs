using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AHM.Total.Travel.DataAccess.Repositories
{
    public class UploaderImageRepository
    {
        public RequestStatus UploaderFile([FromForm] FileModel fileModel)
        {
            RequestStatus response = new RequestStatus();
            try
            {
                string fullpath = Path.GetFullPath(fileModel.path);
                string path = Path.Combine(fullpath, fileModel.FileName);

                if (!Directory.Exists(fullpath))
                {
                    Directory.CreateDirectory(fullpath);

                    if (!Directory.Exists(fullpath))
                    {
                        response.CodeStatus = 100;
                        response.MessageStatus = "El directorio no existe.";
                    }
                    else
                    {
                        using (Stream stream = new FileStream(path, System.IO.FileMode.Create))
                        {
                            fileModel.file.CopyTo(stream);
                        }
                        response.CodeStatus = 200;
                        response.MessageStatus = "Imagen guardada con éxito.";
                    }
                }
                else
                {
                    using (Stream stream = new FileStream(path, System.IO.FileMode.Create))
                    {
                        fileModel.file.CopyTo(stream);
                    }
                    response.CodeStatus = 200;
                    response.MessageStatus = "Imagen guardada con éxito.";
                }
            }
            catch (Exception)
            {

                response.CodeStatus = 100;
                response.MessageStatus = "Ha ocurrido un error.";
            }
            return response;

        }
    }


    public class FileModel
    {
        public string FileName { get; set; }

        public string path { get; set; }

        public IFormFile file { get; set; }

    }
}
