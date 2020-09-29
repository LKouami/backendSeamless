using AutoMapper;
using Seamless.Domain.Commands.User;
using Seamless.Model.Dtos;
using Seamless.Model.Models;
using Seamless.Domain.Dxos.Common;

namespace Seamless.Domain.Dxos
{
    public class UserDxos : BaseDxos, IUserDxos
    {
        public UserDxos()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AUser, UserDto>()
                  .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                  .ForMember(dst => dst.Email, opt => opt.MapFrom(src => src.Email))
                  .ForMember(dst => dst.Status, opt => opt.MapFrom(src => src.Status))
                  .ForMember(dst => dst.Password, opt => opt.MapFrom(src => src.Password))
                  .ForMember(dst => dst.Token, opt => opt.MapFrom(src => src.Token))
                  .ForMember(dst => dst.ModifiedAt, opt => opt.MapFrom(src => src.ModifiedAt))
                  .ForMember(dst => dst.ModifiedBy, opt => opt.MapFrom(src => src.ModifiedBy))
                    ;

                cfg.CreateMap<CreateUserCommand, AUser>()
                  .ForMember(dst => dst.Email, opt => opt.MapFrom(src => src.Email))
                  .ForMember(dst => dst.Status, opt => opt.MapFrom(src => src.Status))
                  .ForMember(dst => dst.Password, opt => opt.MapFrom(src => src.Password))
                  .ForMember(dst => dst.Token, opt => opt.MapFrom(src => src.Token))
                  .ForMember(dst => dst.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
                  .ForMember(dst => dst.CreatedBy, opt => opt.MapFrom(src => src.CreatedBy))
                  .ForMember(dst => dst.ModifiedAt, opt => opt.MapFrom(src => src.CreatedAt))
                  .ForMember(dst => dst.ModifiedBy, opt => opt.MapFrom(src => src.CreatedBy))
                  ;


                cfg.CreateMap<UpdateUserCommand, AUser>()
                    .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                  .ForMember(dst => dst.Email, opt => opt.MapFrom(src => src.Email))
                  .ForMember(dst => dst.Status, opt => opt.MapFrom(src => src.Status))
                  .ForMember(dst => dst.Password, opt => opt.MapFrom(src => src.Password))
                  .ForMember(dst => dst.Token, opt => opt.MapFrom(src => src.Token))
                  .ForMember(dst => dst.ModifiedAt, opt => opt.MapFrom(src => src.ModifiedAt))
                  .ForMember(dst => dst.ModifiedBy, opt => opt.MapFrom(src => src.ModifiedBy))
                  ;
            });

            _mapper = config.CreateMapper();
        }

        public AUser MapCreateRequesttoUser(CreateUserCommand request)
        {
            return _mapper.Map<CreateUserCommand, AUser>(request);
        }

        public UserDto MapUserDto(AUser UserModel)
        {
            return _mapper.Map<AUser, UserDto>(UserModel);
        }

        public AUser MapUpdateRequesttoUser(UpdateUserCommand request)
        {
            return _mapper.Map<UpdateUserCommand, AUser>(request);
        }
    }
}
