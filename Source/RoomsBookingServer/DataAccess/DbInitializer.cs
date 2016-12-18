﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;
using Data.Enums;

namespace DataAccess
{
    public class DbInitializer : DropCreateDatabaseIfModelChanges<DataContext>
    {
        public DbInitializer()
        {

        }
        protected override void Seed(DataContext context)
        {
            var admin = new User
            {
                Login = "admin",
                Role = Role.Admin,
                Password = "33354741122871651676713774147412831195"
            };

            var user = new User
            {
                Login = "user1",
                Role = Role.User,
                Password = "33354741122871651676713774147412831195"
            };

            var users = new Collection<User> {admin, user};

            var rooms = new Collection<MeetingRoom>
            {
                new MeetingRoom
                {
                    RoomNumber = "101",
                    NumberOfSeats = 10,
                    IsBoardAvailable = true,
                    IsProjectorAvailable = false
                },
                new MeetingRoom
                {
                    RoomNumber = "102",
                    NumberOfSeats = 6,
                    IsBoardAvailable = false,
                    IsProjectorAvailable = false
                },
                new MeetingRoom
                {
                    RoomNumber = "210",
                    NumberOfSeats = 30,
                    IsBoardAvailable = true,
                    IsProjectorAvailable = true
                },
            };

            context.Users.AddRange(users);
            context.MeetingRooms.AddRange(rooms);
            base.Seed(context);
        }
    }
}
