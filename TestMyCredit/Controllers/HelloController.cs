﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TestMyCredit.Controllers
{
    public class HelloController : ApiController
    {
        private Models.IGreeter m_greeter;

        public HelloController(Models.IGreeter greeter)
        {
            m_greeter = greeter;
        }

        public string Get()
        {
            return m_greeter.SayHello();
        }
    }
}

