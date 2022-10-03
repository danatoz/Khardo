using System.Text;
using System.Text.Json;
using RabbitMQ.Client;

namespace Tools.RabbitMq
{
    public class RabbitMqService : IRabbitMqService
    {
	    public void SendMessage(object obj)
	    {
		    var message = JsonSerializer.Serialize(obj);
		    SendMessage(message);
	    }

	    public void SendMessage(string message)
	    {
			//TODO вынести значения "localhost" и "QueueForParseExcel"
			// в файл конфигурации
			var factory = new ConnectionFactory() { HostName = "localhost" };
			using (var connection = factory.CreateConnection())
			using (var channel = connection.CreateModel())
			{
				channel.QueueDeclare(queue: "QueueForParseExcel",
					durable: false,
					exclusive: false,
					autoDelete: false,
					arguments: null);

				var body = Encoding.UTF8.GetBytes(message);

				channel.BasicPublish(exchange: "",
					routingKey: "QueueForParseExcel",
					basicProperties: null,
					body: body);
			}
		}
    }
}
