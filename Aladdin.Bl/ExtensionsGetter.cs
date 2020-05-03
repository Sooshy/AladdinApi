using Aladdin.Common.Interfaces;
using Aladdin.Common.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aladdin.Bl
{
    public class ExtensionGetter : IExtensionGetter
    {
        private readonly IList<Source> _sources;
        private readonly ISourceAccessor _sourceAccessor;

        public ExtensionGetter(IConfiguration configuration, ISourceAccessor sourceAccessor)
        {
            _sources = configuration.GetSection("Sources").Get<IList<Source>>();
            _sourceAccessor = sourceAccessor;
        }
        public async Task<IList<WordExtension>> GetExtensions(IList<string> words)
        {
            var sourceResults = new List<SourceResult>();
            foreach (var source in _sources)
            {
                var sourceResult = await _sourceAccessor.GetExtensionsFromSource(source, words);
                sourceResults.Add(sourceResult);
            }
            var wordExtensions = new List<WordExtension>();
            foreach (var word in words)
            {
                var results = sourceResults.ToDictionary(result => result.SourceType, result => result.Results[word]);
                var wordExtension = new WordExtension
                {
                    Word = word,
                    Results = results.Where(item => item.Value != null && item.Value.Count != 0).ToDictionary(x => x.Key, x => x.Value)
                };
                wordExtensions.Add(wordExtension);
            }
            return wordExtensions;
        }
    }
}
