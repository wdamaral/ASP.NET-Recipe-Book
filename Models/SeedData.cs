using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wagner_DAmaral_Assignment01.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices
                .GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();
            if (!context.Recipes.Any())
            {
                context.Recipes.AddRange(
                    new Recipe
                    {
                        PictureUrl = "https://res.cloudinary.com/hellofresh/image/upload/f_auto,fl_lossy,q_auto/v1/hellofresh_s3/image/farce-a-la-saucisse-et-aux-pommes-7a8deb53.jpg",
                        RecipeName = "Turkey Burrito Bowl",
                        Description = "Tasty turkey takes center stage with cilantro-lime rice as its co-star.",
                        Ingredients = "250 g Mild Italian Sausage, uncased - 1 unit Gala Apple, - ¼ cup Dried Cranberries, - 56 g Red Onion, chopped, - 10 g Sage, - 56 g Celery, sliced, - 1 unit Ciabatta Bun, - 340 g Sweet Potato, - 10 g Thyme, - 2 unit Chicken Broth Concentrate, - 1 tsp Cornstarch",
                        PrepareMode = "Preheat the oven to 425°F (to roast sweet potatoes and celery ). Start prepping when the oven " +
                "comes up to temperature! Wash and dry all produce.* Peel and cut the sweet potato into 1/2-inch cubes. " +
                "On a parchment-lined baking sheet, toss the sweet potatoes and celery with 1 tbsp oil (dbl for 4 ppl). " +
                "Season with salt and pepper. Roast in the middle of the oven, stirring halfway through cooking, until " +
                "golden-brown and tender, 18-20 min.\n\nMeanwhile, core, then cut the apple(s) into 1/4-inch pieces. " +
                "Finaly chop sage. Strip 1 tbsp of thyme leaves off the stem (dbl for 4 ppl). Cut ciabatta into 1/2-inch cubes. " +
                "Heat a small pot over medium-low. When pot is hot, add 1 tbsp butter (dbl for 4 ppl), thyme, cranberries and " +
                "half the sage. Swirl until fragrant, 1 min. Transfer cranberry mixture to a large bowl, then add the cubed " +
                "bread. Toss to combine and set aside.\n\nHeat a large oven-proof pan over medium-high heat. When the pan is hot," +
                " add 1 tbsp oil (dbl for 4 ppl), then the onions and apples. Cook, stirring occasionally, until the onions and " +
                "apples soften, 3-4 min. Add the sausage. Cook, breaking up the sausage into smaller pieces, until no pink " +
                "remains, 3-5 min. (TIP: Cook to a minimum internal temp. of 71°C/160°F.**)\n\nReturn the small pot to the stove " +
                "over medium-low heat. Combine the cornstarch with 1/2 cup water (dbl for 4 ppl). Add 1 tbsp butter " +
                "(dbl for 4 ppl), broth concentrates, remaining sage and the cornstarch mixture to the pot. " +
                "Whisk continuously until slightly thickened, 2-3 min. Set aside.\n\nAdd the sweet potatoes and celery to the " +
                "sausage mixture. Stir to combine. Spread the bread topping over the sausage mixture. Turn on the oven broiler. " +
                "Transfer the pan to the middle of the oven. Broil until the bread becomes toasted and golden brown, 2-3 min. " +
                "(TIP: Keep an eye on your bread so that it does not burn!)\n\nDivide the sausage, apple, and sweet potato bake " +
                "between plates. Pour over the sage gravy.",
                        TimeToPrepare = 30
                    },
            new Recipe
            {
                PictureUrl = "https://az858194.vo.msecnd.net/cdn/media/data/default/recipe-large/recipe_meatloaf_monster_with_gory_tomato_sauce_safeway.ashx",
                RecipeName = "Meatloaf Monster with Gory Tomato Sauce",
                Description = "Meatloaf Monster with Gory Tomato Sauce",
                Ingredients = "2 small onions, - 2 lb (1 kg) extra lean ground beef, - 1 cup (250 mL) breadcrumbs, - 1 egg, beaten, - 2 cups (500 mL) tomato sauce, divided, - 1 cup (250 mL) BBQ sauce, - 2 tbsp (30 mL) olive oil, - 2 tbsp (30 mL) Worcestershire sauce, - 1/2 tsp (2 mL) each salt and pepper, - 4 carrot or celery sticks, - 1 stuffed green olive, halved, - 1 cup (250 mL) tortilla chips (triangular shape)",
                PrepareMode = "Preheat oven to 190°C (375°F). Line a baking sheet with parchment paper. Coarsely grate 1 1/2 onions; cut six 1/2-in. (1-cm) triangles (for teeth) from the remaining onion; set aside. In bowl, mix together ground beef, breadcrumbs, egg, grated onion, 1/4 cup (60 mL) tomato sauce, 1/4 cup (60 mL) BBQ sauce, oil, Worcestershire sauce, 2 tbsp (30 mL) water, salt and pepper. Place meat mixture on lined baking sheet. Shape into an oval loaf, about 9 in. (23 cm) long and 5 in. (12 cm) across at its widest. The loaf should be almost as high as it is wide. At one end of loaf, use fingers to make two indents to hold olive halves for eyes (don’t add olive halves until after baking). Insert onion triangles in a row along “mouth” to resemble craggy teeth.Bake 30 min. Brush with remaining BBQ sauce and bake another 20 min. until golden brown and instant-read thermometer inserted in centre registers 74°C (165°F). Let rest 15 min.; transfer to serving platter.Meanwhile, bring remaining tomato sauce in small saucepan to a simmer over medium heat.Arrange olive halves in eye indents. Place carrot or celery sticks at sides of loaf for “legs”. Insert 2 rows of tortilla chips along the top of the loaf as a dinosaur-like spiky back. Serve slices with Gory Tomato Sauce on the side.",
                TimeToPrepare = 75
            },
            new Recipe
            {
                PictureUrl = "https://az858194.vo.msecnd.net/cdn/media/data/default/recipe-large/recipe_spooky_eyeball_donuts_safeway.ashx",
                RecipeName = "Spooky Eyeball Donuts",
                Description = "Spooky Eyeball Donuts",
                Ingredients = "1 small tube black gel icing, - 1 small tube red gel icing, - 12 Compliments Mini Sugar Donuts , - 6 Swedish berry candies, - 6 mini licorice allsorts (round ones)",
                PrepareMode = "Pipe black gel icing on 6 donuts to resemble black “blood veins” in spooky eyeballs. Pipe red gel icing on the remaining 6 donuts to resemble red “blood veins” in spooky bloodshot eyeballs.  Place berry candies (flat-side up) as “irises” in the centre of the 6 donuts with black gel veins. Pipe a black gel dot in the centre of the candies for pupils.  Place a licorice candy in the centre of the 6 red gel decorated donuts.",
                TimeToPrepare = 15
            }
                );
                context.SaveChanges();
            }
        }
    }
}
