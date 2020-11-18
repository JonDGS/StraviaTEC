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
        public OnlineUser AddOnlineUserRecord(LogInUserMsg userInfo)
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
                    return onlineUser;
                }
                else {
                    onlineUser.token = "BadPassword";
                    return onlineUser;
                }
            }
            else if (_context.organizers.Any(o => o.username == userInfo.username)) {
                if (Connector.checkUserPass(userInfo.username, userInfo.passwordHash))
                {
                    onlineUser.id_organizer_fk = _context.organizers.Where(o => o.username == userInfo.username).Select(u => u.id).SingleOrDefault();
                    onlineUser.token = TokenManager.generateToken(12);
                    
                    _context.onlineusers.Add(onlineUser);
                    _context.SaveChanges();
                    return onlineUser;
                }
                else {
                    onlineUser.token = "BadPassword";
                    return onlineUser;
                }
            }
            else {
                Console.WriteLine("NotRegistered");
                onlineUser.token = "NotRegistered";
                return onlineUser;
            }
            
        }
        /*
        Description:Get an online user token 
        Params:Object OnlineUser
        Output:None
       */
        public string getOnlineUserTokenRecord(LogInUserMsg userInfo)
        {
            string token = "Hola hay un error jejej";
            if (_context.athletes.Any(o => o.username == userInfo.username))
            {
                string id_athlete = _context.athletes.Where(o => o.username == userInfo.username).Select(u => u.id).SingleOrDefault();
                token = _context.onlineusers.Where(ou => ou.id_athlete_fk == id_athlete).Select(u => u.token).SingleOrDefault();
                

            }
            else if (_context.organizers.Any(o => o.username == userInfo.username))
            {
                string id_organizer = _context.organizers.Where(o => o.username == userInfo.username).Select(u => u.id).SingleOrDefault();
                token = _context.onlineusers.Where(ou => ou.id_organizer_fk == id_organizer).Select(u => u.token).SingleOrDefault();
               
            }
            return token;

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
        /*
       Description:Adds a follower to Follows table 
       Params:Object Follow
       Output:None
      */
        public void AddFollowsRecord(FollowRequest followrequest)
        {
            Follows follows = new Follows();
            Guid obj = Guid.NewGuid();
            follows.id_follows = obj.ToString();
            follows.id_followee = _context.athletes.Where(a => a.username == followrequest.username).Select(u => u.id).SingleOrDefault();
            follows.id_athlete = _context.onlineusers.Where(ou => ou.token == followrequest.token).Select(a =>a.id_athlete_fk ).SingleOrDefault();
            _context.follows.Add(follows);
            _context.SaveChanges();
        }
        /*
        Description:Updates a follow to Follows table 
        Params:Object Follow
        Output:None
       */
        public void UpdateFollowsRecord(FollowRequest followrequest)
        {
            //Tiene que ser el objeto
            
            string id_followee = _context.athletes.Where(a => a.username == followrequest.username).Select(u => u.id).SingleOrDefault();
            string id_athlete = _context.onlineusers.Where(ou => ou.token == followrequest.token).Select(a => a.id_athlete_fk).SingleOrDefault();
            var follows = _context.follows.Where(f => f.id_athlete == id_athlete && f.id_followee == id_followee).SingleOrDefault();
            _context.follows.Update(follows);
            _context.SaveChanges();
        }
        /*
        Description:Deletes a follow to Follow table 
        Params:id Follow
        Output:none
       */
        public void DeleteFollowsRecord(FollowRequest followrequest)
        {
            
            string id_followee = _context.athletes.Where(a => a.username == followrequest.username).Select(u => u.id).SingleOrDefault();
            string id_athlete = _context.onlineusers.Where(ou => ou.token == followrequest.token).Select(a => a.id_athlete_fk).SingleOrDefault();
            var follows = _context.follows.Where(f => f.id_athlete == id_athlete && f.id_followee == id_followee).SingleOrDefault();
            _context.follows.Remove(follows);
            _context.SaveChanges();
        }
        /*
        Description:Gets the followees or followee according to a specified follow request 
        Params:follow request 
        Output: List of Athlete objects
       */
        public List<Athlete> GetFolloweesRecord(FollowRequest followrequest)
        {
            string id_athlete = _context.onlineusers.Where(ou => ou.token == followrequest.token).Select(a => a.id_athlete_fk).SingleOrDefault();
            var id_followees = _context.follows.Where(f => f.id_athlete == id_athlete).Select(a => a.id_followee).ToArray();
            //Athlete[] followeesList = _context.athletes.Where(f => id_followees.Contains(f.id)).ToArray();
            //Array.ForEach(followeesList, Console.WriteLine);
            return _context.athletes.Where(f => id_followees.Contains(f.id)).ToList();
        }
        /*
        Description:Gets the followees or followee according to a specified follow request 
        Params:follow request 
        Output: List of Athlete objects
       */
        public List<Athlete> GetFollowersRecord(FollowRequest followrequest)
        {
            string id_athlete = _context.onlineusers.Where(ou => ou.token == followrequest.token).Select(a => a.id_athlete_fk).SingleOrDefault();
            var id_followers = _context.follows.Where(f => f.id_followee == id_athlete).Select(a => a.id_athlete).ToArray();
            //Athlete[] followeesList = _context.athletes.Where(f => id_followees.Contains(f.id)).ToArray();
            //Array.ForEach(followeesList, Console.WriteLine);
            return _context.athletes.Where(f => id_followers.Contains(f.id)).ToList();
        }
        /*
        Description:Gets all the follows in Follows table 
        Params:none
        Output:List of all the follows
       */
        public List<Follows> GetFollowsRecords()
        {
            return _context.follows.ToList();
        }
    }
}
