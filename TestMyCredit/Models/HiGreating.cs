using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestMyCredit.Models
{
    public class HiGreating : IGreeter
    {
        public string SayHello()
        {
            return "Hi everyone!";
        }
    }
}