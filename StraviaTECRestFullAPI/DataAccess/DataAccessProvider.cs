using System;
using StraviaTECRestFullAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Data;
using StraviaTECRestFullAPI.Utilities;
using System.Security.Principal;
using Feria_Virtual_REST.Models;

namespace StraviaTECRestFullAPI.DataAccess
{
    public class DataAccessProvider : IDataAccessProvider
    {
        private readonly PostgreSqlContext _context;
        /*
         Description:
         Params:
         Output:
        */
        public DataAccessProvider(PostgreSqlContext context)
        {
            _context = context;
        }
        /*
         Description:
         Params:
         Output:
        */
        public void AddOrganizerRecord(Organizer organizer)
        {
            organizer.passwordHash = Connector.generatedUserPassHash(organizer.username, organizer.passwordHash);
            _context.organizers.Add(organizer);
            _context.SaveChanges();
        }
        /*
         Description:
         Params:
         Output:
        */
        public void UpdateOrganizerRecord(Organizer organizer)
        {
            _context.organizers.Update(organizer);
            _context.SaveChanges();
        }
        /*
         Description:
         Params:
         Output:
        */
        public void DeleteOrganizerRecord(string id)
        {
            var entity = _context.organizers.FirstOrDefault(t => t.id == id);
            _context.organizers.Remove(entity);
            _context.SaveChanges();
        }
        /*
         Description:
         Params:
         Output:
        */
        public Organizer GetOrganizerSingleRecord(string id)
        {
            return _context.organizers.FirstOrDefault(t => t.id == id);
        }
        /*
         Description:
         Params:
         Output:
        */
        public Array GetOrganizersName()
        {
            var nameList = _context.organizers.Select(p => p.name).ToArray();
            return nameList;
        }
        /*
         Description:
         Params:
         Output:
        */
        public List<Organizer> GetOrganizerRecords()
        {
            return _context.organizers.ToList();
        }
        /*
         Description:
         Params:
         Output:
        */
        public void AddAthleteRecord(Athlete athlete)
        {
            athlete.passwordHash = Connector.generatedUserPassHash(athlete.username,athlete.passwordHash);
            athlete.age = DateTime.Now.Year - athlete.birthday.Year;

            _context.athletes.Add(athlete);
            _context.SaveChanges();
        }
        /*
         Description:
         Params:
         Output:
        */
        public void UpdateAthleteRecord(Athlete athlete)
        {
            _context.athletes.Update(athlete);
            _context.SaveChanges();
        }
        /*
         Description:
         Params:
         Output:
        */
        public void DeleteAthleteRecord(string id)
        {
            var entity = _context.athletes.FirstOrDefault(t => t.id == id);
            _context.athletes.Remove(entity);
            _context.SaveChanges();
        }
        /*
         Description:
         Params:
         Output:
        */
        public Athlete GetAthleteSingleRecord(string id)
        {
            return _context.athletes.FirstOrDefault(t=> t.id == id);
        }
        /*
         Description:
         Params:
         Output:
        */
        public List<Athlete> GetAthleteRecords()
        {
            return _context.athletes.ToList();
        }
        /*
         Description:
         Params:
         Output:
        */
        public string AddOnlineUserRecord(LogInUserMsg userInfo)
        {
            OnlineUser onlineUser = new OnlineUser();
            if (_context.athletes.Any(a => a.username == userInfo.username))
            {
                if (Connector.checkUserPass(userInfo.username, userInfo.passwordHash))
                {
                    onlineUser.id_athlete_fk = _context.athletes.Where(a => a.username == userInfo.username).Select(u => u.id).SingleOrDefault();
                    onlineUser.token = TokenManager.generateToken(12);
                    _context.onlineuser.Add(onlineUser);
                    _context.SaveChanges();
                    return "Success";
                }
                else {
                    return "BadPassword";
                }
            }
            else if (_context.organizers.Any(o => o.username == userInfo.username)) {
                if (Connector.checkUserPass(userInfo.username, userInfo.passwordHash))
                {
                    onlineUser.id_organizer_fk = _context.organizers.Where(o => o.username == userInfo.username).Select(u => u.id).SingleOrDefault();
                    onlineUser.token = TokenManager.generateToken(12);
                    
                    _context.onlineuser.Add(onlineUser);
                    _context.SaveChanges();
                    return "Success";
                }
                else {
                    return "BadPassword";
                }
            }
            else {
                Console.WriteLine("NotRegistered");
                return "Error";
            }
            
        }
        /*
         Description:
         Params:
         Output:
        */
        public void UpdateOnlineUserRecord(OnlineUser onlineUser)
        {
            _context.onlineuser.Update(onlineUser);
            _context.SaveChanges();
        }
        /*
         Description:
         Params:
         Output:
        */
        public void DeleteOnlineUserRecord(string token)
        {

            var entity = _context.onlineuser.FirstOrDefault(t => t.token == token);
            _context.onlineuser.Remove(entity);
            _context.SaveChanges();
        }
        /*
         Description:
         Params:
         Output:
        */
        public OnlineUser GetOnlineUserSingleRecord(string token)
        {
            return _context.onlineuser.FirstOrDefault(t => t.token == token);
        }
        /*
         Description:
         Params:
         Output:
        */
        public List<OnlineUser> GetOnlineUserRecords()
        {
            return _context.onlineuser.ToList();
        }
    }
}
