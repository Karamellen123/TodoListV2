// See https://aka.ms/new-console-template for more information
using System.Collections.Generic;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

List<TaskUndone> Uncompleted = new List<TaskUndone>();
List<TaskUndone> CompletedList = new List<TaskUndone>();

//Adding random numbers so it won't be empty the first time (mainly used for debugging)
DateTime date_1 = new DateTime(2024, 2, 25);
DateTime date_2 = new DateTime(2026, 5, 5);
DateTime date_3 = new DateTime(2024, 3, 20);
DateTime date_4 = new DateTime(2024, 12, 14);

Uncompleted.Add(new TaskUndone("-.-", date_1));
Uncompleted.Add(new TaskUndone("Coding",date_2));
Uncompleted.Add(new TaskUndone("Food", date_3));
Uncompleted.Add(new TaskUndone("Pommes", date_4));
Uncompleted.Add(new TaskUndone("Chocolate", date_1));
Uncompleted.Add(new TaskUndone("Paint", date_2));

//LoadTasksFromFile("tasks.txt"); // Load tasks from file when the program starts
MainMenu();

void AddTaskToList()
{
    Console.WriteLine("Add a task to your todo list");
    string answer = "";
    DateTime date;
    Console.WriteLine("Please enter a task:");
    answer = Console.ReadLine();

    Console.WriteLine("Enter a deadline (MM/dd/yyyy): ");
    date = Convert.ToDateTime(Console.ReadLine()); 


    Uncompleted.Add(new TaskUndone(answer, date));
    // return to Main Menu
    MainMenu();

}

void ChangeDate()   
{
    Console.WriteLine("Change deadline");
    int selected;
    DateTime newDate;
    Console.WriteLine("Which task would you like to change the date on? ");

    //Lists the tasks so user can choose which task they want to change
    for (int i = 0; i < Uncompleted.Count; i++)
    {
        Console.WriteLine(i + " " + Uncompleted[i].Name + ", current date: " + Uncompleted[i].Deadline);
    }

    selected = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine("What would you like to change it to? ");
    Console.WriteLine("Enter a deadline (MM/dd/yyyy): ");
    newDate = Convert.ToDateTime(Console.ReadLine());

    //Change selected valuse to new date
    Uncompleted[selected].Deadline = newDate;

    //Displays the new date to user
    Console.WriteLine("The Task: " + Uncompleted[selected].Name + " have changed it's deadline to: " + Uncompleted[selected].Deadline);

    // return to Main menu
    MainMenu();

}

void ShowTaskList()
{
    Console.WriteLine(" Your todo list:");
    
    // Displays the task list
    for (int i = 0; i < Uncompleted.Count; i++)
    {
        Console.WriteLine(i + ") Task name: " + Uncompleted[i].Name + ", current date: " + Uncompleted[i].Deadline);
    }
    Console.WriteLine("___________________________________________________");
    Console.WriteLine("Completed tasks:");
    for (int i = 0; i < CompletedList.Count; i++)
    {
        Console.WriteLine(i + ") Task name: " + CompletedList[i].Name + ", current date: " + CompletedList[i].Deadline);
    }

    Console.ReadKey();
    MainMenu();

}


void SortListByDate()
{
    Console.WriteLine("Sorter list by date");
    var sortedTasks = Uncompleted.OrderBy(task => task.Deadline).ToList();
    foreach (var task in sortedTasks)
    {
        Console.WriteLine("Task: " + task.Name + ", Deadline: " + task.Deadline);
    }
    Console.ReadKey();
    MainMenu();
}


void MainMenu()
{
    Console.Clear();
    Console.WriteLine("Main Menu");
    Console.WriteLine("Welcome to Todo List! \nYou have " + Uncompleted.Count + " tasks to do and " + Uncompleted.Count + " completed. \nPick an option: ");
    Console.WriteLine("1) View todo list");
    Console.WriteLine("2) Add Task to your todo list");
    Console.WriteLine("3) change date \n4) Edit task name \n5) Mark Task as done \n6) Remove task");

    string answer = "";
    answer = Console.ReadLine();
    if(answer != null)
    {
        if (answer == "1") { ShowTaskList(); }
        else if (answer == "2") { AddTaskToList(); }
        else if (answer == "3") { ChangeDate(); }
        else if (answer == "4") { EditTaskName(); }
        else if (answer == "5") { TaskIsCompleted(); }
        else if (answer == "6") { RemoveTask(); }
        // else if(answer == "4") { sortListbyName(); }
        else { Console.WriteLine("temp"); }

    }
}

void TaskIsCompleted()
{
    Console.WriteLine("Mark task as done");
    var sortedUncompletedTasks = Uncompleted.OrderBy(task => task.Deadline).ToList();
    for (int i = 0; i < sortedUncompletedTasks.Count; i++)
    {
        Console.WriteLine(i + ") Task: " + sortedUncompletedTasks[i].Name + ", Deadline: " + sortedUncompletedTasks[i].Deadline);
    }
    Console.WriteLine("Enter the number of the completed task: ");
    int answer = Convert.ToInt32(Console.ReadLine());
    CompletedList.Add(new TaskUndone(sortedUncompletedTasks[answer].Name, sortedUncompletedTasks[answer].Deadline));
    Uncompleted.Remove(sortedUncompletedTasks[answer]); // Remove directly from sorted list

    var sortedCompletedTasks = CompletedList.OrderBy(task => task.Deadline).ToList();
    Console.WriteLine("____________________________________________________________________");
    Console.WriteLine("Completed Tasks");
    for (int i = 0; i < sortedCompletedTasks.Count; i++)
    {
        Console.WriteLine(i + ") Task: " + sortedCompletedTasks[i].Name + ", Deadline: " + sortedCompletedTasks[i].Deadline);
    }

    Console.WriteLine("____________________________________________________________________");
    Console.WriteLine("Incompleted Tasks: ");
    SortListByDate();
    Console.ReadKey();

}

void RemoveTask()
{
    var sortedUncompletedTasks = Uncompleted.OrderBy(task => task.Deadline).ToList();
    for (int i = 0; i < sortedUncompletedTasks.Count; i++)
    {
        Console.WriteLine(i + ") Task: " + sortedUncompletedTasks[i].Name + ", Deadline: " + sortedUncompletedTasks[i].Deadline);
    }
    Console.WriteLine("Enter the number of the task you would like to remove: ");
    int answer = Convert.ToInt32(Console.ReadLine());
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("The  following task will be removed:");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine(answer + ") Task: " + sortedUncompletedTasks[answer].Name + ", Deadline: " + sortedUncompletedTasks[answer].Deadline);
    Uncompleted.Remove(sortedUncompletedTasks[answer]); // Remove directly from sorted list
    Console.ReadKey();
    MainMenu();
}
void EditTaskName()
{
    var sortedUncompletedTasks = Uncompleted.OrderBy(task => task.Deadline).ToList();
    for (int i = 0; i < sortedUncompletedTasks.Count; i++)
    {
        Console.WriteLine(i + ") Task: " + sortedUncompletedTasks[i].Name + ", Deadline: " + sortedUncompletedTasks[i].Deadline);
    }
    Console.WriteLine("Enter the number of the task you would like to change: ");
    int answer = Convert.ToInt32(Console.ReadLine());
    //Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Enter a new name for that task: ");
    string newName = Console.ReadLine();
    Uncompleted[answer].Name = newName;
    Console.WriteLine(answer + ") Task: " + sortedUncompletedTasks[answer].Name + ", Deadline: " + sortedUncompletedTasks[answer].Deadline);
    Console.ReadKey();

    
}

class TaskUndone 
{
    public TaskUndone(string name, DateTime deadline)
    {
        Name = name;
        Deadline = deadline;
    }
    public string Name { get; set; }
    public DateTime Deadline { get; set; }

}

/*
void LoadTasksFromFile(string filename, Dictionary<string, int> tasksUndone)
{
    if (File.Exists(filename))
    {
        string[] lines = File.ReadAllLines(filename);
        foreach (string line in lines)
        {
            string[] parts = line.Split(',');
            string taskName = parts[0];
            int deadline = int.Parse(parts[1]);
            tasksUndone.Add(taskName, deadline);
        }
    }
}

static void SaveTasksToFile(string filename, Dictionary<string, int> tasksUndone)
{
    using (StreamWriter writer = new StreamWriter(filename))
    {
        foreach (var task in tasksUndone)
        {

            writer.WriteLine(task.Key + "," + task.Value);
        }
    }
}
*/
