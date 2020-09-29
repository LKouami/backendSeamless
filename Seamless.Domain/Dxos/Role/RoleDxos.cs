using AutoMapper;
using Seamless.Model.Dtos;
using Seamless.Model;
using Seamless.Model.Models;
using Seamless.Domain.Dxos.Common;

namespace Seamless.Domain.Dxos
{
    public class RoleDxos : BaseDxos, IRoleDxos
    {

        public RoleDxos()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ARole, RoleDto>()
                    .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Name))
                    ;   
                    
                //cfg.CreateMap<CreateRoleCommand, ARole>()
                //    .ForMember(dst => dst.Id, opt => opt.MapFrom(src => 0))
                //    .ForMember(dst => dst.Email, opt => opt.MapFrom(src => src.Email));


                //cfg.CreateMap<UpdateRoleCommand, ARole>()
                //    .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                //    .ForMember(dst => dst.Email, opt => opt.MapFrom(src => src.Email));
            });

            _mapper = config.CreateMapper();
        }

        //public ARole MapCreateRequesttoRole(CreateRoleCommand request)
        //{
        //    return _mapper.Map<CreateRoleCommand, ARole>(request);
        //}

        public RoleDto MapRoleDto(ARole employee)
        {
            return _mapper.Map<ARole, RoleDto>(employee);
        }

        //public ARole MapUpdateRequesttoRole(UpdateRoleCommand request)
        //{
        //    return _mapper.Map<UpdateRoleCommand, ARole>(request);
        //}
    }
}