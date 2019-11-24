using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using DatabaseServer;
using DatabaseTable;

namespace ToyDBServer
{    
    class Index
    {// this class implements an Index Using a Hash table Data structure

        private Hashtable IndexTable = new Hashtable();
        private String columnName;
        private String tableName;
    
        public Index(String tableName, String column) {
            this.columnName = column; // Column on which the index will be implemented
            this.tableName = tableName;   // table in which colunm is located

            // retrieve record and use column to update table 
            /*
             for (int i; i<= number of Records; i++){
               Re
               this.IndexList.Add(columnEntry, RecorfLocation) 
            
            }
             */

        }

        private int hash(string value) {
            int hash = 0;
            if (value.Length == 0) return hash;

            for (int i = 0; i < value.Length; i++)
            {
                char character = value[i];
                hash = character % (38);
            }

            return hash;
        
        }

        public Boolean add(string columnEntry, string RecordLocation) {

            int hash = this.hash(columnEntry);

            // Linear probing Collision handling
            while (this.IndexTable.ContainsKey(hash) == true) { 
                // If the index table already contains the key add one to the has value and check again
                hash = hash + 1;
            }
            try { this.IndexTable.Add(hash, RecordLocation);
                return true;
            } catch (Exception e) {
                Console.WriteLine("Error! Make index entry."+e+"\n");
                return false;
            }
            
                     
        }

        private Boolean createIndexFile() {
            // This creates and index file within the Table file
            try
            {
                return true;
            }
            catch (Exception e) {
                Console.WriteLine("Error! Unable to create index File." + e + "\n");
                return false;
            }

        }

        public Boolean LoadIndexFile() {
            // This loads the values stored in the index file to the hash table
            return false;
        }

        public string IndexLookUp(string colunmEntry)
            // This column retrieves the intended column value and returns the Location of the item
        {
            int Key = this.hash(colunmEntry);
            if (this.IndexTable.ContainsKey(Key))
            {// check if key value matches
             // compare column value 
                try {
                    return (string)this.IndexTable[Key];
                } catch (Exception e) {
                    Console.WriteLine("Error! Unable to Search by Index." + e + "\n");
                    return null;
                }

            } else { return null;
            }
            }

        public Boolean writeIndexFile(String Filename, String Hash, String Value) {

            

            return false;

        }
           
            
        }
        
    }


