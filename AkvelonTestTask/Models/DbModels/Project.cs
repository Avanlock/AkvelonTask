using System;
using AkvelonTestTask.Models.Enums;

namespace AkvelonTestTask.Models.DbModels
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime CompletionDate { get; set; }
        public ProjectStatuses Status { get; set; }
        public int Priority { get; set; }
    }
}