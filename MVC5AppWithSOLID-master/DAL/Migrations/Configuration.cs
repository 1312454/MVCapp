namespace DAL.Migrations
{
    using Contracts;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using DAL.Data;
    using Model;
    using System.Collections.Generic;
    internal sealed class Configuration : DbMigrationsConfiguration<DAL.Data.DataContext>
    {
        IRepositoryBase<User> _users;
        public Configuration(IRepositoryBase<User> users)
        {
            AutomaticMigrationsEnabled = false;
            _users = users;
        }

        protected override void Seed(DAL.Data.DataContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            var User = new List<User> { 
            new User{UserName="admin01",PassWord="admin"},
            new User{UserName="admin02",PassWord="admin"},
            new User{UserName="admin03",PassWord="admin"},
            };
            User.ForEach(s => context.Users.Add(s));
            context.SaveChanges();

             
        }
    }
}
