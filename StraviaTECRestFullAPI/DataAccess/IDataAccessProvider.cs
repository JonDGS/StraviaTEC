using System;
using StraviaTECRestFullAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StraviaTECRestFullAPI.DataAccess
{
    public interface IDataAccessProvider
    {
        void AddPatientRecord(Patient patient);
        void UpdatePatientRecord(Patient patient);
        void DeletePatientRecord(string id);
        Patient GetPatientSingleRecord(string id);
        List<Patient> GetPatientRecords();
        Array GetPatientsName();

        void AddAthleteRecord(Athlete athlete);
        void UpdateAthleteRecord(Athlete athlete);
        void DeleteAthleteRecord(string id);
        Athlete GetAthleteSingleRecord(string id);
        List<Athlete> GetAthleteRecords();
    }
}
