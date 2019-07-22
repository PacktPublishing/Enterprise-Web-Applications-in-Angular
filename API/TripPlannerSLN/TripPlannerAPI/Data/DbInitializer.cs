using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TripPlanner.DAL.Entities;
using TripPlanner.DAL.Models;

namespace TripPlannerAPI.Data
{
    public static class DbInitializer
    {
        public static void Initialize(TripPlannerDBContext context)
        {
            context.Database.EnsureCreated();

            var defaultRole = new Role { Name = "AppUser", Description = "Application Users" };
            if (!context.Roles.Any())
            {
                context.Roles.Add(defaultRole);
                context.SaveChanges();
            }

            if (!context.Users.Any())
            {
                var defaultUser = new User
                {
                    Email = "nitin.rastogi@live.in",
                    Fname = "Nitin",
                    Lname = "Rastogi",
                    IsActive = true,
                    Pwd = "Test123"
                };
                context.Users.Add(defaultUser);


                context.SaveChanges();
                context.UserRoles.Add(new UserRole { UserId = defaultUser.Id, RoleId = defaultRole.Id });
                context.SaveChanges();
            }

            if (!context.Trips.Any())
            {
                

                Trip defaultTrip = new Trip
                {
                    Name = "Road Trip to East Coast",
                    Detail = "Road trip covering Charlotte to Orlando",
                    StartDate = DateTime.Now.AddMonths(1),
                    CreatedById = 1                    
                };
                context.Trips.Add(defaultTrip);
                context.SaveChanges();

                Stay defaultStay = new Stay
                {
                    Name = "Stay in Country Inn",
                    Detail = "Country Inn in Charlotte"
                };
                context.Stays.Add(defaultStay);
                context.SaveChanges();

                defaultTrip.StayId = defaultStay.Id;
                context.SaveChanges();

                Address address = new Address
                {
                    Name = "Hotel Address",
                    Address1 = "2012 San Jones Rd",
                    Address2 = "",
                    City = "Charlotte",
                    State = "NC",
                    Zip = "125487",
                    TripId= defaultTrip.Id
                };

                context.Addresses.Add(address);
                context.SaveChanges();
            }
            
        }
    }
}
