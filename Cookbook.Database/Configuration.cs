using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookbook.Database
{
    internal sealed class Configuration : DbMigrationsConfiguration<DBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            CommandTimeout = 60 * 10;
        }

        protected override void Seed(DBContext context)
        {

        }
    }

}
