using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    class PaperComparer : IComparer<Paper>
    {
        public int Compare(Paper x, Paper y)
        {
            int k = x.Author.Sirname.CompareTo(y.Author.Sirname);
            if (k == 0)
                k = x.Author.Name.CompareTo(y.Author.Name);
            return k;
        }  
    }
}
