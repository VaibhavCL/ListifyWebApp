using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListifyWebApp.Services
{
    /// <summary>
    /// Interface IDbText
    /// </summary>
    public interface IDbText
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="zipCode"></param>
        /// <returns></returns>
        string GetText(string zipCode);
    }
}
