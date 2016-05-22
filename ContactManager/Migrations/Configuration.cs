using ContactManager.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ContactManager.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ContactManager.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ContactManager.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            AddUserAndRole(context);

            context.Companies.AddOrUpdate(p => p.CompanyName,
                new Company
                {
                    CompanyId = "0001",
                    CompanyName = "H&M",
                    Offers = "Buy 2 Get 1",
                    Discount = 1.0,
                },
                new Company
                {
                    CompanyId = "0002",
                    CompanyName = "Zara",
                    Offers = "",
                    Discount = 0.8,
                }
                );



            context.Members.AddOrUpdate(p => p.UserName,
                new Member()
                {
                    Id = "e000001",
                    UserName = "magstar",
                    CompanyId = "0002",
                    ContactId = 123,
                });

            context.Contacts.AddOrUpdate(p => p.Name,
               new Contact
               {
                   ContactId = 123,
                   Name = "Maggie Choi",
                   Address = "Dawning Views",
                   City = "Hong Kong",
                   State = "NA",
                   Zip = "10999",
                   Email = "magstar_choi@hotmail.com",
                   //MemberId = "e000001"
               });

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
        }


        bool AddUserAndRole(ContactManager.Models.ApplicationDbContext context)
        {
            IdentityResult ir;
            var rm = new RoleManager<IdentityRole>
                (new RoleStore<IdentityRole>(context));
            ir = rm.Create(new IdentityRole("canEdit"));
            var um = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));
            var user = new ApplicationUser()
            {
                UserName = "user1@contoso.com",
            };
            ir = um.Create(user, "P_assw0rd1");
            if (ir.Succeeded == false)
                return ir.Succeeded;
            ir = um.AddToRole(user.Id, "canEdit");
            return ir.Succeeded;
        }
    }
}
