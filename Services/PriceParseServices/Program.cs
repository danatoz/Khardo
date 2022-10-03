using Newtonsoft;
using PriceParseServices;
using RabbitMQ.Client.Events;


var factory = new ConnectionFactory() { HostName = "localhost" };
//var factory = new ConnectionFactory() { Uri = new Uri("строка_подключения_облако") };
using (var connection = factory.CreateConnection())
using (var channel = connection.CreateModel())
{
	channel.QueueDeclare(queue: "QueueForParseExcel",
		durable: false,
		exclusive: false,
		autoDelete: false,
		arguments: null);

	var consumer = new EventingBasicConsumer(channel);
	consumer.Received += async (model, ea) =>
	{
		var body = ea.Body.ToArray();
		var message = Encoding.UTF8.GetString(body);
		var result = Newtonsoft.Json.JsonConvert.DeserializeObject<MessageModel>(message);
		await ExcelParse.Parse(result);
	};
	channel.BasicConsume(queue: "QueueForParseExcel",
		autoAck: true,
		consumer: consumer);

	Console.WriteLine(" Press [enter] to exit.");
	Console.ReadLine();
}
