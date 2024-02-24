using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project_ef;

var builder = WebApplication.CreateBuilder(args);

//entity framework configuration
builder.Services.AddDbContext<TasksContext> (p => p.UseInMemoryDatabase("TaskDB"));


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

app.Run();
