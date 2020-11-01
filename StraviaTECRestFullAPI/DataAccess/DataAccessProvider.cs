using System;
using StraviaTECRestFullAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace StraviaTECRestFullAPI.DataAccess
{
    public class DataAccessProvider : IDataAccessProvider
    {
        private readonly PostgreSqlContext _context;

        public DataAccessProvider(PostgreSqlContext context)
        {
            _context = context;
        }

        public void AddPatientRecord(Patient patient)
        {
            _context.patients.Add(patient);
            _context.SaveChanges();
        }

        public void UpdatePatientRecord(Patient patient)
        {
            _context.patients.Update(patient);
            _context.SaveChanges();
        }

        public void DeletePatientRecord(string id)
        {
            var entity = _context.patients.FirstOrDefault(t => t.id == id);
            _context.patients.Remove(entity);
            _context.SaveChanges();
        }

        public Patient GetPatientSingleRecord(string id)
        {
            return _context.patients.FirstOrDefault(t => t.id == id);
        }
        public Array GetPatientsName()
        {
            
            var nameList = _context.patients.Select(p => p.name).ToArray();
            return nameList;
            
            

        }
        public List<Patient> GetPatientRecords()
        {
            return _context.patients.ToList();
        }

        public void AddAthleteRecord(Athlete athlete)
        {
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
    }
}
