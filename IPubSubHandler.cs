using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BamanClub_PubSub
{
    public delegate Task SubscribeHandler(object value);
    public interface IPubSubHandler
    {
        void Subscribe(string topic, SubscribeHandler handler);
        void Unsubscribe(string topic, SubscribeHandler hadnler);
        void Publish(string topic, object value);
    }
}
