using FluentRandomPicker;

namespace BlazorApp1.Models
{
    public class RandomMachine
    {
        private List<RandomBlocks> loadedBlocks;
        public RandomMachine(){
            loadedBlocks = new List<RandomBlocks>();
        }
        public void addBlock(Blocks block) {
            if(loadedBlocks.Count == 8) { return;  }
            foreach(var currentBlock in loadedBlocks) { 
                if (currentBlock.internalBlock.file_name == block.file_name ) {
                    if (currentBlock.weight < 5) {
                        currentBlock.weight += 1;
                    }
                    return;
                }
            }
            RandomBlocks randomBlock = new(block,1);
            loadedBlocks.Add(randomBlock);
        }
        public void removeBlock(Blocks block) {
            if (loadedBlocks.Count == 1 && loadedBlocks[0].weight == 1) { loadedBlocks.Clear(); }
            foreach (var loopedBlock in loadedBlocks) {
                if (loopedBlock.internalBlock.file_name == block.file_name) {
                    if (loopedBlock.weight.Equals(1)) {
                        loadedBlocks.Remove(loopedBlock);
                    }
                    else {
                        loopedBlock.weight -= 1;
                    }
                }
                
                
            }
        }
        public RandomBlocks selectRandomBlock() {
            if (loadedBlocks.Count < 1) {
                return null;
            }
            else if (loadedBlocks.Count == 1) {
                return loadedBlocks.First();
            }
            return Out.Of().PrioritizedElements(loadedBlocks).WithWeightSelector(x => x.weight).PickOne();
        }
        public List<RandomBlocks> returnBlocks() {
            return loadedBlocks;
        }
    }

}

