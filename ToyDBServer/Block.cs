using System;
using System.Collections.Generic;
using System.Text;
using TableRecord;

namespace DataBlock
{
    class Block
    {
        
        public int BlockAddress { get; set; } // Removed Static Modifier to make it unique for each block
        public static int BlockingFactor { get; set; } = 5;
        public static int RecordCount { get; set; }

        /**
         * Create a two dimensional array to store the records in the block.
         * Each block will hold up to 5 records and each record will have 3 fields.
        **/
        public Record[,] RecordArray = new Record[BlockingFactor, 3];
        private String blockName;

        public Block(String name,int Address) {
            this.blockName = name;
            this.BlockAddress = Address;
        
        }

        /**
         * With the blocking factor being 5, each block can hold up to 5 records.
         * When a block becomes full, this function places the new records into another block.
         * This will be done by creating a new incremented table and placing the records there.
         *
         * @return void
        **/
        /*  public void manageBlocks()
        {
             for (int i = 0; i < BlockingFactor; i++)
             {
                 Record record = new Record();
             }
         }
         */
    }
}
