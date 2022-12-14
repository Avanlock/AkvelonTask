using System;
using AkvelonTestTask.Enums;

namespace AkvelonTestTask.Models.DTO
{
    public class Project
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime CompletionDate { get; set; }
        public ProjectStatuses Status { get; set; }
        public int Priority { get; set; }
    }
}