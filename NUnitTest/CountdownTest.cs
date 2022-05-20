using NUnit.Framework;
using OPD;

namespace NUnitTest
{
    public class CountdownTest
    {
        [Test]
        public void SubscribeOne()
        {
            Countdown timer = new Countdown();
            var subscriber = new Subscriber(timer, "subscriber");
            timer.Skip(1000, "event");
        }
        [Test]
        public void UnsubscribeOne()
        {
            Countdown timer = new Countdown();
            var subscriber = new Subscriber(timer, "subscriber");
            subscriber.Ubsubscribe();
            timer.Skip(1000, "event");
        }
        [Test]
        public void SubscribeOneFullCycle()
        {
            Countdown timer = new Countdown();
            var subscriber = new Subscriber(timer, "subscriber");
            timer.Skip(1000, "event_1");
            timer.Skip(1000, "event_2");
            subscriber.Ubsubscribe();
            timer.Skip(1000, "event_3");
        }
        [Test]
        public void SubscribeSeveral()
        {
            Countdown timer = new Countdown();
            Subscriber[] subscribers = {
                new Subscriber(timer, "subscriber_1"),
                new Subscriber(timer, "subscriber_2"),
                new Subscriber(timer, "subscriber_3"),
            };
            timer.Skip(1000, "event_1");
        }
        [Test]
        public void SubscribeSeveralFullCycle()
        {
            Countdown timer = new Countdown();
            Subscriber[] subscribers = {
                new Subscriber(timer, "subscriber_1"),
                new Subscriber(timer, "subscriber_2"),
                new Subscriber(timer, "subscriber_3"),
            };
            for (int i = 0; i < subscribers.Length; i++)
            {
                timer.Skip(1000, $"event_{i}");
                subscribers[i].Ubsubscribe();
            }
        }
    }
}