using System.Drawing;

namespace MILAV.Data
{
	/// <summary>
	/// Origin is always the top left corner
	/// </summary>
	public readonly struct Rectangle
	{
		public readonly int x;
		public readonly int y;
		public readonly int width;
		public readonly int height;

		/// <summary>
		/// Origin is always the top left corner
		/// </summary>
		public Rectangle(int x, int y, int width, int height)
		{
			this.x = x;
			this.y = y;
			this.width = width;
			this.height = height;
		}

		/// <summary>
		/// Origin is always the top left corner
		/// </summary>
		public Rectangle(Point origin, Point bottomRight)
		{
			this.x = origin.X;
			this.y = origin.Y;
			this.width = bottomRight.X - this.x;
			this.height = bottomRight.Y - this.y;
		}

		public Point TopLeftCorner { get { return new Point(x, y); } }

		public Point BottomRightCorner { get { return new Point(x + width, y + height); } }
	}
}
