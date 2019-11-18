using System;
using System.Collections.Generic;
using System.Text;
using TableRecord;

namespace DataBlock
{
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
            for (int i = 0; i < BlockingFactor; i++)
            {
                Record record = new Record();
            }
        }
    }
}
