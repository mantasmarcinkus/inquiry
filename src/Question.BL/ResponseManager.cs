using System;
using System.Linq;

namespace Question.BL
{
    public class ResponseManager : IResponseManager
    {
        public void PostResult(InquiryContext context, Guid recipientId, Guid responseId)
        {
            var response = context.Recipients.FirstOrDefault(x => x.Id == recipientId);
            response.ResponseId = responseId;
            response.Visited = true;
           
            context.SaveChanges();

            InquiryHelper.RecycleInquiry(context, recipientId);
        }
    }

    public interface IResponseManager
    {
        void PostResult(InquiryContext context, Guid recipientId, Guid responseId);
    }
}
