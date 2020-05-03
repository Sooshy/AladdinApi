using Aladdin.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aladdin.Common.Interfaces
{
    public interface IFeedbackLogic
    {
        Task HandleExport(IEnumerable<ExportWordInfo> exportWordInfos);
        Task SaveFeedbacks(IEnumerable<Feedback> feedbacks);
    }
}
