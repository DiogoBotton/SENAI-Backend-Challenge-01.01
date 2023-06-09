using SENAI_Backend_Challenge.ViewModels.User;

namespace SENAI_Backend_Challenge.ViewModels.Event
{
    public class EventViewModel
    {
        public string Name { get; set; }
        public int NumberParticipants { get; set; }
        public DateTime DateOfEvent { get; set; }
        public int HoursDuration { get; set; }
        public UserViewModel User { get; set; }
        public bool IsActive { get; set; }

        public EventViewModel(string name, int numberParticipants, DateTime dateOfEvent, int hoursDuration, UserViewModel user, bool isActive)
        {
            Name = name;
            NumberParticipants = numberParticipants;
            DateOfEvent = dateOfEvent;
            HoursDuration = hoursDuration;
            User = user;
            IsActive = isActive;
        }
    }
}
