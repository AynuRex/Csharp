using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    class TeamsJournal
    {
        List<TeamJournalEntry> changeList = new List<TeamJournalEntry>();
         public void handler(object obj ,ResearchTeamChangedEventsArgs arg)
        {           
            TeamJournalEntry buffer = new TeamJournalEntry(arg.CollectionName, arg.Changes, arg.EventSourceFunc, arg.IdRes);
            changeList.Add(buffer);
        }
        public override string ToString()
        {
            string str="";
            foreach (TeamJournalEntry teamJournal in changeList)
                str = str + teamJournal.ToString()+"\n";
            return str;
        }
    }

}
