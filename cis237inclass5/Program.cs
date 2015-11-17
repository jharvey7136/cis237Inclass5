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



            //Gets access to the collection of tables we can interact with.
            CarsJHarveyEntities1 carsJHarveyEntities = new CarsJHarveyEntities1();
            //***************************************************************************//
            //Loop through all of the cars in the table called Cars.
            foreach (Car car in carsJHarveyEntities.Cars)
            {
                Console.WriteLine(car.id + " " + car.make + " " + car.model);
            }
            //***************************************************************************//

            //***************************************************************************//
            //Find a specific one by any property.
            //Call the where method on the table Cars and pass in a lambde expression for the criteria we are looking for.
            Car carToFind = carsJHarveyEntities.Cars.Where(c => c.id == "V0LCD1814").First();

            //We can look for a specific model from the database with a where clause based on any criteria we want.
            Car otherCarToFind = carsJHarveyEntities.Cars.Where(car => car.model == "Challenger").First();

            //Print them out.
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(carToFind.id + " " + carToFind.make + " " + carToFind.model);
            Console.WriteLine(otherCarToFind.id + " " + otherCarToFind.make + " " + otherCarToFind.model);
            //***************************************************************************//

            //***************************************************************************//
            //Find a car based on the primary Id
            //NOTE: This currently doesnt work because there are no primary Ids set on the tables.
            Car foundCar = carsJHarveyEntities.Cars.Find("V0LCD1814");

            //Print that shit out.
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(foundCar.id + " " + foundCar.make + " " + foundCar.model);
            //***************************************************************************//


            //***************************************************************************//
            //NOTE: This currently doesnt work because there are no primary Ids set on the tables.
            //Add a new Car to the database.
            //Make an instance.
            Car newCarToAdd = new Car();

            //Assign properties to the parts of the model.
            newCarToAdd.id = "88888";
            newCarToAdd.make = "Nissan";
            newCarToAdd.model = "GT-R";
            newCarToAdd.horsepower = 550;
            newCarToAdd.cylinders = 8;
            newCarToAdd.year = "2016";
            newCarToAdd.type = "Car";

            //Add new car to the Cars table.
            carsJHarveyEntities.Cars.Add(newCarToAdd);

            //This method will save the changes to the database.
            carsJHarveyEntities.SaveChanges();
            //***************************************************************************//


            //***************************************************************************//
            //Get a car out of the database that we would like to update
            Car carToFindForUpdate = carsJHarveyEntities.Cars.Find("V0LCD1814");

            //Update some of the properties of the car we found. Dont need to update all of them if we dont want to.
            carToFindForUpdate.make = "Nissan";
            carToFindForUpdate.model = "GT-R";
            carToFindForUpdate.horsepower = 550;
            carToFindForUpdate.cylinders = 8;

            //Save changes to the database.
            carsJHarveyEntities.SaveChanges();
            

            //*******************************************************************************
            //How to do a delete
            //*******************************************************************************

            //Get a car out of the database that we would like to update
            Car carToFindForDelete = carsJHarveyEntities.Cars.Find("88888");

            //Remove the Car from the Cars table
            carsJHarveyEntities.Cars.Remove(carToFindForDelete);

            //Save the changes to the database
            carsJHarveyEntities.SaveChanges();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Deleted the added car. Looking to see if it is still in the DB");

            try
            {
                carToFindForDelete = carsJHarveyEntities.Cars.Find("88888");
                Console.WriteLine(carToFindForDelete.id + " " + carToFindForDelete.make + " " + carToFindForDelete.model);
            }
            catch (Exception e)
            {
                Console.WriteLine("The model you are looking for does not exist");
            }








            Console.ReadKey();
















            /*
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

            
            foreach (EmailAddress email in adventure.EmailAddresses)
            {
                Console.WriteLine(email);
            }
             */
        }
    }
}
