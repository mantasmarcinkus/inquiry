using System;
using Microsoft.AspNetCore.Mvc;
using Question.BL;
using System.Net;

namespace Question.Api.Controllers
{
    [Route("api/[controller]")]
    public class InquiryController : Controller
    {
        private readonly IInquiryManager InquiryManager;
        private readonly InquiryContext Context;

        public InquiryController(IInquiryManager inquiryManager, InquiryContext context)
        {
            InquiryManager = inquiryManager;
            Context = context;
        }

        /// <summary>
        /// Test Query
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public Inquiry Get()
        {
            return InquiryManager.GetInquiry(Context, InquiryHelper.TestInquiry);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Inquiry Get(Guid id)
        {
            var result = InquiryManager.GetInquiry(Context, id);

            if (result == null) { Response.StatusCode = (int)HttpStatusCode.BadRequest; }

            return result;
        }

        // POST api/values
        [HttpPost]
        public bool Post([FromBody]Inquiry inquiry)
        {
            InquiryManager.CreateInquiry(Context, inquiry);

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="token">admin token</param>
        [Route("{token}/recycle")]
        [HttpGet]
        public void Recycle(int token)
        {
            InquiryManager.Recycle(Context);
        }
    }
}
