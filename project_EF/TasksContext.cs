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
} 