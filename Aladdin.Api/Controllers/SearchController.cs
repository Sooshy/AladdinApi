using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aladdin.Common;
using Aladdin.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Aladdin.Api.Controllers
{
    public class SearchController : Controller
    {
        private readonly IExtensionGetter _extensionGetter;

        public SearchController(IExtensionGetter extensionGetter)
        {
            _extensionGetter = extensionGetter;
        }

        [Route("api/[controller]/Search")]
        [HttpPost]
        public async Task<IActionResult> SearchWordExtensionsAsync([FromBody]IList<string> words)
        {
            return Ok(await _extensionGetter.GetExtensions(words));
        }
    }
}