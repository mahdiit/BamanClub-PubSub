using System.Collections.Concurrent;

namespace BamanClub_PubSub
{
    public class PubSubHandler : IPubSubHandler
    {
        private readonly ConcurrentDictionary<string, List<SubscribeHandler>> _inMemoryDic =
            new ConcurrentDictionary<string, List<SubscribeHandler>>();

        public void Publish(string topic, object value)
        {
            if (!_inMemoryDic.ContainsKey(topic)) return;
            var items = _inMemoryDic[topic];
            Parallel.ForEach((items), (item) =>
            {
                item.Invoke(value);
            });
        }

        public void Subscribe(string topic, SubscribeHandler handler)
        {
            var items = _inMemoryDic.GetOrAdd(topic, new List<SubscribeHandler>());
            items.Add(handler);
        }

        public void Unsubscribe(string topic, SubscribeHandler hadnler)
        {
            if (!_inMemoryDic.ContainsKey(topic)) return;
            _inMemoryDic[topic].Remove(hadnler);
        }
    }
}
