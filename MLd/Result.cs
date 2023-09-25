using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLd
{
    public class Result
    {
        public bool Correct { get; set; }
        public object Object { get; set; }
        public List<object> Objetcs { get; set; }
        public string ErrorMessage { get; set; }
        public Exception Ex { get; set; }
    }
}
