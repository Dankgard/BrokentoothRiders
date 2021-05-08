
namespace Tracker
{
    public abstract class Event
    {
        public string Event_type { get; set; }
        public abstract void ToJson(string path);
    }
}
