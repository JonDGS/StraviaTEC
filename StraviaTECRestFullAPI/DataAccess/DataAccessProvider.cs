using System;
using StraviaTECRestFullAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace StraviaTECRestFullAPI.DataAccess
{
    public class DataAccessProvider : IDataAccessProvider
    {
        private readonly PostgreSqlContext _context;

        public DataAccessProvider(PostgreSqlContext context)
        {
            _context = context;
        }

        public void AddOrganizerRecord(Organizer patient)
        {
            _context.organizers.Add(patient);
            _context.SaveChanges();
        }

        public void UpdateOrganizerRecord(Organizer patient)
        {
            _context.organizers.Update(patient);
            _context.SaveChanges();
        }

        public void DeleteOrganizerRecord(string id)
        {
            var entity = _context.organizers.FirstOrDefault(t => t.id == id);
            _context.organizers.Remove(entity);
            _context.SaveChanges();
        }

        public Organizer GetOrganizerSingleRecord(string id)
        {
            return _context.organizers.FirstOrDefault(t => t.id == id);
        }
        public Array GetOrganizersName()
        {
            var nameList = _context.organizers.Select(p => p.name).ToArray();
            return nameList;
        }
        public List<Organizer> GetOrganizerRecords()
        {
            return _context.organizers.ToList();
        }

        public void AddAthleteRecord(Athlete athlete)
        {
            athlete.passwordHash = HashComputer.GetHashString(athlete.passwordHash);
            athlete.age = DateTime.Now.Year - athlete.birthday.Year;

            _context.athletes.Add(athlete);
            _context.SaveChanges();
        }

        public void UpdateAthleteRecord(Athlete athlete)
        {
            _context.athletes.Update(athlete);
            _context.SaveChanges();
        }

        public void DeleteAthleteRecord(string id)
        {
            var entity = _context.athletes.FirstOrDefault(t => t.id == id);
            _context.athletes.Remove(entity);
            _context.SaveChanges();
        }

        public Athlete GetAthleteSingleRecord(string id)
        {
            return _context.athletes.FirstOrDefault(t=> t.id == id);
        }

        public List<Athlete> GetAthleteRecords()
        {
            return _context.athletes.ToList();
        }

        public string AddOnlineUserRecord(LogInUserMsg userInfo)
        {
            OnlineUser onlineUser = new OnlineUser();
            Console.WriteLine(_context.athletes.Any(a => a.username == userInfo.username));
            if (_context.athletes.Any(a => a.username == userInfo.username))
            {
                onlineUser.id_athlete_fk = _context.athletes.Where(a => a.username == userInfo.username).Select(u => u.id).SingleOrDefault();
                Console.WriteLine(onlineUser.id_athlete_fk);
                return "Success";
            }
            else if (_context.organizers.Any(o => o.username == userInfo.username)) {
                onlineUser.id_organizer_fk = _context.athletes.Where(o => o.username == userInfo.username).Select(u => u.id).SingleOrDefault();
                Console.WriteLine(onlineUser.id_organizer_fk);
                return "Success";
            }
            else {
                Console.WriteLine("Usuario no registrado");
                return "Error";
            }
            /*
            _context.onlineUsers.Add(onlineUser);
            _context.SaveChanges();
            */
        }

        public void UpdateOnlineUserRecord(OnlineUser onlineUser)
        {
            _context.onlineUsers.Update(onlineUser);
            _context.SaveChanges();
        }

        public void DeleteOnlineUserRecord(string token)
        {

            var entity = _context.onlineUsers.FirstOrDefault(t => t.token == token);
            _context.onlineUsers.Remove(entity);
            _context.SaveChanges();
        }

        public OnlineUser GetOnlineUserSingleRecord(string token)
        {
            return _context.onlineUsers.FirstOrDefault(t => t.token == token);
        }

        public List<OnlineUser> GetOnlineUserRecords()
        {
            return _context.onlineUsers.ToList();
        }
    }
}
