using System;
using System.IO;

namespace DatabaseServer
{
    class Database
    {
        //The ocation of the database
        public string Location { get; set; }

        //The name of the database
        public string DatabaseName { get; set; }

        //Checks whether or not the input database location and name already exists
        public bool databaseAlreadyExists = false;

        /**
         * Create a new database folder
         *
         * @param string databaseName - The name of the database.
         *
         * @return void
        **/
        public void create(string databaseName)
        {
            //Set the DatabaseName property to the value passed in the parameter
            DatabaseName = databaseName;

            //The location where the database will be stored
            string path = @Location + "\\" + DatabaseName;

            //Create the database folder if it does not exist
            if (!Directory.Exists(path))
            {
                Path.GetFullPath(path);
                Directory.CreateDirectory(path);

                Console.WriteLine("Database successfully created.");
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
        public void use(string databaseName)
        {
            //The location of the database to use
            string path = @Location + "\\" + databaseName;

            try
            {
                Directory.SetCurrentDirectory(path);
                Console.WriteLine("Using database '{0}'", databaseName);
            }

            catch(DirectoryNotFoundException e) 
            {
                Console.WriteLine("The specified database does not exist. {0}", e);
            }
        }
    }


    class Table
    {
        //A unique identifier for the table
        public string TableIdentifier { get; set; }

        //The name of the table
        public string TableName { get; set; }

        //The maximum amount of columns that the table can hold
        public int maxColumnCount = 3;

        //A counter to keep track of the number of columns added to the table
        public int columnCount = 0;

        /**
         * Create a new table in the database as a binary file
         *
         * @param string tableName - The name of the table.
         * @param string columnOne - The primary key.
         * @param string columnTwo - Other column.
         * @param string columnThree - Other column.
         *
         * @return void
        **/
        public void create(string tableName, TableColumn columnOne, TableColumn columnTwo, TableColumn columnThree)
        {
            //Set the TableName property to the value passed in the parameter
            TableName = tableName;
           
            try
            {
                //Write the table object locally to disk as a binary file
                string fileName = TableName.ToLower();

                //Create the table if it does not exist
                if (!Directory.Exists(fileName))
                {
                    using (FileStream stream = new FileStream(fileName, FileMode.Create))
                    {
                        using (BinaryWriter writer = new BinaryWriter(stream))
                        {
                            writer.Write(TableName);
                            writer.Write(columnOne.ColumnName + ": " + columnOne.ColumnType);
                            writer.Write(columnTwo.ColumnName + ": " + columnTwo.ColumnType);
                            writer.Write(columnThree.ColumnName + ": " + columnThree.ColumnType);
                        }
                    }
                }

                //Table already exists
                else
                {
                    Console.WriteLine("Error! That table already exists.\n");
                }
            }

            catch (IOException ioexp)
            {
                Console.WriteLine("Error: {0}", ioexp.Message);
            }
        }


        /**
        * Creates a unique identifer for a table
        *
        * @param string tableName - The name of the table.
        *
        * @return void
        **/
        private void createUniqueIdentifer(string tableName)
        {

        }
    }


    class TableColumn
    {
        public string ColumnName { get; set; }
        public string ColumnType { get; set; }

        /**
         * Create a new table column in the database table
         *
         * @param string tableName - The name of the table to which the columns are to be added.
         * @param string columnName - The name of the column.
         * @param string columnType - The data type for the column - either an integer or string.
         *
         * @return void
        **/
        public void add(string tableName, string columnName, string columnType)
        {
            //Set the ColumnName property to the value passed in the parameter
            ColumnName = columnName;

            //Set the ColumnType property to the value passed in the parameter
            ColumnType = columnType;
        }
    }


    class Record
    {
        int FieldOne { get; set; } = 0;
        string FieldTwo { get; set; } = null;
        string FieldThree { get; set; } = null;

        /**
         * Create a new record in a table
         *
         * @param int fieldOne - The primary key for the record.
         * @param string fieldTwo - Other field.
         * @param string fieldThree - Other field.
         *
         * @return void
        **/
        public void create(string TableName, Block block, int fieldOne, string fieldTwo, string fieldThree)
        {
            //Set the properties to the values passed in the parameter
            FieldOne = fieldOne;
            FieldTwo = fieldTwo;
            FieldThree = fieldThree;
        }

        public void read(string TableName, string columnName, string condition, string operatorSymbol, string idValue)
        {

        }

        public void update(string TableName)
        {

        }

        public void delete(string TableName)
        {

        }
    }


    class Block
    {
        public static int BlockAddress { get; set; }
        public static int BlockingFactor { get; set; } = 5;
        public static int RecordCount { get; set; }

        /**
         * Create a two dimensional array to store the records in the block.
         * Each block will hold up to 5 records and each record will have 3 fields.
        **/
        public Record[,] RecordArray = new Record[BlockingFactor, 3];


        /**
         * Inserts a record into a block.
         * A single block can hold 5 records.
         * A new block will be programmatically created when the block becomes full.
         * 
         * @param Record record - the new record to be added
         * @param int BlockFactor - the amount of records that can be stored per block
         * 
         * @return void
        **/
        public void insertIntoBlock(Record record, int BlockingFactor)
        {
        
        }


        /**
         * Creates a new block when one becomes full
         * 
         * @return void
        **/
        public void createNewBlock()
        {
        
        }


        /**
         * With the blocking factor being 5, each block can hold up to 5 records.
         * When a block becomes full, this function places the new records into another block.
         * This will be done by creating a new incremented table and placing the records there.
         *
         * @return void
        **/
        public void manageBlocks()
        {
            for(int i = 0; i < BlockingFactor; i++)
            {
                Record record = new Record();
            }
        }
    }


    class File
    {
        //Keep track of the table data across all blocks (the different table files)
    }
}