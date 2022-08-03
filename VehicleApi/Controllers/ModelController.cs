using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VehicleLogicB.Dtos;
using VehicleLogicB.Models;
using VehicleLogicB.Repositories;

namespace VehicleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IGenericRepository<Model> repository;

        public ModelController(IMapper mapper, IGenericRepository<Model> repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var model = await repository.GetAll();
            var modelDto = model.Select(x => mapper.Map<ModelDto>(x));//Mapeado a los Dto
            return Ok(modelDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var model = await repository.GetById(id);

            if (model == null)
                return NotFound();

            var modelDto = mapper.Map<ModelDto>(model);
            return Ok(modelDto);
        }

        [HttpPost]
        public async Task<IActionResult> Insert(ModelDto modelDto , int MakeId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (MakeId == 0)
                return NotFound();


            try
            {
                var model = mapper.Map<Model>(modelDto);
                model = await repository.Insert(model);
                return Ok(model);
            }
            catch (Exception ex) { return BadRequest(ex); }


        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, ModelDto modelDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (modelDto.Id != id)
                return BadRequest();

            try
            {
                var model = mapper.Map<Model>(modelDto);
                await repository.Update(model);
                return Ok(model);
            }
            catch (Exception ex) { return BadRequest(ex); }


        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var modelById = await repository.GetById(id);

            if (modelById == null)
                return NotFound();

            await repository.Delete(id);
            return Ok();
        }
    }
}
