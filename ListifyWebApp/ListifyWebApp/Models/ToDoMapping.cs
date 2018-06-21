using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListifyWebApp.Models
{
    /// <summary>
    /// This is a class from database ListifyDB
    /// </summary>
    public class ToDoMapping
    {
        /// <summary>
        /// Id is used for each list item in ToDo list as users id
        /// </summary>
        [Key]
        [Column(Order = 0)]
        public int Id { get; set; }

        /// <summary>
        /// This is used for each list item in ToDo list
        /// </summary>
        [ForeignKey("ToDo")]
        [Column(Order = 1)]
        public int TodoId { get; set; }

        /// <summary>
        /// UserId is an unique id for the user
        /// </summary>
        [Column(Order = 2)]
        public string UserId { get; set; }
        
        /// <summary>
        /// It is column for user to enter a date in ToDo list
        /// </summary>
        [Column(Order = 3)]
        public DateTime? Date { get; set; }

        /// <summary>
        /// To check whether the user is active or not and returns true, if the user is active, and returns 
        /// false if the user is inactive
        /// </summary>
        [Column(Order = 4)]
        public bool IsActive { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column(Order = 5)]
        public long? DeletedUserId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column(Order = 6)]
        public DateTime? DeletionTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column(Order = 7)]
        public DateTime? LastModificationTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column(Order = 8)]
        public long? LastModifierUserId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column(Order = 9)]
        public DateTime? CreationTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column(Order = 10)]
        public long? CreatorUserId { get; set; }

        /// <summary>
        /// User is used to create an object for the ApplicationUser Class
        /// </summary>
        public ApplicationUser User { get; set; }

        /// <summary>
        /// Creating an instance of ToDo
        /// </summary>
        public ToDo ToDo { get; set; }
    }
}
