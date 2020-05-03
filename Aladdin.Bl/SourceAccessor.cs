using Aladdin.Common.Interfaces;
using Aladdin.Common.Models;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aladdin.Bl
{
    public class SourceAccessor : ISourceAccessor
    {
        public async Task<SourceResult> GetExtensionsFromSource(Source source, IList<string> words)
        {
            var result = await source.ApiAddress.PostJsonAsync(words).ReceiveJson<IDictionary<string, IList<string>>>();
            return new SourceResult(source.Type, result);
        }
    }
}