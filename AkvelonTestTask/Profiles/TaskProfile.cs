using AkvelonTestTask.Models.DbModels;
using AutoMapper;

namespace AkvelonTestTask.Profiles
{
    public class TaskProfile : Profile
    {
        public TaskProfile()
        {
            CreateMap<Task, Models.DTO.Task>().ReverseMap();
        }
    }
}