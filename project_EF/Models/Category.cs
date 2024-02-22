using System.ComponentModel.Design;

namespace project_ef.Models;

public class Category
{
    public Guid CategoryId{get;set;}
    public string? Name {get;set;}
    public string? Description {get;set;}

    //This property helps us when we need to get all the tasks that belong to a category.
    public virtual ICollection<Task>? Tasks {get;set;}
}