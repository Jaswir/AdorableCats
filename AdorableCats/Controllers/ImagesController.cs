using AdorableCats.Data;
using AdorableCats.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdorableCats.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        public CatDbContext CatDbContext { get; }

        public ImagesController(CatDbContext catDbContext)
        {
            CatDbContext = catDbContext;
        }

        //api/v1/images/random
        [HttpGet("random")]
        public async Task<ActionResult<CatImage>> Get()
        {
            Random rand = new Random();
            int skipper = rand.Next(0, CatDbContext.Cat_Images.Count());

            var randomCatImages = await CatDbContext
                .Cat_Images
                .OrderBy(id => (""))
                .Skip(skipper)
                .Take(1).ToListAsync();

            return randomCatImages[0];
        }

        [HttpGet("random10")]
        public async Task<ActionResult<IEnumerable<CatImage>>> Get()
        {
            Random rand = new Random();
            int skipper = rand.Next(0, CatDbContext.Cat_Images.Count());

            //var catImage = await CatDbContext.Cat_Images.ToListAsync();
            //return catImage;

            return await CatDbContext
                .Cat_Images
                .OrderBy(id => (""))
                .Skip(skipper)
                .Take(10)
                .ToListAsync();
        }

    }
}
