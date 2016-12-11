using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Question.BL
{
    public interface IInquiryManager
    {
        Inquiry GetInquiry(InquiryContext context, Guid id);

        bool CreateInquiry(InquiryContext context, Inquiry inquiry);

        void Recycle(InquiryContext context);
    }


    public class InquiryManager : IInquiryManager
    {
        public Inquiry GetInquiry(InquiryContext context, Guid id)
        {
            if (context.Recipients.FirstOrDefault(x => x.Id == id).ResponseId == Guid.Empty)
            {
                return context.Inquiries.Include(x => x.Recipients).Include(x => x.Responses).FirstOrDefault(x => x.Id == id);
            }

            return null;
        }

        public bool CreateInquiry(InquiryContext context, Inquiry inquiry)
        {
            inquiry.DateCreated = DateTime.UtcNow;
            context.Add(inquiry);
            context.SaveChanges();

            return true;
        }

        public void Recycle(InquiryContext context)
        {
            var inquiries = context.Inquiries.Include(x => x.Recipients).Include(x => x.Responses).Where(x => !x.Done && x.DateCreated.AddHours(x.Lifetime) <= DateTime.UtcNow);
            foreach (var inquiry in inquiries)
            {
                InquiryHelper.RecycleInquiry(context, inquiry);
            }

            context.SaveChanges();
        }

        
    }
}
