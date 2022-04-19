using System;
using System.Globalization;
using Godot;

namespace BoulderDash.Utils
{
    [Serializable]
    public struct Vector2Int : IEquatable<Vector2Int>, IFormattable
    {
        public int X;
        public int Y;

        public Vector2Int(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0: return X;
                    case 1: return Y;
                    default:
                        throw new IndexOutOfRangeException($"Invalid Vector2Int index addressed: {index}!");
                }
            }

            set
            {
                switch (index)
                {
                    case 0:
                        X = value;
                        break;
                    case 1:
                        Y = value;
                        break;
                    default:
                        throw new IndexOutOfRangeException($"Invalid Vector2Int index addressed: {index}!");
                }
            }
        }

        public float GetMagnitude()
        {
            return Mathf.Sqrt(GetSquareMagnitude());
        }

        public float GetSquareMagnitude()
        {
            return X * X + Y * Y;
        }

        public static Vector2Int operator +(Vector2Int left, Vector2Int right)
        {
            left.X += right.X;
            left.Y += right.Y;
            return left;
        }

        public static Vector2Int operator -(Vector2Int left, Vector2Int right)
        {
            left.X -= right.X;
            left.Y -= right.Y;
            return left;
        }

        public static Vector2Int operator -(Vector2Int vector)
        {
            vector.X = -vector.X;
            vector.Y = -vector.Y;
            return vector;
        }

        public static Vector2Int operator *(Vector2Int vector, int scale)
        {
            vector.X *= scale;
            vector.Y *= scale;
            return vector;
        }

        public static Vector2Int operator *(int scale, Vector2Int vector)
        {
            vector.X *= scale;
            vector.Y *= scale;
            return vector;
        }

        public static Vector2Int operator *(Vector2Int left, Vector2Int right)
        {
            left.X *= right.X;
            left.Y *= right.Y;
            return left;
        }

        public static Vector2Int operator /(Vector2Int vector, int divisor)
        {
            vector.X /= divisor;
            vector.Y /= divisor;
            return vector;
        }

        public static Vector2Int operator /(Vector2Int vector, Vector2Int divisor)
        {
            vector.X /= divisor.X;
            vector.Y /= divisor.Y;
            return vector;
        }

        public static Vector2Int operator %(Vector2Int vector, int divisor)
        {
            vector.X %= divisor;
            vector.Y %= divisor;
            return vector;
        }

        public static Vector2Int operator %(Vector2Int vector, Vector2Int divisor)
        {
            vector.X %= divisor.X;
            vector.Y %= divisor.Y;
            return vector;
        }

        public static bool operator ==(Vector2Int left, Vector2Int right) => left.Equals(right);

        public static bool operator !=(Vector2Int left, Vector2Int right) => !left.Equals(right);

        public static bool operator <(Vector2Int left, Vector2Int right) =>
            left.X == right.Y ? left.Y < right.Y : left.X < right.X;

        public static bool operator >(Vector2Int left, Vector2Int right) =>
            left.X == right.X ? left.Y > right.Y : left.X > right.X;

        public static bool operator <=(Vector2Int left, Vector2Int right) =>
            left.X == right.X ? left.Y <= right.Y : left.X <= right.X;

        public static bool operator >=(Vector2Int left, Vector2Int right) =>
            left.X == right.X ? left.Y >= right.Y : left.X >= right.X;

        public static implicit operator Vector2(Vector2Int vector)
        {
            return new Vector2(vector.X, vector.Y);
        }

        public bool Equals(Vector2Int other)
        {
            return X == other.X && Y == other.Y;
        }

        public override bool Equals(object obj)
        {
            return obj is Vector2Int other && Equals(other);
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() ^ (Y.GetHashCode() << 2);
        }

        public override string ToString()
        {
            return ToString(null, CultureInfo.InvariantCulture.NumberFormat);
        }

        public string ToString(string format)
        {
            return ToString(format, CultureInfo.InvariantCulture.NumberFormat);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return $"({X.ToString(format, formatProvider)}, {Y.ToString(format, formatProvider)})";
        }
    }
}