﻿using RestfulApiExample.Models;

namespace RestfulApiExample.Services
{
    public interface IAdvertService
    {
        List<Advert> GetAdverts(AdvertFilter filter);
        AdvertDetail GetAdvertById(int id);
        void AddVisit(int advertId, string ipAddress);
    }
}
