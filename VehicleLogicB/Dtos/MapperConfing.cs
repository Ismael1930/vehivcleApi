using AutoMapper;
using VehicleLogicB.Models;

namespace VehicleLogicB.Dtos
{
    public class MapperConfing : Profile
    {
        public MapperConfing()
        {
            CreateMap<Car, CarDto>();
            CreateMap<CarDto, Car>();

            CreateMap<Make, MakeDto>();
            CreateMap<MakeDto, Make>();

            CreateMap<Model, ModelDto>();
            CreateMap<ModelDto, Model>();

        }
    }
}
