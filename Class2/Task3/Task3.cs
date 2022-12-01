using System.Collections.Generic;

namespace Task3
{
    abstract class Creature
    {
    }

    class Human : Creature
    {
        internal string Greeting() => "Привет, я человек!";
    }

    class Dog : Creature
    {
        internal string Bark() => "Гав!";
    }

    class Alien : Creature
    {
        internal string Command() => "Ты меня не видишь";
    }

    public class Task3
    {
        internal static void PrintMessageFrom(Creature creature)
        {
            if (creature is Human) Console.WriteLine(((Human)creature).Greeting());
            else if (creature is Dog) Console.WriteLine(((Dog)creature).Bark());
            else if (creature is Alien) Console.WriteLine(((Alien)creature).Command());
        }

        static List<Dog> FindDogs(List<Creature> creatures) => new List<Dog>(creatures.Where((Creature creature) => (creature is Dog)).Select((Creature creature) => (Dog)creature));

        public static void Main(string[] args)
        {
            RunTest();
        }

        internal static void RunTest()
        {
            var creatures = new List<Creature> { new Alien(), new Dog(), new Human(), new Dog() };
            Console.WriteLine("Все сообщения:");

            foreach (var creature in creatures)
            {
                PrintMessageFrom(creature);
            }

            Console.WriteLine();
            Console.WriteLine("Сообщения только от собак:");
            foreach (var dog in FindDogs(creatures))
            {
                Console.WriteLine(dog.Bark());
            }
        }
    }
}