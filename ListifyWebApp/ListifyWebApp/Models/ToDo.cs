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
    public class ToDo
    {
        /// <summary>
        /// This is used for each list item in ToDo list
        /// </summary>
        [Key]
        [Column(Order = 0)]
        public int Id { get; set; }

        /// <summary>
        /// This is required to enter a title by the user in ToDo list
        /// </summary>
        [Column(Order = 1)]
        public string Title { get; set; }

        /// <summary>
        /// This is required to enter a description by the user in ToDo list
        /// </summary>
        [Column(Order = 2)]
        public string Description { get; set; }

        /// <summary>
        /// This is required to enter a date by the user in ToDo list
        /// </summary>
        [Column(Order = 3)]
        public DateTime Date { get; set; }

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
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column(Order = 6)]
        public long? DeletedUserId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column(Order = 7)]
        public DateTime? DeletionTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column(Order = 8)]
        public DateTime? LastModificationTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column(Order = 9)]
        public long? LastModifierUserId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column(Order = 10)]
        public DateTime? CreationTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column(Order = 11)]
        public long? CreatorUserId { get; set; }
    }
}
