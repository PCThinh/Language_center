using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace English_center
{
    internal class MainController
    {
        MainModel mainmodel=new MainModel();
        
        public string check(string name)
        {
            return mainmodel.checkusername(name);
        }
    }
}
