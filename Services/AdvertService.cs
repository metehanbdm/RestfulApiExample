using RestfulApiExample.Models;
using RestfulApiExample.Repositories;

namespace RestfulApiExample.Services
{
    public class AdvertService : IAdvertService
    {
        private readonly IAdvertRepository _advertRepository;

        public AdvertService(IAdvertRepository advertRepository)
        {
            _advertRepository = advertRepository;
        }

        public List<Advert> GetAdverts(AdvertFilter filter)
        {
            return _advertRepository.GetAdverts(filter);
        }

        public AdvertDetail GetAdvertById(int id)
        {
            return _advertRepository.GetAdvertById(id);
        }

        public void AddVisit(int advertId, string ipAddress)
        {
            _advertRepository.AddVisit(advertId, ipAddress);
        }
    }
}
