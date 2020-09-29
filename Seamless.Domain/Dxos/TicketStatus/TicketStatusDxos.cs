using AutoMapper;
using Seamless.Domain.Commands.TicketStatus;
using Seamless.Model.Dtos;
using Seamless.Model.Models;
using Seamless.Domain.Dxos.Common;

namespace Seamless.Domain.Dxos
{
    public class TicketStatusDxos : BaseDxos, ITicketStatusDxos
    {
        public TicketStatusDxos()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<STicketStatus, TicketStatusDto>()
                  .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                  .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Name))
                  .ForMember(dst => dst.Status, opt => opt.MapFrom(src => src.Status))
                  .ForMember(dst => dst.ModifiedAt, opt => opt.MapFrom(src => src.ModifiedAt))
                  .ForMember(dst => dst.ModifiedBy, opt => opt.MapFrom(src => src.ModifiedBy))
                    ;

                cfg.CreateMap<CreateTicketStatusCommand, STicketStatus>()
                  .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Name))
                  .ForMember(dst => dst.Status, opt => opt.MapFrom(src => src.Status))
                  .ForMember(dst => dst.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
                  .ForMember(dst => dst.CreatedBy, opt => opt.MapFrom(src => src.CreatedBy))
                  .ForMember(dst => dst.ModifiedAt, opt => opt.MapFrom(src => src.CreatedAt))
                  .ForMember(dst => dst.ModifiedBy, opt => opt.MapFrom(src => src.CreatedBy))
                  ;


                cfg.CreateMap<UpdateTicketStatusCommand, STicketStatus>()
                    .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                  .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Name))
                  .ForMember(dst => dst.Status, opt => opt.MapFrom(src => src.Status))
                  .ForMember(dst => dst.ModifiedAt, opt => opt.MapFrom(src => src.ModifiedAt))
                  .ForMember(dst => dst.ModifiedBy, opt => opt.MapFrom(src => src.ModifiedBy))
                  ;
            });

            _mapper = config.CreateMapper();
        }

        public STicketStatus MapCreateRequesttoTicketStatus(CreateTicketStatusCommand request)
        {
            return _mapper.Map<CreateTicketStatusCommand, STicketStatus>(request);
        }

        public TicketStatusDto MapTicketStatusDto(STicketStatus TicketStatusModel)
        {
            return _mapper.Map<STicketStatus, TicketStatusDto>(TicketStatusModel);
        }

        public STicketStatus MapUpdateRequesttoTicketStatus(UpdateTicketStatusCommand request)
        {
            return _mapper.Map<UpdateTicketStatusCommand, STicketStatus>(request);
        }
    }
}
