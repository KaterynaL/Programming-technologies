using System;

// Реализовать свойства в классе Person («Человек»), описать  поля  «Фамилия», «Отчество», «Дата рождения», «Пол», «Профессия». 
// Добавить статическое свойство класса «Предприятие». Длина введенного значения не должна превышать 25 символов. Если длина превышает указанное количество, то обрезать строку

namespace Example_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //  Создать объект - экземпляр класса Person
            Person myPers = new Person("ИВАНОВ", "ПЕТР", "пЕтРОВИЧ");
            Console.WriteLine("Имя: {0} \nОтчество: {1} \nФамилия: {2}", myPers.FirstName, myPers.Patronymic, myPers.LastName);

            // Вывести в консоль все свойства объекта

            Console.WriteLine();
            Console.ReadLine();
        }

    }


    public class Person
    {
        // Сделать поля, видимыми только внутри класса
        private string _firstName;
        private string _lastName;
        private string _patronymic;
        // Добавить свойства "Фамилия", "Имя", "Отчество"
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = ConvertString(value); }
        }
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = ConvertString(value); }
        }
        public string Patronymic
        {
            get { return _patronymic; }
            set { _patronymic = ConvertString(value); }
        }
        // Вместо общедоступных полей "Профессия", "Дата Рождения" добавить автосвойства (доступные только для чтения)
        public Profession Prof
        { get; private set; }
        public DateTime BirthDate
        { get; private set; }

        private static string _enterPriseName;
        public static string EnterPriseName
        {
            get { return _enterPriseName; }
            private set
            {
                if (value.Length > 25)
                {
                    _enterPriseName = value.Substring(0, 25);
                }
                else
                {
                    _enterPriseName = value;
                }
            }
        }

        // Установить значения свойствам
        public Person(string lastName, string firstName, string patronymic)
            : this(lastName, firstName, patronymic, Profession.Manager, new DateTime(1970, 12, 12))
        {
        }
        public Person(string lastName, string firstName, string patronymic, Profession prof, DateTime dateBirth)
        {
            FirstName = firstName;
            LastName = lastName;
            Patronymic = patronymic;
            Prof = prof;
            BirthDate = dateBirth;
            EnterPriseName = "ИТ";
        }
        private static string ConvertString(string inStr)
        {
            return string.Format("{0}{1}", char.ToUpper(inStr[0]), inStr.Substring(1).ToLower());
        }
    }
    public enum Profession
    {
        Accounter,
        Manager,
        Programmer
    }
}
