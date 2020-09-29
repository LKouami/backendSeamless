using AutoMapper;
using Seamless.Domain.Commands.NoteType;
using Seamless.Model.Dtos;
using Seamless.Model.Models;
using Seamless.Domain.Dxos.Common;

namespace Seamless.Domain.Dxos
{
    public class NoteTypeDxos : BaseDxos, INoteTypeDxos
    {
        public NoteTypeDxos()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SNoteType, NoteTypeDto>()
                  .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                  .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Name))
                  .ForMember(dst => dst.Status, opt => opt.MapFrom(src => src.Status))
                  .ForMember(dst => dst.Description, opt => opt.MapFrom(src => src.Description))
                  .ForMember(dst => dst.ModifiedAt, opt => opt.MapFrom(src => src.ModifiedAt))
                  .ForMember(dst => dst.ModifiedBy, opt => opt.MapFrom(src => src.ModifiedBy))
                    ;

                cfg.CreateMap<CreateNoteTypeCommand, SNoteType>()
                  .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Name))
                  .ForMember(dst => dst.Status, opt => opt.MapFrom(src => src.Status))
                  .ForMember(dst => dst.Description, opt => opt.MapFrom(src => src.Description))
                  .ForMember(dst => dst.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
                  .ForMember(dst => dst.CreatedBy, opt => opt.MapFrom(src => src.CreatedBy))
                  .ForMember(dst => dst.ModifiedAt, opt => opt.MapFrom(src => src.CreatedAt))
                  .ForMember(dst => dst.ModifiedBy, opt => opt.MapFrom(src => src.CreatedBy))
                  ;


                cfg.CreateMap<UpdateNoteTypeCommand, SNoteType>()
                    .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                  .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Name))
                  .ForMember(dst => dst.Status, opt => opt.MapFrom(src => src.Status))
                  .ForMember(dst => dst.Description, opt => opt.MapFrom(src => src.Description))
                  .ForMember(dst => dst.ModifiedAt, opt => opt.MapFrom(src => src.ModifiedAt))
                  .ForMember(dst => dst.ModifiedBy, opt => opt.MapFrom(src => src.ModifiedBy))
                  ;
            });

            _mapper = config.CreateMapper();
        }

        public SNoteType MapCreateRequesttoNoteType(CreateNoteTypeCommand request)
        {
            return _mapper.Map<CreateNoteTypeCommand, SNoteType>(request);
        }

        public NoteTypeDto MapNoteTypeDto(SNoteType NoteTypeModel)
        {
            return _mapper.Map<SNoteType, NoteTypeDto>(NoteTypeModel);
        }

        public SNoteType MapUpdateRequesttoNoteType(UpdateNoteTypeCommand request)
        {
            return _mapper.Map<UpdateNoteTypeCommand, SNoteType>(request);
        }
    }
}
