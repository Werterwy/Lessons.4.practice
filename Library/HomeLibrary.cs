using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons._4.practice
{
    internal class HomeLibrary
    {
/*        3.	Описать класс «домашняя библиотека». Предусмотреть возможность 
            работы с произвольным числом книг, поиска книги по какому-либо
            признаку(например, по автору или по году издания), добавления книг
            в библиотеку, удаления книг из нее, сортировки книг по разным полям.*/
            
        public string Autor { get; set; }
        public int YearOfPublication { get; set; }
        public string BookTitle { get; set; }
        public HomeLibrary(string Autor, int YearOfPublication, string BookTitle) 
        {
            this.Autor = Autor;
            this.YearOfPublication = YearOfPublication;
            this.BookTitle = BookTitle;
        }
        /// <summary>
        /// добавления книг библиотеку,
        /// </summary>
        /// <param name="homeLibraries"></param>
        /// <returns></returns>
        public HomeLibrary[] AddingBooks(HomeLibrary[] homeLibraries, string autor, int yearOfPublication, string bookTitle)
        {
            HomeLibrary[] temp=new HomeLibrary[homeLibraries.Length+1];
            HomeLibrary add=new HomeLibrary(autor, yearOfPublication, bookTitle);
            for(int i=0; i<homeLibraries.Length; i++)
            {
                temp[i] = homeLibraries[i];
            }
            temp[homeLibraries.Length] = add;
            homeLibraries = temp;

            return homeLibraries;
        }
        /// <summary>
        /// удаления книг из библиотеки по индексу
        /// </summary> 
        /// <param name="homeLibraries"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public HomeLibrary[] RemoveBooks(HomeLibrary[] homeLibraries, int index)
        {
            HomeLibrary[] temp = new HomeLibrary[homeLibraries.Length - 1];
            for (int i = 0; i < index; i++)
            {
                temp[i] = homeLibraries[i];
            }
            for(int j=index; j<temp.Length; j++)
            {
                temp[j] = homeLibraries[j+1];
            }
            homeLibraries = temp;

            return homeLibraries;
        }
        /// <summary>
        /// сортировки книг по годам
        /// </summary>
        /// <param name="homeLibraries"></param>
        /// <returns></returns>
        public HomeLibrary[] SortingByYear(HomeLibrary[] homeLibraries)
        {
            int num = homeLibraries.Length;
            for (int i = 0; i < homeLibraries.Length; i++)
            {
                int max = 0;
                int counter = 0;
                for (int j = 0; j < num; j++)
                {
                    int year = homeLibraries[i].YearOfPublication;

                    if (year > max)
                    {
                        counter = j;
                        max = year;
                    }
                }
                HomeLibrary temp = homeLibraries[num - 1];
                homeLibraries[num - 1] = homeLibraries[counter];
                homeLibraries[counter] = temp;
                num--;
            }

            return homeLibraries;
        }

        /// <summary>
        /// поиска книги по какому-либо признаку по году издания
        /// </summary>
        /// <param name="homeLibraries"></param>
        /// <param name="yearOfPublication"></param>
        /// <returns></returns>
        public void SearchBookYear(HomeLibrary[] homeLibraries, int yearOfPublication)
        {
            for(int i=0; i<homeLibraries.Length; i++)
            {
                if (yearOfPublication == homeLibraries[i].YearOfPublication)
                {
                    string autor = homeLibraries[i].Autor;
                    string bookTitle = homeLibraries[i].BookTitle;
                    Console.WriteLine($"Autor: {autor}");                 
                    Console.WriteLine($"YearOfPublication: {yearOfPublication}");                 
                    Console.WriteLine($"BookTitle: {bookTitle}");
                    Console.WriteLine("");
                }
            }

        }
        /// <summary>
        ///  поиска книги по какому-либо признаку по автору 
        /// </summary>
        /// <param name="homeLibraries"></param>
        /// <param name="autor"></param>
        public void SearchBookAutor(HomeLibrary[] homeLibraries, string autor)
        {
            for (int i = 0; i < homeLibraries.Length; i++)
            {
                if (autor == homeLibraries[i].Autor)
                {
                    int yearOfPublication= homeLibraries[i].YearOfPublication;
                    string bookTitle = homeLibraries[i].BookTitle;
                    Console.WriteLine($"Autor: {autor}");
                    Console.WriteLine($"YearOfPublication: {yearOfPublication}");
                    Console.WriteLine($"BookTitle: {bookTitle}");
                    Console.WriteLine("");
                }
            }

        }

    }
}
