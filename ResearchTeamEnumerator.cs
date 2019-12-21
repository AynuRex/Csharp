using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{ 
    class ResearchTeamEnumerator : IEnumerator    

    {
        private List<Person> persons;
        private List<Paper> papers;
        int index = -1;
        public  ResearchTeamEnumerator(List<Person> _persons, List<Paper> _papers)
        {
            persons = new List<Person>(_persons);
            papers = new List<Paper>(_papers);
        }
        public IEnumerable GetEnumerator()
        {           
            for (int i=0;i<persons.Count;i++)
            {
                for (int j = 0; j < papers.Count; j++)
                {
                    Paper p = papers[j] as Paper;
                    if (p.Author == (Person)persons[i])
                    {
                        yield return persons[i];
                    }
                }
                
            }
        }
        public object Current { get { return persons[index]; }}
        public void Reset()
        {
                index = -1;
        }

        public bool MoveNext()
        { 
            if (index == persons.Count - 1)
            {
                Reset();
                return false;
            }
            index++;
            return true;

            
        }

        
    }
}
