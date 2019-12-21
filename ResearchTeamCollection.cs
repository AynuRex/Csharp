using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ConsoleApp2
{
    class ResearchTeamCollection<Tkey>
    {
        public  event ResearchTeamsChangedHandler ResearchTeamChanged;
        Dictionary<Tkey, ResearchTeam> dicti = new Dictionary<Tkey, ResearchTeam>();
        KeySelector<Tkey> keySelector;
        
        public string CollectionName { get; set; }

        public ResearchTeamCollection(KeySelector<Tkey> _keySelector)
        {
            keySelector = _keySelector;           
        }
        public void AddDefaults()
        {
            ResearchTeam[] reses = { new ResearchTeam("fgfgg", "fjfjfjfh", 4, (TimeFrame)2) };
            AddResearchTeams(reses);
        }


        public void AddResearchTeams(params ResearchTeam[] researches)
        {
            foreach (ResearchTeam research in researches)
            {
                ResearchTeamChanged?.Invoke(this, new ResearchTeamChangedEventsArgs(CollectionName, (Revision)2, " all Properties", research.Id));
                dicti.Add(keySelector(research), research);
                research.PropertyChanged += this.Smth;

            }

        }
        public void Smth(object sender,System.ComponentModel.PropertyChangedEventArgs e)
        {
            ResearchTeam rt = sender as ResearchTeam;
            ResearchTeamChanged?.Invoke(this, new ResearchTeamChangedEventsArgs(CollectionName, (Revision)2, e.PropertyName, rt.Id));
        }
        public override string ToString()
        {
            string result = "";
            foreach(ResearchTeam research in dicti.Values )
            {
                result = result + research.ToString();
                result = result + "\n---------------------------------------\n";
            }
            return result;
        }
        public virtual string ToShortString()
        {
            string result = "";
            foreach (ResearchTeam research in dicti.Values)
            {
                result = result + research.ToShortString();
                result = result + "\n---------------------------------------\n";
            }
            return result;
        }
        public DateTime LastDate
        {
            get
            {
                bool flag = false;
                foreach(ResearchTeam research in dicti.Values)
                    if (research.LastPaper != null)
                    {
                        flag = true;
                        break;
                    }
                if (flag == true)
                    return dicti.Max(pair => pair.Value.Papers.Max(paper => paper.DatPub));
                else return new DateTime();
            }
        }
        public IEnumerable<KeyValuePair<Tkey,ResearchTeam>> TimeFrameGroup(TimeFrame time)
        {
           return dicti.Where(res => res.Value.Period == time);
        }
        public IEnumerable<IGrouping<TimeFrame, KeyValuePair<Tkey, ResearchTeam>>> TimeFrameGroupBy
        {
            get
            {
                return dicti.GroupBy(someMag => someMag.Value.Period);
            }
        }
        public bool Remove(ResearchTeam rs)
        {            
            foreach(KeyValuePair<Tkey,ResearchTeam> pair in dicti)
            {
                if (rs == pair.Value)
                {
                    dicti.Remove(pair.Key);
                    ResearchTeamChanged?.Invoke(this, new ResearchTeamChangedEventsArgs(CollectionName, (Revision)0, " ", pair.Value.Id));
                    rs.PropertyChanged -= this.Smth;
                    return true;
                }
            }
            return false;
        }
        public bool Replace(ResearchTeam rtold,ResearchTeam rtnew)
        {
            foreach (KeyValuePair<Tkey, ResearchTeam> pair in dicti)
            {
                if (rtold == pair.Value)
                {
                    dicti[pair.Key] = rtnew;
                    ResearchTeamChanged?.Invoke(this, new ResearchTeamChangedEventsArgs(CollectionName, (Revision)1, " ", pair.Value.Id));
                    rtold.PropertyChanged -= this.Smth;
                    return true;
                }
            }
            return false;
        }
        public ResearchTeam this[Tkey key]
        {
            get
            {
                return dicti[key];
            }           
        }

        
    }

}
