using System;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace DHJ.FileManagement.Applications
{
    public class ProcessHistory : Entity
    {
        public string ApplicationName { get; set; }

        public string StepName { get; set; }

        public DateTime ExecuteTime { get; set; }

        public ApprovedResult Result { get; set; }
    }
}