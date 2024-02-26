using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Data.Concrete;
using Tasks.Data.Entities;

namespace Tasks.ConsoleUI.ExtensionMethods
{
    public static class MyTaskFuncionality
    {
        public static void Start() 
        {
            Console.WriteLine("1 - View all Tasks");
            Console.WriteLine("2 - Add a new Task");
            Console.WriteLine("3 - Find a Task");
            Console.WriteLine("0 - Quit");
            Console.WriteLine();

            if (!int.TryParse(Console.ReadLine(), out int option))
            {
                return;
            }

            switch (option)
            {
                case 1:
                    ViewAllTasks();
                    break;
                case 2:
                    AddTask();
                    break;
                case 3:
                    FindTask();
                    break;
                default:
                    break;
            }
        }

        public static void ViewTask(MyTask task)
        {
            Console.WriteLine();
            Console.WriteLine($"Id:           {task.Id}");
            Console.WriteLine($"Title:        {task.Title}");
            Console.WriteLine($"Description:  {task.Description}");
            Console.Write("Completed:    ");
            Console.WriteLine(task.isCompleted ? "Yeey" : "Nope");
            Console.WriteLine(new string('_', 50));
        }
        
        public static void ViewAllTasks()
        {
            MyTaskContext tasksContext = new MyTaskContext();
            var AllTasks = tasksContext.MyTasks.ToList();

            foreach (MyTask task in AllTasks)
            {
                ViewTask(task);
            }
        }


        public static void AddTask()
        {
            Console.WriteLine("Now you can add new task!");
            Console.Write("Now write your Task's title:  ");
            string TasksTitle = Console.ReadLine()!;

            while (TasksTitle == string.Empty)
            {
                Console.WriteLine("Oops! You wrote something wrong");
                Console.Write("Write your Task's title:  ");
                TasksTitle = Console.ReadLine()!;
            }   

            Console.Write("Now write your Task's description:  ");
            string TasksDescription = Console.ReadLine()!;

            while (TasksDescription == string.Empty)
            {
                Console.WriteLine("Oops! You wrote something wrong");
                Console.Write("Write your Task's description:  ");
                TasksDescription = Console.ReadLine()!;
            }

            Console.Write($"Adding your task");
            Thread.Sleep(500);
            Console.Write(".");
            Thread.Sleep(500);
            Console.Write(".");
            

            using MyTaskContext context = new MyTaskContext();
            
            MyTask newTask = new MyTask()
            {
                Title = TasksTitle,
                Description = TasksDescription
            };

            context.Add(newTask);
            context.SaveChanges();

            Console.WriteLine(".");
            Console.WriteLine();
            Console.WriteLine("Your task successfuly added!");
            Console.WriteLine();
            Console.WriteLine($"        Title:  {TasksTitle}");
            Console.WriteLine($"        Description:  {TasksDescription}");
        }

        public static void FindTask()
        {
            Console.WriteLine();
            Console.WriteLine("1 - Find Task by Id");
            Console.WriteLine("2 - Find Task by title");
            Console.WriteLine();

            if (!int.TryParse(Console.ReadLine(), out int option))
            {
                return;
            }

            if (option == 1)
            {
                Console.WriteLine();
                Console.WriteLine("Write the searching Task's Id");
                Console.Write("Id:  ");

                if (!int.TryParse(Console.ReadLine(), out int taskId))
                {
                    Console.WriteLine("Invalid Id");
                    Console.WriteLine();
                    return;
                }

                FindTaskById(taskId);
            }

            if (option == 2)
            {
                Console.WriteLine();
                Console.WriteLine("Write the searching Task's title");
                Console.Write("Title:  ");
                string taskTitle = Console.ReadLine()!;
                FindTaskByTitle(taskTitle);
            }

        }

        public static MyTask? FindTaskByTitle( string? title )
        {
            if (title.IsNullOrEmpty())
            {
                return null;
            }

            MyTaskContext context = new MyTaskContext();
            MyTask? task = context.MyTasks.Where(task => task.Title == title).FirstOrDefault();
            
            if (task != null)
            {
                ViewTask(task);
                return task;
            }
            
            else
            {
                Console.WriteLine("There's no Task with that title");
                Console.WriteLine();
                return null;
            }
        }

        public static MyTask? FindTaskById(int titleId)
        {
            MyTaskContext context = new MyTaskContext();
            MyTask? task = context.MyTasks.Find(titleId);
            if (task != null)
            {
                ViewTask(task);
                return task;
            }
            else
            {
                Console.WriteLine("There's no Task with that Id");
                Console.WriteLine();
                return null;
            }
        }
    }
}
