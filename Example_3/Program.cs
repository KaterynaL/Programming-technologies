using System;

//	в классе Person запретить указывать дату рождения более, чем сегодня
//	создать новый класс «Работник» на базе класса Person, добавить свойства «Должность» и «Уволен», добавить метод «Уволить»
//	создать класс «Директор» на базе класса «Работник». Запретить увольнение директора путем изменения поведения метода «Уволить»


namespace Example_3
{
    class Program
    {
        static void Main(string[] args)
        {
            // Создать экземпляр класса Employee, вывести полное имя и признак "Уволен" в консоль
            Employee employee = new Employee("Иванов", "Иван", "Иванович", new DateTime(1980, 12, 01), "Бухгалтер");
            Console.WriteLine();
            Console.WriteLine("Информация о сотруднике:");
            Console.WriteLine("ФИО: {0}", employee.FullName);
            Console.WriteLine("Уволен: {0}", employee.Dismissed);
            // Уволить сотрудника
            employee.Dismiss();
            Console.WriteLine();
            Console.WriteLine("Информация о сотруднике:");
            Console.WriteLine("ФИО: {0}", employee.FullName);
            Console.WriteLine("Уволен: {0}", employee.Dismissed);


            // Создать экземпляр класса Director, вывести полное имя и признак "Уволен" в консоль
            Director director = new Director("Павлов", "Александр", "Анатольевич", new DateTime(1963, 12, 29));
            Console.WriteLine();
            Console.WriteLine("Информация о директоре:");
            Console.WriteLine("ФИО: {0}", director.FullName);
            Console.WriteLine("Должность: {0}", director.Post);
            Console.WriteLine("Уволен: {0}", director.Dismissed);
            
            // Уволить директора
            director.Dismiss();
            Console.ReadKey();
        }
    }
    public class Person
    {
        private string _firstName;
        private string _lastName;
        private string _patronymic;
        private DateTime _birthDate;

        /// <summary>
        /// Создать описание сотрудника
        /// </summary>
        /// <param name="lastName">Фамилия</param>
        /// <param name="firstName">Имя</param>
        /// <param name="patronymic">Отчество</param>
        /// <param name="birthDate">Дата рождения</param>
        public Person(string lastName, string firstName, string patronymic, DateTime birthDate)
        {
            _firstName = firstName;
            _lastName = lastName;
            _patronymic = patronymic;
            _birthDate = birthDate;
        }


        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        /// <summary>
        /// Отчество
        /// </summary>
        public string Patronymic
        {
            get { return _patronymic; }
            set { _patronymic = value; }
        }

        /// <summary>
        /// Фамилия и инициалы
        /// </summary>
        public string FullName
        {
            get
            {
                return string.Format("{0} {1}.{2}.", LastName, FirstName.Substring(0, 1), Patronymic.Substring(0, 1));
            }
        }

        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime BirthDate
        {
            get { return _birthDate; }
            set
            {
                // Контроль правильности даты рождения
                if (value > DateTime.Now)
                {
                    throw new ArgumentException(string.Format("Некорректная дата рождения: {0}", value));
                }
                _birthDate = value;
            }
        }

        /// <summary>
        /// Возраст
        /// </summary>
        public int Age
        {
            get
            {
                DateTime today = DateTime.Now;
                int age = today.Year - BirthDate.Year;
                // Если в этом году еще не было дня рождения
                if (today.Month < BirthDate.Month || today.Month == BirthDate.Month && today.Day < BirthDate.Day)
                {
                    age--;
                }
                return age;
            }
        }
    }

    // Класс Employee

    public class Employee : Person
    {
        private string _post;
        /// <summary>
        /// Должность
        /// </summary>
        public string Post
        {
            get { return _post; }
            set { _post = value; }
        }

        private bool _dismissed;
        /// <summary>
        /// Работник уволен
        /// </summary>
        public bool Dismissed
        {
            get { return _dismissed; }
        }

        /// <summary>
        /// Уволить работника
        /// </summary>
        public virtual void Dismiss()
        {
            _dismissed = true;
        }

        /// <summary>
        /// Создать работника
        /// </summary>
        /// <param name="lastName">Фамилия</param>
        /// <param name="firstName">Имя</param>
        /// <param name="patronymic">Отчество</param>
        /// <param name="birthDate">Дата рождения</param>
        /// <param name="post">Должность</param>
        public Employee(string lastName, string firstName, string patronymic, DateTime birthDate, string post)
            : base(lastName, firstName, patronymic, birthDate)
        {
            _post = post;
        }
    }
    // Класс "Директор"

    public class Director : Employee
    {
        public Director(string lastName, string firstName, string patronymic, DateTime birthDate) :
            base(lastName, firstName, patronymic, birthDate, "Директор")
        {
        }

        public override void Dismiss()
        {
            Console.WriteLine("Нельзя уволить директора!");
        }
    }
}
