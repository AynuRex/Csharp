using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    interface IDateAndCopy
    {
        string Name { get; set; }
        object DeepCopy();
        
    }
}
