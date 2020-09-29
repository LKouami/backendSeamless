using AutoMapper;
using Seamless.Domain.Commands.TicketField;
using Seamless.Model.Dtos;
using Seamless.Model.Models;
using Seamless.Domain.Dxos.Common;

namespace Seamless.Domain.Dxos
{
    public class TicketFieldDxos : BaseDxos, ITicketFieldDxos
    {
        public TicketFieldDxos()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<STicketField, TicketFieldDto>()
                  .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                  .ForMember(dst => dst.Title, opt => opt.MapFrom(src => src.Title))
                  .ForMember(dst => dst.Status, opt => opt.MapFrom(src => src.Status))
                  .ForMember(dst => dst.Description, opt => opt.MapFrom(src => src.Description))
                  .ForMember(dst => dst.Type, opt => opt.MapFrom(src => src.Type))
                  .ForMember(dst => dst.IsRequired, opt => opt.MapFrom(src => src.IsRequired))
                  .ForMember(dst => dst.Order, opt => opt.MapFrom(src => src.Order))
                  .ForMember(dst => dst.ChoiceList, opt => opt.MapFrom(src => src.ChoiceList))
                  .ForMember(dst => dst.ModifiedAt, opt => opt.MapFrom(src => src.ModifiedAt))
                  .ForMember(dst => dst.ModifiedBy, opt => opt.MapFrom(src => src.ModifiedBy))
                    ;

                cfg.CreateMap<CreateTicketFieldCommand, STicketField>()
                  .ForMember(dst => dst.Title, opt => opt.MapFrom(src => src.Title))
                  .ForMember(dst => dst.Status, opt => opt.MapFrom(src => src.Status))
                  .ForMember(dst => dst.Description, opt => opt.MapFrom(src => src.Description))
                  .ForMember(dst => dst.Type, opt => opt.MapFrom(src => src.Type))
                  .ForMember(dst => dst.IsRequired, opt => opt.MapFrom(src => src.IsRequired))
                  .ForMember(dst => dst.Order, opt => opt.MapFrom(src => src.Order))
                  .ForMember(dst => dst.ChoiceList, opt => opt.MapFrom(src => src.ChoiceList))
                  .ForMember(dst => dst.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
                  .ForMember(dst => dst.CreatedBy, opt => opt.MapFrom(src => src.CreatedBy))
                  .ForMember(dst => dst.ModifiedAt, opt => opt.MapFrom(src => src.CreatedAt))
                  .ForMember(dst => dst.ModifiedBy, opt => opt.MapFrom(src => src.CreatedBy))
                  ;


                cfg.CreateMap<UpdateTicketFieldCommand, STicketField>()
                    .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                  .ForMember(dst => dst.Title, opt => opt.MapFrom(src => src.Title))
                  .ForMember(dst => dst.Status, opt => opt.MapFrom(src => src.Status))
                  .ForMember(dst => dst.Description, opt => opt.MapFrom(src => src.Description))
                  .ForMember(dst => dst.Type, opt => opt.MapFrom(src => src.Type))
                  .ForMember(dst => dst.IsRequired, opt => opt.MapFrom(src => src.IsRequired))
                  .ForMember(dst => dst.Order, opt => opt.MapFrom(src => src.Order))
                  .ForMember(dst => dst.ChoiceList, opt => opt.MapFrom(src => src.ChoiceList))
                  .ForMember(dst => dst.ModifiedAt, opt => opt.MapFrom(src => src.ModifiedAt))
                  .ForMember(dst => dst.ModifiedBy, opt => opt.MapFrom(src => src.ModifiedBy))
                  ;
            });

            _mapper = config.CreateMapper();
        }

        public STicketField MapCreateRequesttoTicketField(CreateTicketFieldCommand request)
        {
            return _mapper.Map<CreateTicketFieldCommand, STicketField>(request);
        }

        public TicketFieldDto MapTicketFieldDto(STicketField TicketFieldModel)
        {
            return _mapper.Map<STicketField, TicketFieldDto>(TicketFieldModel);
        }

        public STicketField MapUpdateRequesttoTicketField(UpdateTicketFieldCommand request)
        {
            return _mapper.Map<UpdateTicketFieldCommand, STicketField>(request);
        }
    }
}
