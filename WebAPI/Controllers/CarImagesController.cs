using Business.Abstract;
using Core.Utilities.FileOperations;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers        
{                                   
    [Route("api/[controller]")]     
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        ICarImageService _carImageService;
        IConfiguration _configuration;

        public CarImagesController(IConfiguration configuration, ICarImageService carImageService)
        {
            _configuration = configuration;
            _carImageService = carImageService;
        }

        [HttpGet("getallimages")]
        public IActionResult GetAllImages()
        {
            var result = _carImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();            
        }
        [HttpGet("getbyidimages")]
        public IActionResult GetByIdImages(int id)
        {
            var result = _carImageService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost("addimage")]
        public IActionResult Add([FromForm] IFormFile imageFile, [FromForm] CarImage entity)
        {
            entity.ImagePath = Guid.NewGuid() + Path.GetExtension(imageFile.FileName);
            var result = _carImageService.Add(entity);
            if (result.Success)
            {
                Operation.WriteImageFile(imageFile, _configuration.GetSection("ImageRootPath").Value, entity.ImagePath);
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("updateimage")]
        public IActionResult Update([FromForm] IFormFile imageFile, [FromForm] CarImage entity)
        {
            var deleted = _carImageService.GetById(entity.Id);
            if (deleted.Success)
            {
                Operation.DeleteImageFile(_configuration.GetSection("ImageRootPath").Value, deleted.Data.Single().ImagePath);
            }

            entity.ImagePath = Guid.NewGuid() + Path.GetExtension(imageFile.FileName);
            var updated = _carImageService.Update(entity);
            if (updated.Success)
            {
                Operation.WriteImageFile(imageFile, _configuration.GetSection("ImageRootPath").Value, entity.ImagePath);
                return Ok(updated);
            }
            return BadRequest(updated);
        }
        [HttpPost("deleteimage")]
        public IActionResult Delete([FromForm] CarImage entity)
        {
            var result = _carImageService.GetById(entity.Id);
            if (result.Success)
            {
                Operation.DeleteImageFile(_configuration.GetSection("ImageRootPath").Value, result.Data.Single().ImagePath);
                var deleted = _carImageService.Delete(entity);
                if (deleted.Success) return Ok(deleted);
            }
            return BadRequest();
        }
    }
}
