namespace BamanClub_PubSub
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start");
            var pubSub = new PubSubHandler();
            pubSub.Subscribe("topic1",  async (object data) =>
            {
                await Task.Delay(1000);
                Console.WriteLine($"{DateTime.Now.ToShortTimeString()}\tTopic 1 Sub1\t{data.ToString()}");
                
            });

            pubSub.Subscribe("topic2", async (object data) =>
            {
                await Task.Delay(3000);
                Console.WriteLine($"{DateTime.Now.ToShortTimeString()}\tTopic 2 Sub 1\t{data.ToString()}");
                
            });


            pubSub.Subscribe("topic1", async (object data) =>
            {
                await Task.Delay(5000);
                Console.WriteLine($"{DateTime.Now.ToShortTimeString()}\tTopic 1 Sub 2\t{data.ToString()}");
                
            });

            pubSub.Subscribe("topic2", async (object data) =>
            {
                await Task.Delay(4500);
                Console.WriteLine($"{DateTime.Now.ToShortTimeString()}\tTopic2 Sub 2\t{data.ToString()}");
                
            });


            pubSub.Publish("topic1", "Hello 1");
            pubSub.Publish("topic2", "Hello 2");


            Console.WriteLine("End");
            Console.ReadKey();
        }
    }
}
