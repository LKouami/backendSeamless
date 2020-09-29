using AutoMapper;
using Seamless.Domain.Commands.Category;
using Seamless.Model.Dtos;
using Seamless.Model.Models;
using Seamless.Domain.Dxos.Common;

namespace Seamless.Domain.Dxos
{
    public class CategoryDxos : BaseDxos, ICategoryDxos
    {
        public CategoryDxos()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SCategory, CategoryDto>()
                  .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                  .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Name))
                  .ForMember(dst => dst.Status, opt => opt.MapFrom(src => src.Status))
                  .ForMember(dst => dst.Description, opt => opt.MapFrom(src => src.Description))
                  .ForMember(dst => dst.Level, opt => opt.MapFrom(src => src.Level))
                  .ForMember(dst => dst.ParentId, opt => opt.MapFrom(src => src.ParentId))
                  .ForMember(dst => dst.ModifiedAt, opt => opt.MapFrom(src => src.ModifiedAt))
                  .ForMember(dst => dst.ModifiedBy, opt => opt.MapFrom(src => src.ModifiedBy))
                    ;

                cfg.CreateMap<CreateCategoryCommand, SCategory>()
                  .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Name))
                  .ForMember(dst => dst.Status, opt => opt.MapFrom(src => src.Status))
                  .ForMember(dst => dst.Description, opt => opt.MapFrom(src => src.Description))
                  .ForMember(dst => dst.Level, opt => opt.MapFrom(src => src.Level))
                  .ForMember(dst => dst.ParentId, opt => opt.MapFrom(src => src.ParentId))
                  .ForMember(dst => dst.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
                  .ForMember(dst => dst.CreatedBy, opt => opt.MapFrom(src => src.CreatedBy))
                  .ForMember(dst => dst.ModifiedAt, opt => opt.MapFrom(src => src.CreatedAt))
                  .ForMember(dst => dst.ModifiedBy, opt => opt.MapFrom(src => src.CreatedBy))
                  ;


                cfg.CreateMap<UpdateCategoryCommand, SCategory>()
                    .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                  .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Name))
                  .ForMember(dst => dst.Status, opt => opt.MapFrom(src => src.Status))
                  .ForMember(dst => dst.Description, opt => opt.MapFrom(src => src.Description))
                  .ForMember(dst => dst.Level, opt => opt.MapFrom(src => src.Level))
                  .ForMember(dst => dst.ParentId, opt => opt.MapFrom(src => src.ParentId))
                  .ForMember(dst => dst.ModifiedAt, opt => opt.MapFrom(src => src.ModifiedAt))
                  .ForMember(dst => dst.ModifiedBy, opt => opt.MapFrom(src => src.ModifiedBy))
                  ;
            });

            _mapper = config.CreateMapper();
        }

        public SCategory MapCreateRequesttoCategory(CreateCategoryCommand request)
        {
            return _mapper.Map<CreateCategoryCommand, SCategory>(request);
        }

        public CategoryDto MapCategoryDto(SCategory CategoryModel)
        {
            return _mapper.Map<SCategory, CategoryDto>(CategoryModel);
        }

        public SCategory MapUpdateRequesttoCategory(UpdateCategoryCommand request)
        {
            return _mapper.Map<UpdateCategoryCommand, SCategory>(request);
        }
    }
}
