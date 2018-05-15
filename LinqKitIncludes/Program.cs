using System;
using System.Collections.Generic;
using System.Linq;
using LinqKit;
using LinqKitIncludes.Data;
using Microsoft.EntityFrameworkCore;


namespace LinqKitIncludes
{
    class Program
    {
        static void Main(string[] args)
        {
            // change your connection string here
            const string connectionString =
                @"Server=(localdb)\MSSQLLocalDB;Database=LinqKitIncludes";

            var f = new ContextFactory(connectionString);

            SetupDatabase(f.GetNewContext());

            SetupEntities(f.GetNewContext());

            var defaultParents = f.GetNewContext().Parent
                .Include(p => p.Child)
                .First();


            var asExpandableParents = f.GetNewContext().Parent.AsExpandable()
                .Include(p => p.Child)
                .First();

            bool parentExists, childExists;
            {
                var ctx = f.GetNewContext();
                parentExists = ctx.Parent.Any();
                childExists = ctx.Child.Any();
            }
            bool defaultIncludes = defaultParents
                .Child
                .Any();

            bool asExpandableIncludes = asExpandableParents
                .Child
                .Any();

            Console.WriteLine($"ParentExists: {parentExists}");
            Console.WriteLine($"ChildExists: {childExists}");
            Console.WriteLine($"defaultIncludes: {defaultIncludes}");
            Console.WriteLine($"asExpandableIncludes: {asExpandableIncludes}");

            Console.ReadLine();
        }

        static void SetupEntities(LinqKitIncludesContext ctx)
        {
            var parent = new Parent()
            {
                Name = "Parent1",
                Child = new List<Child>
                {
                    new Child
                    {
                        Name = "Child1"
                    },
                    new Child
                    {
                        Name = "Child2"
                    }
                }};
            ctx.Parent.Add(parent);
            ctx.SaveChanges();
        }


        static void SetupDatabase(
            LinqKitIncludesContext ctx)
        {
            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();
        }
    }
}
