// See https://aka.ms/new-console-template for more information
List<string> TaskName = new List<string>();
List<int> TaskDate = new List<int>();
List<bool> isTaskCompleted = new List<bool>();

Dictionary<string, int> TasksUndone = new Dictionary<string, int>();
Dictionary<string, int> TasksCompleted = new Dictionary<string, int>();

//Adding random numbers so it won't be empty the first time (mainly used for debugging)
TasksUndone.Add("-.-", 9);
TasksUndone.Add("Coding", 2);
TasksUndone.Add("Food", 5);
TasksUndone.Add("Pommes", 3);
TasksUndone.Add("Chocolate", 8);

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
    
    TasksUndone.Add(answer, date);
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
    for (int i = 0; i < TasksUndone.Count; i++)
    {
        Console.WriteLine(i + " " + TasksUndone.Keys.ElementAt(i) + ", current date: " + TasksUndone.Values.ElementAt(i));
    }

    selected = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine("What would you like to change it to? ");
    newDate = Convert.ToInt32(Console.ReadLine());
    
    //Change selected valuse to new date
    string selectedTask = TasksUndone.Keys.ElementAt(selected);
    TasksUndone[selectedTask] = newDate;

    //Displays the new date to user
    Console.WriteLine("The Task: " + TasksUndone.Keys.ElementAt(selected) + " have changed it's deadline to: " + TasksUndone.Values.ElementAt(selected));

    // return to Main menu
    MainMenu();

}

void ShowTaskList()
{
    Console.WriteLine(" Your todo list:");
    
    // Displays the task list
    for (int i = 0; i < TasksUndone.Count; i++)
    {
        //Console.WriteLine(i + ") Task name:" + TaskName[i] + ", current date: " + TaskDate[i] + ", status: " + isTaskCompleted[i]);
        Console.WriteLine(i + ") Task name: " + TasksUndone.Keys.ElementAt(i) + ", current date: " + TasksUndone.Values.ElementAt(i));
    }
    Console.ReadKey();
    // return to main menu
    MainMenu();

}
void sortListbyName()
{
    var sortedKeys = TasksUndone.Keys.OrderBy(key => key).ToList(); // Fick hjälp av chat GPT med den här raden, fick inte ihop det, ska kolla LINQ igen
    foreach (var key in sortedKeys)
    {
        Console.WriteLine("Task: " + key + ", Deadline: " + TasksUndone[key]);
    }
    Console.ReadKey();
    MainMenu();
}

void SortListByDate()
{
    var sortedKeys = TasksUndone.Keys.OrderBy(key => TasksUndone[key]).ToList();
    foreach (var key in sortedKeys)
    {
        Console.WriteLine("Task: " + key + ", Deadline: " + TasksUndone[key]);
    }
    Console.ReadKey();
    MainMenu();
}


void MainMenu()
{
    Console.Clear();
    Console.WriteLine("Welcome to Todo List! \nYou have " + TasksUndone.Count + " tasks to do and " + TasksCompleted.Count + " completed. \nPick an option: ");
    Console.WriteLine("1) View todo list");
    Console.WriteLine("2) Add Task to your todo list");
    Console.WriteLine("3) change date");

    string answer = "";
    answer = Console.ReadLine();

    if (answer == "1") { sortListbyName(); }
    else if (answer == "2") { AddTaskToList(); }
    else if (answer == "3") { ChangeDate(); }
   // else if(answer == "4") { sortListbyName(); }
    else { Console.WriteLine("temp"); }

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
