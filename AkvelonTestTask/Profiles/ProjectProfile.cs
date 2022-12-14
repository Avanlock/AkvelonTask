using AkvelonTestTask.Models.DbModels;
using AutoMapper;

namespace AkvelonTestTask.Profiles
{
    public class ProjectProfile : Profile
    {
        public ProjectProfile()
        {
            CreateMap<Project, Models.DTO.Project>().ReverseMap();
        }

    }
}