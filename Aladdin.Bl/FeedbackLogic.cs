using Aladdin.Common.Interfaces;
using Aladdin.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aladdin.Bl
{
    public class FeedbackLogic : IFeedbackLogic
    {
        private readonly IFeedbackSaver _feedbackSaver;

        public FeedbackLogic(IFeedbackSaver feedbackSaver)
        {
            _feedbackSaver = feedbackSaver;
        }
        public async Task HandleExport(IEnumerable<ExportWordInfo> exportWordInfos)
        {
            var time = DateTime.Now;
            var export = new Export()
            {
                SendTime = time,
                ExportedWords = exportWordInfos
            };
            await _feedbackSaver.SaveExport(export);
            var feedbacks = new List<Feedback>();
            foreach (var word in exportWordInfos)
            {
                feedbacks.Add(new Feedback()
                {
                    Word = word.Word,
                    WordExtension = word.WordExtension,
                    EditedWord = word.EditedWord,
                    ExtensionType = word.ExtensionType,
                    FeedbackType = FeedbackType.Like,
                    SendTime = time
                });
                if (word.EditedWord != null && word.EditedWord != "")
                {
                    feedbacks.Add(new Feedback()
                    {
                        Word = word.Word,
                        WordExtension = word.WordExtension,
                        EditedWord = word.EditedWord,
                        ExtensionType = word.ExtensionType,
                        FeedbackType = FeedbackType.Correction,
                        SendTime = time
                    });
                }
            }
            await SaveFeedbacks(feedbacks);
        }

        public async Task SaveFeedbacks(IEnumerable<Feedback> feedbacks)
        {
            var time = DateTime.Now;
            foreach (var feedback in feedbacks)
            {
                if (feedback.SendTime == null)
                {
                    feedback.SendTime = time;
                }
            }
            await _feedbackSaver.SaveFeedbacks(feedbacks);
        }
    }
}