using Microsoft.AspNetCore.Mvc;

namespace APBD_LAB5;

[ApiController]
[Route("api/[controller]")]
public class AnimalsController : ControllerBase
{
    private static List<Animal> _animals = new List<Animal>();

    [HttpGet]
    public IActionResult GetAnimals()
    {
        return Ok(_animals);
    }

    [HttpGet("{id}")]
    public IActionResult GetAnimalById(int id)
    {
        var animal = _animals.Find(a => a.Id == id);
        if (animal == null)
        {
            return NotFound();
        }
        return Ok(animal);
    }

    [HttpPost]
    public IActionResult AddAnimal(Animal animal)
    {
        animal.Id = _animals.Count + 1;
        _animals.Add(animal);
        return CreatedAtAction(nameof(GetAnimalById), new { id = animal.Id }, animal);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateAnimal(int id, Animal updatedAnimal)
    {
        var index = _animals.FindIndex(a => a.Id == id);
        if (index == -1)
        {
            return NotFound();
        }
        updatedAnimal.Id = id;
        _animals[index] = updatedAnimal;
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteAnimal(int id)
    {
        var animal = _animals.Find(a => a.Id == id);
        if (animal == null)
        {
            return NotFound();
        }
        _animals.Remove(animal);
        return NoContent();
    }
}