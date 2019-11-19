using System;
using System.Collections.Generic;
using System.Text;

namespace DataBlock
{
    class BlockManager
    {
        private static List<Block> ActiveBlocks;
        private static String BLOCKS_HOME = null;  // File location of Blocks
        private static int BlockCount = 0;

        public BlockManager(String ParentDirectory) {
            BlockManager.setHOMEDirectory(ParentDirectory); // CreateThe File for All  Blocks
            BlockManager.createNewBlock(); // Create a new Block
            
        }

        public static void setHOMEDirectory(String ParentDirectory)
        {
            try
            {
                String BLOCKS_HOME = System.IO.Path.Combine(ParentDirectory, "blocks");
                System.IO.Directory.CreateDirectory(BLOCKS_HOME);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error! unable to create New Data Block" + e + "\n");
            }
        }


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
        public static void insertIntoBlock(TableRecord.Record record, int BlockingFactor)
        {
            // Look at current Block for available location

            // if Location Unavailable seache for available Block Addresses in existing blocks
            for (int i = 0; i < ActiveBlocks.Count; i++)
            {
                if (ActiveBlocks[i].RecordArray.Length < BlockingFactor)
                {
                    ActiveBlocks[i].RecordArray[1, 1] = record; // Dummy Method              
                }
            }
            BlockManager.createNewBlock();
      

        }

        /**
        * Creates a new block when one becomes full
        * 
        * @return void
       **/
        private static void createNewBlock()
        {
            try {
                // Create Block address by incrementing counter
                BlockManager.BlockCount = BlockManager.BlockCount + 1;

                // Create a new folder for the Data Block
                String BlockFileLocation = System.IO.Path.Combine(BlockManager.BLOCKS_HOME, "b" + BlockManager.BlockCount);
                System.IO.Directory.CreateDirectory(BlockFileLocation);

                // Create a new Block Object and add to Block List
                Block b = new Block("b"+ BlockManager.BlockCount, BlockManager.BlockCount);
                BlockManager.ActiveBlocks.Add(b);

            } catch (Exception e) { 
            Console.WriteLine("Error! unable to create New Data Block" + e + "\n");
            }
            }

        public static TableRecord.Record getRecord(int BlockID, int BlockSubID) {
            try { // Read from Array (Double check if it should be reading from File)
                TableRecord.Record r = BlockManager.ActiveBlocks[BlockID - 1].RecordArray[BlockSubID, 1];
                return r;
            
            }
            catch (Exception e) {
                Console.WriteLine("Error! unable to Retrieve Data Block" + e + "\n");
                return null;
            }
            
        }
                        
        }


    }

