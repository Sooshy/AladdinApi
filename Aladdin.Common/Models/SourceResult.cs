using System;
using System.Collections.Generic;
using System.Text;

namespace Aladdin.Common.Models
{
    public class SourceResult
    {
        public SourceResult(string sourceType, IDictionary<string, IList<string>> results)
        {
            SourceType = sourceType;
            Results = results;
        }

        public string SourceType { get; set; }
        public IDictionary<string, IList<string>> Results { get; set; }
    }
}
