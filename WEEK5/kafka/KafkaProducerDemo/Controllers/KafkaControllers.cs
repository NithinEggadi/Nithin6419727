using Microsoft.AspNetCore.Mvc;
using Confluent.Kafka;
using KafkaProducerDemo.Models;
using Microsoft.Extensions.Configuration;

namespace KafkaProducerDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KafkaController : ControllerBase
    {
        private readonly IConfiguration _config;

        public KafkaController(IConfiguration config)
        {
            _config = config;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendMessage([FromBody] MessageRequest request)
        {
            var bootstrapServers = _config["Kafka:BootstrapServers"];
            var topic = _config["Kafka:Topic"];

            var config = new ProducerConfig { BootstrapServers = bootstrapServers };

            using var producer = new ProducerBuilder<Null, string>(config).Build();

            try
            {
                var result = await producer.ProduceAsync(topic, new Message<Null, string> { Value = request.Message });
                return Ok($"✅ Message sent to {result.TopicPartitionOffset}");
            }
            catch (ProduceException<Null, string> ex)
            {
                return StatusCode(500, $"❌ Kafka Error: {ex.Error.Reason}");
            }
        }
    }
}