using Microsoft.AspNetCore.Mvc;
using Confluent.Kafka;

namespace KafkaConsumerDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConsumerController : ControllerBase
    {
        [HttpGet("consume")]
        public IActionResult ConsumeMessage()
        {
            var config = new ConsumerConfig
            {
                BootstrapServers = "localhost:9092",
                GroupId = "dotnet-consumer-group",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            using var consumer = new ConsumerBuilder<Ignore, string>(config).Build();
            consumer.Subscribe("chat-topic");

            var timeout = TimeSpan.FromSeconds(5);

            try
            {
                var result = consumer.Consume(timeout);

                if (result != null)
                {
                    return Ok($"✅ Received message: {result.Message.Value}");
                }

                return NotFound("❌ No message received (timeout).");
            }
            catch (ConsumeException ex)
            {
                return StatusCode(500, $"Kafka consume error: {ex.Error.Reason}");
            }
            finally
            {
                consumer.Close();
            }
        }
    }
}