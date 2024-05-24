using Business.Exceptions;
using Business.Services.Abstracts;
using Core.Models;
using Core.RepositoryAbstracts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Concretes
{
    public class ServicessService : IServicessService
    {
        private readonly IServicessRepository _servicessRepository;
        private readonly IWebHostEnvironment _env;

        public ServicessService(IServicessRepository servicessRepository, IWebHostEnvironment env)
        {
            _servicessRepository = servicessRepository;
            _env = env;
        }

        public void AddServicess(Servicess servicess)
        {
            if (servicess == null)
                throw new NotFoundException("Services not found");
            if (servicess.ImgFile == null)
                throw new NotNullException("ImgFile", "ImgFile can't be null");
            if (servicess.ImgFile.Length > 2097152)
                throw new FileSizeException("ImgFile", "filesize is not correct");
            if (servicess.ImgFile.ContentType.Contains("images/"))
                throw new FileContentTypeException("ImgFile", "content type is not correct");


             string fileName=servicess.ImgFile.FileName;
            string path=_env.WebRootPath+@"\uploads\servicess\"+fileName;
            using (FileStream fileStream = new FileStream(path, FileMode.Create))
            {
                servicess.ImgFile.CopyTo(fileStream);
            }
            servicess.ImgUrl=fileName;
            _servicessRepository.Add(servicess);
            _servicessRepository.Commit();



        }

        public void DeleteServicess(int id)
        {
            var existServicess = _servicessRepository.Get(x => x.Id == id);
            if (existServicess == null)
            {
                throw new NotFoundException("Services not found");

            }
            if (!File.Exists(existServicess.ImgUrl))
            {
                File.Delete(existServicess.ImgUrl);
            }
            _servicessRepository.Delete(existServicess);
            _servicessRepository.Commit();

               


        }

        public List<Servicess> GetAllServicess(Func<Servicess, bool>? func = null)
        {
           return _servicessRepository.GetAll(func);
        }

        public Servicess GetServicess(Func<Servicess, bool>? func = null)
        {
            return _servicessRepository.Get(func);
        }

        public void UpdateServicess(int id, Servicess servicess)
        {
            var existServicess = _servicessRepository.Get(x => x.Id == id);
            if (existServicess == null)
            {
                if (existServicess.ImgFile != null)
                {
                    if (servicess.ImgFile == null)
                        throw new NotNullException("ImgFile", "ImgFile can't be null");
                    if (servicess.ImgFile.Length > 2097152)
                        throw new FileSizeException("ImgFile", "filesize is not correct");
                    if (servicess.ImgFile.ContentType.Contains("images/"))
                        throw new FileContentTypeException("ImgFile", "content type is not correct");


                    string fileName = servicess.ImgFile.FileName;
                    string path = _env.WebRootPath + @"\uploads\servicess\" + fileName;
                    using (FileStream fileStream = new FileStream(path, FileMode.Create))
                    {
                        servicess.ImgFile.CopyTo(fileStream);
                    }
                    servicess.ImgFile = existServicess.ImgFile;
                    servicess.Title=existServicess.Title;
                    _servicessRepository.Commit();
                  

                }

            }
                
        }
    }
}
