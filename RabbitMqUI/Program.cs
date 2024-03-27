
using RabbitMQ.Client;
using System.Text;
using System.Threading.Channels;

string anahtar;

Console.WriteLine("Yapmak istediğiniz işlemi berlirtiniz");
Console.WriteLine("Mail servisi için 1");
Console.WriteLine("SMS sevis için 2");
Console.WriteLine("Yazınız");
int a = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Mesajınızı girinizz");
string mesaj = Convert.ToString(Console.ReadLine());

anahtar =Convert.ToString(a);
Mesaj(mesaj,anahtar);

static void Mesaj(string? mesaj, string anahtar)
{
    var factory = new ConnectionFactory();
    factory.Uri = new Uri("amqps://cbxmlocy:S38I2EJv1lZ0U2N4yu1YRD49zRMUbRkd@cow.rmq2.cloudamqp.com/cbxmlocy");
    using var connection = factory.CreateConnection();
    var channel = connection.CreateModel();


    channel.QueueDeclare(anahtar, true, false, false);//RabbitMQ gönderdiğimiz kuyruk ismi


    var body = Encoding.UTF8.GetBytes(mesaj);

    channel.BasicPublish(string.Empty, anahtar, null, body);//Verinin RabbitMQ’ye gönderildiği yer.
    Console.WriteLine("OKey");
} 
Console.ReadLine();