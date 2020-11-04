using System;
using StraviaTECRestFullAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StraviaTECRestFullAPI.DataAccess
{
    public interface IDataAccessProvider
    {
        void AddOrganizerRecord(Organizer patient);
        void UpdateOrganizerRecord(Organizer patient);
        void DeleteOrganizerRecord(string id);
        Organizer GetOrganizerSingleRecord(string id);
        List<Organizer> GetOrganizerRecords();
        Array GetOrganizersName();

        void AddAthleteRecord(Athlete athlete);
        void UpdateAthleteRecord(Athlete athlete);
        void DeleteAthleteRecord(string id);
        Athlete GetAthleteSingleRecord(string id);
        List<Athlete> GetAthleteRecords();
    }
}
