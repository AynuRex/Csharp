using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    class TeamJournalEntry
    {
        public string CollectionName { get; set; }
        public Revision Changes { get; set; }
        public string EventSourceFunc { get; set; }
        public int IdRes { get; set; }
        public TeamJournalEntry(string _collectionName, Revision _changed, string _eventSourceFunc, int _IdRes)
        {
            CollectionName = _collectionName;
            Changes = _changed;
            EventSourceFunc = _eventSourceFunc;
            IdRes = _IdRes;
        }
        public override string ToString()
        {
            return CollectionName+ " " + Changes+" " + EventSourceFunc + " "+ IdRes.ToString();
        }

    }
}
