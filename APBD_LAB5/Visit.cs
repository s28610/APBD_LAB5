namespace APBD_LAB5;

public class Visit
{
    public int Id { get; set; }
    public DateTime VisitDate { get; set; }
    public int AnimalId { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }


    public Visit(int id, DateTime visitDate, int animalId, string description, int price)
    {
        Id = id;
        VisitDate = visitDate;
        AnimalId = animalId;
        Description = description;
        Price = price;
    }
}