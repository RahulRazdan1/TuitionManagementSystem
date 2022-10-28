using AutoMapper;

namespace Application.TMS
{
    public class RegisterProfileMapping : Profile
    {
        public RegisterProfileMapping()
        {
            CreateMap<Register.Input, UserDetail>();
        }
    }
}
