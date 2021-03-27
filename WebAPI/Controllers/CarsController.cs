using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.Entity_Framework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebAPI.Controllers        
{
    [Route("api/[controller]")]     
    [ApiController]                 
    public class CarsController : ControllerBase
    {
        ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet("getallcars")]
        public IActionResult GetAllCars()
        {
            
            var result = _carService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getcardetailsbyid")]
        public IActionResult GetAllCarsDetails(int carId)
        {

            var result = _carService.GetCarDetailsById(carId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        //[HttpGet("getcardetailsbyid")]
        //public IActionResult GetCarDetailsById(int carId)
        //{

        //    var result = _carService.GetCarDetailsById(carId);
        //    if (result.Success)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest(result);
        //}


        [HttpGet("getbybrand")]
        public IActionResult GetByBrandIdOfCars(int brandId)
        {
            var result = _carService.GetCarsByBrandId(brandId);
            if (result.Success)
            {
                
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbycolor")]
        public IActionResult GetByColorIdOfCars(int colorId)
        {
            var result = _carService.GetCarsByColorId(colorId);
            if (result.Success)
            {

                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Car car)
        {
            var result = _carService.Add(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}

//Ioc Container  -->  Inversion of Control       -->     Kontrolün tersine çevrilmesi
//Dependency chain  -->  Bağımlılık zinciri
//Loosely coupled  -->   Gevşek bağımlılık  (indirgenmiş)
//The controller names are plural       --- Kontrolcü isimlendirmeleri çoğul yazılır
//       Transportation token   ---   Ulaşım belirteci
// ----> ATTRIBUTE : Bir class'a dair önbilgi verme şeklidir.Class'ın imzası denebilir.