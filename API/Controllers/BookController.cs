using API.Service;
using Core;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {

        private readonly ILogger<BooksController> _logger;
        private readonly IBookService _bookService;
        public BooksController(ILogger<BooksController> logger, IBookService bookService)
        {
            _logger = logger;
            _bookService = bookService;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpPost(Name = "Publish")]
        public IActionResult Publish()
        {
            _bookService.Publish(Guid.Parse("a9d80280-5472-4573-a1b4-e881449bfeae"));
            return Ok();
        }

        [HttpPut(Name = "AddChapter")]
        public IActionResult AddChapter()
        {
            _bookService.AddChapter(Guid.Parse("a9d80280-5472-4573-a1b4-e881449bfeae"), new ViewModels.ChapterViewModel());
            return Ok();
        }
    }
}
