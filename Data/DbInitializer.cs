using SmartPark.Models;
using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace SmartPark.Data
{
    public static class DbInitializer
    {
        public static void Initialize(SmartParkContext context)
        {
            context.Database.EnsureCreated();

            // --- SEED USERS (Uporabniki) ---
            if (context.UserSMs.Any())
            {
                return; // DB already seeded
            }

            var userSMja = new UserSM[]
            {
                new UserSM { FirstName = "Janez", LastName = "Novak", Email = "janez.novak@example.com", Phone = "+38640123456" },
                new UserSM { FirstName = "Ana", LastName= "Kovač", Email = "ana.kovac@example.com", Phone = "+38640123457" },
                new UserSM { FirstName = "Miha", LastName = "Horvat", Email = "miha.horvat@example.com", Phone = "+38640123458" }
            };
            context.UserSMs.AddRange(userSMja);
            context.SaveChanges();

            // --- SEED PARKIRIŠČA (Parking lots) ---
            var parkingL = new ParkingLot[]
            {
                new ParkingLot { Location = "Ljubljana - Center", Capacity = 100 },
                new ParkingLot { Location = "Ljubljana - BTC", Capacity = 200 }
            };
            context.ParkingLots.AddRange(parkingL);
            context.SaveChanges();

            // --- SEED PARKIRNA MESTA (Parking spots) ---
            var parkingSpots = new ParkingSpot[]
            {
                new ParkingSpot { IsOccupied = false, ParkingLotID = parkingL[0].ParkingLotID },
                new ParkingSpot { IsOccupied = false, ParkingLotID = parkingL[0].ParkingLotID },
                new ParkingSpot { IsOccupied = true,  ParkingLotID = parkingL[1].ParkingLotID }
            };
            context.ParkingSpots.AddRange(parkingSpots);
            context.SaveChanges();

            // --- SEED REZERVACIJE (Reservations) ---
            var reservations = new Reservation[]
            {
                new Reservation
                {
                    ReservationID = 1,
                    UserSMId = userSMja[0].Id,
                    ParkingSpotID = parkingSpots[2].ParkingSpotID,
                    StartTime = DateTime.Now.AddHours(-1),
                    EndTime = DateTime.Now.AddHours(2)
                },
                new Reservation
                {
                    ReservationID = 2,
                    UserSMId = userSMja[1].Id,
                    ParkingSpotID = parkingSpots[1].ParkingSpotID,
                    StartTime = DateTime.Now.AddHours(1),
                    EndTime = DateTime.Now.AddHours(3)
                }
            };
            context.Reservations.AddRange(reservations);
            context.SaveChanges();
/*
            // --- SEED ADMINISTRATOR ROLES & USERS (Identity) ---
            var roles = new IdentityRole[]
            {
                new IdentityRole { Name = "Administrator", NormalizedName = "ADMINISTRATOR" },
                new IdentityRole { Name = "Uporabnik", NormalizedName = "UPORABNIK" }
            };
            foreach (var role in roles)
            {
                if (!context.Roles.Any(r => r.Name == role.Name))
                    context.Roles.Add(role);
            }
            context.SaveChanges();

            var adminUser = new ApplicationUser
            {
                FirstName = "Admin",
                LastName = "SmartPark",
                Email = "admin@smartpark.si",
                NormalizedEmail = "ADMIN@SMARTPARK.SI",
                UserName = "admin@smartpark.si",
                NormalizedUserName = "ADMIN@SMARTPARK.SI",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D")
            };

            if (!context.Users.Any(u => u.UserName == adminUser.UserName))
            {
                var passwordHasher = new PasswordHasher<ApplicationUser>();
                adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, "Admin123!");
                context.Users.Add(adminUser);
                context.SaveChanges();

                var adminRole = context.Roles.First(r => r.Name == "Administrator");
                context.UserRoles.Add(new IdentityUserRole<string>
                {
                    RoleId = adminRole.Id,
                    UserId = adminUser.Id
                });
                context.SaveChanges();
            }
*/
        }
    }
}