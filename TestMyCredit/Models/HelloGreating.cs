using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestMyCredit.Models
{
    public class HelloGreating : IGreeter
    {
        public string SayHello()
        {
            return "Hi there!";
        }
    }
}