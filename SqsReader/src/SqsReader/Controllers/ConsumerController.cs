using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SqsReader.Services;

namespace SqsReader.Controllers
{
    [Route("api/[controller]")]
    public class ConsumerController : Controller
    {
        private readonly ISqsConsumerService _sqsConsumerService;

        public ConsumerController(ISqsConsumerService sqsConsumerService)
        {
            _sqsConsumerService = sqsConsumerService;
        }

        [HttpPost]
        [Route("start")]
        public IActionResult Start()
        {
            _sqsConsumerService.StartConsuming();
            return StatusCode((int)HttpStatusCode.OK);
        }

        [HttpPost]
        [Route("stop")]
        public IActionResult Stop()
        {
            _sqsConsumerService.StopConsuming();
            return StatusCode((int)HttpStatusCode.OK);
        }

        [HttpPost]
        [Route("reprocess")]
        public IActionResult Reprocess()
        {
            _sqsConsumerService.ReprocessMessages();
            return StatusCode((int)HttpStatusCode.OK);
        }

        [HttpGet]
        [Route("status")]
        public async Task<IActionResult> Status()
        {
            var status = await _sqsConsumerService.GetStatus();
            return StatusCode((int)HttpStatusCode.OK, status);
        }
    }
}