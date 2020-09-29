using AutoMapper;
using Seamless.Domain.Commands.AppParameter;
using Seamless.Model.Dtos;
using Seamless.Model.Models;
using Seamless.Domain.Dxos.Common;

namespace Seamless.Domain.Dxos
{
    public class AppParameterDxos : BaseDxos, IAppParameterDxos
    {
        public AppParameterDxos()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SAppParameter, AppParameterDto>()
                  .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                  .ForMember(dst => dst.ParameterName, opt => opt.MapFrom(src => src.ParameterName))
                  .ForMember(dst => dst.Section, opt => opt.MapFrom(src => src.Section))
                  .ForMember(dst => dst.Value, opt => opt.MapFrom(src => src.Value))
                  .ForMember(dst => dst.TypeParameter, opt => opt.MapFrom(src => src.TypeParameter))
                  .ForMember(dst => dst.ValuesList, opt => opt.MapFrom(src => src.ValuesList))
                  .ForMember(dst => dst.Status, opt => opt.MapFrom(src => src.Status))
                  .ForMember(dst => dst.ModifiedAt, opt => opt.MapFrom(src => src.ModifiedAt))
                  .ForMember(dst => dst.ModifiedBy, opt => opt.MapFrom(src => src.ModifiedBy))
                    ;

                cfg.CreateMap<CreateAppParameterCommand, SAppParameter>()
                 .ForMember(dst => dst.ParameterName, opt => opt.MapFrom(src => src.ParameterName))
                  .ForMember(dst => dst.Section, opt => opt.MapFrom(src => src.Section))
                  .ForMember(dst => dst.Value, opt => opt.MapFrom(src => src.Value))
                  .ForMember(dst => dst.TypeParameter, opt => opt.MapFrom(src => src.TypeParameter))
                  .ForMember(dst => dst.ValuesList, opt => opt.MapFrom(src => src.ValuesList))
                  .ForMember(dst => dst.Status, opt => opt.MapFrom(src => src.Status))
                  .ForMember(dst => dst.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
                  .ForMember(dst => dst.CreatedBy, opt => opt.MapFrom(src => src.CreatedBy))
                  .ForMember(dst => dst.ModifiedAt, opt => opt.MapFrom(src => src.CreatedAt))
                  .ForMember(dst => dst.ModifiedBy, opt => opt.MapFrom(src => src.CreatedBy))
                  ;


                cfg.CreateMap<UpdateAppParameterCommand, SAppParameter>()
                    .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                  .ForMember(dst => dst.ParameterName, opt => opt.MapFrom(src => src.ParameterName))
                  .ForMember(dst => dst.Section, opt => opt.MapFrom(src => src.Section))
                  .ForMember(dst => dst.Value, opt => opt.MapFrom(src => src.Value))
                  .ForMember(dst => dst.TypeParameter, opt => opt.MapFrom(src => src.TypeParameter))
                  .ForMember(dst => dst.ValuesList, opt => opt.MapFrom(src => src.ValuesList))
                  .ForMember(dst => dst.Status, opt => opt.MapFrom(src => src.Status))
                  .ForMember(dst => dst.ModifiedAt, opt => opt.MapFrom(src => src.ModifiedAt))
                  .ForMember(dst => dst.ModifiedBy, opt => opt.MapFrom(src => src.ModifiedBy))
                  ;
            });

            _mapper = config.CreateMapper();
        }

        public SAppParameter MapCreateRequesttoAppParameter(CreateAppParameterCommand request)
        {
            return _mapper.Map<CreateAppParameterCommand, SAppParameter>(request);
        }

        public AppParameterDto MapAppParameterDto(SAppParameter AppParameterModel)
        {
            return _mapper.Map<SAppParameter, AppParameterDto>(AppParameterModel);
        }

        public SAppParameter MapUpdateRequesttoAppParameter(UpdateAppParameterCommand request)
        {
            return _mapper.Map<UpdateAppParameterCommand, SAppParameter>(request);
        }
    }
}
