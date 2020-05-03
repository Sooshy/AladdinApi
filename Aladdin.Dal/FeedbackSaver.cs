using Aladdin.Common.Interfaces;
using Aladdin.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aladdin.Dal
{
    public class FeedbackSaver : IFeedbackSaver
    {
        public async Task SaveFeedbacks(IEnumerable<Feedback> feedbacks)
        {
            await Task.Delay(1000);
            Console.WriteLine("Saved Feedback");
        }

        public async Task SaveExport(Export export)
        {
            await Task.Delay(1000);
            Console.WriteLine("Saved Export");
        }
    }
}