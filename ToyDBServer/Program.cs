using System;
using System.IO;
using DatabaseServer;
using ServerConnect;
using Parser;

namespace ToyDBServer
{
    class Program
    {
        //Create server object
        static Server server = new Server();

        //Create parser object
        static SQLParser parser = new SQLParser();

        //Create database object
        static Database database = new Database();

        static void Main(string[] args)
        {
            server.ExecuteServer();

            SetDatabaseFolder();

            AwaitQuery();
        }

        /**
         * Initial setup.
         * Accepts as input the specified folder where the database is to be created.
         *
         * @return void
        **/
        private static void SetDatabaseFolder()
        {
            Console.Write("Enter the location where the database is to be created: ");
            database.Location = Console.ReadLine();
        }


        /**
         * Listens for incoming queries from the client
         *
         * @return void
        **/
        private static void AwaitQuery()
        {
            while (true)
            {
                Console.WriteLine("\nAwaiting query ... ");

                // Suspend while waiting for incoming connection Using Accept()
                server.ClientSocket = server.Listener.Accept();

                server.ReceiveQuery();
            }
        }


        /**
         * Creates a new database folder.
         * Accepts as input the name of the database.
         *
         * @return void
        **/
        private static void CreateDatabase()
        {
            //Get the inputted database name
            Console.Write("\nEnter the name of the database to create: ");
            database.DatabaseName = Console.ReadLine();

            //Call the create database method
            database.create(database.DatabaseName);
            
            //Run again if there is an error that the database folder already exists
            if(database.databaseAlreadyExists == true)
            {
                SetDatabaseFolder();
            }
        }

        /**
         * Selects the database to use.
         * Accepts as input the name of the database.
         *
         * @return void
        **/
        private static void UseDatabase()
        {
            //Get the inputted database name
            Console.Write("\nEnter the name of the database to use: ");
            string currentDatabase = Console.ReadLine();

            //Call the use database method
            database.use(database.DatabaseName);
        }

        /**
         * Creates a new table in the current database.
         * Accepts as input the name of the database.
         *
         * @return void
        **/
        private static void CreateTable()
        {
            //Create the table object
            Table table = new Table();

            //Get the inputted table name
            Console.Write("\nEnter the name of the table: ");
            table.TableName = Console.ReadLine();

            //Create the table column object as an array
            TableColumn[] column = new TableColumn[table.maxColumnCount * 2];
           
            //Create 3 columns in the table
            for (int i = 1; i <= 3; i++)
            {
                //Initialize
                column[i] = new TableColumn();

                //Get the inputted column name
                Console.Write("\nEnter a name for column {0}: ", i);
                column[i].ColumnName = Console.ReadLine();

                //Get the inputted column type
                Console.Write("Enter a type (int/string) for column {0}: ", i);
                column[i].ColumnType = Console.ReadLine();

                //Add the columns to the table
                if (table.columnCount < table.maxColumnCount)
                {
                    column[i].add(table.TableName, column[i].ColumnName, column[i].ColumnType);

                    //Increment the column count
                    table.columnCount += 1;
                }

                else
                {
                    Console.WriteLine("Error! Maximum number of columns exceeded.");
                }   
            }

            //Call the create table method
            table.create(table.TableName, column[1], column[2], column[3]);
        }


        /**
         * Parses the text of the inputted query
         * @param string query - the query to be parsed and executed
         *
         * @return void
        **/
        public static void ParseQuery(string query)
        {

        }
    }
}
