namespace BlazorApp1.Models
{
    public class RandomMachine
    {
        private List<RandomBlocks> loadedBlocks;
        RandomMachine(){
            loadedBlocks = new List<RandomBlocks>();
        }
        public void addBlock(Blocks block) { // what if it substracts a percentage from all previous blocks to add the new block with a 10% chance 
            RandomBlocks randomBlock = new(block, new float()); //(what if it was only when the user changed it)
            loadedBlocks.Add(randomBlock);
            float currentBlockDistribution = 1 / loadedBlocks.Count; 
            foreach (var loopedBlock in loadedBlocks) { 
                loopedBlock.chance = currentBlockDistribution;
            }
        }
        public void removeBlock(Blocks block) {
            float currentBlockDistribution = 1 / (loadedBlocks.Count-1);
            foreach (var loopedBlock in loadedBlocks) {
                if (loopedBlock.internalBlock.file_name == block.file_name) {
                    loadedBlocks.Remove(loopedBlock);
                }
                else {
                    loopedBlock.chance = currentBlockDistribution;
                }
            }
        }
        public RandomBlocks selectRandomBlock() {
            float totalProbability = loadedBlocks.Sum(randomBlock => randomBlock.chance);
            double randomValue = new Random().NextDouble() * totalProbability;
            foreach (var randomBlock in loadedBlocks) {
                randomValue -= randomBlock.chance;
                if (randomValue <= 0f) {
                    return randomBlock;
                }
            }

            return loadedBlocks[0]; // Fallback if probabilities are not properly set
        }
    }

}

