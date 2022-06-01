using AnimalsWebApiHW.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AnimalsWebApiHW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        public List<Animal> Animals { get; set; }

        public AnimalController()
        {
            Animals = new List<Animal>()
            {
                new Animal() { Name = "Dog", Age = 5},
                new Animal() { Name = "Cat", Age = 2},
                new Animal() { Name = "Giraffe", Age = 8},
                new Animal() { Name = "Horse", Age = 4},
                new Animal() { Name = "Fish", Age = 1}
            };
        }

        [Route("{name}")]
        public IActionResult GetAnimalByName(string name)
        {
            if (name.ToLower() == "giraffe")
            {
                return LocalRedirect("~/api/animal/smile");
            }

            foreach (var animal in Animals)
            {
                if (animal.Name.ToLower() == name.ToLower())
                {
                    return Ok(animal);
                }
            }
            return NotFound();
        }

        [Route("smile")]
        public IActionResult Smile()
        {
            return Ok("             :)\n\n\n         :)\n\n\n                   :)");
        }


        [Route("special/{name}")]
        public ActionResult<Animal> GetAnimalByName2(string name)
        {
            if (name.ToLower() == "giraffe")
            {
                return LocalRedirect("~/api/animal/smile");
            }

            foreach (var animal in Animals)
            {
                if (animal.Name.ToLower() == name.ToLower())
                {
                    return animal;
                }
            }
            return NotFound();
        }
    }
}
