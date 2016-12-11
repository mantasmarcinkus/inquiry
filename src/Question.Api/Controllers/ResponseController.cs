using Microsoft.AspNetCore.Mvc;
using Question.BL;
using Question.Api.Models;

namespace Question.Api.Controllers
{
    [Route("api/[controller]")]
    public class ResponseController
    {
        private readonly IResponseManager ResponseManager;
        private readonly InquiryContext Context;

        public ResponseController(IResponseManager responseManager, InquiryContext context)
        {
            ResponseManager = responseManager;
            Context = context;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]PostClass pc)
        {
            ResponseManager.PostResult(Context, pc.recipientId, pc.responseId);
        }
    }
}
