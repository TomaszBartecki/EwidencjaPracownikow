
namespace Projekt
{
    #region [uningNamespaces]

    using System;
    using System.Collections.Generic;
    using System.Linq;

    #endregion

    public class Employee : Person, IDisplayAdultEmployees
    {
        private List<Employee> employees;

        #region [Properties]

        public string ID { set; get; }

        public float Salary { set; get; }

        public string Position { set; get; }

        public uint Seniority { set; get; }
        #endregion

        #region [Private methods]

        private void GetEmployeeData()
        {
            bool isNotPositive = false;
            bool tryParse = false;
            float parssedValue = 0f;
            do
            {
                Console.WriteLine("Podaj Wynagrodzenie:");
                var output = Console.ReadLine();
                tryParse = float.TryParse(output, out parssedValue);
                if (!tryParse)
                {
                    Console.WriteLine("Niepoprawny format danych");
                    continue;
                }

                isNotPositive = (parssedValue < 0f);
                if (isNotPositive)
                {
                    Console.WriteLine("Wielkosc wwynagrodzenia nie moze byc ujemna");
                }

                if (tryParse && !isNotPositive)
                {
                    break;
                }              
            } while (true);

            this.Salary = parssedValue;

            var exeptionOccurred = false;
            do
            {
                try
                {
                    exeptionOccurred = false;
                    Console.WriteLine("Podaj doswiadczenie:");
                    this.Seniority = uint.Parse(Console.ReadLine());
                }
                catch (OverflowException e)
                {
                    exeptionOccurred = true;
                    Console.WriteLine("Nieprawidlowa wielkosc doswiadczenia.\nOutpout:{0}", e.Message);
                }
                catch (FormatException e)
                {
                    exeptionOccurred = true;
                    Console.WriteLine("Nieprawidlowa wielkosc doswiadczenia.\nOutpout:{0}", e.Message);
                }
                catch (Exception e)
                {
                    exeptionOccurred = true;
                    Console.WriteLine("Nieprawidlowa wielkosc doswiadczenia.\nOutpout:{0}", e.Message);
                }
            }
            while (exeptionOccurred);

            Console.WriteLine("Podaj stanowisko");
            this.Position = Console.ReadLine();
        }


        private Employee FiilData()
        {
            this.GetPersonData();
            this.GetEmployeeData();

            return new Employee
            {
                Name = Name,
                Surname = Surname,                 
                Age = Age,
                Gender = Gender,
                ID = Guid.NewGuid().ToString(),
                Salary = Salary,
                Seniority = Seniority,
                Position = Position
            };
        }

        private void DisplayCurrentEmployee(Employee emp)
        {
            Console.WriteLine("ID:{0}", emp.ID);
            Console.WriteLine("Imie:{0}", emp.Name);
            Console.WriteLine("Nazwisko:{0}", emp.Surname);
            Console.WriteLine("Wiek:{0}", emp.Age);
            Console.WriteLine("Plec:{0}", emp.Gender);
            Console.WriteLine("Stanowisko:{0}", emp.Position);
            Console.WriteLine("Wynagrodzenie:{0}", emp.Salary);
            Console.WriteLine("Doswiadczenie:{0}", emp.Seniority);
        }

        #endregion

        #region [Public methods]

        public void AdddEmployee()
        {
            if (this.employees == null)
            {
                this.employees = new List<Employee>();
            }

            this.employees.Add(new Employee().FiilData());            
        }

        public void DisplayAllEmployees()
        {
            if (this.employees == null || this.employees.Count == 0)
            {
                Console.WriteLine("Brak pracownikow do wyswietlenia");
                return;
            }

            var counterEmployee = 1;
            foreach (var emp in employees)
            {
                Console.WriteLine("=================================== Pracownik nr:{0} =================================== ", counterEmployee);
                this.DisplayCurrentEmployee(emp);

                counterEmployee++;
            }
        }

        public void RemoveEmploye()
        {
            if (this.employees == null || this.employees.Count == 0)
            {
                Console.WriteLine("Lista pracownikow jest pusta!");
                return;
            }


            Console.WriteLine("Podaj  ID pracownika:");
            var id = Console.ReadLine();
            var isRemoved = false;
            for (int i = 0; i < employees.Count; i++)
            {
                if (employees[i].ID == id)
                {
                    Console.WriteLine("=================================== Usuwanie pracownika =================================== ");
                    this.DisplayCurrentEmployee(employees[i]);
                    this.employees.RemoveAt((i));
                    isRemoved = true;
                }
            }

            if (!isRemoved) 
            {
                Console.WriteLine("Nie zaleziono pracownika o takim ID:{0}", id);
            }
        }

        public void DisplayAdultEmployees()
        {
            if (this.employees == null || this.employees.Count == 0)
            {
                Console.WriteLine("Brak prcowninikow");
                return;
            }

            var adultEmployees = this.employees.Where(empl => empl.Age >= 18).ToList();
            if (adultEmployees.Count == 0)
            {
                Console.WriteLine("Nie znaleziono pracownikow pelnoletnich");
                return;
            }

            var counterEmployee = 1;
            foreach (var adultEmploy in adultEmployees)
            {
                Console.WriteLine("===================================Pelnoletni pracownik nr:{0} =================================== ", counterEmployee);
                this.DisplayCurrentEmployee(adultEmploy);

                counterEmployee++;
            }
        }

        #endregion
    }
}
