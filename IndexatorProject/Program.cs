using System.Collections;

namespace IndexatorProject
{
    class Student
    {
        public string Name { get; set; }

        string email;
        string phone;
        string address;
        public Student(string name)
        {
            Name = name;
        }

        public string this[string prop]
        {
            get
            {
                switch (prop)
                {
                    case "email": return email; break;
                    case "phone": return phone; break;
                    case "address": return address; break;
                    default:
                        throw new Exception("Undefine property name");
                }
            }
            set
            {
                switch (prop)
                {
                    case "email": email = value; break;
                    case "phone": phone = value; break;
                    case "address": address = value; break;
                    default:
                        break;
                }
            }
        }
    }

    class Group
    {
        Student[] students;

        string name;
        int year;
        public Group(Student[] students)
        {
            this.students = students;
        }

        public Student this[int index]
        {
            set 
            { 
                if(index >= 0 && index < students.Length)
                    students[index] = value;
            }
            get 
            {
                if (index >= 0 && index < students.Length)
                    return students[index];
                else
                    throw new ArgumentOutOfRangeException();
            }
        }

        public string this[string prop]
        {
            set
            {
                switch (prop)
                {
                    case "name": name = value; break;
                    case "year": year = Convert.ToInt32(value); break;
                    default:
                        break;
                }
            }
            get
            {
                switch (prop)
                {
                    case "name": return name; break;
                    case "year": return year.ToString(); break;
                    default:
                        throw new Exception("Invalid peroperty");
                }
            }
        }

        //public void SetStudent(int index, Student student)
        //{
        //    students[index] = student;
        //}
    }


    class Matrix
    {
        int[][] items = new int[4][];
        public Matrix()
        {
            Random random = new Random();
            for(int i = 0; i < items.Length; i++)
            {
                items[i] = new int[5];
                for (int j = 0; j < items[i].Length; j++)
                    items[i][j] = random.Next() % 100;
            }
        }

        public int this[int i, int j]
        {
            set { items[i][j] = value; }
            get { return items[i][j]; }
        }
    }


    

    internal class Program
    {


        static void Method(in Group a)
        {
            a = new Group(null);
        }

        static void Main(string[] args)
        {
            Group nn = new Group(null);
            Method(nn);



            Group group = new Group(
                new[]
                {
                    new Student("Bob"),
                    new Student("Joe"),
                    new Student("Tim"),
                    new Student("Sam"),
                    new Student("Micke"),
                }
                );

            Student student = group[2];

            student["email"] = "tim@gmail.com";

            Console.WriteLine(student.Name);

            Matrix matrix = new Matrix();

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 5; j++)
                    Console.Write($"{matrix[i, j]}\t");
                Console.WriteLine();
            }
        }
    }
}