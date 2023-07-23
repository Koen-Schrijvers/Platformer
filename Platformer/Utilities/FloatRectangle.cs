using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer.Utilities
{
    internal class FloatRectangle
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public FloatRectangle(float x, float y, float width, float height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public float Top
        {
            get
            {
                return Y;
            }
        }
        public float Left
        {
            get
            {
                return X;
            }
        }
        public float Right
        {
            get
            {
                return X + Width;
            }
        }
        public float Bottom
        {
            get
            {
                return Y + Height;
            }
        }
        public Vector2 UpperLeftPoint
        {
            get
            {
                return new Vector2(X, Y);
            }
        }
        public Vector2 BottomRightPoint
        {
            get
            {
                return new Vector2(X + Width, Y + Height);
            }
        }
        public Vector2 CenterPoint
        {
            get
            {
                return new Vector2(X + (Width / 2), Y + (Height / 2));
            }
        }
        public bool Intersects(Rectangle rectangle)
        {
            return this.X < rectangle.Right && this.Right > rectangle.Left &&
                this.Y < rectangle.Bottom && this.Bottom > rectangle.Top;
        }
        public bool Intersects(FloatRectangle rectangle)
        {
            return this.X < rectangle.Right && this.Right > rectangle.Left &&
                this.Y < rectangle.Bottom && this.Bottom > rectangle.Top;
        }
    }
}

