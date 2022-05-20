using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPD
{
    public class Countdown
    {
        public delegate void EventCallback(string message);

        Dictionary<string, EventCallback> events;
        public Countdown()
        {
            events = new Dictionary<string, EventCallback>();
        }
        public void AddEvent(string name, EventCallback callback)
        {
            events.Add(name, callback);
        }
        public void RemoveEvent(string name)
        {
            events.Remove(name);
        }
        public void Skip(int ms, string message)
        {
            Thread.Sleep(ms);
            foreach (var eventCallback in events)
            {
                eventCallback.Value(message);
            }
        }
    }

    public class Subscriber
    {
        public Subscriber(Countdown cd, string name)
        {
            SubscribeName = name;
            CdObject = cd;
            cd.AddEvent(name, (message) => Display(message));
        }

        public void Ubsubscribe()
        {
            CdObject.RemoveEvent(SubscribeName);
        }

        private void Display(string eventText)
        {
            Console.WriteLine("Событие: {0} \n   Подписчик: {1}", eventText, SubscribeName);
        }
        private Countdown CdObject;
        private string SubscribeName;
    }
}
