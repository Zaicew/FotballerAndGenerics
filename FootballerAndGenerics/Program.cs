using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballerAndGenerics
{
    class Program
    {
        static void Main(string[] args)
        {
            Person o = new Person("Adak", "Adacki", "20.03.1980");
            Person o2 = new Student("Babak", "Babacki", "13.04.1990", 2, 1, 12345);
            Person o3 = new Footballer("Cabak", "Cabacki", "10.08.1986", "defence", "FC Barcelona");

            Console.WriteLine(o.ToString());
            Console.WriteLine(o2.ToString());
            Console.WriteLine(o3.ToString());

            Student stu = new Student("Dabak", "Dabacki", "22.12.1990", 2, 5, 54321);
            Footballer soc = new Footballer("Ebak", "Ebacki", "14.09.1984", "attack", "Chelsea");

            Console.WriteLine(stu.ToString());
            Console.WriteLine(soc.ToString());

            ((Footballer)o3).ScoreAGoal();
            soc.ScoreAGoal();
            soc.ScoreAGoal();

            FootballPlayer f1 = new FootballPlayer("Fabak", "Fabacki", "14.09.1984", "attack", "Chelsea");

            f1.ScoreAGoal();

            Console.WriteLine(f1.ToString());

            HandballPlayer h1 = new HandballPlayer("Gabak", "Gabacki", "05.05.2020", "Defence", "HanPlay");

            h1.ScoreAGoal();

            Console.WriteLine(h1.ToString());
            Console.WriteLine(o3.ToString());
            Console.WriteLine(soc.ToString());

            Console.WriteLine("-----------------------------------");

            ((Student)o2).AddRate("PO", "14.03.2020", 5.0);
            ((Student)o2).AddRate("Databases", "14.03.2020", 4.0);

            Console.WriteLine(o2.ToString());

            stu.AddRate("Databases", "01.05.2019", 5.0);
            stu.AddRate("Computer Science", "13.03.2020", 5.5);
            stu.AddRate("Computer technology", "15.03.2020", 3.5);
            Console.WriteLine("---------------Powinny być 3 oceny -------------");

            Console.WriteLine(stu.ToString());

            Console.WriteLine("---------------Powinny być 2 oceny -------------");

            stu.DeleteRate("Computer technology", "15.03.2020", 3.5);

            Console.WriteLine(stu.ToString());

            stu.AddRate("AWW", "02.04.2011", 4.5);
            stu.DeleteAllRates();

            Console.WriteLine("---------------Powinny być 0 oceny -------------");

            Console.WriteLine(stu.ToString());


            Console.ReadKey();


        }
    }
}

class Person
{
    protected string name;
    protected string surname;
    protected string dateOfBirth;

    public Person()
    {
        this.name = "noname";
        this.surname = "nosurname";
        this.dateOfBirth = Convert.ToString(DateTime.Today);
    }

    public Person(string name_, string surname_, string dateOfBirth_)
    {
        this.name = name_;
        this.surname = surname_;
        this.dateOfBirth = dateOfBirth_;
    }

    public override string ToString()
    {
        return "Name: " + name + ", surname: " + surname + ", date of birth: " + dateOfBirth;
    }
}

class Student : Person 
{
    private int year;
    private int group;
    private int nrOfIndex;
    //private int rate;
    public List<Rate> rate = new List<Rate>();

    //private List<T> rate = new List<T>();
    //private IList<Ocena> oceny = new IList<Ocena>();


    //private ArrayList list = new ArrayList();
    
        
    public Student()
    {
       
    }

    public Student(string name_, string surname_, string dateOfBirth_,int year_, int group_, int nrOfIndex_)
    {
        this.name = name_;
        this.surname = surname_;
        this.dateOfBirth = dateOfBirth_;
        this.year = year_;
        this.group = group_;
        this.nrOfIndex = nrOfIndex_;
    }
    public override string ToString()
    {
        return "Name: " + name + ", surname: " + surname + ", date of birth: " + dateOfBirth
            + " year of study: " + year + ", group: " + group + ", numer of index: " + nrOfIndex + " " + ShowRates();
    }
    public string ToString(string nameOfSubject_)
    {
        return "Name: " + name + ", surname: " + surname + ", date of birth: " + dateOfBirth
            + " year of study: " + year + ", group: " + group + ", numer of index: " + nrOfIndex + " " + ShowRates(nameOfSubject_);
    }

    public void AddRate(string nameOfSubject_, string date_, double value_)
    {
        rate.Add(new Rate(nameOfSubject_, date_, value_));
    }

    public string ShowRates()
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < rate.Count; i++)
        {
            sb.Append("\n");
            sb.Append(rate[i].ToString());
        }
        
        return sb.ToString();
    }

    public string ShowRates(string nameOfSubject_)
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i<rate.Count; i++)
        {
            Rate o = rate[i];
            if (o.nameOfSubject == nameOfSubject_)
            {
                sb.Append("\n");
                sb.Append(rate[i].ToString());
            }
        }
        return sb.ToString();
    }

    public void DeleteRate(string nameOfSubject_, string date_, double valueOfRate_)
    {
        for (int i = 0; i < rate.Count; i++)
        {
            Rate o = rate[i];
            if (o.nameOfSubject == nameOfSubject_ && o.date == date_ && o.valueOfRate == valueOfRate_)
            {
                rate.RemoveAt(i);
            }
        }

    }

    public void DeleteRateOfSubject(string nameOfSubject_)
    {
        for (int i = 0; i < rate.Count; i++)
        {
            Rate o = rate[i];
            if (o.nameOfSubject == nameOfSubject_)
            {
                rate.RemoveAt(i);
            }
        }

    }

    public void DeleteAllRates()
    {
        rate.Clear();
    }


    //StringBuilder sb = new StringBuilder();
    //sb.AppendLine("Team: " + _name);
    //    sb.AppendLine("Amount of power: " + AmountOfPower());
    //    for (int i = 0; i<_list.Count; i++)
    //    {
    //        sb.AppendLine(_list[i].ToString());
    //    }
    //    return sb.ToString();
}

class Footballer : Person
{
    public string position { get; private set; }
    public string club { get; private set; }
    public int numberOfGoals { get; private set; } = 0;

    public Footballer()
    {

    }

    public Footballer(string name_, string surname_, string dateOfBirth_, string position_, string club_)
    {
        this.name = name_;
        this.surname = surname_;
        this.dateOfBirth = dateOfBirth_;
        this.position = position_;
        this.club = club_;
    }

    public override string ToString()
    {
        return "Name: " + name + ", surname: " + surname + ", date of birth: " + dateOfBirth
            + " position: " + position + ", club: " + club + ", numer of goals: " + numberOfGoals;
    }

    public virtual void ScoreAGoal()
    {
        numberOfGoals++;
    }
}

class Rate
{
    //tutaj powinny być private - ale jak dostać się do nich w pętli sprawdzającej showrates
    public string nameOfSubject { get; private set; }
    public string date { get; private set; }
    public double valueOfRate { get; private set; }

    // tutaj inna możlwiosć - stworzenie zmiennej publicznej, 
    //która pobiera prywatną w obrębie swojej klasy i udostępnia ją na zewnątrz
    //- brak możliwości zmiany sammej zmiennej prywatnej 

    //public string nameOfSubjectPublic { get { return nameOfSubject; } set { nameOfSubject = value; } }
    //public string datePublic { get { return date; } set { date = value; } }
    //public double valuePublic { get { return valueOfRate; } set { valueOfRate = value; } }

    public Rate()
    {

    }

    public Rate(string nameOfSubject_, string date_, double value_)
    {
        this.nameOfSubject = nameOfSubject_;
        this.date = date_;
        this.valueOfRate = value_;
    }

    public string ToString(string nameOfSubject_)
    {
        return "Name of subject: " + nameOfSubject + ", date: " + date + ", rate: " + valueOfRate + " ";
    }
    public override string ToString()
    {
        return "Name of subject: " + nameOfSubject + ", date: " + date + ", rate: " + valueOfRate + " ";
    }
}

class HandballPlayer : Footballer
{

    public HandballPlayer(string name_, string surname_, string dateOfBirth_, string position_, string club_) : 
        base(name_, surname_, dateOfBirth_, position_, club_)
    {
    }

    public override void ScoreAGoal()
    {
        Console.WriteLine("Handball player score a goal!");
        base.ScoreAGoal();
    }
}

class FootballPlayer : Footballer
{

    public FootballPlayer(string name_, string surname_, string dateOfBirth_, string position_, string club_) :
    base(name_, surname_, dateOfBirth_, position_, club_)
    {
    }

    public override void ScoreAGoal()
    {
        Console.WriteLine("Football player score a goal!");
        base.ScoreAGoal();
    }
}