
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

var factory = new ConnectionFactory();
factory.Uri = new Uri("amqps://cbxmlocy:S38I2EJv1lZ0U2N4yu1YRD49zRMUbRkd@cow.rmq2.cloudamqp.com/cbxmlocy");


using var connection = factory.CreateConnection();
var channel = connection.CreateModel();

channel.QueueDeclare("1", true, false, false);//kullandığımız kuyruk sistemi ismi 
var consumer = new EventingBasicConsumer(channel);
channel.BasicConsume("1", true, consumer);
consumer.Received += Consumer_Received;
Console.ReadLine();

void Consumer_Received(object? sender, BasicDeliverEventArgs e)
{
    Console.WriteLine("Gelen mesaj:" + Encoding.UTF8.GetString(e.Body.ToArray()));
}