using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Question.BL
{
    public static class InquiryHelper
    {
        public static Guid TestInquiry = Guid.Parse("056a878f-3293-460a-ba26-337dd16768a2");

        public static List<Inquiry> MockedInquiries = new List<Inquiry>()
        {
            new Inquiry()
            {
                Id = TestInquiry,
                Value = "What language the front end should be written in?" ,
                AuthorName = "Mantas M",
                AuthorEmail = "mantas@mantas.lt",
                DateCreated = DateTime.UtcNow.AddHours(-2),
                Responses = new List<Response> ()
                {
                    new Response()
                    {
                        Id = Guid.NewGuid(),
                        Value = "React"
                    },
                    new Response()
                    {
                        Id = Guid.NewGuid(),
                        Value = "Angular"
                    },
                    new Response()
                    {
                        Id = Guid.NewGuid(),
                        Value = "Pure HTML + JS"
                    }
                },
                Recipients = new List<Recipient> ()
                {
                    new Recipient()
                    {
                        Id = Guid.NewGuid(),
                        Email = "m@m.lt"
                    },
                    new Recipient()
                    {
                        Id = Guid.NewGuid(),
                        Email = "z@z.lt"
                    }
                }

            }
        };

        public static void AddTestData(DbContext context)
        {
            context.Add(MockedInquiries.FirstOrDefault());
            context.SaveChanges();
        }

        public static async void RecycleInquiry(InquiryContext context, Guid recipientId)
        {
            var inquiryId = context.Recipients.FirstOrDefault(x => x.Id == recipientId).InquiryId;

            // If there are no Recipients to give response lets finish the workflow
            if (context.Inquiries.FirstOrDefault(x => x.Id == inquiryId).Recipients.Count(x => x.ResponseId == Guid.NewGuid()) == 0)
            {
                RecycleInquiry(context, context.Inquiries.Include(x => x.Recipients).Include(x => x.Responses).FirstOrDefault(x => x.Id == inquiryId));
            }
        }

        public static async void RecycleInquiry(InquiryContext context, Inquiry inquiry)
        {
            MailHelper.SendEmail(inquiry);
            // TO DO: For testing purposes I won't delete inquiries, but when in production they will be removed when the lifetime is done.
#if !DEBUG
            context.Remove(inquiry);
#else
            inquiry.Done = true;
#endif
        }
    }
}
