namespace SpeedSolverDatabase.Models;

public class Objective
{
    public int ObjectiveId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public int CreatorId { get; set; }
    public virtual User? Creator { get; set; }
}