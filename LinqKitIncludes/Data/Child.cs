using System;
using System.Collections.Generic;

namespace LinqKitIncludes.Data
{
    public partial class Child
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ParentId { get; set; }

        public Parent Parent { get; set; }
    }
}
