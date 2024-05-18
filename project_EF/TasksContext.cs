using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using project_ef.Models;

namespace project_ef;
public class TasksContext: DbContext
{
    /* The "DbSet" is a set of data from the "model" that we have previously created. Basically, this would represent what a table is within the context of the Entity Framework.  */
    public DbSet<Category> Categories {get;set;}
    public DbSet<Models.Task> Tasks {get;set;}
    /* The Model must be named singularly. While the collections, that is, the DbSet, must be named in plural. This is because DbSet represents all the data within the database model or table. That is, it represents the attributes of the database. */ 

    public TasksContext(DbContextOptions<TasksContext> options) :base(options){}

    /* It's that simple to create an Entity Framework configuration. */


    //let's apply Fluent API
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        List<Category> categoriesUnit = new List<Category>();
        categoriesUnit.Add(new Category(){CategoryId = Guid.Parse("d8d1e903-0c79-4e92-9fc1-df471bd2882d"), Name = "Pending activities", EffortLevel = 20});
        categoriesUnit.Add(new Category(){CategoryId = Guid.Parse("a803e17f-b1e9-4e69-a426-0ae1a5ba0dc3"), Name = "Personal activities", EffortLevel = 50});


        modelBuilder.Entity<Category>(category =>
        {
            category.ToTable("Categoria");//table name
            category.HasKey(p=> p.CategoryId);
            category.Property(p=> p.Name).IsRequired().HasMaxLength(150);
            category.Property(p=> p.Description).IsRequired(false);//This way this field will not be mandatory.
            category.Property(p=> p.EffortLevel);
            category.HasData(categoriesUnit);
        });

        List<project_ef.Models.Task> tasksUnit = new List<project_ef.Models.Task>();
        tasksUnit.Add(new project_ef.Models.Task(){TaskId = Guid.Parse("04799f58-7631-4371-aa78-41f7e06f758f"), CategoryId = Guid.Parse("d8d1e903-0c79-4e92-9fc1-df471bd2882d"), PriorityTask = Priority.Medium, Title = "Payment of public services", CreationDate = DateTime.Now});
        tasksUnit.Add(new project_ef.Models.Task(){TaskId = Guid.Parse("986cf55a-4c1d-477f-8719-3acf5695f8ce"), CategoryId = Guid.Parse("a803e17f-b1e9-4e69-a426-0ae1a5ba0dc3"), PriorityTask = Priority.Low, Title = "Finish watching the movie on netflix", CreationDate = DateTime.Now});


        modelBuilder.Entity<project_ef.Models.Task>(task =>
        {
            task.ToTable("Tarea");
            task.HasKey(p=> p.TaskId);
            task.HasOne(p=> p.Category).WithMany(p=> p.Tasks).HasForeignKey(p=> p.CategoryId);
            task.Property(p=> p.Title).IsRequired().HasMaxLength(200);
            task.Property(p=> p.Description).IsRequired(false);
            task.Property(p=> p.PriorityTask);
            task.Property(p=> p.CreationDate);
            task.Property(p=> p.TimeLimit);
            task.Ignore(p=> p.Summary);
            task.HasData(tasksUnit);
        });
    }
} 