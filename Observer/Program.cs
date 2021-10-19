using System;
using System.Collections.Generic;

namespace Observer
{
    public class Message
    {
        public string MessageContent { get; set; }
        public override string ToString()
        {
            return $"{MessageContent}";
        }
    }

    public interface ISubscriber
    {
        public void Update(Message  message);
    }

    
    public interface Subject
    {
        public void Attach(ISubscriber subscriber);
        public void Detach(ISubscriber subscriber);
        public void NotifyUpdate(Message message);
    }


    public class MessagePublisher : Subject
    {
        public List<ISubscriber> subscribers { get; set; } = new List<ISubscriber>();
        public void Attach(ISubscriber subscriber)
        {
            subscribers.Add(subscriber);
        }

        public void Detach(ISubscriber subscriber)
        {
            subscribers.Remove(subscriber);
        }

        public void NotifyUpdate(Message message)
        {
            foreach (var item in subscribers)
            {
                item.Update(message);
            }
        }
    }


    public class MessageSubscriberOne : ISubscriber
    {
        public void Update(Message message)
        {
            Console.WriteLine($"MessageSubscriberOne :{message}");
        }
    }

    public class MessageSubscriberTwo : ISubscriber
    {
        public void Update(Message message)
        {
            Console.WriteLine($"MessageSubscriberTwo :{message}");
        }
    }

    public class MessageSubscriberThree : ISubscriber
    {
        public void Update(Message message)
        {
            Console.WriteLine($"MessageSubscriberThree :{message}");
        }
    }





    class Program
    {
        static void Main(string[] args)
        {
            MessageSubscriberOne s1 = new MessageSubscriberOne();
            MessageSubscriberTwo s2 = new MessageSubscriberTwo();
            MessageSubscriberThree s3 = new MessageSubscriberThree();

            MessagePublisher publisher = new MessagePublisher();

            publisher.Attach(s1);
            publisher.Attach(s2);

            publisher.NotifyUpdate(new Message { MessageContent = "First Message" });

            publisher.Detach(s1);
            publisher.Attach(s3);

            publisher.NotifyUpdate(new Message { MessageContent = "Second Message" });
        }
    }
}
