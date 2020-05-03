using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aladdin.Common.Interfaces;
using Aladdin.Common.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Aladdin.Api.Controllers
{
    public class FeedbackController : Controller
    {
        private readonly IFeedbackLogic _feedbackLogic;

        public FeedbackController(IFeedbackLogic feedbackLogic)
        {
            _feedbackLogic = feedbackLogic;
        }

        [Route("api/[controller]/SendFeedback")]
        [HttpPost]
        public async Task<IActionResult> SendFeedback([FromBody]IEnumerable<Feedback> feedbacks)
        {
            await _feedbackLogic.SaveFeedbacks(feedbacks);
            return Ok();
        }

        [Route("api/[controller]/SendExport")]
        [HttpPost]
        public async Task<IActionResult> SendExport([FromBody]IEnumerable<ExportWordInfo> exportWordInfos)
        {
            await _feedbackLogic.HandleExport(exportWordInfos);
            return Ok();
        }
    }
}