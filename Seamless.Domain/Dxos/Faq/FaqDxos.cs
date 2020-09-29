using AutoMapper;
using Seamless.Domain.Commands.Faq;
using Seamless.Model.Dtos;
using Seamless.Model.Models;
using Seamless.Domain.Dxos.Common;

namespace Seamless.Domain.Dxos
{
    public class FaqDxos : BaseDxos, IFaqDxos
    {
        public FaqDxos()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SFaq, FaqDto>()
                  .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                  .ForMember(dst => dst.CategoryId, opt => opt.MapFrom(src => src.CategoryId))
                  .ForMember(dst => dst.Status, opt => opt.MapFrom(src => src.Status))
                  .ForMember(dst => dst.Title, opt => opt.MapFrom(src => src.Title))
                  .ForMember(dst => dst.Description, opt => opt.MapFrom(src => src.Description))
                  .ForMember(dst => dst.Locale, opt => opt.MapFrom(src => src.Locale))
                  .ForMember(dst => dst.ModifiedAt, opt => opt.MapFrom(src => src.ModifiedAt))
                  .ForMember(dst => dst.ModifiedBy, opt => opt.MapFrom(src => src.ModifiedBy))
                    ;

                cfg.CreateMap<CreateFaqCommand, SFaq>()
                  .ForMember(dst => dst.CategoryId, opt => opt.MapFrom(src => src.CategoryId))
                  .ForMember(dst => dst.Status, opt => opt.MapFrom(src => src.Status))
                  .ForMember(dst => dst.Title, opt => opt.MapFrom(src => src.Title))
                  .ForMember(dst => dst.Description, opt => opt.MapFrom(src => src.Description))
                  .ForMember(dst => dst.Locale, opt => opt.MapFrom(src => src.Locale))
                  .ForMember(dst => dst.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
                  .ForMember(dst => dst.CreatedBy, opt => opt.MapFrom(src => src.CreatedBy))
                  .ForMember(dst => dst.ModifiedAt, opt => opt.MapFrom(src => src.CreatedAt))
                  .ForMember(dst => dst.ModifiedBy, opt => opt.MapFrom(src => src.CreatedBy))
                  ;


                cfg.CreateMap<UpdateFaqCommand, SFaq>()
                    .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                  .ForMember(dst => dst.CategoryId, opt => opt.MapFrom(src => src.CategoryId))
                  .ForMember(dst => dst.Status, opt => opt.MapFrom(src => src.Status))
                  .ForMember(dst => dst.Title, opt => opt.MapFrom(src => src.Title))
                  .ForMember(dst => dst.Description, opt => opt.MapFrom(src => src.Description))
                  .ForMember(dst => dst.Locale, opt => opt.MapFrom(src => src.Locale))
                  .ForMember(dst => dst.ModifiedAt, opt => opt.MapFrom(src => src.ModifiedAt))
                  .ForMember(dst => dst.ModifiedBy, opt => opt.MapFrom(src => src.ModifiedBy))
                  ;
            });

            _mapper = config.CreateMapper();
        }

        public SFaq MapCreateRequesttoFaq(CreateFaqCommand request)
        {
            return _mapper.Map<CreateFaqCommand, SFaq>(request);
        }

        public FaqDto MapFaqDto(SFaq FaqModel)
        {
            return _mapper.Map<SFaq, FaqDto>(FaqModel);
        }

        public SFaq MapUpdateRequesttoFaq(UpdateFaqCommand request)
        {
            return _mapper.Map<UpdateFaqCommand, SFaq>(request);
        }
    }
}
