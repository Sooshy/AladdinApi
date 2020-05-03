using Aladdin.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aladdin.Common.Interfaces
{
    public interface IFeedbackSaver
    {
        Task SaveFeedbacks(IEnumerable<Feedback> feedbacks);
        Task SaveExport(Export export);
    }
}
