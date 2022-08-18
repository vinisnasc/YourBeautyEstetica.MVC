using AutoMapper;
using YB.Domain.Models;
using YourBeautyEstetica.MVC.Models;

namespace YourBeautyEstetica.MVC.Configs.AutoMapperConfig
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Cliente, ClienteDTO>().ReverseMap();
            CreateMap<Funcionario, FuncionarioDTO>().ReverseMap();
            CreateMap<Agendamento, AgendamentoDTO>().ReverseMap();
            CreateMap<Servico, ServicoDTO>().ReverseMap();
        }
    }
}