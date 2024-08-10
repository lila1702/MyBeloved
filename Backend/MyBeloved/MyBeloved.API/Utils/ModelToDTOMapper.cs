using AutoMapper;

namespace MyBeloved.API.Utils
{
    public class ModelToDTOMapper : Profile
    {
        public ModelToDTOMapper()
        {
            CreateMap<Models.Account, DTOs.AccountDTO>();
            CreateMap<Models.Notebook, DTOs.NotebookDTO>()
                .ForMember(dest => dest.Categories, opt => opt.MapFrom(src => src.NotebookCategories.Select(nc => nc.Category)));
            CreateMap<Models.Category, DTOs.CategoryDTO>();
            CreateMap<Models.Page, DTOs.PageDTO>();
            CreateMap<Models.Partner, DTOs.PartnerDTO>();
        }
    }
}
