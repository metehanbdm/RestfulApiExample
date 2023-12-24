using RestfulApiExample.Models;

namespace RestfulApiExample.Repositories
{
    public interface IAdvertRepository
    {
        List<Advert> GetAdverts(AdvertFilter filter);
        AdvertDetail GetAdvertById(int id);
        void AddVisit(int advertId, string ipAddress);
    }
}
