using System;
using TaskManagement;

TaskLinkedList tasks = new TaskLinkedList();

tasks.Add(new TaskItem
{
    TaskId = 1,
    TaskName = "Design UI",
    Status = "Pending"
});

tasks.Add(new TaskItem
{
    TaskId = 2,
    TaskName = "Develop Backend",
    Status = "In Progress"
});

tasks.Display();

Console.WriteLine();

tasks.Search(2);

Console.WriteLine();

tasks.Delete(1);

tasks.Display();