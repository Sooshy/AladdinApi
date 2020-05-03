using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Aladdin.Common.Models
{
    public enum FeedbackType
    {
        [EnumMember(Value = "Like")]
        Like,
        [EnumMember(Value = "Correction")]
        Correction
    }
}