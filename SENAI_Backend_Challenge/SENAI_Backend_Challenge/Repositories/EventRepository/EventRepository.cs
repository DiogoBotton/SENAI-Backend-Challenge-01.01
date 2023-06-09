using SENAI_Backend_Challenge.Contexts;
using SENAI_Backend_Challenge.Domains.Event;
using SENAI_Backend_Challenge.Domains.Event.Interfaces;
using SENAI_Backend_Challenge.SeedWork;

namespace SENAI_Backend_Challenge.Repositories.EventRepository
{
    public class EventRepository : BaseRepository<Event>, IEventRepository
    {
        public EventRepository(SenaiContext ctx) : base(ctx)
        {
        }
    }
}
