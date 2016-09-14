namespace PubsAutoMapperMVCApp.DataContexts.PubsMigrations
{
    using PubsDomainLibrary.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PubsDomainLibrary.Concrete.PubsDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"DataContexts\PubsMigrations";
        }

        protected override void Seed(PubsDomainLibrary.Concrete.PubsDbContext context)
        {
            #region Lengthy way
            Author a1 = new Author { FirstName = "Robert", LastName = "Ludlum" };
            Author a2 = new Author { FirstName = "Jeffrey", LastName = "Archer" };
            Author a3 = new Author { FirstName = "Edward", LastName = "De Bono" };
            Author a4 = new Author { FirstName = "Sidney", LastName = "Sheldon" };
            Author a5 = new Author { FirstName = "Desmond", LastName = "Morris" };
            Author a6 = new Author { FirstName = "J.K", LastName = "Rowling" };
            Author a7 = new Author { FirstName = "Eric Van", LastName = "Lustbader" };

            Book b1 = new Book { Title = "Bourne Identity", Price = 120.90m, Category = "Fiction" };
            Book b2 = new Book { Title = "Not a Penny Less Not a Penny More", Price = 100.90m, Category = "Fiction" };
            Book b3 = new Book { Title = "Lateral Thinking", Price = 90, Category = "NonFiction" };
            Book b4 = new Book { Title = "If Tomorrow Comes", Price = 130.90m, Category = "Fiction" };
            Book b5 = new Book { Title = "People Watching", Price = 300, Category = "NonFiction" };
            Book b6 = new Book { Title = "Harry Potter", Price = 70.90m, Category = "Fiction" };
            Book b7 = new Book { Title = "Bourne Sanction", Price = 140.90m, Category = "Fiction" };

            b1.Authors.Add(a1);
            b2.Authors.Add(a2);
            b3.Authors.Add(a3);
            b4.Authors.Add(a4);
            b5.Authors.Add(a5);
            b6.Authors.Add(a6);
            b7.Authors.Add(a1);
            b7.Authors.Add(a7);

            context.Books.Add(b1);
            context.Books.Add(b2);
            context.Books.Add(b3);
            context.Books.Add(b4);
            context.Books.Add(b5);
            context.Books.Add(b6);
            context.Books.Add(b7);
            #endregion

            #region Try
            //context.Authors.AddOrUpdate(a => a.FirstName,
            //     new Author { FirstName = "Robert", LastName = "Ludlum" },
            //     new Author { FirstName = "Jeffrey", LastName = "Archer" },
            //     new Author { FirstName = "Edward", LastName = "De Bono" },
            //     new Author { FirstName = "Sidney", LastName = "Sheldon" },
            //     new Author { FirstName = "Desmond", LastName = "Morris" },
            //     new Author { FirstName = "J.K", LastName = "Rowling" },
            //     new Author { FirstName = "Eric Van", LastName = "Lustbader" }
            //    );


            //context.Books.AddOrUpdate(b => b.Title,
            //    new Book { Title = "Bourne Identity", Price = 120.90m, Category = "Fiction", Authors = new List<Author> { context.Authors.FirstOrDefault(a => a.AuthorId == 1) } },
            //    new Book { Title = "Not a Penny Less Not a Penny More", Price = 100.90m, Category = "Fiction", Authors = new List<Author> { context.Authors.FirstOrDefault(a => a.AuthorId == 2) } },
            //    new Book { Title = "Lateral Thinking", Price = 90, Category = "NonFiction", Authors = new List<Author> { context.Authors.FirstOrDefault(a => a.AuthorId == 3) } },
            //    new Book { Title = "If Tomorrow Comes", Price = 130.90m, Category = "Fiction", Authors = new List<Author> { context.Authors.FirstOrDefault(a => a.AuthorId == 4) } },
            //    new Book { Title = "People Watching", Price = 300, Category = "NonFiction", Authors = new List<Author> { context.Authors.FirstOrDefault(a => a.AuthorId == 5) } },
            //    new Book { Title = "Harry Potter", Price = 70.90m, Category = "Fiction", Authors = new List<Author> { context.Authors.FirstOrDefault(a => a.AuthorId == 6) } },
            //    new Book { Title = "Bourne Sanction", Price = 140.90m, Category = "Fiction", Authors = new List<Author> { context.Authors.FirstOrDefault(a => a.AuthorId == 1), context.Authors.FirstOrDefault(a => a.AuthorId == 6) }
            //    }
            //    );
            #endregion

            #region Default
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
            #endregion
        }
    }
}
