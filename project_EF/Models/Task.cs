using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.SignalR.Protocol;

namespace project_ef.Models;

public class Task
{
    //[Key]
    public Guid TaskId {get;set;}

    //[ForeignKey("CategoryId")]
    public Guid CategoryId {get;set;}

    //[Required]
    //[MaxLength(200)]
    public string? Title {get;set;}
    public string? Description {get;set;}
    public Priority PriorityTask {get;set;}
    public DateTime CreationDate {get;set;}
    public DateTime TimeLimit {get;set;}
    
    //This property will help us when we need to obtain the Category belonging to a Task
    public virtual Category? Category {get;set;}

    //[NotMapped]
    public string? Summary {get;set;}//This property will have the title and summary of its description. Since we don't want it to be generated in the database but only within C#, we use "NotMapped".
}
public enum Priority
{
    Low,
    Medium,
    High
}