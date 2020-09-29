using AutoMapper;
using Seamless.Domain.Commands.Permission;
using Seamless.Model.Dtos;
using Seamless.Model.Models;
using Seamless.Domain.Dxos.Common;

namespace Seamless.Domain.Dxos
{
    public class PermissionDxos : BaseDxos, IPermissionDxos
    {
        public PermissionDxos()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SPermission, PermissionDto>()
                  .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                  .ForMember(dst => dst.Title, opt => opt.MapFrom(src => src.Title))
                  .ForMember(dst => dst.Status, opt => opt.MapFrom(src => src.Status))
                  .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Name))
                  .ForMember(dst => dst.ParentId, opt => opt.MapFrom(src => src.ParentId))
                  .ForMember(dst => dst.Level, opt => opt.MapFrom(src => src.Level))
                  .ForMember(dst => dst.ModifiedAt, opt => opt.MapFrom(src => src.ModifiedAt))
                  .ForMember(dst => dst.ModifiedBy, opt => opt.MapFrom(src => src.ModifiedBy))
                    ;

                cfg.CreateMap<CreatePermissionCommand, SPermission>()
                  .ForMember(dst => dst.Title, opt => opt.MapFrom(src => src.Title))
                  .ForMember(dst => dst.Status, opt => opt.MapFrom(src => src.Status))
                  .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Name))
                  .ForMember(dst => dst.ParentId, opt => opt.MapFrom(src => src.ParentId))
                  .ForMember(dst => dst.Level, opt => opt.MapFrom(src => src.Level))
                  .ForMember(dst => dst.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
                  .ForMember(dst => dst.CreatedBy, opt => opt.MapFrom(src => src.CreatedBy))
                  .ForMember(dst => dst.ModifiedAt, opt => opt.MapFrom(src => src.CreatedAt))
                  .ForMember(dst => dst.ModifiedBy, opt => opt.MapFrom(src => src.CreatedBy))
                  ;


                cfg.CreateMap<UpdatePermissionCommand, SPermission>()
                    .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                  .ForMember(dst => dst.Title, opt => opt.MapFrom(src => src.Title))
                  .ForMember(dst => dst.Status, opt => opt.MapFrom(src => src.Status))
                  .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Name))
                  .ForMember(dst => dst.ParentId, opt => opt.MapFrom(src => src.ParentId))
                  .ForMember(dst => dst.Level, opt => opt.MapFrom(src => src.Level))
                  .ForMember(dst => dst.ModifiedAt, opt => opt.MapFrom(src => src.ModifiedAt))
                  .ForMember(dst => dst.ModifiedBy, opt => opt.MapFrom(src => src.ModifiedBy))
                  ;
            });

            _mapper = config.CreateMapper();
        }

        public SPermission MapCreateRequesttoPermission(CreatePermissionCommand request)
        {
            return _mapper.Map<CreatePermissionCommand, SPermission>(request);
        }

        public PermissionDto MapPermissionDto(SPermission PermissionModel)
        {
            return _mapper.Map<SPermission, PermissionDto>(PermissionModel);
        }

        public SPermission MapUpdateRequesttoPermission(UpdatePermissionCommand request)
        {
            return _mapper.Map<UpdatePermissionCommand, SPermission>(request);
        }
    }
}
