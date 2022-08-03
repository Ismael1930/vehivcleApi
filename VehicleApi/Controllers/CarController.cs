using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VehicleLogicB.Dtos;
using VehicleLogicB.Models;
using VehicleLogicB.Repositories;

namespace VehicleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IGenericRepository<Car> repository;
       

        public CarController(IMapper mapper, IGenericRepository<Car> repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var cars = await repository.GetAll();
            var carDto = cars.Select(x => mapper.Map<CarDto>(x));//Mapeado a los Dto
            return Ok(carDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var car = await repository.GetById(id);

            if (car == null)
                return NotFound();

            var carDto = mapper.Map<CarDto>(car);
            return Ok(carDto);
        }

        [HttpPost]
        public async Task<IActionResult> Insert(CarDto carDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            try
            {
                var car = mapper.Map<Car>(carDto);
                car = await repository.Insert(car);
                return Ok(car);
            }
            catch (Exception ex) { return BadRequest(ex); }


        }
                         
        [HttpPut]
        public async Task<IActionResult> Update(int id, CarDto carDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (carDto.Id != id)
                return BadRequest();

            try
            {
                var car = mapper.Map<Car>(carDto);
                await repository.Update(car);
                return Ok(carDto);
            }
            catch (Exception ex) { return BadRequest(ex); }


        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var makeById = await repository.GetById(id);

            if (makeById == null)
                return NotFound();

            await repository.Delete(id);
            return Ok();
        }
    }
}
