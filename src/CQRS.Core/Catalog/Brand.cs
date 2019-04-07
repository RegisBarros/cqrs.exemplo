using CQRS.Core.Common;
using System;

namespace CQRS.Core.Catalog
{
    public class Brand : Entity
    {
        public Brand(string name, string code)
        {
            Id = Guid.NewGuid();
            Name = name;
            Code = code;
        }

        public string Name { get; private set; }

        public string Code { get; private set; }
    }
}
