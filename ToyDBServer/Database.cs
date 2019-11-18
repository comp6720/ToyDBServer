using System;
using System.IO;

namespace DatabaseServer
{
    class Database
    {
        //The location of the database. The value of this is set at runtime by the user
        public String Location { get; set; }

        //The name of the database
        public String DatabaseName { get; set; }

        //Create a single instance of the database class to be shared by all other classes
        public static readonly Database Instance = new Database();

        //Checks whether or not the input database location and name already exists
        public bool databaseAlreadyExists = false;


        /**
         * Create a new database folder
         *
         * @param string databaseName - The name of the database.
         *
         * @return void
        **/
        public void CreateDatabase(string databaseName)
        {
            //Set the DatabaseName property to the value passed in the parameter
            DatabaseName = databaseName;

            //The location where the database will be stored
            String path = @Location + "\\" + DatabaseName;

            //Create the database folder if it does not exist
            if (!Directory.Exists(path))
            {
                try
                {
                    Path.GetFullPath(path);
                    Directory.CreateDirectory(path);

                    Console.WriteLine("Database successfully created.");
                }

                catch (DirectoryNotFoundException e)
                {
                    Console.WriteLine("DirectoryNotFoundException: {0}", e);
                }
            }

            //Database folder already exists
            else
            {
                databaseAlreadyExists = true;
                Console.WriteLine("Error! That folder already exists.\n");
            }
        }


        /**
         * Navigates to the specified database folder
         *
         * @param string databaseName - The name of the database.
         *
         * @return void
        **/
        public void UseDatabase(string databaseName)
        {
            //The location of the database to use
            String path = @Location + "\\" + databaseName;

            try
            {
                Directory.SetCurrentDirectory(path);
                Console.WriteLine("Using database '{0}'", databaseName);
            }

            catch(DirectoryNotFoundException e) 
            {
                Console.WriteLine("The specified database does not exist: {0}", e);
            }
        }


        /**
         * Removes a database folder and all its contents
         *
         * @param string databaseName - The name of the database.
         *
         * @return void
        **/
        public void DropDatabase(string databaseName)
        {
            //The location of the database to use
            String path = @Location + "\\" + databaseName;

            if (path.Contains(databaseName))
            {
                if (path != null)
                {
                    foreach (String FileFound in Directory.GetFiles(path))
                    {
                        File.Delete(FileFound);
                    }
                }

                //call delete to delete files and empty directory
                var dir = new DirectoryInfo(path);
                dir.Delete(true);

                Console.WriteLine("Database successfully deleted.");
            }

            else
            {
                Console.WriteLine("The specified database does not exist.");
            }
        }
    }
}