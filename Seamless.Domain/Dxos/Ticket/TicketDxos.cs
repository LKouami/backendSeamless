using AutoMapper;
using Seamless.Domain.Commands.Ticket;
using Seamless.Model.Dtos;
using Seamless.Model.Models;
using Seamless.Domain.Dxos.Common;

namespace Seamless.Domain.Dxos
{
    public class TicketDxos : BaseDxos, ITicketDxos
    {
        public TicketDxos()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<STicket, TicketDto>()
                  .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                  .ForMember(dst => dst.CategoryId, opt => opt.MapFrom(src => src.CategoryId))
                  .ForMember(dst => dst.Status, opt => opt.MapFrom(src => src.Status))
                  .ForMember(dst => dst.ParentId, opt => opt.MapFrom(src => src.ParentId))
                  .ForMember(dst => dst.PriorityId, opt => opt.MapFrom(src => src.PriorityId))
                  .ForMember(dst => dst.Object, opt => opt.MapFrom(src => src.Object))
                  .ForMember(dst => dst.Description, opt => opt.MapFrom(src => src.Description))
                  .ForMember(dst => dst.File, opt => opt.MapFrom(src => src.File))
                  .ForMember(dst => dst.State, opt => opt.MapFrom(src => src.State))
                  .ForMember(dst => dst.UserId, opt => opt.MapFrom(src => src.UserId))
                  .ForMember(dst => dst.ModifiedAt, opt => opt.MapFrom(src => src.ModifiedAt))
                  .ForMember(dst => dst.ModifiedBy, opt => opt.MapFrom(src => src.ModifiedBy))
                    ;

                cfg.CreateMap<CreateTicketCommand, STicket>()
                  .ForMember(dst => dst.CategoryId, opt => opt.MapFrom(src => src.CategoryId))
                  .ForMember(dst => dst.Status, opt => opt.MapFrom(src => src.Status))
                  .ForMember(dst => dst.ParentId, opt => opt.MapFrom(src => src.ParentId))
                  .ForMember(dst => dst.PriorityId, opt => opt.MapFrom(src => src.PriorityId))
                  .ForMember(dst => dst.Object, opt => opt.MapFrom(src => src.Object))
                  .ForMember(dst => dst.Description, opt => opt.MapFrom(src => src.Description))
                  .ForMember(dst => dst.File, opt => opt.MapFrom(src => src.File))
                  .ForMember(dst => dst.State, opt => opt.MapFrom(src => src.State))
                  .ForMember(dst => dst.UserId, opt => opt.MapFrom(src => src.UserId))
                  .ForMember(dst => dst.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
                  .ForMember(dst => dst.CreatedBy, opt => opt.MapFrom(src => src.CreatedBy))
                  .ForMember(dst => dst.ModifiedAt, opt => opt.MapFrom(src => src.CreatedAt))
                  .ForMember(dst => dst.ModifiedBy, opt => opt.MapFrom(src => src.CreatedBy))
                  ;


                cfg.CreateMap<UpdateTicketCommand, STicket>()
                    .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                  .ForMember(dst => dst.CategoryId, opt => opt.MapFrom(src => src.CategoryId))
                  .ForMember(dst => dst.Status, opt => opt.MapFrom(src => src.Status))
                  .ForMember(dst => dst.ParentId, opt => opt.MapFrom(src => src.ParentId))
                  .ForMember(dst => dst.PriorityId, opt => opt.MapFrom(src => src.PriorityId))
                  .ForMember(dst => dst.Object, opt => opt.MapFrom(src => src.Object))
                  .ForMember(dst => dst.Description, opt => opt.MapFrom(src => src.Description))
                  .ForMember(dst => dst.File, opt => opt.MapFrom(src => src.File))
                  .ForMember(dst => dst.UserId, opt => opt.MapFrom(src => src.UserId))
                  .ForMember(dst => dst.ModifiedAt, opt => opt.MapFrom(src => src.ModifiedAt))
                  .ForMember(dst => dst.ModifiedBy, opt => opt.MapFrom(src => src.ModifiedBy))
                  ;
            });

            _mapper = config.CreateMapper();
        }

        public STicket MapCreateRequesttoTicket(CreateTicketCommand request)
        {
            return _mapper.Map<CreateTicketCommand, STicket>(request);
        }

        public TicketDto MapTicketDto(STicket TicketModel)
        {
            return _mapper.Map<STicket, TicketDto>(TicketModel);
        }

        public STicket MapUpdateRequesttoTicket(UpdateTicketCommand request)
        {
            return _mapper.Map<UpdateTicketCommand, STicket>(request);
        }
    }
}
