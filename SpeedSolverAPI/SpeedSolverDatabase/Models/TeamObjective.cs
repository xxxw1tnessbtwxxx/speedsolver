using System.ComponentModel.DataAnnotations;

namespace SpeedSolverDatabase.Models
{
    public class TeamObjective
    {
        public int TeamTaskId { get; set; }
        public int TeamId { get; set; }
        public int ObjectiveId { get; set; }
        public DateTime? Deadline { get; set; } = DateTime.Now.AddDays(7);
        public DateTime? CompletedAt { get; set; }
        public virtual Team? Team { get; set; }
        
    }
}
