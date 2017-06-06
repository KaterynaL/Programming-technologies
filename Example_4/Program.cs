using System;
using System.Collections.Generic;

// Добавить в класс Employee статическое событие «Сотрудник уволен»
// При увольнении сотрудника выдавать в консоль сообщение с полным именем уволенного

namespace Example_4
{
    class Program
    {
        static void Main(string[] args)
        {
            // Добавить обработчик события "Уволен"
            Employee.DismissedAnyEmployee += dismissedAnyEmployee;

            List<Employee> workers = new List<Employee>();
            workers.Add(new Employee("Иванов", "Иван", "Иванович", new DateTime(1960, 10, 23), "Дворник"));
            workers.Add(new Employee("Петров", "Петр", "Петрович", new DateTime(1970, 5, 15), "Кладовщик"));
            workers.Add(new Employee("Сидоров", "Свирид", "Свиридович", new DateTime(1980, 1, 10), "Начальник отдела АСУ"));

            foreach (var worker in workers)
            {
                worker.Dismiss();
            }

            Console.ReadKey();
        }

        private static void dismissedAnyEmployee(object sender, DismissEmployeeEventArgs e)
        {
            Console.WriteLine("Уволен работник: {0}", e.FullName);
        }

    }
    // Описать класс параметров события для передачи имени сотрудника
    // Добавить в класс Employee статическое событие, которое будет срабатывать при увольнении любого сотрудника
    // Добавить в класс Employee protected-метод для вызова события
    // При увольнении сотрудника вызываейте метод вызова события

    public class DismissEmployeeEventArgs : EventArgs
    {

        internal DismissEmployeeEventArgs(string fullName)
        {
            FullName = fullName;
        }

        /// <summary>
        /// Имя уволенного сотрудника
        /// </summary>
        public string FullName
        {
            get; set;
        }
    }


    /// <summary>
    /// Работник
    /// </summary>
    public class Employee : Person
    {
        /// <summary>
        /// Событие срабатывает при увольнении любого сотрудника
        /// </summary>
        public static event EventHandler<DismissEmployeeEventArgs> DismissedAnyEmployee;


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
            onDismissed();
        }

        protected void onDismissed()
        {
            if (DismissedAnyEmployee != null)
            {
                DismissedAnyEmployee(this, new DismissEmployeeEventArgs(FullName));
            }
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

    /// <summary>
    /// Персона
    /// </summary>
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

}


