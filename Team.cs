using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    class Team : IDateAndCopy
    {
        protected string organization;
        protected int ID;


        public string Name { get; set; }
        public virtual object DeepCopy()
        {
            Team team1 = new Team();
            team1.organization = organization;
            team1.ID = ID;
            return team1;
        }
        
        public String Org
        {
            get
            {
                return organization;
            }
            set
            {
                organization = value;
            }

        }

        public Team(string name_, int ID_)
            {
            organization=name_;
            ID = ID_;
            }

        public Team()
        {
            organization = "GOGOOGOGOGO";
            ID = 0;
        }

        public int Iden
        {
            get
            {
                return ID;
            }
            set
            {
                if (value<0)
                {
                    string str = "iNDEX OUT OF RANGE";
                    throw new System.IndexOutOfRangeException(str);
                }
            }
        }
        public override bool Equals(object obj)
        {
            if (this.GetType() != obj.GetType())
                return false;
            if (this.organization == ((Team)obj).organization && this.ID == ((Team)obj).ID)
                return true;
            else
                return false;
        }
        public static bool operator ==(Team obj1, Team obj2)
        {
            return obj1.Equals(obj2);
        }
        public static bool operator !=(Team obj1, Team obj2)
        {
            return !(obj1.Equals(obj2));
        }
        public override string ToString()
        {
            return organization + " "+ID.ToString();
        }
        public override int GetHashCode()
        {
            return ToString().GetHashCode()*3+10;
        }


    }

}
