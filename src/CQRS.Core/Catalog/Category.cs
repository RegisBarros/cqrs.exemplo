using CQRS.Core.Common;
using System;

namespace CQRS.Core.Catalog
{
    public class Category : Entity
    {
        public Category(string name, string code)
        {
            Id = Guid.NewGuid();
            Name = name;
            Code = code;
        }

        public string Name { get; private set; }

        public string Code { get; private set; }
    }
}
