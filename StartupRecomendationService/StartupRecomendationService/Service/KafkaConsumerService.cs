using Confluent.Kafka;
using Neo4jClient;
using Newtonsoft.Json.Linq;
using StartupRecomendationService.Models;
using System.Diagnostics;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace StartupRecomendationService.Service
{
    public class KafkaConsumerService: IHostedService
    {
        private readonly IGraphClient _client;
        private readonly string topic1 = "product";
       private readonly string topic2 = "investor";
        private readonly string groupId1 = "recomedation_group";
       // private readonly string groupId2 = "investor4_group";
        private readonly string bootstrapServers = "localhost:9092";

        public KafkaConsumerService(IGraphClient client)
        {
            _client = client;
            
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {

            Thread productThread = new Thread(ProductConsumer)
            {
                Name = "ProductThread"
            };

            Thread investorThread = new Thread(InvestorConsumer)
            {
                Name = "InvestorThread"
            };

            productThread.Start();
           investorThread.Start();

            return Task.CompletedTask;
        }
        private void ProductConsumer()
        {
            var config = new ConsumerConfig
            {
                GroupId = groupId1,
                BootstrapServers = bootstrapServers,
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            try
            {
                using (var consumerBuilder = new ConsumerBuilder
                <Ignore, string>(config).Build())
                {
                    consumerBuilder.Subscribe(topic1);
                    var cancelToken = new CancellationTokenSource();

                    try
                    {
                        do
                        {
                            var consumer = consumerBuilder.Consume
                               (cancelToken.Token);
                           // dynamic product1 = JObject.Parse(consumer.Message.Value);
                           
                             var product = JsonSerializer.Deserialize
                                          <Product>
                                   (consumer.Message.Value);
                           
                           // Product product = new Product();
                           // product.ProductId = product1.ProductId;
                           // Console.WriteLine($"Processing Product Id:{product.ProductId}");
                           // product.Title = product1.Title;
                           //// product.ImageFile = product1.ImageFile;
                           // //Console.WriteLine($"Processing Product Id:{product.ImageFile}");
                           // product.Category = product1.Category;
                           // product.Location = product1.Location;
                           // product.Stage = product1.Stage;
                           // product.SharePrice = product1.SharePrice;
                           // product.BusinessModel = product1.BusinessModel;
                           // product.Description = product1.Description;
                            //Console.WriteLine($"Product : {product.ProductId}");
                            _client.Cypher.Create("(p: Product $product)")
                                           .WithParam("product", product)
                                                 .ExecuteWithoutResultsAsync();
                            _client.Cypher.Match("(p:Product),(i:User)")
                             .Where((User i, Product p) => i.Category == product.Category && p.ProductId == product.ProductId)
                             .Create("(i)-[r:sameCategory]->(p)")
                             .ExecuteWithoutResultsAsync();
                            _client.Cypher.Match("(p:Product),(i:User)")
                              .Where((User i, Product p) => i.Location == product.Location && p.ProductId == product.ProductId)
                              .Create("(i)-[r:sameLocation]->(p)")
                              .ExecuteWithoutResultsAsync();
                            _client.Cypher.Match("(p:Product),(i:User)")
                             .Where((User i, Product p) => i.Stage == product.Stage && p.ProductId == product.ProductId)
                             .Create("(i)-[r:sameStage]->(p)")
                             .ExecuteWithoutResultsAsync();
                            _client.Cypher.Match("(p:Product),(i:User)")
                              .Where((User i, Product p) => i.Model == product.BusinessModel && p.ProductId == product.ProductId)
                              .Create("(i)-[r:sameModel]->(p)")
                              .ExecuteWithoutResultsAsync();
                            _client.Cypher.Match("(p:Product),(i:User)")
                             .Where((User i, Product p) => i.Category == product.Category && p.ProductId == product.ProductId)
                             .Create("(i)-[r:sameCategory]->(p)")
                             .ExecuteWithoutResultsAsync();
                            _client.Cypher.Match("(p:Product),(i:User)")
                              .Where((User i, Product p) => i.Location == product.Location && p.ProductId == product.ProductId)
                              .Create("(i)-[r:sameLocation]->(p)")
                              .ExecuteWithoutResultsAsync();
                            _client.Cypher.Match("(p:Product),(i:User)")
                             .Where((User i, Product p) => i.Stage == product.Stage && p.ProductId == product.ProductId)
                             .Create("(i)-[r:sameStage]->(p)")
                             .ExecuteWithoutResultsAsync();

                            Console.WriteLine("Received order request");
                            Console.WriteLine($"Processing Product Id:{product.ProductId}");
                            Debug.WriteLine($"Processing Product Id:{product.ProductId}");
                        }while (true);
                    }
                    catch (OperationCanceledException)
                    {
                        consumerBuilder.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
        private void InvestorConsumer()
        {
            var config = new ConsumerConfig
            {
                GroupId = groupId1,
                BootstrapServers = bootstrapServers,
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            try
            {
                using (var consumerBuilder = new ConsumerBuilder
                <Ignore, string>(config).Build())
                {
                    consumerBuilder.Subscribe(topic2);
                    var cancelToken = new CancellationTokenSource();

                    try
                    {
                        do
                        {
                            var consumer = consumerBuilder.Consume
                               (cancelToken.Token);
                            //  dynamic investor1 = JObject.Parse(consumer.Message.Value);
                            var investor1 = JsonSerializer.Deserialize
                                <User>
                                    (consumer.Message.Value);
                            User investor = new User();
                            investor.Id = investor1.Id;
                            investor.Name = investor1.Name;
                            investor.Category = investor1.Category;
                            investor.Location = investor1.Location;
                            investor.Stage = investor1.Stage;
                            investor.Model = investor1.Model;
                            _client.Cypher.Create("(i: User $investor)")
                                           .WithParam("investor", investor)
                                                 .ExecuteWithoutResultsAsync();

                            Console.WriteLine($"Processing Investor Id:{investor.Id}");

                            _client.Cypher.Match("(p:Product),(i:User)")
                               .Where((User i, Product p) => i.Id == investor.Id && p.Category == investor.Category)
                               .Create("(i)-[r:sameCategory]->(p)")
                               .ExecuteWithoutResultsAsync();
                            _client.Cypher.Match("(p:Product),(i:User)")
                              .Where((User i, Product p) => i.Id == investor.Id && p.Location == investor.Location)
                              .Create("(i)-[r:sameLocation]->(p)")
                              .ExecuteWithoutResultsAsync();
                            _client.Cypher.Match("(p:Product),(i:User)")
                             .Where((User i, Product p) => i.Id == investor.Id && p.Stage == investor.Stage)
                             .Create("(i)-[r:sameStage]->(p)")
                             .ExecuteWithoutResultsAsync();
                            _client.Cypher.Match("(p:Product),(i:User)")
                              .Where((User i, Product p) => i.Id == investor.Id && p.BusinessModel == investor.Model)
                              .Create("(i)-[r:sameModel]->(p)")
                              .ExecuteWithoutResultsAsync();
                            _client.Cypher.Match("(p:Product),(i:User)")
                               .Where((User i, Product p) => i.Id == investor.Id && p.Category == investor.Category)
                               .Create("(i)-[r:sameCategory]->(p)")
                               .ExecuteWithoutResultsAsync();
                            _client.Cypher.Match("(p:Product),(i:User)")
                              .Where((User i, Product p) => i.Id == investor.Id && p.Location == investor.Location)
                              .Create("(i)-[r:sameLocation]->(p)")
                              .ExecuteWithoutResultsAsync();
                            _client.Cypher.Match("(p:Product),(i:User)")
                            .Where((User i, Product p) => i.Id == investor.Id && p.Stage == investor.Stage)
                            .Create("(i)-[r:sameStage]->(p)")
                            .ExecuteWithoutResultsAsync();

                            Console.WriteLine("Received order request");
                            Console.WriteLine($"Processing Investor Id:{investor.Id}");
                            Debug.WriteLine($"Processing Investor Id:{ investor.Id}");
                        }while(true);    
                    }
                    catch (OperationCanceledException)
                    {
                        consumerBuilder.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}

