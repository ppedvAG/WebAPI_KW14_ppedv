using ControllerSamples.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControllerSamples.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoController : ControllerBase
    {
        private readonly IVideoService videoService;

        public VideoController(IVideoService videoService)
        {
            this.videoService = videoService;
        }

        [HttpGet("{name}")]
        public async Task<ActionResult> Index (string name)
        {
            if (string.IsNullOrEmpty(name))
                return BadRequest();

            Stream stream = await videoService.GetVideoByName(name);

            return new FileStreamResult(stream, "video/mp4");
        }
    }
}
