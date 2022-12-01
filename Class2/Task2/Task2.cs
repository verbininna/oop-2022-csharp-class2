namespace Task2
{
    abstract class Animal
    {
        internal virtual string message { get; set; } = "";
    
        internal void Talk()
        {
           Console.WriteLine(this.message);
        }
    }

    internal class Cat:Animal
    {
        internal override string message { get; set; } = "Кошка мяучит 'мяу-мяу'";
    }

    internal class Dog : Animal
    {
        internal override string message { get; set; } = "Собака гавкает 'гав-гав-гав'";
    }

    internal class Goose : Animal
    {
        internal override string message { get; set; } = "Гусь гогочет 'га-га-га'";

    }

    internal class Task2
    {
        internal static void Main(string[] args)
        {
            RunTest();
        }

        internal static void RunTest()
        {
            foreach (var animal in new List<Animal> {new Cat(), new Dog(), new Goose()})
            {
                animal.Talk();
            }
        }
    }
}