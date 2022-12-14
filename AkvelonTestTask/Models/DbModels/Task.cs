using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using AkvelonTestTask.Enums;

namespace AkvelonTestTask.Models.DbModels
{
    public class Task
    {
        [Key]
        [JsonIgnore]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public TaskStatuses Status { get; set; }
        public Guid ProjectId { get; set; }
        public string Description { get; set; }
        public Project Project { get; set; }
    }
}