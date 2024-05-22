using System.Formats.Tar;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project_ef;
using project_ef.Models;

var builder = WebApplication.CreateBuilder(args);

//This setting only works for in-memory Entity Framework. Now we are going to comment on it since there could be some conflict between both configurations.
//This is because we need a configuration for each context.
//builder.Services.AddDbContext<TasksContext> (p => p.UseInMemoryDatabase("TaskDB"));

builder.Services.AddSqlServer<TasksContext>(builder.Configuration.GetConnectionString("cnTareas"));

/* builder.Services.AddSqlServer<TasksContext>("Data Source= SERVERNAME; Initial Catalog= NAMEDATABASE;Trusted_Connection=True; Integrated Security=True;TrustServerCertificate=True"); */

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

//endpoint
app.MapGet("/dbconnection", async ([FromServices] TasksContext dbContext) =>
{
    //This takes care of creating the database and verifying that the database can be created. In case the database is not created, then it creates it. The "EnsureCreated()" method returns a boolean value.
    dbContext.Database.EnsureCreated();

    //Instead of verifying that the "EnsureCreated()" method has returned true or false, we are going to use the Ok() method and the "IsInMemory()" method that will return a boolean informing us if the database was created in memory:
    return Results.Ok("Database in memory: "+dbContext.Database.IsInMemory());
});
//The next thing you need to do is build the project using the “dotnet build” command. If no errors appear then we run "dotnet run", which will provide us with the ports that we can use to consume our API in Postman.

//Now let's go to Postman and use our endpoint name "dbconnection" to verify that our API is working fine.

//If Postman returns the message we inserted in the Ok() method and returns true, it means that Entity Framework took the models we created and created the in-memory database successfully. If so, it gives us the assurance that the Entity Framework is configured correctly, therefore we can connect to a real database.


//This endpoint will return all tasks.
app.MapGet("/api/tasks", async ([FromServices] TasksContext dbContext) =>
{
    return Results.Ok(dbContext.Tasks);
});

//This endpoint will return all low priority tasks.
app.MapGet("/api/filteredtasks", async ([FromServices] TasksContext dbContext) =>
{
    return Results.Ok(dbContext.Tasks.Where(p=> p.PriorityTask == project_ef.Models.Priority.Low));
});

//This endpoint will return all low priority tasks with their corresponding category.
app.MapGet("/api/tasks/category", async ([FromServices] TasksContext dbContext) =>
{
    return Results.Ok(dbContext.Tasks.Include(p => p.Category).Where(p=> p.PriorityTask == project_ef.Models.Priority.Low));
});

//This endpoint is responsible for loading records into the database.
app.MapPost("/api/tasks", async ([FromServices] TasksContext dbContext, [FromBody] project_ef.Models.Task task) =>
{
    /* each of these fields is overwritten with the data received */
    task.TaskId = Guid.NewGuid();
    task.CreationDate = DateTime.Now;
    /* await dbContext.AddAsync(task); */ /* Both ways of adding are valid. */
    await dbContext.Tasks.AddAsync(task);
    await dbContext.SaveChangesAsync();/* In this way we confirm that the record was saved. */
    return Results.Ok();

});

app.Run();
