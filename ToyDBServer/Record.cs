using System;
using System.Collections.Generic;
using System.Text;
using DataBlock;

namespace TableRecord
{
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
        public void CreateRecord(string TableName, Block block, int fieldOne, string fieldTwo, string fieldThree)
        {
            //Set the properties to the values passed in the parameter
            FieldOne = fieldOne;
            FieldTwo = fieldTwo;
            FieldThree = fieldThree;
        }

        public void ReadRecord(string TableName, string columnName, string condition, string operatorSymbol, string idValue)
        {

        }

        public void UpdateRecord(string TableName)
        {

        }

        public void DeleteRecord(string TableName)
        {

        }
    }
}
