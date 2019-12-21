using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
 delegate Tkey KeySelector<Tkey>(ResearchTeam rt);
    class Program
    {
        static void Main(string[] args)
        {
            Team team1 = new Team("fghfh", 44);
            Team team2 = (Team)team1.DeepCopy();
            team1.Org = "fg";
            Console.WriteLine(team1.ToString());
            Console.WriteLine(team2.ToString());
            if (team1 == team2)
                Console.WriteLine("TRUE\n");
            else
                Console.WriteLine("False\n");
            try
            {
                team1.Iden = -5;
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex);
            }

            ResearchTeam res = new ResearchTeam();
            res.AddMembers(new Person("dfghdfg", "rthhrh", new DateTime(2015, 9, 12)), new Person());
            res.AddPapers(new Paper());
            res.AddPapers(new Paper("eettey", new Person("fhrht", "rhrthrh", new DateTime(4, 4, 4)), new DateTime(9, 9, 9)));
            res.AddPapers(new Paper("blabla", new Person("hherh", "cnnnrh", new DateTime(3, 3, 3)), new DateTime(3000, 5, 3)));
            Console.WriteLine(res.ToString());

            Console.WriteLine(res.Tea);

            ResearchTeam res1 = (ResearchTeam)res.DeepCopy();

            res.AddPapers(new Paper("sdgg", new Person("FDGDF", "RFHRHR", new DateTime()), new DateTime(2000, 5, 5)));
            Console.WriteLine(res.ToString());
            Console.WriteLine("\n");
            Console.WriteLine(res1.ToString());

            Console.WriteLine("\n");

            foreach (Person c in res1.GetPersons())
            {
                Console.WriteLine(c.ToString());
            }
            Console.WriteLine("\n");
            foreach (Paper c in res.GetLasts(20))
            {
                Console.WriteLine(c.ToString());
            }
            ResearchTeamEnumerator research = new ResearchTeamEnumerator(res1.Persons, res1.Papers);
            Console.WriteLine("---------------------------------");
            foreach (Person c in research.GetEnumerator())
            {
                Console.WriteLine(c.ToString());
            }
            Console.WriteLine("---------------------------------");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("---------------------------------");
            Console.WriteLine();
            res1.SortByDate();
            Console.WriteLine(res1);
            Console.WriteLine("---------------------------------");
            res1.SortByPub();
            Console.WriteLine(res1);
            Console.WriteLine("---------------------------------");
            res1.SortByAuthor();
            Console.WriteLine(res1);
            Console.WriteLine("********************************");

            string KeySelector1(ResearchTeam re)
            {
                return re.ToString();
            }
            ResearchTeamCollection<string> rescol = new ResearchTeamCollection<string>(KeySelector1);
            rescol.AddDefaults();
            ResearchTeam team = new ResearchTeam("gh", "dfhfgh", 45, (TimeFrame)2);
            team.AddPapers(new Paper(), new Paper("fgfg", new Person(), new DateTime(56, 2, 2)));
            rescol.AddResearchTeams(team);
            rescol.AddResearchTeams(res1);
            Console.WriteLine(rescol.ToString());
            Console.WriteLine(rescol.LastDate.ToString());
            List<IGrouping<TimeFrame, KeyValuePair<string, ResearchTeam>>> groups = rescol.TimeFrameGroupBy.ToList();
            foreach (IGrouping<TimeFrame, KeyValuePair<string, ResearchTeam>> group in groups)
            {
                foreach (KeyValuePair<string, ResearchTeam> pair in group)
                    Console.WriteLine(pair.Value);
            }
            Console.WriteLine("********************************");
            foreach (KeyValuePair<string, ResearchTeam> somePair in rescol.TimeFrameGroup(TimeFrame.Long))
            {
                Console.WriteLine(somePair.Value);
            }
            GenerateElement<Team, ResearchTeam> f = ((j) =>
            {
                KeyValuePair<Team, ResearchTeam> pair = new KeyValuePair<Team, ResearchTeam>(new Team("goose goose ura", j), new ResearchTeam());
                return pair;
            });
            int i = 0;
            string input = string.Empty;
            int key = 0;
            while (key == 0)
            {
                Console.WriteLine("input number:");
                key = 1;
                try
                {
                    input = Console.ReadLine();
                    i = int.Parse(input);
                }
                catch (FormatException)
                {
                    key = 0;
                    Console.WriteLine($"Unable to parse '{input}'");
                }

            }


            TestCollections<Team, ResearchTeam> test = new TestCollections<Team, ResearchTeam>(i, i, i, i, f);
            test.countTime(0, f);
            Console.WriteLine("-----------------------------------------------");
            test.countTime(i / 2, f);
            Console.WriteLine("-----------------------------------------------");
            test.countTime(i - 1, f);
            Console.WriteLine("-----------------------------------------------");
            test.countTime(i, f);
            Console.WriteLine("/////////////////////////////////////////////////////////////");
            Console.WriteLine("GOOSE Gooose URA");
            Console.WriteLine("GOOSE Gooose URA");
            Console.WriteLine("GOOSE Gooose URA");
            ResearchTeamCollection<string> col1 = new ResearchTeamCollection<string>(KeySelector1);
            ResearchTeamCollection<string> col2 = new ResearchTeamCollection<string>(KeySelector1);
            TeamsJournal journal = new TeamsJournal();

            col1.ResearchTeamChanged += journal.handler;
            col1.AddDefaults();
            col1.AddResearchTeams(res1);
            res1.Theme = "In Lion world";
            col1.Remove(res1);
            res1.Theme = "In Traiter world";
            col1.AddResearchTeams(res1);
            col1.Replace(res1, new ResearchTeam());
            res1.Theme = "In war World ";
            Console.WriteLine(journal.ToString());
        }
    }
}