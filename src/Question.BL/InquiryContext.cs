using Microsoft.EntityFrameworkCore;

namespace Question.BL
{
    public class InquiryContext : DbContext
    {
        public InquiryContext(DbContextOptions<InquiryContext> options)
            : base(options)
        {
        }

        ~InquiryContext()
        {

        }

        public DbSet<Inquiry> Inquiries { get; set; }

        public DbSet<Response> Responses { get; set; }

        public DbSet<Recipient> Recipients { get; set; }
    }
}
