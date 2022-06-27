// See https://aka.ms/new-console-template for more information
using System.Data.Odbc;

string connectionString = "Driver={Microsoft Access Driver (*.mdb)}; Dbq=C:\\TestDB.mdb; Uid = ; Pwd =; ";

var query = $@"SELECT * from TABLE1;";

OdbcCommand command = new(query);

using (OdbcConnection connection = new(connectionString))
{
    command.Connection = connection;
    connection.Open();
    List<Person> persons = new();

    using (var reader = command.ExecuteReader())
    {
        while (reader.Read())
        {
            var person = new Person
            {
                Id = reader.GetInt32(0),
                FirstName = reader.GetString(1)
            };

            persons.Add(person);
        }
    };

    foreach (Person person in persons)
    {
        Console.WriteLine($"Name: {person.FirstName}, Id: {person.Id}");
    }

    Console.ReadLine();
}

class Person
{
    public int Id { get; set; }

    public string? FirstName { get; set; }
}

