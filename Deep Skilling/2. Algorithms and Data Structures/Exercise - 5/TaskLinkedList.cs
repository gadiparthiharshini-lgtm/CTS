using System;

namespace TaskManagement
{
    public class TaskLinkedList
    {
        private TaskNode? head;

        // Add Task
        public void Add(TaskItem task)
        {
            TaskNode newNode = new TaskNode(task);

            if (head == null)
            {
                head = newNode;
                return;
            }

            TaskNode temp = head;

            while (temp.Next != null)
            {
                temp = temp.Next;
            }

            temp.Next = newNode;
        }

        // Search Task
        public void Search(int id)
        {
            TaskNode? temp = head;

            while (temp != null)
            {
                if (temp.Data.TaskId == id)
                {
                    Console.WriteLine($"Found: {temp.Data.TaskId} | {temp.Data.TaskName} | {temp.Data.Status}");
                    return;
                }

                temp = temp.Next;
            }

            Console.WriteLine("Task Not Found.");
        }

        // Display Tasks
        public void Display()
        {
            Console.WriteLine("\nTask List");

            TaskNode? temp = head;

            while (temp != null)
            {
                Console.WriteLine($"{temp.Data.TaskId} | {temp.Data.TaskName} | {temp.Data.Status}");
                temp = temp.Next;
            }
        }

        // Delete Task
        public void Delete(int id)
        {
            if (head == null)
            {
                Console.WriteLine("Task List is Empty.");
                return;
            }

            if (head.Data.TaskId == id)
            {
                head = head.Next;
                Console.WriteLine($"Task {id} Deleted.");
                return;
            }

            TaskNode current = head;

            while (current.Next != null && current.Next.Data.TaskId != id)
            {
                current = current.Next;
            }

            if (current.Next != null)
            {
                current.Next = current.Next.Next;
                Console.WriteLine($"Task {id} Deleted.");
            }
            else
            {
                Console.WriteLine("Task Not Found.");
            }
        }
    }
}