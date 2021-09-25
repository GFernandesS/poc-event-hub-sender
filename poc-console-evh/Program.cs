using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Producer;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace poc_console_evh
{
    class Program
    {
        private static readonly string connectionString = "Endpoint=sb://evhns-poc-article.servicebus.windows.net/;SharedAccessKeyName=sas-access;SharedAccessKey=pM2vUmmsCIycmG47Bh8KTt7JE6BJ1DQF0DwM/758Ge4=;EntityPath=evh-poc-1";

        private static readonly string topicName = "evh-poc-1";
        static async Task Main()
        {
            await using var producerClient = new EventHubProducerClient(connectionString, topicName);

            using (var eventBatch = await producerClient.CreateBatchAsync())
            {
                var events = GetEvents();

                foreach (var eventData in events)
                    eventBatch.TryAdd(eventData);

                await producerClient.SendAsync(eventBatch);
            }

            WriteLine("Eventos enviados com sucesso");
        }

        static IEnumerable<EventData> GetEvents()
        {
            var users = new List<POCOUser> { new(), new() };

            foreach(var user in users)
                yield return new EventData(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(user)));
        }
    }
}
