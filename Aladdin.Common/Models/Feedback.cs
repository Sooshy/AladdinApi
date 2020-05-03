using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aladdin.Common.Models
{
    public class Feedback : ExportWordInfo
    {
        public DateTime? SendTime { get; set; }
        public FeedbackType FeedbackType { get; set; }
    }
}