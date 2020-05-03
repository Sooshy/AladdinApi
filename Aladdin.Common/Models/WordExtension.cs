using System.Collections.Generic;

namespace Aladdin.Common.Models
{
    public class WordExtension
    {
        public string Word { get; set; }
        public IDictionary<string, IList<string>> Results { get; set; }
    }
}