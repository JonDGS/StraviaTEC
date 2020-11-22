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
        public void DeleteOrganizerRecord(string token)
        {
            string id_organizer = _context.onlineusers.Where(ou => ou.token == token).Select(a => a.id_organizer_fk).SingleOrDefault();
            this.DeleteOnlineUserRecord(token);
            var entity = _context.organizers.FirstOrDefault(t => t.id == id_organizer);
            _context.organizers.Remove(entity);
            _context.SaveChanges();
        }
        /*
        Description:Gets an organizer to Organizer table 
        Params:id Organizer
        Output:Organizer object
       */
        public Organizer GetOrganizerSingleRecord(string token)
        {
            string id_organizer = _context.onlineusers.Where(ou => ou.token == token).Select(a => a.id_organizer_fk).SingleOrDefault();
            return _context.organizers.FirstOrDefault(t => t.id == id_organizer);
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
        public void DeleteAthleteRecord(string token)
        {
            string id_athlete = _context.onlineusers.Where(ou => ou.token == token).Select(a => a.id_athlete_fk).SingleOrDefault();
            this.DeleteFollowByToken(token);
            this.DeleteOnlineUserRecord(token);
            var entity = _context.athletes.FirstOrDefault(t => t.id == id_athlete);
            _context.athletes.Remove(entity);
            _context.SaveChanges();
        }
        /*
        Description:Gets an athlete according to a specified id 
        Params:id athlete
        Output: Athlete object
       */
        public Athlete GetAthleteSingleRecord(string token)
        {
            string id_athlete = _context.onlineusers.Where(ou => ou.token == token).Select(a => a.id_athlete_fk).SingleOrDefault();
            return _context.athletes.FirstOrDefault(t=> t.id == id_athlete);
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
            bool verifiedCredentials = Connector.checkUserPass(userInfo.username, userInfo.passwordHash);
            if (_context.athletes.Any(a => a.username == userInfo.username))
            {
                string id_athlete = _context.athletes.Where(a => a.username == userInfo.username).Select(u => u.id).SingleOrDefault();
                if (verifiedCredentials)
                {
                    if (_context.onlineusers.Any(ou => ou.id_athlete_fk == id_athlete)) {

                        var entity = _context.onlineusers.FirstOrDefault(ou => ou.id_athlete_fk == id_athlete);
                        return entity;
                    }
                    else {
                        onlineUser.id_athlete_fk = id_athlete;

                        onlineUser.token = TokenManager.generateToken(12);
                        _context.onlineusers.Add(onlineUser);
                        _context.SaveChanges();
                        return onlineUser;
                    }
                }
                else {
                    onlineUser.token = "BadPassword";
                    return onlineUser;
                }
            }
            else if (_context.organizers.Any(o => o.username == userInfo.username)) {

                string id_organizer = _context.organizers.Where(o => o.username == userInfo.username).Select(u => u.id).SingleOrDefault();
                if (verifiedCredentials)
                {
                    if (_context.onlineusers.Any(ou => ou.id_organizer_fk == id_organizer))
                    {
                        var entity = _context.onlineusers.FirstOrDefault(ou => ou.id_organizer_fk == id_organizer);
                        return entity;
                    }
                    else
                    {
                        onlineUser.id_organizer_fk = id_organizer;
                        onlineUser.token = TokenManager.generateToken(12);
                        _context.onlineusers.Add(onlineUser);
                        _context.SaveChanges();
                        return onlineUser;
                    }
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
        public void AddRaceRecord(Race race,string token)
        {
            race.id_organizer = _context.onlineusers.Where(ou => ou.token == token).Select(a => a.id_organizer_fk).SingleOrDefault();
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
        Description:Gets a race with token
        Params:id Race
        Output:Race object
       */
        public List<Race> GetRacesByToken(string token)
        {
            string id_organizer = _context.onlineusers.Where(ou => ou.token == token).Select(a => a.id_organizer_fk).SingleOrDefault();
            return _context.race.Where(t => t.id_organizer == id_organizer).ToList();
        }
        /*
        Description:Gets a race with the specified id 
        Params:id Race
        Output:Race object
       */
        public Race GetRaceSingleRecord(string id)
        {
            return _context.race.FirstOrDefault(r => r.id_race == id);
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
        Description:Deletes a follow to Follow table 
        Params:id Follow
        Output:none
       */
        public void DeleteFollowByToken(string token)
        {
            string id_athlete = _context.onlineusers.Where(ou => ou.token == token).Select(a => a.id_athlete_fk).SingleOrDefault();
            var follows = _context.follows.Where(f => f.id_athlete == id_athlete || f.id_followee == id_athlete).ToArray();
            for (int i=0; i<follows.Length;i++) {
                _context.follows.Remove(follows[i]);
            }
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
        /*
       Description:Adds a race to AthleteEnrollsChallenge table 
       Params:Object Race
       Output:None
      */
        public void AddChallengeEnrollmentRecord(AthleteEnrollsChallenge challengeEnrollment, string token)
        {
            challengeEnrollment.id_athlete = _context.onlineusers.Where(ou => ou.token == token).Select(a => a.id_athlete_fk).SingleOrDefault();
            _context.athleteenrollschallenges.Add(challengeEnrollment);
            _context.SaveChanges();
        }
        /*
        Description:Updates an enrollment in AthleteEnrollsChallenge table 
        Params:Object Race
        Output:None
       */
        public void UpdateChallengeEnrollmentRecord(AthleteEnrollsChallenge challengeEnrollment)
        {
            _context.athleteenrollschallenges.Update(challengeEnrollment);
            _context.SaveChanges();
        }
        /*
        Description:Deletes an AthleteEnrollsChallenge with a specified id 
        Params:id Race
        Output:None
       */
        public void DeleteChallengeEnrollmentRecord(int id)
        {
            var entity = _context.athleteenrollschallenges.FirstOrDefault(t => t.id == id);
            _context.athleteenrollschallenges.Remove(entity);
            _context.SaveChanges();
        }
        /*
        Description:Gets an AthleteEnrollsChallengewith the specified id 
        Params:id Race
        Output:Race object
       */
        public AthleteEnrollsChallenge GetChallengeEnrollmentSingleRecord(int id)
        {
            var enrollment = _context.athleteenrollschallenges.FirstOrDefault(ou => ou.id == id);
            return enrollment;
        }
        /*
        Description:Gets all enrollments the in AthleteEnrollsChallenge table 
        Params:Object AthleteEnrollsChallenge object
        Output:Array of AthleteEnrollsChallenge
       */
        public List<AthleteEnrollsChallenge> GetChallengeEnrollmentRecords()
        {
            return _context.athleteenrollschallenges.ToList();
        }
        /*
        Description:Gets challenges according to a specified token
        Params:token
        Output: List of Challenge object
       */
        public List<Challenge> GetChallengeEnrollmentByToken(string token)
        {
            string id_athlete = _context.onlineusers.Where(ou => ou.token == token).Select(a => a.id_athlete_fk).SingleOrDefault();
            var id_challenges = _context.athleteenrollschallenges.Where(aec => aec.id_athlete == id_athlete).Select(ch => ch.id_challenge).ToArray();
            return _context.challenge.Where(r => id_challenges.Contains(r.id_challenge)).ToList();
        }
        /*
      Description:Adds a race to AthleteEnrollsRace table 
      Params:Object AthleteEnrollsRace
      Output:None
     */
        public void AddRaceEnrollmentRecord(AthleteEnrollsRace raceEnrollment, string token)
        {
            raceEnrollment.id_athlete= _context.onlineusers.Where(ou => ou.token == token).Select(a => a.id_athlete_fk).SingleOrDefault();
            _context.athleteenrollsraces.Add(raceEnrollment);
            _context.SaveChanges();
        }
        /*
        Description:Updates an enrollment in AthleteEnrollsRace table 
        Params:Object AthleteEnrollsRace
        Output:None
       */
        public void UpdateRaceEnrollmentRecord(AthleteEnrollsRace raceEnrollment)
        {
            _context.athleteenrollsraces.Update(raceEnrollment);
            _context.SaveChanges();
        }
        /*
        Description:Deletes an AthleteEnrollsRace with a specified id 
        Params:id AthleteEnrollsRace
        Output:None
       */
        public void DeleteRaceEnrollmentRecord(int id)
        {
            var entity = _context.athleteenrollsraces.FirstOrDefault(t => t.id == id);
            _context.athleteenrollsraces.Remove(entity);
            _context.SaveChanges();
        }
        /*
        Description:Gets an AthleteEnrollsRace with the specified id 
        Params:id Race
        Output:Race object
       */
        public AthleteEnrollsRace GetRaceEnrollmentSingleRecord(int id)
        {
           
            return _context.athleteenrollsraces.FirstOrDefault(r => r.id == id);
        }
        /*
        Description:Gets all enrollments the in AthleteEnrollsChallenge table 
        Params:Object AthleteEnrollsChallenge object
        Output:Array of AthleteEnrollsChallenge
       */
        public List<AthleteEnrollsRace> GetRaceEnrollmentRecords()
        {
            return _context.athleteenrollsraces.ToList();
        }
        /*
        Description:Gets an athlete according to a specified id 
        Params:id athlete
        Output: Athlete object
       */
        public List<Race> GetRaceEnrollmentByToken(string token)
        {
            string id_athlete = _context.onlineusers.Where(ou => ou.token == token).Select(a => a.id_athlete_fk).SingleOrDefault();
            var id_races = _context.athleteenrollsraces.Where(aer => aer.id_athlete == id_athlete).Select(r => r.id_race).ToArray();
            return _context.race.Where(r => id_races.Contains(r.id_race)).ToList();
        }
        /*
       Description:Adds an Activity to Activity table 
       Params:Object Activity, token
       Output:None
      */
        public void AddActivityRecord(Activity activity, string token)
        {
            string id_athlete = _context.onlineusers.Where(ou => ou.token == token).Select(a => a.id_athlete_fk).SingleOrDefault();
            activity.id_athlete = id_athlete;
            activity.duration = activity.closing_time - activity.starting_time;
            _context.activity.Add(activity);
            _context.SaveChanges();
        }
        /*
        Description:Updates an Activity to Activity table 
        Params:Object Activity
        Output:None
       */
        public void UpdateActivityRecord(Activity activity)
        {
            activity.duration = activity.closing_time - activity.starting_time;
            _context.activity.Update(activity);
            _context.SaveChanges();
        }
        /*
        Description:Deletes an Activity to Activity table 
        Params:id Activity
        Output:none
       */
        public void DeleteActivityRecord(string id)
        {
            
            var entity = _context.activity.FirstOrDefault(t => t.id_activity == id);
            _context.activity.Remove(entity);
            _context.SaveChanges();
        }
        /*
        Description:Gets an Activity according to a specified Activity id 
        Params:id Activity
        Output: Activity object
       */
        public Activity GetActivitySingleRecord(string actId)
        {
           
            return _context.activity.FirstOrDefault(ac => ac.id_activity == actId);
        }
        /*
        Description:Gets all the Activities in Activity table 
        Params:none
        Output:List of all the Activities
       */
        public List<Activity> GetActivityRecords()
        {
            return _context.activity.ToList();
        }
        /*
        Description:Gets all the Group in Group table 
        Params:none
        Output:List of all the Activity
       */
        public List<Activity> GetActivityByToken(string token)
        {
            string id_athlete = _context.onlineusers.Where(ou => ou.token == token).Select(a => a.id_athlete_fk).SingleOrDefault();
            return _context.activity.Where(a => a.id_athlete == id_athlete).ToList();
        }

        public List<ActivityType> GetActivityTypes() 
        {
            return _context.activity_type.ToList();
        }
        /*
        Description:Adds an Group to Group table 
        Params:Object Organizer
        Output:None
       */
        public void AddGroupRecord(Group group,string token)
        {
            string id_organizer = _context.onlineusers.Where(ou => ou.token == token).Select(a => a.id_organizer_fk).SingleOrDefault();
            string name = _context.organizers.Where(or => or.id == id_organizer).Select(o => o.name).SingleOrDefault();
            group.id_organizer = id_organizer;
            group.admin = name;
            _context.groups.Add(group);
            _context.SaveChanges();
        }
        /*
        Description:Updates an Group to Group table 
        Params:Object Group
        Output:None
       */
        public void UpdateGroupRecord(Group group)
        {
            _context.groups.Update(group);
            _context.SaveChanges();
        }
        /*
        Description:Deletes an Group to Group table 
        Params:id Group
        Output:None
       */
        public void DeleteGroupRecord(string id)
        {
            
            var entity = _context.groups.FirstOrDefault(t => t.id_group == id);
            _context.groups.Remove(entity);
            _context.SaveChanges();
        }
        /*
        Description:Gets an Group to Group table 
        Params:id Organizer
        Output:Organizer object
       */
        public Group GetGroupSingleRecord(string id)
        { 
            return _context.groups.FirstOrDefault(t => t.id_group == id);
        }

        /*
        Description:Gets all the Group in Group table 
        Params:none
        Output:List of all the Group
       */
        public List<Group> GetGroupRecords()
        {
            return _context.groups.ToList();
        }
        /*
       Description:Gets a Group to Group table by token
       Params:token
       Output:Organizer object
      */
        public List<Group> GetGroupByToken(string token)
        {
            string id_organizer = _context.onlineusers.Where(ou => ou.token == token).Select(a => a.id_organizer_fk).SingleOrDefault();
            return _context.groups.Where(t => t.id_organizer == id_organizer).ToList();
        }

        /*
       Description:Adds a RaceSponsorship to RaceSponsorship table 
       Params:Object RaceSponsorship
       Output:None
      */
        public void AddRaceSponsorshipRecord(RaceSponsorship rsponsorship)
        {
            
            _context.racehassponsor.Add(rsponsorship);
            _context.SaveChanges();
        }
        /*
        Description:Updates a RaceSponsorship to RaceSponsorship table 
        Params:Object RaceSponsorship
        Output:None
       */
        public void UpdateRaceSponsorshipRecord(RaceSponsorship rsponsorship)
        {
            _context.racehassponsor.Update(rsponsorship);
            _context.SaveChanges();
        }
        /*
        Description:Deletes an RaceSponsorship to RaceSponsorship table 
        Params:id ChallengeSponsorship
        Output:None
       */
        public void DeleteRaceSponsorshipRecord(string id)
        {

            var entity = _context.racehassponsor.FirstOrDefault(r => r.id == id);
            _context.racehassponsor.Remove(entity);
            _context.SaveChanges();
        }
        /*
        Description:Gets an RaceSponsorship to RaceSponsorship table 
        Params:id RaceSponsorship
        Output:RaceSponsorship object
       */
        public RaceSponsorship GetRaceSponsorshipSingleRecord(string id)
        {
            return _context.racehassponsor.FirstOrDefault(r => r.id == id);
        }

        /*
        Description:Gets all the RaceSponsorship in RaceSponsorship table 
        Params:none
        Output:List of all the RaceSponsorship
       */
        public List<RaceSponsorship> GetRaceSponsorshipRecords()
        {
            return _context.racehassponsor.ToList();
        }
        /*
       Description:Gets a Group to Group table by token
       Params:token
       Output:Organizer object
      */
        public List<RaceSponsorship> GetRaceSponsorshipByIDRace(string idrace)
        {
            var raceList = _context.racehassponsor.Where(r => r.id_race == idrace).ToList();
            return raceList;
        }
        /*
        Description:Adds a ChallengeSponsorship to ChallengeSponsorship table 
        Params:Object ChallengeSponsorship
        Output:None
       */
        public void AddChallengeSponsorshipRecord(ChallengeSponsorship chsponsorship)
        {
            _context.challengehassponsor.Add(chsponsorship);
            _context.SaveChanges();
        }
        /*
        Description:Updates a ChallengeSponsorship to ChallengeSponsorship table 
        Params:Object ChallengeSponsorship
        Output:None
       */
        public void UpdateChallengeSponsorshipRecord(ChallengeSponsorship chsponsorship)
        {
            _context.challengehassponsor.Update(chsponsorship);
            _context.SaveChanges();
        }
        /*
        Description:Deletes an ChallengeSponsorship to ChallengeSponsorship table 
        Params:id ChallengeSponsorship
        Output:None
       */
        public void DeleteChallengeSponsorshipRecord(string id)
        {

            var entity = _context.challengehassponsor.FirstOrDefault(t => t.id == id);
            _context.challengehassponsor.Remove(entity);
            _context.SaveChanges();
        }
        /*
        Description:Gets an ChallengeSponsorship to ChallengeSponsorship table 
        Params:id ChallengeSponsorship
        Output:ChallengeSponsorship object
       */
        public ChallengeSponsorship GetChallengeSponsorshipSingleRecord(string id)
        {
            return _context.challengehassponsor.FirstOrDefault(ch => ch.id == id);
        }

        /*
        Description:Gets all the Group in Group table 
        Params:none
        Output:List of all the Group
       */
        public List<ChallengeSponsorship> GetChallengeSponsorshipRecords()
        {
            return _context.challengehassponsor.ToList();
        }
        /*
       Description:Gets a Group to Group table by token
       Params:token
       Output:Organizer object
      */
        public List<ChallengeSponsorship> GetChallengeSponsorshipByIDChallenge(string id)
        {
            var id_organizer = _context.challengehassponsor.Where(ch => ch.id == id).ToList();
            return id_organizer;
        }
        /*
       Description:Adds an athlete to AthleteBelongsGroup table 
       Params:AthleteBelongsGroup
       Output:AthleteBelongsGroup object
      */

        public void AddAthleteBelongsGroupRecord(AthleteBelongsGroup athletebelongsgroup, string token)
        {
            string id_athlete = _context.onlineusers.Where(ou => ou.token == token).Select(a => a.id_athlete_fk).SingleOrDefault();
            athletebelongsgroup.id_athlete = id_athlete;
            _context.athletebelongsgroup.Add(athletebelongsgroup);
            _context.SaveChanges();
        }
        /*
       Description:Updates an athlete to AthleteBelongsGroup table 
       Params:AthleteBelongsGroup
       Output:AthleteBelongsGroup object
      */

        public void UpdateAthleteBelongsGroupRecord(AthleteBelongsGroup athletebelongsgroup)
        {
            _context.athletebelongsgroup.Update(athletebelongsgroup);
            _context.SaveChanges();
        }
        /*
       Description:Deletes an athlete to AthleteBelongsGroup table 
       Params:id
       Output:AthleteBelongsGroup object
      */

        public void DeleteAthleteBelongsGroupRecord(string id)
        {
            var entity = _context.athletebelongsgroup.FirstOrDefault(abg => abg.id == id);
            _context.athletebelongsgroup.Remove(entity);
            _context.SaveChanges();
        }
        /*
       Description:Get an AthleteBelongsGroup table 
       Params:id
       Output:AthleteBelongsGroup object
      */

        public AthleteBelongsGroup GetAthleteBelongsGroupSingleRecord(string id)
        {
            return _context.athletebelongsgroup.FirstOrDefault(abg => abg.id == id);
        }
        /*
       Description:Get all the AthleteBelongsGroup table 
       Params:token
       Output:AthleteBelongsGroup object
      */
        public List<AthleteBelongsGroup> GetAthleteBelongsGroupRecords()
        {
            return _context.athletebelongsgroup.ToList();
        }
        /*
       Description:Get a  Groups with token 
       Params:token
       Output:athletebelongsgroup object
      */
        public List<Group> GetGroupsByAthleteToken(string token)
        {
            string id_athlete = _context.onlineusers.Where(ou => ou.token == token).Select(a => a.id_athlete_fk).SingleOrDefault();
            var groupsIds = _context.athletebelongsgroup.Where(abg => abg.id_athlete == id_athlete).Select(abg => abg.id_group).ToArray();
            return _context.groups.Where(g => groupsIds.Contains(g.id_group)).ToList();
        }
        /*
       Description:Gets challenge to ChallengeByOrganizerToken table 
       Params:token
       Output:Challenges object
      */
        public List<Challenge> GetChallengeByOrganizerToken(string organizertoken) {
            string idorganizer = _context.onlineusers.Where(ou => ou.token == organizertoken).Select(ou => ou.id_organizer_fk).SingleOrDefault();
            return _context.challenge.Where(ch => ch.id_organizer == idorganizer).ToList();
        }
        /*
       Description:Deletes an Challenges to Challenges table 
       Params:id
       Output:Challenges object
      */
        public void DeleteChallengeRecord(string id)
        {
            var entity = _context.challenge.FirstOrDefault(ch => ch.id_challenge == id);
            _context.challenge.Remove(entity);
            _context.SaveChanges();
        }
        /*
       Description:Updates a Challenge to Challenges table 
       Params:id
       Output:Challenges object
      */
        public void UpdateChallengeRecord(Challenge challenge)
        {
            _context.challenge.Update(challenge);
            _context.SaveChanges();
        }
        /*
        Description:Gets an Challenge with the specified id 
        Params:id Challenge
        Output:Challenge object
       */
        public Challenge GetChallengeSingleRecord(string id)
        {

            return _context.challenge.FirstOrDefault(ch=> ch.id_challenge == id);
        }

    }
}
