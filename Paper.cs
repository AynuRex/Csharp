using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Paper:IComparable,IComparer<Paper>
    {
        public string Title {get;set;}
        public Person Author { get; set; }
        public DateTime DatPub { get; set; }
        public Paper(string _title,Person _author, DateTime _datPub)
        {
            Title = _title;
            Author = _author;
            DatPub = _datPub;
        }
        public Paper()
        {
            Title = "In Goosee World";
            DatPub = new DateTime(2018, 01, 18);
            Author = new Person();
        }
        public override string ToString()
        {
            string _paper = Title + " " + Author.ToShortString() + " " + DatPub.ToString();
            return _paper;
        }
        public int CompareTo(object obj)
        {
            Paper obj1 = obj as Paper;

            if (DatPub < obj1.DatPub)
                return -1;
            else if (DatPub == obj1.DatPub)
                return 0;
            else
                return 1;
        }

        public int Compare(Paper x, Paper y)
        {
            return x.Title.CompareTo(y.Title);
        }
    }
}
