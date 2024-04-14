using Microsoft.AspNetCore.Mvc;

namespace APBD_LAB5;

[ApiController]
[Route("api/[controller]")]
public class VisitsController : ControllerBase
{
    private static List<Visit> _visits = new List<Visit>();

    [HttpGet("{animalId}")]
    public IActionResult GetVisitsByAnimalId(int animalId)
    {
        var visits = _visits.FindAll(v => v.AnimalId == animalId);
        return Ok(visits);
    }

    [HttpPost]
    public IActionResult AddVisit(Visit visit)
    {
        visit.Id = _visits.Count + 1;
        _visits.Add(visit);
        return CreatedAtAction(nameof(GetVisitsByAnimalId), new { animalId = visit.AnimalId }, visit);
    }
}