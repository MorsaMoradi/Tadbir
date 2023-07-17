

using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.JavaScript;
using Tadbir.Domain.Cofiguration;

Console.WriteLine("Enter count for generate data = ");
var count = Convert.ToInt32(Console.ReadLine());

var channel = ConfigQueue();
for (int i = 0; i < count; i++)
{
    var obj = JsonConvert.SerializeObject(RandName());
    var message = System.Text.Encoding.UTF8.GetBytes(obj);
    channel.BasicPublish(QueueConst.PersonExchange, "", false, body: message);
    Console.WriteLine($"Person { i+1 } Created =>"+ obj);
    Thread.Sleep(1000);
}


static Person RandName()
{
    string[] lastNames = new string[] { "Moradi", "Ahmadi", "Khajavi", "Rad","Hosseini", "Hasani", "Modiri", "Khaghani", "Khalilzadeh", "Jahani", "Mohseni", "Amarlou", "Shokri", "Tohi", "Shafiei", "Khani"
    ,"Ramezani","Jamalo","Zamani","Golzar","Sepehri","Bahmani","Moghimi","Maleki"};
    string[] firstNames = new string[] { "Ali", "Hasan", "Maryam", "Morteza", "Jafar", "Sara", "Zahra", "Saeid", "Malihe", "Rezvan", "Reza", "Behnaz", "Fatemeh", "Pedram", "Sepehr", "Javad", "Mostafa", "Mohammad"
    ,"Arash","Keyivan","Sanaz","Afsaneh","Hadi","Mehdi","Leyila"};

    Random rand = new Random(DateTime.Now.Second);
    return new Person(firstNames[rand.Next(0, firstNames.Length - 1)],
     lastNames[rand.Next(0, lastNames.Length - 1)], rand.Next(10, 70));
}



static IModel ConfigQueue()

{
    var settings = new RabbitMqConfiguration();
    ConnectionFactory factory = new ConnectionFactory();
    factory.UserName =settings.Username;
    factory.Password = settings.Password;

    IConnection conn = factory.CreateConnection();
    var channel = conn.CreateModel();
    channel.QueueDeclare(QueueConst.PersonQueue,true,false,false);
    channel.ExchangeDeclare(QueueConst.PersonExchange, ExchangeType.Direct);
    channel.QueueBind(QueueConst.PersonQueue, QueueConst.PersonExchange, "");
    return channel;

}

public class Person
{
    public Person(string firstName, string lastName, int age)
    {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
    }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
}