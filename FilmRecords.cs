using Films.Common;
using Films.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Films.Business
{
    class FilmRecords
    {
        private FilmData manager = new FilmData();

        public List<Film> GetAll()
        {
            return manager.GetAll();
        }

        public Film Get(int id)
        {
            return manager.Get(id);
        }

        public void Add(Film Film)
        {
            manager.Add(Film);
        }

        public void Update(Film Film)
        {
            manager.Update(Film);
        }

        public void Delete(int id)
        {
            manager.Delete(id);
        }
    }
}
