using BoardR.Loggers;

namespace BoardR
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            DateTime tomorrow = DateTime.Now.AddDays(1);
            BoardItem task = new Task("Write unit tests", "Peter", tomorrow);
            BoardItem issue = new Issue("Review tests", "Someone must review Peter's tests.", tomorrow);

            Board.AddItem(task);
            Board.AddItem(issue);
            task.AdvanceStatus();
            issue.AdvanceStatus();

            Board.LogHistory(new ConsoleLogger());

            //Console.WriteLine(task.ViewInfo()); 
            //Console.WriteLine(issue.ViewInfo()); 
        }
    }
}