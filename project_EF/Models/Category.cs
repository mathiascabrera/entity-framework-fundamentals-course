using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Text.Json.Serialization;

namespace project_ef.Models;

public class Category
{
    //[Key]
    public Guid CategoryId{get;set;}

    //[Required]
    //[MaxLength(150)]
    public string? Name {get;set;}
    public string? Description {get;set;}

    //This variable will contain the effort required to perform the Task.
    public int? EffortLevel {get;set;}

    //This property helps us when we need to get all the tasks that belong to a category.
    [JsonIgnore]
    public virtual ICollection<Task>? Tasks {get;set;}
}