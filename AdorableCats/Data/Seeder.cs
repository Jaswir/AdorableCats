using AdorableCats.Models;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace AdorableCats.Data
{
    public class Seeder
    {
        public async void Seed(CatDbContext catDbContext)
        {
            string cat_imagesJSON = System.IO.File.ReadAllText(@"Data\cat_images_without_dupes.json");
            List<CatImage> catImagesList = JsonConvert.DeserializeObject<List<CatImage>>(cat_imagesJSON);

            //Seeds CatImage Data incase table is empty
            var catImagesEmpty = catDbContext.Cat_Images.Any();
            if (catImagesEmpty != null) return;

            await catDbContext.AddRangeAsync(
                catImagesList);

            await catDbContext.SaveChangesAsync();

    
        }

    }
}
