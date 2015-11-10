using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237inclass5
{
    class Program
    {
        static void Main(string[] args)
        {
            AdventureWorks2012Entities adventure = new AdventureWorks2012Entities();

            int counter = 0;
            Guid id = new Guid();

            foreach (Person person in adventure.People)
            {
                if (counter == 0)
                {
                    id = person.rowguid;
                }
                if (counter++ > 20)
                    break;
                Console.WriteLine(person.FirstName + " " + person.LastName + " " + person.rowguid);
            }
            Console.WriteLine();
            Console.WriteLine("----------------------------------------");
            Console.WriteLine(adventure.People.Find(id));

            /*
            foreach (EmailAddress email in adventure.EmailAddresses)
            {
                Console.WriteLine(email);
            }
             */
        }
    }
}
