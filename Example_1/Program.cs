using System;

// Создать класс Person(«Человек»), описать поля «Фамилия», «Отчество», «Дата рождения», «Пол», «Профессия». Описать перечисление «Профессия».
namespace Example_1
{
    class Program
    {
        static void Main(string[] args)
        {
            //  Объект - экземпляр класса Person
            Person person = new Person("Иванов", "Иван", "Иванович");

            //  Вывод в консоль всех свойства объекта
            Console.Write("Фамилия: ");
            Console.WriteLine(person.LastName);
            Console.Write("Имя: ");
            Console.WriteLine(person.FirstName);
            Console.Write("Отчество: ");
            Console.WriteLine(person.Patronymic);

            Person person1 = new Person("Сидоров", "", "Иванович", Profession.Manager, DateTime.Now);

            Console.ReadLine();
        }

    }

    // Класс Person
    public class Person
    {
        //  Поля: имя, фамилия, отчество
        public string FirstName;
        public string LastName;
        public string Patronymic;
        public Profession Prof;
        public DateTime BirthDate;
        public static string EnterPriseName;
        //  Конструкторы
        public Person(string lastName, string firstName, string patronymic) : this(lastName, firstName, patronymic, Profession.Manager, new DateTime(1970, 12, 12))
        {
        }
        public Person(string lastName, string firstName, string patronymic, Profession prof, DateTime dateBirth)
        {
            FirstName = firstName;
            LastName = lastName;
            Patronymic = patronymic;
            Prof = prof;
            BirthDate = dateBirth;
            Person.EnterPriseName = "ИТ";
        }
    }
    public enum Profession
    {
        Accounter,
        Manager,
        Programmer
    }
}
