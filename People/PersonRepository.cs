using System;
using System.Collections.Generic;
using System.Linq;
using People.Models;
using SQLite;

namespace People
{
    // This class defines the schema for the Person Table in the database.
    public class PersonRepository
    {
        // Properties for the class with getters and setters
        public string StatusMessage { get; set; }
        
        // The connection to the SQLite database
        private SQLiteConnection conn;

        // Constructor for the class
        public PersonRepository(string dbPath)
        {
            // Initialize a new SQLiteConnection
            conn = new SQLiteConnection(dbPath);
            // Create the Person table
            conn.CreateTable<Person>();
        }


        // Class methods below.

        /// <summary>
        /// Adds a new person to the SQLite database
        /// </summary>
        /// <param name="name">The name of the person to be added</param>
        public void AddNewPerson(string name)
        {
            int result = 0;
            try
            {
                //basic validation to ensure a name was entered
                if (string.IsNullOrEmpty(name))
                    throw new Exception("Valid name required");

                // Insert a new person into the Person table.

                // Instatiate the new person with the name argument
                Person p = new Person { Name = name };
                // Add the new person to the database and assign to result
                result = conn.Insert(p);

                StatusMessage = string.Format("{0} record(s) added [Name: {1})", result, name);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", name, ex.Message);
            }

        }
        /// <summary>
        /// Gets all the people from the database
        /// </summary>
        /// <returns>A list of class Person with all the people in the database.</returns>
        public List<Person> GetAllPeople()
        {
            // Return a list of people saved to the Person table in the database
            try
            {
                List<Person> people = conn.Table<Person>().ToList();
                return people;
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrive data. {0}", ex.Message);
            }
            return new List<Person>();
        }
        
        public List<Person> GetSomePeople()
        {
            // Return person named 'Andrew'

            var user = from u in conn.Table<Person>()
                       where u.Name == "Andrew"
                       select u;
            return user.ToList(); // lots of options avaiable after user here ***********
            
        }
    }
}