using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    class Program
    {
        static void Main(string[] args)
        {

            // create list
            List<Student> studentslist = new List<Student>();

            studentslist.Add(new Student("Allan", 95, 200));
            studentslist.Add(new Student("Adrian", 95, 200));
            studentslist.Add(new Student("Per", 75, 300));
            studentslist.Add(new Student("Vincet", 40, 50));
            studentslist.Add(new Student("John", 12, 45));
            studentslist.Add(new Student("Jens", 23, 500));


            //Lambda query
            var result1 = studentslist.OrderBy(x => x.Name).ToList();
            var result2 = studentslist.OrderByDescending(x => x.Name).ToList();
            var result3 = studentslist.OrderBy(x => x.Donation).ToList();
            var result4 = studentslist.OrderBy(x => x.Name).ThenBy(x => x.Donation).ToList();
            var result5 = studentslist.OrderBy(x => x.Name).ThenByDescending(x => x.Donation).ToList();
            var result6 = studentslist.Where(x => x.Donation > 200).ToList();
            var result7 = studentslist.Where(x => x.Donation > 200 && x.Average > 50).ToList();
            var result8 = studentslist.Select(x => x.Name).ToList();
            var result9 = studentslist.Where(x => x.Donation > 200).Select(x => x.Name).ToList();       //select students name som theres donation > 200
            var result10 = studentslist.Sum(x => x.Donation);                           // return double cw(result10);
            var resul11 = studentslist.Find(x => x.Donation > 200 && x.Average > 50 && x.Name.StartsWith("A"));       //cw(result.name);
            var resul12 = studentslist.Any(x => x.Donation > 200 && x.Average > 50 && x.Name.StartsWith("A"));   // result is a true or false
            studentslist.RemoveAt(1);  // remove by index
            studentslist.Add(new Student("Adrian", 95, 200));  // add a item to the list
            var result13 = studentslist.Where(x => x.Name.Equals("Allan")).ToList();  //Equlas

            foreach (var item in studentslist)
            {
                Console.WriteLine($"{item.Name} - {item.Average} - {item.Donation}");
            }


            //Linq query
            var result14 = from Student in studentslist where Student.Name == "Allan" select Student;
            foreach (var item in result14)
            {
                Console.WriteLine($"{item.Name} - {item.Donation} -{item.Average}");
            }

            var result15 = from Student in studentslist where Student.Average > 50 where Student.Donation > 200 select Student;
            foreach (var item in result15)
            {
                Console.WriteLine($"{item.Name} - {item.Donation} -{item.Average}");
            }



            Console.ReadLine();

        }

    }

}
