using CP3.Data.AppData;
using CP3.Domain.Entities;
using CP3.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CP3.Data.Repositories
{
    public class BarcoRepository : IBarcoRepository
    {
        private readonly ApplicationContext _context;

        public BarcoRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void Add(Barco barco)
        {
            _context.Barcos.Add(barco);
            _context.SaveChanges();
        }

        public void Update(Barco barco)
        {
            _context.Barcos.Update(barco);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var barco = _context.Barcos.Find(id);
            if (barco != null)
            {
                _context.Barcos.Remove(barco);
                _context.SaveChanges();
            }
        }

        public Barco GetById(int id)
        {
            return _context.Barcos.Find(id);
        }

        public IEnumerable<Barco> GetAll()
        {
            return _context.Barcos.ToList();
        }
    }
}
