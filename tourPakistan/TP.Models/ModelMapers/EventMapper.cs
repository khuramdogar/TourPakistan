﻿using System;
using System.Linq;
using TP.Models.DomainModels;
using TP.Models.WebModels;

namespace TP.Models.ModelMapers
{
    public static class EventMapper
    {
        public static EventModel MapFromServerToClient(this Event source)
        {
            return new EventModel
            {
                EventId = source.EventId,
                Title = source.Title,
                Description = source.Description,
                ScheduledDate = source.ScheduledDate,
                EndDate = source.EndDate,
                RegistrationStartDate = source.RegistrationStartDate,
                RegistrationEndDate = source.RegistrationEndDate,
                RecCreatedBy = source.RecCreatedBy,
                RecCreatedByName = source.AspNetUser.FirstName,
                RecCreatedDate = source.RecCreatedDate,
                RecLastUpdatedBy = source.RecLastUpdatedBy,
                RecLastUpdatedDate = source.RecLastUpdatedDate,
                LocationName = source.Location.LocationName,
                LocationId = source.Location.LocationId,
                LocationImage = Convert.ToBase64String(source.Location.LocationImages.OrderByDescending(x=>x.RecCreatedDate).First().ImageData)
            };
        }

        public static Event MapFromClientToServer(this EventModel source)
        {
            return new Event
            {
                EventId = source.EventId,
                Title = source.Title,
                Description = source.Description,
                ScheduledDate = source.ScheduledDate,
                EndDate = source.EndDate,
                RegistrationStartDate = source.RegistrationStartDate,
                RegistrationEndDate = source.RegistrationEndDate,
                RecCreatedBy = source.RecCreatedBy,
                RecCreatedDate = source.RecCreatedDate,
                RecLastUpdatedDate = source.RecLastUpdatedDate,
                RecLastUpdatedBy = source.RecLastUpdatedBy,
                LocationId = source.LocationId
            };
        }
    }
}
