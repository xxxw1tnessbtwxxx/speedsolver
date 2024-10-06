namespace SpeedSolverDatabase.Models
{
    public class Team
    {
        public int TeamId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int CreatorId { get; set; }
        public DateTime CreationDate { get; set; }

        public virtual User Creator { get; set; }
        public virtual List<TeamObjectives> Objectives { get; set; }
    }
}
