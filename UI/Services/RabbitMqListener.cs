using System;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Common.Enums;
using Microsoft.Extensions.Logging;

namespace UI.Services
{
	public class RabbitMqListener : BackgroundService
	{
		private readonly IConnection _connection;
		private readonly IModel _chanel;
		private readonly ILogger<RabbitMqListener> _logger;

		public RabbitMqListener(ILogger<RabbitMqListener> logger)
		{
			var factory = new ConnectionFactory { HostName = "localhost" };
			try
			{
				_logger = logger;
				_connection = factory.CreateConnection();
				_chanel = _connection.CreateModel();
				_chanel.QueueDeclare(queue: nameof(QueueName.MyQueue), durable: false, exclusive: false,
					autoDelete: false, arguments: null);
			}
			catch (RabbitMQ.Client.Exceptions.BrokerUnreachableException ex)
			{
				_logger.LogError("Проверьте RabbitMQ, возможно не запущено приложение или проблемы с подключением");
				_logger.LogError($"{ex.Message}");
				_logger.LogError($"{ex.StackTrace}");
			}
			catch (Exception ex)
			{
				_logger.LogError($"{ex.Message}");
				_logger.LogError($"{ex.StackTrace}");
			}
		}

		protected override Task ExecuteAsync(CancellationToken stoppingToken)
		{
			try
			{
				stoppingToken.ThrowIfCancellationRequested();
				var consumer = new EventingBasicConsumer(_chanel);
				consumer.Received += (ch, ea) =>
				{
					var content = Encoding.UTF8.GetString(ea.Body.ToArray());
					//TODO обрабатываем полученное сообщение
					Debug.WriteLine($"Получено сообщение {content}");
					_chanel?.BasicAck(ea.DeliveryTag, false);
				};

				_chanel?.BasicConsume(nameof(QueueName.MyQueue), false, consumer);
			}
			catch (Exception ex)
			{
				_logger.LogError($"{ex.Message}");
				_logger.LogError($"{ex.StackTrace}");
			}


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
