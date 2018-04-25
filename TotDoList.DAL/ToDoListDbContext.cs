using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration.Conventions;
using ToDoList.Domain;

namespace TotDoList.DAL
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    [DbConfigurationType(typeof(SupportCenterDbConfiguration))]
    public class ToDoListDbContext : DbContext
    {
        // Your context has been configured to use a 'ToDoListDbContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'TotDoList.DAL.ToDoListDbContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'ToDoListDbContext' 
        // connection string in the application configuration file.
        public ToDoListDbContext()
            : base("name=ToDoListDbContext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<ToDo> ToDos { get; set; }
        public virtual DbSet<Person> Persons { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder); // does nothing! (empty body)

            // Remove pluralizing tablenames
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            // Remove cascading delete for all required-relationships
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            // 'Ticket.TicketNumber' as unique identifier
          //  modelBuilder.Entity<Ticket>().HasKey(t => t.TicketNumber);

            // 'Ticket.State' as index
           // modelBuilder.Entity<Ticket>().Property(t => t.State)
             //   .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute()));
        } 
    }

  

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}