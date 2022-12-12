using System.Threading.Tasks;
using AkvelonTestTask.Models.Enums;

namespace AkvelonTestTask.Models.DbModels
{
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public TaskStatuses Status { get; set; }
    }
}