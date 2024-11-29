using System.Collections.Concurrent;

namespace SimplePubSub
{
    public class MemoryPubSubHandler<T> : IPubSubHandler<T>
    {
        private readonly ConcurrentDictionary<string, List<SubscribeHandler<T>>> _inMemoryDic =
            new();

        public void Publish(string topic, T value)
        {
            if (!_inMemoryDic.ContainsKey(topic)) return;
            var items = _inMemoryDic[topic];
            Parallel.ForEach((items), (item) =>
            {
                item.Invoke(value);
            });
        }

        public void Subscribe(string topic, SubscribeHandler<T> handler)
        {
            var items = _inMemoryDic.GetOrAdd(topic, new List<SubscribeHandler<T>>());
            items.Add(handler);
        }

        public void Unsubscribe(string topic, SubscribeHandler<T> hadnler)
        {
            if (!_inMemoryDic.ContainsKey(topic)) return;
            _inMemoryDic[topic].Remove(hadnler);
        }
    }
}
