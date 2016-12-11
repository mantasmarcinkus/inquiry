using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Question.BL
{
    public class Recipient : BaseModel
    {
        public string Email { get; set; }

        public Guid ResponseId { get; set; } = Guid.Empty;

        [ForeignKey("ResponseId")]
        public Response Response { get; set; }

        public Guid InquiryId { get; set; }

        [ForeignKey("InquiryId")]
        public Inquiry Inquiry { get; set; }

        public bool Visited { get; set; } = false;
    }
}
