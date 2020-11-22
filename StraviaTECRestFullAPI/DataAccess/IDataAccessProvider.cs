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
        List<Race> GetRacesByToken(string token);
        Race GetRaceSingleRecord(string idrace);
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

        /*
       Description: CRUD Operations for AthletesEnrollsChallenge
       */
        void AddChallengeEnrollmentRecord(AthleteEnrollsChallenge atEnCh, string token);
        void UpdateChallengeEnrollmentRecord(AthleteEnrollsChallenge atEnCh);
        void DeleteChallengeEnrollmentRecord(int id);
        AthleteEnrollsChallenge GetChallengeEnrollmentSingleRecord(int id);
        List<AthleteEnrollsChallenge> GetChallengeEnrollmentRecords();
        List<Challenge> GetChallengeEnrollmentByToken(string athletetoken);
        /*
       Description: CRUD Operations for Challenge
       */
        List<Challenge> GetChallengeByOrganizerToken(string organizertoken);
        Challenge GetChallengeSingleRecord(string id);
        void UpdateChallengeRecord(Challenge challenge);
        void DeleteChallengeRecord(string id);

        /*
       Description: CRUD Operations for AthletesEnrollsRace
       */
        void AddRaceEnrollmentRecord(AthleteEnrollsRace atEnRa, string token);
        void UpdateRaceEnrollmentRecord(AthleteEnrollsRace atEnRa);
        void DeleteRaceEnrollmentRecord(int id);
        AthleteEnrollsRace GetRaceEnrollmentSingleRecord(int id);
        List<AthleteEnrollsRace> GetRaceEnrollmentRecords();
        List<Race> GetRaceEnrollmentByToken(string athletetoken);

        /*
        Description: CRUD Operations for Activity
       */
        void AddActivityRecord(Activity activity, string token);
        void UpdateActivityRecord(Activity activity);
        void DeleteActivityRecord(string actId);
        Activity GetActivitySingleRecord(string actId);
        List<Activity> GetActivityByToken(string token);
        List<Activity> GetActivityRecords();
        List<ActivityType> GetActivityTypes();
        /*
       Description: CRUD Operations for group
      */
        void AddGroupRecord(Group group, string token);
        void UpdateGroupRecord(Group group);
        void DeleteGroupRecord(string idgroup);
        Group GetGroupSingleRecord(string idgroup);
        List<Group> GetGroupRecords();
        List<Group> GetGroupByToken(string token);

        /*
        Description: CRUD Operations for RaceSponsorship 
       */
        void AddRaceSponsorshipRecord(RaceSponsorship raceSponsorship);
        void UpdateRaceSponsorshipRecord(RaceSponsorship raceSponsorship);
        void DeleteRaceSponsorshipRecord(string id);
        RaceSponsorship GetRaceSponsorshipSingleRecord(string id);
        List<RaceSponsorship> GetRaceSponsorshipRecords();
        List<RaceSponsorship> GetRaceSponsorshipByIDRace(string id);

        /*
        Description: CRUD Operations for ChallengeSponsorship 
       */
        void AddChallengeSponsorshipRecord(ChallengeSponsorship challengeSponsorship);
        void UpdateChallengeSponsorshipRecord(ChallengeSponsorship challengeSponsorship);
        void DeleteChallengeSponsorshipRecord(string id);
        ChallengeSponsorship GetChallengeSponsorshipSingleRecord(string id);
        List<ChallengeSponsorship> GetChallengeSponsorshipRecords();
        List<ChallengeSponsorship> GetChallengeSponsorshipByIDChallenge(string id);

        /*
        Description: CRUD Operations for AthleteBelongsGroup 
       */
        void AddAthleteBelongsGroupRecord(AthleteBelongsGroup athletebelongsgroup, string token);
        void UpdateAthleteBelongsGroupRecord(AthleteBelongsGroup athletebelongsgroup);
        void DeleteAthleteBelongsGroupRecord(string id);
        AthleteBelongsGroup GetAthleteBelongsGroupSingleRecord(string id);
        List<AthleteBelongsGroup> GetAthleteBelongsGroupRecords();
        List<Group> GetGroupsByAthleteToken(string token);







    }
}
