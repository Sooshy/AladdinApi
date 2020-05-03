using System;
using System.Collections.Generic;
using System.Text;

namespace Aladdin.Common.Models
{
    public class Export
    {
        public DateTime? SendTime { get; set; }
        public IEnumerable<ExportWordInfo> ExportedWords { get; set; }
    }
}
