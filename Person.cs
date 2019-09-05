using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    public class Person
    {
        private string surname;

        public string Name { get; set; }

        public string Surname
        {
            set
            {
                this.surname = value;
            }

            get
            {
                return this.surname;
            }
        }

        public uint Age { set; get; }

        protected string Gender { set; get;}  


        protected void GetPersonData()
        {
            Console.WriteLine("Podaj ime:");
            this.Name = Console.ReadLine();

            Console.WriteLine("Podaj nazwisko:");
            this.Surname = Console.ReadLine();

            uint parsedAge = 0;
            while (true)
            {
                Console.WriteLine("Podaj wiek:");
                var outpout = Console.ReadLine();
                if (uint.TryParse(outpout, out parsedAge))
                {
                    break;
                }

                Console.WriteLine("Podales nieprawny wiek:{0}", outpout);
            }

            this.Age = parsedAge;
            Console.WriteLine("Podaj plec:");
            this.Gender = Console.ReadLine();
        }
    }
}
