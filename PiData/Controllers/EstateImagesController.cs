using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PiData.Data;
using PiData.Data.Entities;
using PiData.Services;
using PiData.Specification;
using PiData.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PiData.Controllers
{
    public class EstateImagesController : Controller
    {
        private readonly IEstateService _estateService;
        private readonly IFileUpload _fileUpload;
        private readonly ApplicationDbContext _applicationDbContext;

        public EstateImagesController(IEstateService estateService, IFileUpload fileUpload,ApplicationDbContext applicationDbContext)
        {
            _estateService = estateService;
            _fileUpload = fileUpload;
            _applicationDbContext = applicationDbContext;
        }
       
        public async Task<IActionResult> Upload(int estateId)
        {
            if (estateId == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            var spec = new EstateFindSpecification(estateId);
            var estate = await _estateService.FirstAsync(spec);
            ViewBag.EstateId = estateId;
            ViewBag.EstateIdAndOwnerNameSurname ="Add Picture for ID:#" + estate.Id + " Property (" +estate.Owner.Name + " " + estate.Owner.Surname + " )";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile[] file, int estateId)  //Defined word "file" in dropzone
        {
            if (estateId != 0)
            {
                var spec = new EstateFindSpecification(estateId);
                var estate = await _estateService.FirstAsync(spec);
                if (estate == null)
                {
                    return NotFound();
                }
                if (file.Length > 0)
                {
                    foreach (var item in file)
                    {
                        var result = _fileUpload.Upload(item);
                        if (result.FileResult == Utilities.FileResult.Succeded)
                        {
                            EstatePicture estatePicture = new EstatePicture();
                            estatePicture.ImageUrl = result.FileUrl;
                            estatePicture.EstateId = estate.Id;
                            estate.EstatePictures.Add(estatePicture);
                            await _applicationDbContext.SaveChangesAsync();
                        }
                    }
                }
            }

            return View();
        }
    }
}
