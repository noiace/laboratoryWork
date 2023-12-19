using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab9
{
    class Test
    {
        public string Subject{ get; set; }
        public bool 
            
            
            
            
            
            
            
            
            
            
            
            isPassed{ get; set; }

        public Test(string Subject, bool isPassed)
        {
            this.Subject = Subject;
            this.isPassed = isPassed;
        }
        public Test()
        {
            this.Subject = "BD";
            this.isPassed = false;
        }
        public override string ToString()
        {
            return $"{Subject} {isPassed}";
        }
    }
}
