
using MVPTema3.Models;
using MVPTema3Magazin.Models;
using System;
using System.Linq;

namespace MVPTema3.Services
{
    public class UtilizatorService
    {
        private readonly MyDbContext _context;

        public UtilizatorService()
        {
            _context = new MyDbContext();
        }

        public IQueryable<Utilizator> GetAllUtilizatori()
        {
            return _context.Utilizator;
        }

        public void AddUtilizator(string username, string password, bool isAdmin)
        {
            if (_context.Utilizator.Any(u => u.Nume_utilizator == username))
            {
                throw new InvalidOperationException("User already exists.");
            }

            var newUser = new Utilizator
            {
                Nume_utilizator = username,
                Parola = password,
                Is_admin = isAdmin,
                Is_Active = true
            };

            _context.Utilizator.Add(newUser);
            _context.SaveChanges(); // Save changes to the database
        }

        public void EditUtilizator(int userId, string newUsername, string newPassword, bool isAdmin)
        {
            var user = _context.Utilizator.Find(userId);
            if (user == null)
            {
                throw new InvalidOperationException("User not found.");
            }

            user.Nume_utilizator = newUsername;
            user.Parola = newPassword; // Update password with the new value
            user.Is_admin = isAdmin;
            _context.SaveChanges(); // Save changes to the database
        }


        public void SoftDeleteUtilizator(int userId)
        {
            var user = _context.Utilizator.Find(userId);
            if (user == null)
            {
                throw new InvalidOperationException("User not found.");
            }

            user.Is_Active = false;
            _context.SaveChanges(); // Save changes to the database
        }

        public Utilizator Authenticate(string username, string password)
        {
            // Ensure username and password are not empty
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("Username and password are required.");
            }

            // Iterate through each user in the collection
            foreach (var user in _context.Utilizator)
            {
                // Check if the username and password match
                if (user.Nume_utilizator == username && user.Parola == password && user.Is_Active == true)
                {
                    // Return the user if found
                    return user;
                }
            }

            // If no matching user is found, return null
            return null;
        }


    }
}