using SQLite;

namespace ToDoList
{
    [Table("items")]
    /// <summary>
    /// Basic object/item model for the items shown in the application.
    /// </summary>
    public class ToDoItem
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        /// <summary>
        /// Name/description of your task.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Whether the item is flagged as important.
        /// </summary>
        public bool Important { get; set; }
    }
}
