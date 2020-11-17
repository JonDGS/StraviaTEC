﻿using System;
using StraviaTECRestFullAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StraviaTECRestFullAPI.DataAccess
{
    public interface IDataAccessProvider
    {
        void AddOrganizerRecord(Organizer organizer);
        void UpdateOrganizerRecord(Organizer organizer);
        void DeleteOrganizerRecord(string id);
        Organizer GetOrganizerSingleRecord(string id);
        List<Organizer> GetOrganizerRecords();
        Array GetOrganizersName();

        void AddAthleteRecord(Athlete athlete);
        void UpdateAthleteRecord(Athlete athlete);
        void DeleteAthleteRecord(string id);
        Athlete GetAthleteSingleRecord(string id);
        List<Athlete> GetAthleteRecords();

        string AddOnlineUserRecord(LogInUserMsg userInfo);
        //void UpdateOnlineUserRecord(OnlineUser onlineUser);
        void DeleteOnlineUserRecord(string token);
        OnlineUser GetOnlineUserSingleRecord(string token);
        List<OnlineUser> GetOnlineUserRecords();
    }
}