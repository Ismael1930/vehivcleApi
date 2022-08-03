using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VehicleLogicB.Dtos;
using VehicleLogicB.Models;
using VehicleLogicB.Repositories;

namespace VehicleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MakeController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IGenericRepository<Make> repository;

        public MakeController(IMapper mapper, IGenericRepository<Make> repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var makes = await repository.GetAll();
            var makesDto = makes.Select(x => mapper.Map<MakeDto>(x));//Mapeado a los Dto
            return Ok(makesDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var make = await repository.GetById(id);

            if (make == null)
                return NotFound();

            var makeDto = mapper.Map<MakeDto>(make);
            return Ok(makeDto); 
        }

        [HttpPost]
        public async Task<IActionResult> Insert(MakeDto makeDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            try
            {
                var make = mapper.Map<Make>(makeDto);
                make = await repository.Insert(make);
                return Ok(make);
            }
            catch (Exception ex ) {return BadRequest(ex);}

           
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id,MakeDto makeDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

               makeDto.Id = id;

            if (makeDto.Id != id)
                return BadRequest();


            try
            {
                var make = mapper.Map<Make>(makeDto);
                make = await repository.Update(make);
                return Ok(make);
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
