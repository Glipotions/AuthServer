using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthServer.Core.Configuration
{
    public class Client
    {
        public string Id { get; set; }
        public string Secret { get; set; }



        /// <summary>
        /// Token'in hangi apiler'e erişebileceğini bu string aracılığıyla belirleriz.
        /// 
        /// </summary>
        public List<string> Audiences { get; set; }
    }
}
