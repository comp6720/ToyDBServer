using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace DatabaseTable
{
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
        public void CreateTable(string tableName, TableColumn columnOne, TableColumn columnTwo, TableColumn columnThree)
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
        private void CreateUniqueIdentifer(string tableName)
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
        public void AddColumn(string tableName, string columnName, string columnType)
        {
            //Set the ColumnName property to the value passed in the parameter
            ColumnName = columnName;

            //Set the ColumnType property to the value passed in the parameter
            ColumnType = columnType;
        }
    }
}
