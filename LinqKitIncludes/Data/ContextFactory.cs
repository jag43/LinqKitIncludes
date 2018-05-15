using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace LinqKitIncludes.Data
{
    public class ContextFactory
    {
        private readonly string _connectionString;

        public ContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public LinqKitIncludesContext GetNewContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<LinqKitIncludesContext>()
                    .UseSqlServer(_connectionString);

            var ctx = new LinqKitIncludesContext(optionsBuilder.Options);

            return ctx;
        }
    }
}
