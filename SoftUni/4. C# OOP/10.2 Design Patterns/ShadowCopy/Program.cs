
//string a = "3";

//string b = a;

//a = a + "4";

//Console.WriteLine(a);
//Console.WriteLine(b);


Person person1 = new Person("bortis", 18);
person1.Home = new Home("kusha");

Person person2 = person1.ShallowCopy();

person2.Name = "boreto";
person2.Age = 12;
person2.Home.Name = "123";

Console.WriteLine(person1);
Console.WriteLine(person2);

public class Person
{
    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }
    public string Name { get; set; }
    public int Age { get; set; }

    public Home Home { get; set; }

    // Method to perform shallow copy
    public Person ShallowCopy()
    {
        return (Person)MemberwiseClone();
    }

    public override string ToString()
    {
        return $"{Name}, {Age}, {Home.Name}";
    }
}
public class Home
{
    public Home(string name)
    {
        Name = name;
    }

    public string Name { get; set; }
}