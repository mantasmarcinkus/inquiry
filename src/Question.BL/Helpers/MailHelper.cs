using System;
using System.Linq;
using System.Text;

namespace Question.BL
{
    public static class MailHelper
    {
        public static void SendEmail(Inquiry inquiry)
        {
            var to = inquiry.AuthorEmail;
            var title = $"Inquiry Completed: {inquiry.Value}";
            var sb = new StringBuilder();
            var nl = Environment.NewLine;

            // TO DO: rework this part to GroupBy, Select and Join (too lazy at this moment)
            var count = inquiry.Responses.Count();
            foreach(var response in inquiry.Responses)
            {
                sb.Append($"{response.Value} - {Math.Round((float)(inquiry.Recipients.Count(x => x.ResponseId == response.Id)/count), 2, MidpointRounding.AwayFromZero)*100}% {nl}");
            }

            var body = $"Good day, {inquiry.AuthorName}! {nl}The results to your questions are{nl} {sb.ToString()}";
        }
    }
}
