using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.ComponentModel;
namespace ConsoleApp2
{
    class ResearchTeam : Team,INotifyPropertyChanged
    {

        string theme;
        TimeFrame period;
        List<Person> persons;
        List<Paper> papers;
        public event PropertyChangedEventHandler PropertyChanged;

        
        public ResearchTeam(string _theme, string _organization, int Id, TimeFrame _period)
        {
            theme = _theme;
            organization = _organization;
            period = _period;
            ID = Id;
            persons = new List<Person>();         
            papers = new List<Paper>();
            AddPapers(new Paper());
        }
        public ResearchTeam()
        {           
            theme = "Goose";
            organization = "GOOGOGOOGOGO";
            period = TimeFrame.TwoYears;
            persons = new List<Person>();
            papers = new List<Paper>();
            AddPapers(new Paper());
        }
       

        public string Theme
        {
            get
            {
                return theme;
            }
            set
            {
                
                theme = value;
                PropertyChanged(this, new PropertyChangedEventArgs(string.Format("Theme changed to {0}", value)));
            }
        }
        public string Organization
        {
            get
            {
                return organization;
            }
            set
            {
                organization = value;
                PropertyChanged(this, new PropertyChangedEventArgs(string.Format("Organization changed to {0}", value)));

            }
        }
        public List<Paper> Papers
        {
            get
            {
                return papers;
            }
            set
            {
                papers = value;
                PropertyChanged(this, new PropertyChangedEventArgs(string.Format("Papers changed to {0}", value)));

            }
        }
        public List<Person> Persons
        {
            get
                    {
                return persons;
            }
            set
                    {
                persons = value;
                PropertyChanged(this, new PropertyChangedEventArgs(string.Format("Persons changed to {0}", value)));

            }

        }
        public int Id
        {
            get
            {
                return ID;
            }
            set
            {
                ID = value;
                PropertyChanged(this, new PropertyChangedEventArgs(string.Format("ID changed to {0}", value)));

            }
        }
        


        public TimeFrame Period
        {
            get
            {
                return period;
            }
            set
            {
                period = value;
            }
        }
       
          
        public Paper LastPaper
        {
            get
            {
                if (papers.Count == 0)
                    return null;
                else
                {
                    Paper last = new Paper();
                    last = (Paper)papers[0];
                    for (int i = 1; i < Papers.Count; i++)
                    {
                        if (last.DatPub > ((Paper)papers[i]).DatPub)
                            last = (Paper)papers[i];
                    }
                    return last;
                }
            }
        }

        public bool this[TimeFrame i]
        {
            get
            {
                if (i == period)
                    return true;
                else
                    return false;
            }
        }
        public void AddPapers(params Paper[] pps)
        {
            int j = 0;            
           while (j < pps.Length){
                papers.Add(pps[j]) ;               
                ++j;
            }            
                
        }
        public void AddMembers(params Person[] pps)
        {
            int j = 0;
            while (j < pps.Length)
            {
                persons.Add(pps[j]);               
                ++j;
            }
        }


        public Team Tea
        {
            get
            {
                Team SomeTeam = new Team();
                SomeTeam.Org = organization;
                SomeTeam.Iden = ID;
                return SomeTeam;
            }
            set
            {
                base.organization = ((Team)value).Org;
                base.ID = ((Team)value).Iden;
            }

        }

        public override string ToString()
        {
            string res = theme + " " + organization + " " + ID.ToString() + " " + period.ToString();
            for (int i = 0; i <papers.Count; i++)
                res = res+ "\n" +   (i + 1) + " paper--" + papers[i].ToString();
            for (int i=0;i<persons.Count;i++)
                res = res+ "\n "+(i+1)+ " persons--" + persons[i].ToString();
            return res;
        }
        public virtual string ToShortString()
        {
            string res= theme + " " + organization + " " + ID.ToString() + " " + period.ToString();
            return res;
        }

        public override object DeepCopy()
        {
            ResearchTeam res1 = new ResearchTeam();
            res1.organization = organization;
            res1.ID = ID;
            res1.period = period;
            res1.theme = theme;
            for (int i = 0; i < papers.Count; i++)
                res1.papers.Add(papers[i]);
            for (int i = 0; i < persons.Count; i++)
                res1.persons.Add(persons[i]);
            return res1;
        }

        public IEnumerable GetPersons()
        {
            for(int i=0;i<Persons.Count;i++)
            {
                bool flag = true;
                for(int j=0;j<papers.Count;j++)
                {
                    if ((Person)Persons[i]==((Paper)papers[j]).Author)
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag == true)
                    yield return persons[i];
                        
            }
            yield break;
        }

        public IEnumerable GetLasts(int n)
        {
            DateTime date = DateTime.Today;
            for(int i=0;i<papers.Count;i++)
            {
                if (((Paper)papers[i]).DatPub.Year > date.Year - n)
                    yield return papers[i];
            }
            yield break;
        }
        public void SortByDate()
        {
            Papers.Sort((a, b) => a.CompareTo(b));
        }
        public void SortByPub()
        {
            Papers.Sort((a, b) => a.Compare(a, b));
        }
        public void SortByAuthor()
        {
            PaperComparer paperComparer = new PaperComparer();
            Papers.Sort((a, b) => paperComparer.Compare(a, b));
        }
    }

}
