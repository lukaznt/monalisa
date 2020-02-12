using System;
using System.Collections;
using System.Collections.Generic;

namespace MI20_1
{

    enum Gender
    {
        FEMALE,
        MALE
    }

    class Program
    {
        static void Main(string[] args)
        {
            Program P1 = new Program();
            P1.Work();
        }

        void Work()
        {
            List<Student> Students = new List<Student>();

            int n;
            bool isParsed;
            do
            {
                Console.Write("How many students ? ");
                isParsed = Int32.TryParse(Console.ReadLine(), out n);
            } while (!isParsed || n < 0);

            if (n >= 3)
            {
                for (int i = 0; i < n; i++)
                {
                    Students.Add(new Student("STD" + (i + 1), (i % 2 == 0) ? Gender.FEMALE : Gender.MALE));
                    Students[i].score.Score = 20.0 - i;
                }
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine();
                    string name;
                    do
                    {
                        Console.Write("student " + (i + 1) + " name: ");
                        name = Console.ReadLine();
                    } while (name.Length == 0);

                    Console.Write("Gender ? F / M ");
                    Gender gender;
                    while (true)
                    {
                        string genderString = Console.ReadLine();
                        if (genderString.ToLower() == "f")
                        {
                            gender = Gender.FEMALE;
                            break;
                        }
                        else if (genderString.ToLower() == "m")
                        {
                            gender = Gender.FEMALE;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Unkown gender, try again...");
                        }
                    }
                    double scoreDouble;
                    do
                    {
                        Console.Write("Student score (" + 12.56 + ") :");
                        isParsed = Double.TryParse(Console.ReadLine(), out scoreDouble);
                    } while (!isParsed);
                    Students.Add(new Student(name, gender));
                    Students[i].score.Score = scoreDouble;
                }
            }
            Console.WriteLine("\n------------------------------");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(Students[i].ToString() + " score: " + Students[i].score.ToString());
            }

            Console.WriteLine("\n---------SCORES-----------------");
            Students.Sort();
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(Students[i].ToString() + " score: " + Students[i].score.ToString());
            }

            Console.WriteLine("\n---------NAMES-----------------");
            Students.Sort(new Student.StudentNameComparer());

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(Students[i].ToString() + " score: " + Students[i].score.ToString());
            }

            Console.WriteLine("\n---------SCORES-----------------");
            Students.Sort((S1, S2) => S1.score.CompareTo(S2.score));

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(Students[i].ToString() + " score: " + Students[i].score.ToString());
            }

            Console.ReadLine();
        }
    }

    class Scorable : IComparable
    {
        private double _Score = -1.0;

        public double Score
        {
            get { return _Score; }
            set { if (20.0 >= value && 0.0 <= value) _Score = value; }
        }

        public int CompareTo(object obj)
        {
            return _Score.CompareTo((obj as Scorable)._Score);
        }

        public override string ToString()
        {
            return (_Score >= 0.0) ? _Score.ToString() : "ABS";
        }
    }

    class Student : IComparable<Student> // extends & implements
    {
        private string _Name;  // final
        private Gender _Female;  // final
        public Scorable score = new Scorable();

        public Student(string name, Gender female)
        {
            this._Female = female;
            this._Name = name;
        }

        public string Name
        {
            get { return _Name; }
        }

        public Gender Female()
        {
            return _Female;
        }

        public override string ToString()
        {
            return ((_Female == 0) ? "Ms " : "Mr ") + _Name;
        }

        public int CompareTo(Student s)
        {
            return this.score.CompareTo(s.score);
        }

        public class StudentNameComparer : IComparer<Student>
        {
            public int Compare(Student x, Student y)
            {
                return x.Name.CompareTo(y.Name);
            }
        }
    }
}
