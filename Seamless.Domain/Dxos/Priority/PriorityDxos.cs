using AutoMapper;
using Seamless.Domain.Commands.Priority;
using Seamless.Model.Dtos;
using Seamless.Model.Models;
using Seamless.Domain.Dxos.Common;

namespace Seamless.Domain.Dxos
{
    public class PriorityDxos : BaseDxos, IPriorityDxos
    {
        public PriorityDxos()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SPriority, PriorityDto>()
                  .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                  .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Name))
                  .ForMember(dst => dst.Status, opt => opt.MapFrom(src => src.Status))
                  .ForMember(dst => dst.ModifiedAt, opt => opt.MapFrom(src => src.ModifiedAt))
                  .ForMember(dst => dst.ModifiedBy, opt => opt.MapFrom(src => src.ModifiedBy))
                    ;

                cfg.CreateMap<CreatePriorityCommand, SPriority>()
                  .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Name))
                  .ForMember(dst => dst.Status, opt => opt.MapFrom(src => src.Status))
                  .ForMember(dst => dst.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
                  .ForMember(dst => dst.CreatedBy, opt => opt.MapFrom(src => src.CreatedBy))
                  .ForMember(dst => dst.ModifiedAt, opt => opt.MapFrom(src => src.CreatedAt))
                  .ForMember(dst => dst.ModifiedBy, opt => opt.MapFrom(src => src.CreatedBy))
                  ;


                cfg.CreateMap<UpdatePriorityCommand, SPriority>()
                    .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                  .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Name))
                  .ForMember(dst => dst.Status, opt => opt.MapFrom(src => src.Status))
                  .ForMember(dst => dst.ModifiedAt, opt => opt.MapFrom(src => src.ModifiedAt))
                  .ForMember(dst => dst.ModifiedBy, opt => opt.MapFrom(src => src.ModifiedBy))
                  ;
            });

            _mapper = config.CreateMapper();
        }

        public SPriority MapCreateRequesttoPriority(CreatePriorityCommand request)
        {
            return _mapper.Map<CreatePriorityCommand, SPriority>(request);
        }

        public PriorityDto MapPriorityDto(SPriority PriorityModel)
        {
            return _mapper.Map<SPriority, PriorityDto>(PriorityModel);
        }

        public SPriority MapUpdateRequesttoPriority(UpdatePriorityCommand request)
        {
            return _mapper.Map<UpdatePriorityCommand, SPriority>(request);
        }
    }
}
