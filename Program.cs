using SimplePubSub;

namespace BamanClub_PubSub
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start");
            var pubSub = new MemoryPubSubHandler<int>();            
            const int cards = 50;

            pubSub.Subscribe("CardsHandler", async (int param) =>{

            for(int i = 0; i < param; i++){
                await Task.Delay(200 * i);

                pubSub.Publish("CardsStatus", i);
            }
            });

            pubSub.Subscribe("CardsStatus",  (int param) => {
                Console.WriteLine($"{DateTime.Now.ToShortTimeString()}\t{param}\t{(Convert.ToDecimal( param)/ Convert.ToDecimal(cards)) * 100}");
                return Task.CompletedTask;
            });
            Console.WriteLine("End, press any key to exit....");
            Console.WriteLine();
            pubSub.Publish("CardsHandler", cards);
            Console.ReadKey();
        }
    }
}
