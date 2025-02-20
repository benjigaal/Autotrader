using AutotraderAPI.Models;
using AutotraderAPI.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutotraderAPI.Controllers
{
    [Route("cars")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly AutotraderContext context;

        public CarsController(AutotraderContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public async Task<ActionResult> AddNewCar(CreateCarDto createdCarDto)
        {
            var car = new Car 
            { 
                Id = Guid.NewGuid(),
                Brand = createdCarDto.Brand,
                Type = createdCarDto.Type,
                Color = createdCarDto.Color,
                Myear = createdCarDto.Myear
            };

            
                await context.Cars.AddAsync(car);
                await context.SaveChangesAsync();

                return StatusCode(201, new {result = car, message = "Sikeres felvétel."});
        }

        [HttpGet]
        public async Task<ActionResult> GetAllCar()
        {
              var cars = await context.Cars.ToListAsync();
              if(cars != null)
              {
                  return Ok(new {result = cars, message = "Sikeres lekérdezés."});
              }

              Exception e = new();
              return BadRequest(new { result = "", message = e.Message });
        }

        [HttpGet("ById")]
        public async Task<ActionResult> GetCar(Guid id)
        {
              var car = await context.Cars.FirstOrDefaultAsync(x => x.Id == id);
              if(car != null)
              {
                  return Ok(new { result = car, message = "Sikeres találat." });
              }

              return NotFound(new { result = "", message = "Nincs ilyen autó az adatbázisban.." });
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteCar(Guid id)
        {
              var car = await context.Cars.FirstOrDefaultAsync(x => x.Id == id);
              if (car != null)
              {
                  context.Cars.Remove(car);
                  await context.SaveChangesAsync();

                  return Ok(new { result = car, message = "Sikeres törlés." });
              }

              return NotFound(new { result = "", message = "Nincs ilyen autó az adatbázisban.." });
        }

        [HttpPut]
        public async Task<ActionResult> UpdateCar(Guid id, UpdateCarDto updateCarDto)
        {
              var existingCar = await context.Cars.FirstOrDefaultAsync(x => x.Id == id);
              if (existingCar != null)
              {
                  existingCar.Brand = updateCarDto.Brand;
                  existingCar.Type = updateCarDto.Type;
                  existingCar.Color = updateCarDto.Color;
                  existingCar.Myear = updateCarDto.Myear;
                  existingCar.UpdatedTime = DateTime.Now;
                  context.Cars.Update(existingCar);
                  await context.SaveChangesAsync();

                  return Ok(new { result = existingCar, message = "Sikeres módosítás." });
              }

              return NotFound(new { result = "", message = "Nincs ilyen autó az adatbázisban.." });
        }
    }
}
