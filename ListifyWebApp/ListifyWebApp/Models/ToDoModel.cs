using System.ComponentModel.DataAnnotations;

namespace ListifyWebApp.Models
{
    /// <summary>
    /// This Model is for ToDo List
    /// </summary>
    public class ToDoModel
    {
        /// <summary>
        /// This is used for user to get their userId for each account
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// This is used for user to get their id in ToDoList
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// This is used to enter a text in the title by the user
        /// </summary>
        [Required(ErrorMessage = "Please enter the title to continue")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string Title { get; set; }
        /// <summary>
        /// This is used to enter a text in the description field bu the user
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// This is used to enter a date
        /// </summary>
        [Required(ErrorMessage = "Please enter a date to continue")]
        public string date { get; set; }
        
    }
}