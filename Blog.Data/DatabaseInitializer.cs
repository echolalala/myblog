using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data
{
    public static class DatabaseInitializer
    {
        public static void Initialize()
        {
            using (var db = new EFDbContext())
            {
                if (db.Database.Exists())
                {
                    Database.SetInitializer<EFDbContext>(null);
                }
                else
                {
                    Database.SetInitializer<EFDbContext>(new CreateDatabaseIfNotExists<EFDbContext>());
                }
            }
        }
    }
}
