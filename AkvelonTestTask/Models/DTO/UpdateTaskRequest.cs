using System;
using System.Text.Json.Serialization;
using AkvelonTestTask.Enums;

namespace AkvelonTestTask.Models.DTO
{
    public class UpdateTaskRequest
    {
        public string Name { get; set; }
        public TaskStatuses Status { get; set; }
        public string Description { get; set; }
    }
}