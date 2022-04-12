using ControllerSamples.Data;
using ControllerSamples.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ControllerSamples.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagingSortingController : ControllerBase
    {
        private readonly MovieDbContext _dbContext;
        public PagingSortingController(MovieDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("PagingListWithPageParametersObject")]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovies(int pageNumer = 1, int pageSize = 3)
        {
            return await _dbContext.Movie.OrderBy(e => e.Title)
                                         .Skip((pageNumer - 1) * pageSize)
                                         .Take(pageSize).ToListAsync();
        }

    }
}
