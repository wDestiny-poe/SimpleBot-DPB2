using DreamPoeBot.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace SimpleBot.Extensions.Positions
{
    public class Position : IEquatable<Position>
    {
        protected Vector2i Vector;

        public Position(Vector2i vector)
        {
            Vector = vector;
        }

        public Position(int x, int y)
        {
            Vector = new Vector2i(x, y);
        }

        public Vector2i AsVector => Vector;

        public static implicit operator Vector2i(Position position)
        {
            return position.Vector;
        }

        public bool Equals(Position other)
        {
            return this == other;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Position);
        }

        [SuppressMessage("ReSharper", "RedundantCast.0")]
        public static bool operator ==(Position left, Position right)
        {
            if (ReferenceEquals(left, right))
                return true;

            if (((object)left == null) || ((object)right == null))
                return false;

            return left.Vector.X == right.Vector.X &&
                   left.Vector.Y == right.Vector.Y;
        }

        public static bool operator !=(Position left, Position right)
        {
            return !(left == right);
        }

        [SuppressMessage("ReSharper", "NonReadonlyMemberInGetHashCode")]
        public override int GetHashCode()
        {
            return (Vector.X * 11) ^ Vector.Y;
        }

        public override string ToString()
        {
            return Vector.ToString();
        }

        public class Comparer : IComparer<Vector2i>
        {
            public static readonly Comparer Instance = new Comparer();

            static Comparer()
            {
            }

            private Comparer()
            {
            }

            public int Compare(Vector2i first, Vector2i second)
            {
                int x = first.X - second.X;
                if (x == 0) return first.Y - second.Y;
                return x;
            }
        }
    }
    public class Vector2iComparer : IComparer<DreamPoeBot.Common.Vector2i>
    {
        public int Compare(DreamPoeBot.Common.Vector2i a, DreamPoeBot.Common.Vector2i b)
        {
            // Ordena por Y primeiro, depois X (ajuste conforme necessário)
            int cmp = a.Y.CompareTo(b.Y);
            if (cmp == 0)
                cmp = a.X.CompareTo(b.X);
            return cmp;
        }
    }
}