namespace MinecraftBlockPicker.Models
{
    public class RandomBlocks
    {
        public readonly Blocks? internalBlock;
        public int weight { get; set; }
        public RandomBlocks(Blocks? internalBlock, int weight) {
            this.internalBlock = internalBlock;
            this.weight = weight;
        }
    }
}
