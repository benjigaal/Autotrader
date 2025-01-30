using AutotraderAPI.Models;
using AutotraderAPI.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutotraderAPI.Controllers
{
    [Route("cars")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        [HttpPost]
        public ActionResult AddNewCar(CreateCarDto createdCarDto)
        {
            var car = new Car 
            { 
                Id = Guid.NewGuid(),
                Brand = createdCarDto.Brand,
                Type = createdCarDto.Type,
                Color = createdCarDto.Color,
                Myear = createdCarDto.Myear
            };

            using (var context = new AutotraderContext())
            {
                context.Cars.Add(car);
                context.SaveChanges();

                return StatusCode(201, new {result = car, message = "Sikeres felvétel."});
            }
            return Ok();
        }
    }
}
