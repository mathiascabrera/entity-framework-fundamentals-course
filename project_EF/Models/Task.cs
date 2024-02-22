using Microsoft.AspNetCore.SignalR.Protocol;

namespace project_ef.Models;

public class Task
{
    public Guid TaskId {get;set;}
    public Guid CategoryId {get;set;}
    public string Title {get;set;}
    public string Description {get;set;}
    public Priority PriorityTask {get;set;}
    public DateTime CreationDate {get;set;}
    
    //This property will help us when we need to obtain the Category belonging to a Task
    public Category Category {get;set;}
}
public enum Priority
{
    Low,
    Medium,
    High
}