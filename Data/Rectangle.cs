namespace MILAV.Data
{
    public readonly struct Rectangle
    {
        public readonly int x;
        public readonly int y;
        public readonly int width;
        public readonly int height;

        public Rectangle(int x,int y, int width, int height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }
    }
}
