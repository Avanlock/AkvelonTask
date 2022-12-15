using System;
using System.Text.Json.Serialization;
using AkvelonTestTask.Enums;

namespace AkvelonTestTask.Models.DTO
{
    public class Task
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public TaskStatuses Status { get; set; }
        public Guid ProjectId { get; set; }
        public string Description { get; set; }
        [JsonIgnore]
        public Project Project { get; set; }
    }
}