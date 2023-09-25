using Lessons._4.practice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HomeLibrary[] homeLibraries = new HomeLibrary[1];
            HomeLibrary temp = new HomeLibrary("Werder", 2014, "Reder");
            homeLibraries[0] = temp;
            homeLibraries = homeLibraries[0].AddingBooks(homeLibraries, "ert", 2012, "ytnv");
            homeLibraries = homeLibraries[0].RemoveBooks(homeLibraries, 1);
            homeLibraries[0].SearchBookYear(homeLibraries, 2014);
            homeLibraries[0].SearchBookAutor(homeLibraries, "Werder");

        }
    }
}
