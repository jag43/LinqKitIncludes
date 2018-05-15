using System;
using System.Collections.Generic;

namespace LinqKitIncludes.Data
{
    public partial class Parent
    {
        public Parent()
        {
            Child = new HashSet<Child>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Child> Child { get; set; }
    }
}
