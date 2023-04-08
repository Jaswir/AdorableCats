using AdorableCats.Data;
using AdorableCats.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

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
        //Return a random images
        [HttpGet("random")]
        public async Task<ActionResult<CatImage>> GetRandom()
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

        //api/v1/images/random10
        //Return 10 random images
        [HttpGet("random10")]
        
        public async Task<ActionResult<IEnumerable<CatImage>>> GetRandom10()
        {
            Random rand = new Random();
            int skipper = rand.Next(0, CatDbContext.Cat_Images.Count());

            return await CatDbContext
                .Cat_Images
                .OrderBy(id => (""))
                .Skip(skipper)
                .Take(10)
                .ToListAsync();
        }

    }
}
