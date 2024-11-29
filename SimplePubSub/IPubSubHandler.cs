using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplePubSub
{
    public delegate Task SubscribeHandler<in D>(D data);
    
    public interface IPubSubHandler<D>
    {
        void Subscribe(string topic, SubscribeHandler<D> handler);
        void Unsubscribe(string topic, SubscribeHandler<D> hadnler);
        void Publish(string topic, D value);
    }
}
