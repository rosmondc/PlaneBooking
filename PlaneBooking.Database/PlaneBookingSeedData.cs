using Microsoft.AspNetCore.Identity;
using PlaneBooking.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PlaneBooking.Database
{
    public static class PlaneBookingSeedData
    {
        public static void EnsureDataSeed(this PlaneBookingContext db, RoleManager<CustomIdentityRole> roleManager)
        {

            if (!roleManager.RoleExistsAsync("NormalUser").Result)
            {
                CustomIdentityRole role = new CustomIdentityRole();
                role.Name = "NormalUser";
                role.Description = "Perform normal operations.";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }


            if (!roleManager.RoleExistsAsync("Administrator").Result)
            {
                CustomIdentityRole role = new CustomIdentityRole();
                role.Name = "Administrator";
                role.Description = "Perform all the operations.";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }


            if (!db.Tutors.Any() || !db.TutorAvailabilities.Any())
            {
                var tutor = new List<Tutor>
                {
                    new Tutor
                    {
                        Description = "Mike",
                        CreatedAt = DateTime.Now,
                        Availabilities = new List<TutorAvailability>
                        {
                            new TutorAvailability
                            {
                                TutorId = 1,
                                Description = "Free slot",
                                ScheduleDate = new DateTime(2020, 08, 15),
                                CreatedAt = DateTime.Now
                            },
                            new TutorAvailability
                            {
                                TutorId = 1,
                                Description = "Free slot 2",
                                ScheduleDate = new DateTime(2020, 08, 16),
                                CreatedAt = DateTime.Now
                            },
                            new TutorAvailability
                            {
                                TutorId = 1,
                                Description = "Free slot 3",
                                ScheduleDate = new DateTime(2020, 08, 17),
                                CreatedAt = DateTime.Now
                            }
                        }

                    },
                    new Tutor
                    {
                        Description = "George",
                        CreatedAt = DateTime.Now,
                        Availabilities = new List<TutorAvailability>
                        {
                            new TutorAvailability
                            {
                                TutorId = 2,
                                Description = "Free slot 1",
                                ScheduleDate = new DateTime(2020, 08, 15),
                                CreatedAt = DateTime.Now
                            },
                            new TutorAvailability
                            {
                                TutorId = 2,
                                Description = "Free slot 2",
                                ScheduleDate = new DateTime(2020, 08, 17),
                                CreatedAt = DateTime.Now
                            }
                        }
                    }
                };

                db.Tutors.AddRange(tutor);

                var airport = new List<Airport>
                {
                    new Airport
                    {
                        Description = "Panso",
                        CreatedAt = DateTime.Now,
                        Location = "Panama",
                        Planes = new List<Plane>
                        {
                            new Plane
                            {
                                Description = "MiG-21",
                                CreatedAt = DateTime.Now,
                                PlaneDepartures = new List<PlaneDeparture>
                                {
                                    new PlaneDeparture
                                    {
                                        PlaneId = 1,
                                        Description = "Free slot",
                                        Departure = new DateTime(2020, 09, 15),
                                        CreatedAt = DateTime.Now
                                    },
                                    new PlaneDeparture
                                    {
                                        PlaneId = 1,
                                        Description = "Free slot",
                                        Departure = new DateTime(2020, 09, 18),
                                        CreatedAt = DateTime.Now
                                    }
                                }

                            },
                            new Plane
                            {
                                Description = "Hawker",
                                CreatedAt = DateTime.Now,
                                PlaneDepartures = new List<PlaneDeparture>
                                {
                                    new PlaneDeparture
                                    {
                                        PlaneId = 2,
                                        Description = "Free slot",
                                        Departure = new DateTime(2020, 08, 15),
                                        CreatedAt = DateTime.Now
                                    }
                                }

                            }
                            ,
                            new Plane
                            {
                                Description = "B-52",
                                CreatedAt = DateTime.Now,
                                PlaneDepartures = new List<PlaneDeparture>
                                {
                                    new PlaneDeparture
                                    {
                                        PlaneId = 3,
                                        Description = "Free slot",
                                        Departure = new DateTime(2020, 08, 10),
                                        CreatedAt = DateTime.Now
                                    }
                                }

                            }
                        }
                    }
                };

                db.Airports.AddRange(airport);

                db.SaveChanges();
            }
        }
    }
}
