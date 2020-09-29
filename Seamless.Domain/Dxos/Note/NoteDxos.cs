using AutoMapper;
using Seamless.Domain.Commands.Note;
using Seamless.Model.Dtos;
using Seamless.Model.Models;
using Seamless.Domain.Dxos.Common;

namespace Seamless.Domain.Dxos
{
    public class NoteDxos : BaseDxos, INoteDxos
    {
        public NoteDxos()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SNote, NoteDto>()
                  .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                  .ForMember(dst => dst.UserId, opt => opt.MapFrom(src => src.UserId))
                  .ForMember(dst => dst.Status, opt => opt.MapFrom(src => src.Status))
                  .ForMember(dst => dst.TicketId, opt => opt.MapFrom(src => src.TicketId))
                  .ForMember(dst => dst.Channel, opt => opt.MapFrom(src => src.Channel))
                  .ForMember(dst => dst.Note, opt => opt.MapFrom(src => src.Note))
                  .ForMember(dst => dst.ModifiedAt, opt => opt.MapFrom(src => src.ModifiedAt))
                  .ForMember(dst => dst.ModifiedBy, opt => opt.MapFrom(src => src.ModifiedBy))
                    ;

                cfg.CreateMap<CreateNoteCommand, SNote>()
                  .ForMember(dst => dst.UserId, opt => opt.MapFrom(src => src.UserId))
                  .ForMember(dst => dst.Status, opt => opt.MapFrom(src => src.Status))
                  .ForMember(dst => dst.TicketId, opt => opt.MapFrom(src => src.TicketId))
                  .ForMember(dst => dst.Channel, opt => opt.MapFrom(src => src.Channel))
                  .ForMember(dst => dst.Note, opt => opt.MapFrom(src => src.Note))
                  .ForMember(dst => dst.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
                  .ForMember(dst => dst.CreatedBy, opt => opt.MapFrom(src => src.CreatedBy))
                  .ForMember(dst => dst.ModifiedAt, opt => opt.MapFrom(src => src.CreatedAt))
                  .ForMember(dst => dst.ModifiedBy, opt => opt.MapFrom(src => src.CreatedBy))
                  ;


                cfg.CreateMap<UpdateNoteCommand, SNote>()
                    .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                  .ForMember(dst => dst.UserId, opt => opt.MapFrom(src => src.UserId))
                  .ForMember(dst => dst.Status, opt => opt.MapFrom(src => src.Status))
                  .ForMember(dst => dst.TicketId, opt => opt.MapFrom(src => src.TicketId))
                  .ForMember(dst => dst.Channel, opt => opt.MapFrom(src => src.Channel))
                  .ForMember(dst => dst.Note, opt => opt.MapFrom(src => src.Note))
                  .ForMember(dst => dst.ModifiedAt, opt => opt.MapFrom(src => src.ModifiedAt))
                  .ForMember(dst => dst.ModifiedBy, opt => opt.MapFrom(src => src.ModifiedBy))
                  ;
            });

            _mapper = config.CreateMapper();
        }

        public SNote MapCreateRequesttoNote(CreateNoteCommand request)
        {
            return _mapper.Map<CreateNoteCommand, SNote>(request);
        }

        public NoteDto MapNoteDto(SNote NoteModel)
        {
            return _mapper.Map<SNote, NoteDto>(NoteModel);
        }

        public SNote MapUpdateRequesttoNote(UpdateNoteCommand request)
        {
            return _mapper.Map<UpdateNoteCommand, SNote>(request);
        }
    }
}
