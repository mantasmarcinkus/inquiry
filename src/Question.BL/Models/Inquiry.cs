using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Question.BL
{

    public class BaseQuery : BaseModel
    {
        public string Value { get; set; }
    }

    public class Inquiry : BaseQuery
    {
        public DateTime DateCreated { get; set; }

        public string AuthorEmail { get; set; }

        public string AuthorName { get; set; }

        public bool Done { get; set; } = false;

        public int Lifetime { get; set; } = 1;

        public List<Response> Responses { get; set; } = new List<Response>();

        public List<Recipient> Recipients { get; set; } = new List<Recipient>();
    }

    public class Response : BaseQuery
    {
    }
}
