using AutoMapper;
using Seamless.Domain.Commands.Assignment;
using Seamless.Model.Dtos;
using Seamless.Model.Models;
using Seamless.Domain.Dxos.Common;

namespace Seamless.Domain.Dxos
{
    public class AssignmentDxos : BaseDxos, IAssignmentDxos
    {
        public AssignmentDxos()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SAssignment, AssignmentDto>()
                  .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                  .ForMember(dst => dst.TicketId, opt => opt.MapFrom(src => src.TicketId))
                  .ForMember(dst => dst.Status, opt => opt.MapFrom(src => src.Status))
                  .ForMember(dst => dst.ClosedDate, opt => opt.MapFrom(src => src.ClosedDate))
                  .ForMember(dst => dst.ClosedUserId, opt => opt.MapFrom(src => src.ClosedUserId))
                  .ForMember(dst => dst.CloseReasonId, opt => opt.MapFrom(src => src.CloseReasonId))
                  .ForMember(dst => dst.AssigneeId, opt => opt.MapFrom(src => src.AssigneeId))
                  .ForMember(dst => dst.AssignerId, opt => opt.MapFrom(src => src.AssignerId))
                  .ForMember(dst => dst.ModifiedAt, opt => opt.MapFrom(src => src.ModifiedAt))
                  .ForMember(dst => dst.ModifiedBy, opt => opt.MapFrom(src => src.ModifiedBy))
                    ;

                cfg.CreateMap<CreateAssignmentCommand, SAssignment>()
                  .ForMember(dst => dst.TicketId, opt => opt.MapFrom(src => src.TicketId))
                  .ForMember(dst => dst.Status, opt => opt.MapFrom(src => src.Status))
                  .ForMember(dst => dst.ClosedDate, opt => opt.MapFrom(src => src.ClosedDate))
                  .ForMember(dst => dst.ClosedUserId, opt => opt.MapFrom(src => src.ClosedUserId))
                  .ForMember(dst => dst.CloseReasonId, opt => opt.MapFrom(src => src.CloseReasonId))
                  .ForMember(dst => dst.AssigneeId, opt => opt.MapFrom(src => src.AssigneeId))
                  .ForMember(dst => dst.AssignerId, opt => opt.MapFrom(src => src.AssignerId))
                  .ForMember(dst => dst.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
                  .ForMember(dst => dst.CreatedBy, opt => opt.MapFrom(src => src.CreatedBy))
                  .ForMember(dst => dst.ModifiedAt, opt => opt.MapFrom(src => src.CreatedAt))
                  .ForMember(dst => dst.ModifiedBy, opt => opt.MapFrom(src => src.CreatedBy))
                  ;


                cfg.CreateMap<UpdateAssignmentCommand, SAssignment>()
                  .ForMember(dst => dst.TicketId, opt => opt.MapFrom(src => src.TicketId))
                  .ForMember(dst => dst.Status, opt => opt.MapFrom(src => src.Status))
                  .ForMember(dst => dst.ClosedDate, opt => opt.MapFrom(src => src.ClosedDate))
                  .ForMember(dst => dst.ClosedUserId, opt => opt.MapFrom(src => src.ClosedUserId))
                  .ForMember(dst => dst.CloseReasonId, opt => opt.MapFrom(src => src.CloseReasonId))
                  .ForMember(dst => dst.AssigneeId, opt => opt.MapFrom(src => src.AssigneeId))
                  .ForMember(dst => dst.AssignerId, opt => opt.MapFrom(src => src.AssignerId))
                  .ForMember(dst => dst.ModifiedAt, opt => opt.MapFrom(src => src.ModifiedAt))
                  .ForMember(dst => dst.ModifiedBy, opt => opt.MapFrom(src => src.ModifiedBy))
                  ;
            });

            _mapper = config.CreateMapper();
        }

        public SAssignment MapCreateRequesttoAssignment(CreateAssignmentCommand request)
        {
            return _mapper.Map<CreateAssignmentCommand, SAssignment>(request);
        }

        public AssignmentDto MapAssignmentDto(SAssignment AssignmentModel)
        {
            return _mapper.Map<SAssignment, AssignmentDto>(AssignmentModel);
        }

        public SAssignment MapUpdateRequesttoAssignment(UpdateAssignmentCommand request)
        {
            return _mapper.Map<UpdateAssignmentCommand, SAssignment>(request);
        }
    }
}
