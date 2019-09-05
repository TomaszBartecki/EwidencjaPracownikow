using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    public class Menu
    {
        private Employee employee = new Employee();

        public event Action EmployeeHander;

        private void Display()
        {
            Console.WriteLine("-------:::==== Mernu ===:::-------");
            Console.WriteLine("| 1 - Dodaj pracownika            |");
            Console.WriteLine("| 2 - Usun Pracownika             |");
            Console.WriteLine("| 3 - Wyswietl pracownika         |");
            Console.WriteLine("| 4 - Wypisz pelnoletnich         |");
            Console.WriteLine("| 5 - O autorze                   |");
            Console.WriteLine("| ESC - Wyjscie z menu            |");
            Console.WriteLine("----------------------------------");
            Console.WriteLine("\n\n Wybierz opcje z Menu:");
        }

        private void OnAboutAuthor()
        {
            Console.WriteLine("\nCzesc Drogi Uzytkowniku\n Dziekuje za skorzystanie z mojego programu.\nPozdrawiam Tomasz");
        }

        private void PressAnyKey()
        {
            Console.WriteLine("\nNadisnij dowolny klawisz aby powrocic do nenu:");
            Console.ReadKey();
        }

        public void Run()
        {
            this.EmployeeHander += OnAboutAuthor;

            while (true)
            {
                Console.Clear();
                this.Display();
                var keyPressed = Console.ReadKey();
                Console.WriteLine("\nWybrano:{0}", keyPressed.KeyChar);
                switch (keyPressed.KeyChar.ToString())
                {
                    case "1":
                        this.employee.AdddEmployee();
                        this.PressAnyKey();
                       break;
                    case "2":
                        this.employee.RemoveEmploye();
                        this.PressAnyKey();
                        break;
                    case "3":
                        this.employee.DisplayAllEmployees();
                        this.PressAnyKey();
                        break;
                    case "4":
                        this.employee.DisplayAdultEmployees();
                        this.PressAnyKey();
                        break;
                    case "5":
                        if (EmployeeHander != null)
                        {
                            EmployeeHander();
                            this.PressAnyKey();
                        }
                        break;
                }


                if (keyPressed.Key == ConsoleKey.Escape)
                {
                    this.EmployeeHander -= OnAboutAuthor;
                    break;
                }
            }
        }

        
    }
}