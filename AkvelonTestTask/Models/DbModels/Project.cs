using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using AkvelonTestTask.Enums;

namespace AkvelonTestTask.Models.DbModels
{
    public class Project
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime CompletionDate { get; set; }
        public ProjectStatuses Status { get; set; }
        public int Priority { get; set; }
        public IEnumerable<Task> Tasks { get; set; }
    }
}