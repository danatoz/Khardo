using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Common.Enums;

namespace UI.Services
{
	public class RabbitMqListener : BackgroundService
	{
		private readonly IConnection _connection;
		private readonly IModel _chanel;

		public RabbitMqListener()
		{
			var factory = new ConnectionFactory { HostName = "localhost" };
			_connection = factory.CreateConnection();
			_chanel = _connection.CreateModel();
			_chanel.QueueDeclare(queue: nameof(QueueName.MyQueue), durable: false, exclusive: false, autoDelete: false, arguments: null);
		}

		protected override Task ExecuteAsync(CancellationToken stoppingToken)
		{
			stoppingToken.ThrowIfCancellationRequested();
			var consumer = new EventingBasicConsumer(_chanel);
			consumer.Received += (ch, ea) =>
			{
				var content = Encoding.UTF8.GetString(ea.Body.ToArray());
				//TODO обрабатываем полученное сообщение
				Debug.WriteLine($"Получено сообщение {content}");
				_chanel.BasicAck(ea.DeliveryTag, false);
			};

			_chanel.BasicConsume(nameof(QueueName.MyQueue), false, consumer);

			return Task.CompletedTask;
		}

		public override void Dispose()
		{
			_chanel.Close();
			_connection.Close();
			base.Dispose();
		}
	}
}
