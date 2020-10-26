using Router.Attributes;

namespace ToDoo
{
    [Utility(UtilityName = "todo")]
    public class ToDoApi
    {
        private ToDoService Service { get; set; }

        [Command(CommandName = "add", Parameters = "[Start datetime] [ToDoType]")]
        public void AddToDo(string startDateTime, int toDoType)
        {

        }
        
        [Command(CommandName = "add", Parameters = "[Start datetime] [ToDoType] {[Sunday] [Monday] [Tuesday] [Wednesday] [Thursday] [Friday] [Saturday]}")]
        public void AddToDo(string startDateTime, int toDoType, params int[] dayOfWeek)
        {

        }
    }
}