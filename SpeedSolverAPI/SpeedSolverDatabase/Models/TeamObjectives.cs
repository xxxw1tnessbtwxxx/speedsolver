namespace SpeedSolverDatabase.Models
{
    public class TeamObjectives
    {
        public int TeamTaskId { get; set; }
        public int TeamId { get; set; }
        public int ObjectiveId { get; set; }

        public virtual Team Team { get; set; }
    }
}
