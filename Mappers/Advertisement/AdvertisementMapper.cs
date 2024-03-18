using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Dtos.Advertisement;
using Backend.Models;

namespace Backend.Mappers
{
    public static class AdvertisementMapper
    {
         public static AdvertisementDto ToAdvertisementDto(this Advertisement advertisementModel)
        {
            return new AdvertisementDto
            {
                Id = advertisementModel.Id,
                AdvertisementEmail = advertisementModel.AdvertisementEmail,
                Price = advertisementModel.Price,
                NumberOfDays = advertisementModel.NumberOfDays,
                StartDate = advertisementModel.StartDate,
            };
        }

        public static Advertisement ToAdvertisementFromCreateDTO(this AdvertisementDto advertisementDto)
        {
            return new Advertisement
            {
                Id = advertisementDto.Id,
                AdvertisementEmail = advertisementDto.AdvertisementEmail,
                Price = advertisementDto.Price,
                NumberOfDays = advertisementDto.NumberOfDays,
                StartDate = advertisementDto.StartDate,
            };
        }

        }
}
//