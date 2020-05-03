using Aladdin.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aladdin.Common.Interfaces
{
    public interface ISourceAccessor
    {
        Task<SourceResult> GetExtensionsFromSource(Source source, IList<string> words);
    }
}