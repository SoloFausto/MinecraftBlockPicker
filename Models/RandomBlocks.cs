namespace BlazorApp1.Models
{
    public class RandomBlocks
    {
        public readonly Blocks? internalBlock;
        public float chance { get; set; }
        public RandomBlocks(Blocks? internalBlock, float chance) {
            this.internalBlock = internalBlock;
            this.chance = chance;
        }
    }
}
