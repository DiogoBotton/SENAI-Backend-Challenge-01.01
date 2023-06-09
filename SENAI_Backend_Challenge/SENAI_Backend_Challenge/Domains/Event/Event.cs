using SENAI_Backend_Challenge.SeedWork;

namespace SENAI_Backend_Challenge.Domains.Event
{
    public class Event : AbstractDomain
    {
        public string Name { get; set; }
        public int NumberParticipants { get; set; }
        public DateTime DateOfEvent { get; set; }
        public int HoursDuration { get; set; }
        public long UserId { get; set; }
        public bool IsActive { get; set; }

        public Event(string name, int numberParticipants, DateTime dateOfEvent, int hoursDuration, long userId)
        {
            Name = name;
            NumberParticipants = numberParticipants;
            DateOfEvent = dateOfEvent;
            HoursDuration = hoursDuration;
            UserId = userId;
            IsActive = true;
        }

        public void UpdateEvent(string name, int numberParticipants, DateTime dateOfEvent, int hoursDuration)
        {
            Name = name;
            NumberParticipants = numberParticipants;
            DateOfEvent = dateOfEvent;
            HoursDuration = hoursDuration;
        }

        public void DesactiveEvent()
        {
            IsActive = false;
        }
    }
}
