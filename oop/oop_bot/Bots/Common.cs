using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Xml;

namespace Chat_Bot
{
   enum Keyword
   {
        Hello = 0,
        Bye = 1,
        Name = 2,
        Time,
        Add,
        Sub,
        Mult,
        Div,
        Exchange,
        Run,
        Math,
        Unknown
    }
}
