using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Films.Common
{
    class Film
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Fans { get; set; }
        public int Year { get; set; }

        public Film()
        {

        }

        public Film(int id, string title, int fans, int year)
        {
            this.Id = id;
            this.Title = title;
            this.Fans = fans;
            this.Year = year;
        }

    }
}
