using CQRS.Core.Common;
using System;

namespace CQRS.Core.Catalog
{
    public class Price : ValueObject<Price>
    {
        public Price(decimal old, decimal current)
        {
            Old = old;
            Current = current;
        }

        public decimal Old { get; private set; }
        public decimal Current { get; private set; }

        protected override bool EqualsCore(Price other)
        {
            return other.Old == Old && other.Current == Current;
        }

        // TODO: must be implemented
        protected override int GetHashCodeCore()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return Current.ToString("c");
        }
    }
}
