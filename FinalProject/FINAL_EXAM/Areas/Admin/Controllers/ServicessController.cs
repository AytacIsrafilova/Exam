using Business.Exceptions;
using Business.Services.Abstracts;
using Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Data;

namespace FINAL_EXAM.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ServicessController : Controller
    {
        private readonly IServicessService _servicessService;

        public ServicessController(IServicessService servicessService)
        {
            _servicessService = servicessService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create( Servicess servicess)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                _servicessService.AddServicess(servicess);
            }
            catch (NotFoundException ex)
            {

                return View("Error");
            }
            catch(NotNullException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);

            } 
            catch(FileSizeException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);

            } catch(FileContentTypeException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);

            }
            return RedirectToAction("Index");
           
        }

        public IActionResult Delete(int id)
        {
            if(!ModelState.IsValid)
                return View();
            try
            {
                _servicessService.DeleteServicess(id);
            }
            catch (NotFoundException ex)
            {
                return View("Error");

            }
            return RedirectToAction("Index");
        }
        public IActionResult Update(int id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Update(Servicess servicess,int id)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                _servicessService.UpdateServicess(id,servicess);
            }
            catch (NotFoundException ex)
            {

                return View("Error");
            }
            catch (FileSizeException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);

            }
            catch (FileContentTypeException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);

            }
            return RedirectToAction("Index");
        }
    }
}
