using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplePubSub
{
    public delegate Task SubscribeHandler<T>(T data);
    public interface IPubSubHandler<T>
    {
        void Subscribe(string topic, SubscribeHandler<T> handler);
        void Unsubscribe(string topic, SubscribeHandler<T> hadnler);
        void Publish(string topic, T value);
    }
}
