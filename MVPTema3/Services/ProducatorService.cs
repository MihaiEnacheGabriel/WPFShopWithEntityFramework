using MVPTema3.Models;
using MVPTema3Magazin.Models;
using System;
using System.Linq;

namespace MVPTema3.Services
{
    public class ProducatorService
    {
        private readonly MyDbContext _context;

        public ProducatorService()
        {
            _context = new MyDbContext();
        }

        public IQueryable<Producator> GetAllProducers()
        {
            return _context.Producator;
        }

        public void AddProducer(string producerName, string producerCountry)
        {
            if (_context.Producator.Any(p => p.Nume_producator == producerName))
            {
                throw new InvalidOperationException("Producer already exists.");
            }

            var newProducer = new Producator
            {
                Nume_producator = producerName,
                Tara_origine = producerCountry,
                Is_Active = true
            };

            _context.Producator.Add(newProducer);
            _context.SaveChanges(); // Save changes to the database
        }

        public void EditProducer(int producerId, string newProducerName, string newProducerCountry)
        {
            var producer = _context.Producator.Find(producerId);
            if (producer == null)
            {
                throw new InvalidOperationException("Producer not found.");
            }

            if (_context.Producator.Any(p => p.Nume_producator == newProducerName && p.ID_producator != producerId))
            {
                throw new InvalidOperationException("Another producer with the same name already exists.");
            }

            producer.Nume_producator = newProducerName;
            producer.Tara_origine = newProducerCountry;
            _context.SaveChanges(); // Save changes to the database
        }

        public void SoftDeleteProducer(int producerId)
        {
            var producer = _context.Producator.Find(producerId);
            if (producer == null)
            {
                throw new InvalidOperationException("Producer not found.");
            }

            producer.Is_Active = false;
            _context.SaveChanges(); // Save changes to the database
        }
    }
}
