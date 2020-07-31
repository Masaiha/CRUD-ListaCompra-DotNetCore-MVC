using AutoMapper;
using Masanori.com.App.ViewModels;
using Masanori.com.Business.Models;

namespace Masanori.com.App.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Empresa, EmpresaViewComponent>().ReverseMap();
            CreateMap<Endereco, EnderecoViewComponent>().ReverseMap();
            CreateMap<Compra, CompraViewComponent>().ReverseMap();
            CreateMap<Produto, ProdutoViewComponent>().ReverseMap();
        }
    }
}
