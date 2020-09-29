using AutoMapper;
using Seamless.Domain.Commands.ActivityLog;
using Seamless.Model.Dtos;
using Seamless.Model.Models;
using Seamless.Domain.Dxos.Common;

namespace Seamless.Domain.Dxos
{
    public class ActivityLogDxos : BaseDxos, IActivityLogDxos
    {
        public ActivityLogDxos()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SActivityLog, ActivityLogDto>()
                  .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                  .ForMember(dst => dst.Action, opt => opt.MapFrom(src => src.Action))
                  .ForMember(dst => dst.Status, opt => opt.MapFrom(src => src.Status))
                  .ForMember(dst => dst.Libelle, opt => opt.MapFrom(src => src.Libelle))
                  .ForMember(dst => dst.UserId, opt => opt.MapFrom(src => src.UserId))
                  .ForMember(dst => dst.ModifiedAt, opt => opt.MapFrom(src => src.ModifiedAt))
                  .ForMember(dst => dst.ModifiedBy, opt => opt.MapFrom(src => src.ModifiedBy))
                    ;

                cfg.CreateMap<CreateActivityLogCommand, SActivityLog>()
                  .ForMember(dst => dst.Action, opt => opt.MapFrom(src => src.Action))
                  .ForMember(dst => dst.Status, opt => opt.MapFrom(src => src.Status))
                  .ForMember(dst => dst.Libelle, opt => opt.MapFrom(src => src.Libelle))
                  .ForMember(dst => dst.UserId, opt => opt.MapFrom(src => src.UserId))
                  .ForMember(dst => dst.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
                  .ForMember(dst => dst.CreatedBy, opt => opt.MapFrom(src => src.CreatedBy))
                  .ForMember(dst => dst.ModifiedAt, opt => opt.MapFrom(src => src.CreatedAt))
                  .ForMember(dst => dst.ModifiedBy, opt => opt.MapFrom(src => src.CreatedBy))
                  ;


                cfg.CreateMap<UpdateActivityLogCommand, SActivityLog>()
                    .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                  .ForMember(dst => dst.Action, opt => opt.MapFrom(src => src.Action))
                  .ForMember(dst => dst.Status, opt => opt.MapFrom(src => src.Status))
                  .ForMember(dst => dst.Libelle, opt => opt.MapFrom(src => src.Libelle))
                  .ForMember(dst => dst.UserId, opt => opt.MapFrom(src => src.UserId))
                  .ForMember(dst => dst.ModifiedAt, opt => opt.MapFrom(src => src.ModifiedAt))
                  .ForMember(dst => dst.ModifiedBy, opt => opt.MapFrom(src => src.ModifiedBy))
                  ;
            });

            _mapper = config.CreateMapper();
        }

        public SActivityLog MapCreateRequesttoActivityLog(CreateActivityLogCommand request)
        {
            return _mapper.Map<CreateActivityLogCommand, SActivityLog>(request);
        }

        public ActivityLogDto MapActivityLogDto(SActivityLog ActivityLogModel)
        {
            return _mapper.Map<SActivityLog, ActivityLogDto>(ActivityLogModel);
        }

        public SActivityLog MapUpdateRequesttoActivityLog(UpdateActivityLogCommand request)
        {
            return _mapper.Map<UpdateActivityLogCommand, SActivityLog>(request);
        }
    }
}
