using AutoMapper;
using Seamless.Domain.Commands.Message;
using Seamless.Model.Dtos;
using Seamless.Model.Models;
using Seamless.Domain.Dxos.Common;

namespace Seamless.Domain.Dxos
{
    public class MessageDxos : BaseDxos, IMessageDxos
    {
        public MessageDxos()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SMessage, MessageDto>()
                  .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                  .ForMember(dst => dst.UserId, opt => opt.MapFrom(src => src.UserId))
                  .ForMember(dst => dst.Status, opt => opt.MapFrom(src => src.Status))
                  .ForMember(dst => dst.TicketId, opt => opt.MapFrom(src => src.TicketId))
                  .ForMember(dst => dst.Text, opt => opt.MapFrom(src => src.Text))
                  .ForMember(dst => dst.ModifiedAt, opt => opt.MapFrom(src => src.ModifiedAt))
                  .ForMember(dst => dst.ModifiedBy, opt => opt.MapFrom(src => src.ModifiedBy))
                    ;

                cfg.CreateMap<CreateMessageCommand, SMessage>()
                  .ForMember(dst => dst.UserId, opt => opt.MapFrom(src => src.UserId))
                  .ForMember(dst => dst.Status, opt => opt.MapFrom(src => src.Status))
                  .ForMember(dst => dst.TicketId, opt => opt.MapFrom(src => src.TicketId))
                  .ForMember(dst => dst.Text, opt => opt.MapFrom(src => src.Text))
                  .ForMember(dst => dst.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
                  .ForMember(dst => dst.CreatedBy, opt => opt.MapFrom(src => src.CreatedBy))
                  .ForMember(dst => dst.ModifiedAt, opt => opt.MapFrom(src => src.CreatedAt))
                  .ForMember(dst => dst.ModifiedBy, opt => opt.MapFrom(src => src.CreatedBy))
                  ;


                cfg.CreateMap<UpdateMessageCommand, SMessage>()
                    .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                  .ForMember(dst => dst.UserId, opt => opt.MapFrom(src => src.UserId))
                  .ForMember(dst => dst.Status, opt => opt.MapFrom(src => src.Status))
                  .ForMember(dst => dst.TicketId, opt => opt.MapFrom(src => src.TicketId))
                  .ForMember(dst => dst.Text, opt => opt.MapFrom(src => src.Text))
                  .ForMember(dst => dst.ModifiedAt, opt => opt.MapFrom(src => src.ModifiedAt))
                  .ForMember(dst => dst.ModifiedBy, opt => opt.MapFrom(src => src.ModifiedBy))
                  ;
            });

            _mapper = config.CreateMapper();
        }

        public SMessage MapCreateRequesttoMessage(CreateMessageCommand request)
        {
            return _mapper.Map<CreateMessageCommand, SMessage>(request);
        }

        public MessageDto MapMessageDto(SMessage MessageModel)
        {
            return _mapper.Map<SMessage, MessageDto>(MessageModel);
        }

        public SMessage MapUpdateRequesttoMessage(UpdateMessageCommand request)
        {
            return _mapper.Map<UpdateMessageCommand, SMessage>(request);
        }
    }
}
