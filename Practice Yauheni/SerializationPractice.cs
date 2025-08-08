using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Xml.Serialization;

namespace Yauheni;

// Сериализация нужна для сохранения состояния чего либо (например, игра)
// Для сериализации классов необходимы аттрибуты
public class SerializationPractice
{
    public void SerializationPracticeMain()
    {
        var groups = new List<Group>();
        var students = new List<Student>();

        for (int i = 0; i < 10; i++)
        {
            groups.Add(new Group(i, $"Группа: {i}"));
        }

        for (int i = 0; i < 300; i++)
        {
            var student = new Student(Guid.NewGuid().ToString().Substring(0, 5), i % 100)
            {
                Group = groups[i % 9]
            };

            students.Add(student);
        }

        // XML сериализатор
        var xmlFormatter = new XmlSerializer(typeof(List<Group>));
        // Запись в файл
        using (var file = new FileStream("group.xml", FileMode.Create))
        {
            xmlFormatter.Serialize(file, groups);
            Console.WriteLine("Сериализация xml выполнена успешно!");
        }

        // Чтение из xml файлы
        using (var file = new FileStream("group.xml", FileMode.OpenOrCreate))
        {
            if (xmlFormatter.Deserialize(file) is List<Group> newGroups)
            {
                foreach (var group in newGroups)
                {
                    Console.WriteLine($"Xml Deserialize group: {group}");
                }
            }
        }

        // XML сериализатор
        var jsonFormatter = new DataContractJsonSerializer(typeof(List<Student>));
        // Запись в файл
        using (var file = new FileStream("students.json", FileMode.Create))
        {
            jsonFormatter.WriteObject(file, students);
            Console.WriteLine("Сериализация json выполнена успешно!");
        }

        // Чтение из json файлы
        using (var file = new FileStream("students.json", FileMode.OpenOrCreate))
        {
            if (jsonFormatter.ReadObject(file) is List<Student> newStudents)
            {
                foreach (var student in newStudents)
                {
                    Console.WriteLine($"Json Deserialize student: {student}");
                }
            }
        }
    }
}

// Аттрибут для сериализации XML
[Serializable]
public class Group
{
    [NonSerialized] // Аттрибут для исключения сериализации
    private readonly Random rnd = new();

    public int Number { get; set; }
    public string Name { get; set; }

    public Group() { }

    public Group(int number, string name)
    {
        // Проверка входных параметров
        // ...

        Number = number;
        Name = name;
    }

    public override string ToString()
    {
        return Number.ToString();
    }
}

// Аттрибут для сериализации JSON
[DataContract]
public class Student
{
    [DataMember] 
    public string Name { get; set; }
    [DataMember] 
    public int Age { get; set; }
    [DataMember] 
    public Group Group { get; set; }

    public Student(string name, int age)
    {
        // Проверка входных параметров
        // ...

        Name = name;
        Age = age;
    }

    public override string ToString()
    {
        return Name;
    }
}