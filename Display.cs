using Films.Business;
using Films.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Films.Presentation
{
    class Display
    {
        private int closeOperationId = 6;
        private FilmRecords FilmRecords = new FilmRecords();
        public Display()
        {
            Input();
        }

        private void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 18)+"MENU"+new string(' ', 18));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. List all entries");
            Console.WriteLine("2. Add new entry");
            Console.WriteLine("3. Update entry");
            Console.WriteLine("4. Fetch entry by ID");
            Console.WriteLine("5. Delete entry by ID");
            Console.WriteLine("6. Exit");
        }

        private void Input()
        {
            var operation = -1;
            do
            {
                ShowMenu();
                operation = int.Parse(Console.ReadLine());
                switch (operation)
                {
                    case 1:
                        ListAll();
                        break;
                    case 2:
                        Add();
                        break;
                    case 3:
                        Update();
                        break;
                    case 4:
                        Fetch();
                        break;
                    case 5:
                        Delete();
                        break;
                    default:
                        break;
                }
            } while (operation != closeOperationId);
        }

        private void Delete()
        {
            Console.WriteLine("Enter ID to delete: ");
            int id = int.Parse(Console.ReadLine());
            FilmRecords.Delete(id);
            Console.WriteLine("Done.");
        }

        private void Fetch()
        {
            Console.WriteLine("Enter ID to fetch: ");
            int id = int.Parse(Console.ReadLine());
            Film Film = FilmRecords.Get(id);
            if (Film != null)
            {
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("ID: " + Film.Id);
                Console.WriteLine("Title: " + Film.Title);
                Console.WriteLine("Fans: " + Film.Fans);
                Console.WriteLine("Year: " + Film.Year);
                Console.WriteLine(new string('-', 40));
            }
        }

        private void Update()
        {
            Console.WriteLine("Enter ID to update: ");
            int id = int.Parse(Console.ReadLine());
            Film Film = FilmRecords.Get(id);
            if (Film != null)
            {
                Console.WriteLine("Enter title: ");
                Film.Title = Console.ReadLine();
                Console.WriteLine("Enter fans: ");
                Film.Fans = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter year: ");
                Film.Year = int.Parse(Console.ReadLine());
                FilmRecords.Update(Film);
            }
            else
            {
                Console.WriteLine("Film not found!");
            }
        }

        private void Add()
        {
            Film Film = new Film();
            Console.WriteLine("Enter title: ");
            Film.Title = Console.ReadLine();
            Console.WriteLine("Enter fans: ");
            Film.Fans = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter year: ");
            Film.Year = int.Parse(Console.ReadLine());
            FilmRecords.Add(Film);
        }

        private void ListAll()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 16)+"FilmS"+new string(' ', 16));
            Console.WriteLine(new string('-', 40));
            var Films = FilmRecords.GetAll();
            foreach (var item in Films)
            {            
                Console.WriteLine("{0} {1} {2} {3}", item.Id, item.Title, item.Fans, item.Year);
            }
        }

    }
}
