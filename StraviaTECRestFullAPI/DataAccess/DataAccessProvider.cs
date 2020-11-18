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
         Description:Class constructor
         Params:Instace of Posgresql DB
         Output:none
        */
        public DataAccessProvider(PostgreSqlContext context)
        {
            _context = context;
        }
        /*
         Description:Adds an organizer to Organizer table 
         Params:Object Organizer
         Output:None
        */
        public void AddOrganizerRecord(Organizer organizer)
        {
            organizer.passwordhash = Connector.generatedUserPassHash(organizer.username, organizer.passwordhash);
            _context.organizers.Add(organizer);
            _context.SaveChanges();
        }
        /*
        Description:Updates an organizer to Organizer table 
        Params:Object Organizer
        Output:None
       */
        public void UpdateOrganizerRecord(Organizer organizer)
        {
            _context.organizers.Update(organizer);
            _context.SaveChanges();
        }
        /*
        Description:Deletes an organizer to Organizer table 
        Params:id Organizer
        Output:None
       */
        public void DeleteOrganizerRecord(string id)
        {
            var entity = _context.organizers.FirstOrDefault(t => t.id == id);
            _context.organizers.Remove(entity);
            _context.SaveChanges();
        }
        /*
        Description:Gets an organizer to Organizer table 
        Params:id Organizer
        Output:Organizer object
       */
        public Organizer GetOrganizerSingleRecord(string id)
        {
            return _context.organizers.FirstOrDefault(t => t.id == id);
        }
        /*
        Description:Gets all the organizers's name 
        Params:None
        Output:Array of Organizer's names
       */
        public Array GetOrganizersName()
        {
            var nameList = _context.organizers.Select(p => p.name).ToArray();
            return nameList;
        }
        /*
        Description:Gets all the organizer 
        Params:None
        Output:All the organizer in the table Organizer
       */
        public List<Organizer> GetOrganizerRecords()
        {
            return _context.organizers.ToList();
        }
        /*
        Description:Adds an athlete to Athlete table 
        Params:Object Athlete
        Output:None
       */
        public void AddAthleteRecord(Athlete athlete)
        {
            athlete.passwordhash = Connector.generatedUserPassHash(athlete.username,athlete.passwordhash);
            athlete.age = DateTime.Today.Year - athlete.birthyear;
            //DateTime.Today.Year

            _context.athletes.Add(athlete);
            _context.SaveChanges();
        }
        /*
        Description:Updates an athlete to Athlete table 
        Params:Object Athlete
        Output:None
       */
        public void UpdateAthleteRecord(Athlete athlete)
        {
            _context.athletes.Update(athlete);
            _context.SaveChanges();
        }
        /*
        Description:Deletes an athlete to Athlete table 
        Params:id Athlete
        Output:none
       */
        public void DeleteAthleteRecord(string id)
        {
            var entity = _context.athletes.FirstOrDefault(t => t.id == id);
            _context.athletes.Remove(entity);
            _context.SaveChanges();
        }
        /*
        Description:Gets an athlete according to a specified id 
        Params:id athlete
        Output: Athlete object
       */
        public Athlete GetAthleteSingleRecord(string id)
        {
            return _context.athletes.FirstOrDefault(t=> t.id == id);
        }
        /*
        Description:Gets all the athletes in Athletes table 
        Params:none
        Output:List of all the athletes
       */
        public List<Athlete> GetAthleteRecords()
        {
            return _context.athletes.ToList();
        }
        /*
        Description:Adds an online user to OnlineUser table 
        Params:Login message with the credentials to be validated
        Output:Succes, Bad Password, Not registered message
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
                    _context.onlineusers.Add(onlineUser);
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
                    
                    _context.onlineusers.Add(onlineUser);
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
        Description:Updates an online user in OnlineUser table 
        Params:Object OnlineUser
        Output:None
       */
        public void UpdateOnlineUserRecord(OnlineUser onlineUser)
        {
            _context.onlineusers.Update(onlineUser);
            _context.SaveChanges();
        }
        /*
        Description:Deletes an online user in OnlineUser table (Logout functionality) 
        Params:token 
        Output:None
       */
        public void DeleteOnlineUserRecord(string token)
        {

            var entity = _context.onlineusers.FirstOrDefault(t => t.token == token);
            _context.onlineusers.Remove(entity);
            _context.SaveChanges();
        }
        /*
        Description:Gets an online user with a specific token 
        Params:Token
        Output:Object Online User
       */
        public OnlineUser GetOnlineUserSingleRecord(string token)
        {
            return _context.onlineusers.FirstOrDefault(t => t.token == token);
        }
        /*
         Description:Gets all the online users  
         Params:None
         Output:List of all the online users
        */
        public List<OnlineUser> GetOnlineUserRecords()
        {
            return _context.onlineusers.ToList();
        }
        /*
        Description:Adds a race to Race table 
        Params:Object Race
        Output:None
       */
        public void AddRaceRecord(Race race)
        {

            _context.race.Add(race);
            _context.SaveChanges();
        }
        /*
        Description:Updates a race in Race table 
        Params:Object Race
        Output:None
       */
        public void UpdateRaceRecord(Race race)
        {
            _context.race.Update(race);
            _context.SaveChanges();
        }
        /*
        Description:Deletes a race with a specified id 
        Params:id Race
        Output:None
       */
        public void DeleteRaceRecord(string idrace)
        {
            var entity = _context.race.FirstOrDefault(t => t.id_race == idrace);
            _context.race.Remove(entity);
            _context.SaveChanges();
        }
        /*
        Description:Gets a race with the specified id 
        Params:id Race
        Output:Race object
       */
        public Race GetRaceSingleRecord(string id)
        {
            return _context.race.FirstOrDefault(t => t.id_race == id);
        }
        /*
        Description:Gets all the races in Race table 
        Params:Object Race
        Output:Array of Races
       */
        public List<Race> GetRaceRecords()
        {
            return _context.race.ToList();
        }

    }
}
