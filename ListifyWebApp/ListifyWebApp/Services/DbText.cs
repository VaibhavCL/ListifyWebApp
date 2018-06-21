using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ListifyWebApp.Services
{
    /// <summary>
    /// It is a class that implements the interface IDbText
    /// </summary>
    public class DbText : IDbText
    {
        private List<UserMaster> users = new List<UserMaster>();
        /// <summary>
        /// 
        /// </summary>
        public  int Id = 1;

        /// <summary>
        /// Constructor
        /// </summary>
        public DbText()
        {
            // Add products for the Demonstration  
            Add(new UserMaster { Name = "User1", EmailID = "user1@test.com", MobileNo = "1234567890" });
            Add(new UserMaster { Name = "User2", EmailID = "user2@test.com", MobileNo = "1234567890" });
            Add(new UserMaster { Name = "User3", EmailID = "user3@test.com", MobileNo = "1234567890" });
        }

         UserMaster Add(UserMaster item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            item.ID = Id++;
            users.Add(item);
            return item;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            users.RemoveAll(p => p.ID == id);
            return true;
        }

         UserMaster Get(int id)
        {
            return users.FirstOrDefault(x => x.ID == id);
        }

         IEnumerable<UserMaster> GetAll()
        {
            return users;
        }

         bool Update(UserMaster item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }


            int index = users.FindIndex(p => p.ID == item.ID);
            if (index == -1)
            {
                return false;
            }
            users.RemoveAt(index);
            users.Add(item);
            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="zipCode"></param>
        /// <returns></returns>
        public string GetText(string zipCode)
        {
            throw new NotImplementedException();
        }
    }
 
}