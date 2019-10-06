using System;
using System.Collections.Generic;
using Sdayu.DAL.Types.Domain;

namespace Sdayu.DAL.Tests.Factories
{
    public static class RoomFactory
    {
        public static Room Create(Guid id)
        {
            return new Room {Id = id};
        }

        public static Room Create()
        {
            return new Room {Id = new Guid()};
        }

        public static Room WithTitle(this Room room, string title)
        {
            room.Title = title;
            return room;
        }

        public static Room WithBooking(this Room room, ICollection<Booking> bookingDtos)
        {
            room.Bookings = bookingDtos;
            return room;
        }

        public static Room WithHotel(this Room room, Hotel hotel)
        {
            room.Hotel = hotel;
            return room;
        }

        public static Room WithPeopleCount(this Room room, int count)
        {
            room.PeopleCount = count;
            return room;
        }

        public static Room WithDescription(this Room room, string description)
        {
            room.Description = description;
            return room;
        }

        //public static Room WithImageRoomId(this Room room, Guid? imageRoomId = null) ToDo
        //{
        //    room.ImageRoomId = imageRoomId;
        //    return room;
        //}

        public static Room WithRoomTypeId(this Room room, Guid? roomTypeId = null)
        {
            room.RoomTypeId = roomTypeId;
            return room;
        }
   
        public static Room WithRoomType(this Room room, RoomType roomType)
        {
            room.RoomType = roomType;
            return room;
        }

        public static Room WithPrice(this Room room, double price)
        {
            room.Price = price;
            return room;
        }

        public static Room WithRooms(this Room room, string description)
        {
            room.BedDescription = description;
            return room;
        }
    }
}