using System.Xml.Serialization;

Person person = new Person { Name = "John", Age = 30 };

SerializeToXml(person, "person.xml");

Person deserializedPerson = DeserializeFromXml<Person>("person.xml");

Console.WriteLine($"Deserialized Person - Name: {deserializedPerson.Name}, Age: {deserializedPerson.Age}");

static void SerializeToXml(object obj, string filename)
{
    XmlSerializer serializer = new XmlSerializer(obj.GetType());

    using (TextWriter writer = new StreamWriter(filename))
    {
        serializer.Serialize(writer, obj);
    }
}

static T DeserializeFromXml<T>(string filename)
{
    XmlSerializer serializer = new XmlSerializer(typeof(T));

    using (TextReader reader = new StreamReader(filename))
    {
        return (T)serializer.Deserialize(reader);
    }
}