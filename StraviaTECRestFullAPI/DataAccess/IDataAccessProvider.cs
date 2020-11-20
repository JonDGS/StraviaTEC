using System;
using StraviaTECRestFullAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StraviaTECRestFullAPI.DataAccess
{
    public interface IDataAccessProvider
    {
        /*
        Description: CRUD Operations for organizer 
        */
        void AddOrganizerRecord(Organizer organizer);
        void UpdateOrganizerRecord(Organizer organizer);
        void DeleteOrganizerRecord(string token);
        Organizer GetOrganizerSingleRecord(string token);
        List<Organizer> GetOrganizerRecords();
        Array GetOrganizersName();
        /*
        Description: CRUD Operations for athlete 
       */
        void AddAthleteRecord(Athlete athlete);
        void UpdateAthleteRecord(Athlete athlete);
        void DeleteAthleteRecord(string token);

        Athlete GetAthleteSingleRecord(string token);
        List<Athlete> GetAthleteRecords();
        /*
        Description: CRUD Operations for online users 
       */
        OnlineUser AddOnlineUserRecord(LogInUserMsg userInfo);
        void DeleteOnlineUserRecord(string token);
        OnlineUser GetOnlineUserSingleRecord(string token);
        List<OnlineUser> GetOnlineUserRecords();

        /*
        Description: CRUD Operations for race 
       */
        void AddRaceRecord(Race race,string token);
        void UpdateRaceRecord(Race race);
        void DeleteRaceRecord(string idrace);
        Race GetRaceSingleRecord(string token);
        List<Race> GetRaceRecords();

        /*
        Description: CRUD Operations for follows 
       */
        void AddFollowsRecord(FollowRequest followrequest);
        void UpdateFollowsRecord(FollowRequest followrequest);
        void DeleteFollowsRecord(FollowRequest followrequest);
        void DeleteFollowByToken(string token);

        List<Athlete> GetFolloweesRecord(FollowRequest followrequest);
        List<Athlete> GetFollowersRecord(FollowRequest followrequest);
        List<Follows> GetFollowsRecords();

    }
}
