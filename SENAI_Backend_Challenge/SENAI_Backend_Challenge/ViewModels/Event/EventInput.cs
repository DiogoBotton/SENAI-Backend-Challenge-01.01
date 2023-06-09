using System.ComponentModel.DataAnnotations;

namespace SENAI_Backend_Challenge.ViewModels.Event
{
    public class EventInput
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int NumberParticipants { get; set; }
        [Required]
        public DateTime DateOfEvent { get; set; }
        [Required]
        public int HoursDuration { get; set; }
        [Required]
        public long UserId { get; set; }
    }
}
