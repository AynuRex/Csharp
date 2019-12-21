using System;

namespace ConsoleApp2
{
    class Person:IDateAndCopy
    {
        string name;
        string sirname;
        System.DateTime birthDate;        

        public Person(string _name, string _sirname, DateTime _birthDate)
        {
            name = _name;
            sirname = _sirname;
            birthDate = _birthDate;
        }

        public Person()
        {
            name = "Oleg";
            sirname = "Lavrent'ev";
            birthDate = new DateTime(2000, 10, 25);
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        
        public string Sirname
        {
            get
            {
                return sirname;
            }
            set
            {
                sirname = value;
            }
        }
        


        public DateTime BirthDate
        {
            get
            {
                return birthDate;
            }
            set
            {
                birthDate = value;
            }
        }
        public int BirthDateYear
        {
            get
            {
                return birthDate.Year;
            }
            set
            {
                birthDate = new DateTime(value, birthDate.Month, birthDate.Day);
            }
        }

        public override string ToString()
        {
            string _person = sirname + " " + name + " " + birthDate.ToString();
            return _person;
        }
        public virtual string ToShortString()
        {
            string _person = sirname + " " + name;
            return _person;
        }

        public virtual object DeepCopy()
        {
             Person person1 = new Person();
            person1.name = Name;
            person1.sirname = sirname;
            person1.birthDate = new DateTime(birthDate.Year, BirthDate.Month, birthDate.Day);
            return person1;
        }

        public  override bool Equals(object obj)
        {
            if (this.GetType() != obj.GetType())
                return false;
            if (this.name == ((Person)obj).name && this.sirname == ((Person)obj).sirname && this.birthDate == ((Person)obj).birthDate)
                return true;
            else
                return false;
        }
        public static bool operator==(Person obj1,Person obj2)
        {
            return obj1.Equals(obj2);
        }
        public static bool operator!=(Person obj1, Person obj2)
        {
            return !(obj1.Equals(obj2));
        }
    }
}
