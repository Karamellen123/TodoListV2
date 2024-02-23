// See https://aka.ms/new-console-template for more information
using System.Collections.Generic;
using System.Threading.Tasks;

//List<string> TaskName = new List<string>();
//List<int> TaskDate = new List<int>();
//List<bool> isTaskCompleted = new List<bool>();
List<TaskUndone> Uncompleted = new List<TaskUndone>();
List<TaskCompleted> CompletedList = new List<TaskCompleted>();

//Dictionary<string, int> TasksUndone = new Dictionary<string, int>();
//Dictionary<string, int> TasksCompleted = new Dictionary<string, int>();

//Adding random numbers so it won't be empty the first time (mainly used for debugging)
Uncompleted.Add(new TaskUndone("-.-", 9));
Uncompleted.Add(new TaskUndone("Coding", 2));
Uncompleted.Add(new TaskUndone("Food", 5));
Uncompleted.Add(new TaskUndone("Pommes", 3));
Uncompleted.Add(new TaskUndone("Chocolate", 8));
Uncompleted.Add(new TaskUndone("Paint", 4));

//LoadTasksFromFile("tasks.txt"); // Load tasks from file when the program starts
MainMenu();

void AddTaskToList()
{ 
    string answer = "";
    int date;
    Console.WriteLine("Please enter a task:");
    answer = Console.ReadLine();

    Console.WriteLine("Enter a deadline: ");
    date = Convert.ToInt32(Console.ReadLine());

    Uncompleted.Add(new TaskUndone(answer, date));
    // return to Main Menu
    MainMenu();

}

//Changes date at a position in the dictionary.
void ChangeDate()   
{
    int selected;
    int newDate;
    Console.WriteLine("Which task would you like to change the date on? ");

    //Lists the tasks so user can choose which task they want to change
    for (int i = 0; i < Uncompleted.Count; i++)
    {
        Console.WriteLine(i + " " + Uncompleted[i].Name + ", current date: " + Uncompleted[i].Deadline);
    }

    selected = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine("What would you like to change it to? ");
    newDate = Convert.ToInt32(Console.ReadLine());

    //Change selected valuse to new date
    Uncompleted[selected].Deadline = newDate;

    /*
    int selectedTask = Uncompleted[selected].Deadline;
    Uncompleted[selectedTask] = newDate;
    */

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
        //Console.WriteLine(i + ") Task name:" + TaskName[i] + ", current date: " + TaskDate[i] + ", status: " + isTaskCompleted[i]);
        Console.WriteLine(i + ") Task name: " + Uncompleted[i].Name + ", current date: " + Uncompleted[i].Deadline);
    }
    Console.WriteLine("___________________________________________________");
    Console.WriteLine("Completed tasks:");
    for (int i = 0; i < CompletedList.Count; i++)
    {
        //Console.WriteLine(i + ") Task name:" + TaskName[i] + ", current date: " + TaskDate[i] + ", status: " + isTaskCompleted[i]);
        Console.WriteLine(i + ") Task name: " + CompletedList[i].Name + ", current date: " + CompletedList[i].Deadline);
    }

    Console.ReadKey();
    // return to main menu
    MainMenu();

}
void ViewUncompletedListbyName()
{
    //var sortedValue = TasksUndone.Values.OrderBy(value => value).ToList();
    var sortedTasks = Uncompleted.OrderBy(task => task.Name).ToList(); 
    foreach (var task in sortedTasks)
    {
        Console.WriteLine("Task: " + task.Name + ", Deadline: " + task.Deadline);
    }
    Console.ReadKey();
    MainMenu();
}

void SortListByDate()
{
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
    Console.WriteLine("Welcome to Todo List! \nYou have " + Uncompleted.Count + " tasks to do and " + Uncompleted.Count + " completed. \nPick an option: ");
    Console.WriteLine("1) View todo list");
    Console.WriteLine("2) Add Task to your todo list");
    Console.WriteLine("3) change date \n4) Mark Task as done");

    string answer = "";
    answer = Console.ReadLine();

    if (answer == "1") 
    { 
        //ViewUncompletedListbyName();
        ShowTaskList();
    }
    else if (answer == "2") { AddTaskToList(); }
    else if (answer == "3") { ChangeDate(); }
    else if(answer == "4") { TaskIsCompleted(); }
    else if(answer == "5") { RemoveTask(); }
   // else if(answer == "4") { sortListbyName(); }
    else { Console.WriteLine("temp"); }

}

void TaskIsCompleted()
{
    var sortedUncompletedTasks = Uncompleted.OrderBy(task => task.Deadline).ToList();
    for (int i = 0; i < sortedUncompletedTasks.Count; i++)
    {
        Console.WriteLine(i + ") Task: " + sortedUncompletedTasks[i].Name + ", Deadline: " + sortedUncompletedTasks[i].Deadline);
    }
    Console.WriteLine("Enter the number of the completed task: ");
    int answer = Convert.ToInt32(Console.ReadLine());
    CompletedList.Add(new TaskCompleted(sortedUncompletedTasks[answer].Name, sortedUncompletedTasks[answer].Deadline));
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
    Console.WriteLine("Enter the number of the task you would like to change: ");
    int answer = Convert.ToInt32(Console.ReadLine());
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("The  following task will be removed:");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine(answer + ") Task: " + sortedUncompletedTasks[answer].Name + ", Deadline: " + sortedUncompletedTasks[answer].Deadline);
    Uncompleted.Remove(sortedUncompletedTasks[answer]); // Remove directly from sorted list
    Console.ReadKey();
    MainMenu();
}






class TaskUndone 

{
    public TaskUndone(string name, int deadline)
    {
        Name = name;
        Deadline = deadline;
    }
    public string Name { get; set; }
    public int Deadline { get; set; }

}

class TaskCompleted
{
    public TaskCompleted(string name, int deadline)
    {
        Name = name;
        Deadline = deadline;
    }
    public string Name { get; set; }
    public int Deadline { get; set; }
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
