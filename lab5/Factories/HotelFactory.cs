using System;
using System.Collections.Generic;
using Sdayu.DAL.Types.Domain;

namespace Sdayu.DAL.Tests.Factories
{
    public static class HotelFactory
    {
        public static Hotel Create(Guid id)
        {
            return new Hotel() {Id = id};
        }
        
        public static Hotel Create()
        {
            return new Hotel() {Id = new Guid()};
        }
        
        public static Hotel WithTitle(this Hotel hotel, string title){
            hotel.Title = title;
            return hotel;
        }
        
        public static Hotel WithRating(this Hotel hotel, double rating){
            hotel.Rating = rating;
            return hotel;
        }

        public static Hotel WithDescription(this Hotel hotel, string description){
            hotel.Description = description;
            return hotel;
        }
        
        public static Hotel WithImageHotelId(this Hotel hotel, List<HotelImage> images = null){
            hotel.HotelImages = images ?? new List<HotelImage>();
            return hotel;
        }
        
        public static Hotel WithHotelTypeId(this Hotel hotel, Guid? hotelTypeId = null){
            hotel.HotelTypeId = hotelTypeId;
            return hotel;
        }

        public static Hotel WithCity(this Hotel hotel, City city = null){
            if (city == null)
            {
                var country = new Country()
                {
                    Id = new Guid(),
                    Title = "Country",
                    Regions = new List<Region>()
                };

                var region = new Region()
                {
                    Id = new Guid(),
                    Title = "Region",
                    Country = country,
                    Cities = new List<City>(),
                    CountryId = country.Id
                };

                hotel.City = new City()
                {
                    Id = new Guid(),
                    Title = "City",
                    Region = region,
                    Hotels = new List<Hotel>() {hotel},
                    RegionId = region.Id
                };
            }
            hotel.City = city;
            return hotel;
        }

        public static Hotel WithHotelType(this Hotel hotel,  HotelType hotelType){
            hotel.HotelType = hotelType;
            return hotel;
        }
        
        public static Hotel WithComments(this Hotel hotel, ICollection<Comment> comments = null)
        {
            hotel.Comments = comments ?? new List<Comment>();
            return hotel;
        }

        public static Hotel WithRooms(this Hotel hotel, ICollection<Room> rooms = null){
            hotel.Rooms = rooms ?? new List<Room>();
            return hotel;
        }
    }
}

