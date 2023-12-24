using Dapper;
using RestfulApiExample.Models;
using System;
using System.Data;
using System.Data.Common;
using System.Text;

namespace RestfulApiExample.Repositories
{
    public class AdvertRepository : IAdvertRepository
    {
        private readonly IDbConnection _dbConnection;

        public AdvertRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public List<Advert> GetAdverts(AdvertFilter filter)
        {
            var query = "SELECT * FROM Adverts WHERE 1=1";

            // Filtreleme işlemleri
            if (filter.CategoryId > 0)
            {
                query += " AND categoryId = @CategoryId";
            }

            if (filter.Price.HasValue)
            {
                query += " AND price <= @Price";
            }

            if (!string.IsNullOrEmpty(filter.Gear))
            {
                query += " AND gear = @Gear";
            }

            if (!string.IsNullOrEmpty(filter.Fuel))
            {
                query += " AND fuel = @Fuel";
            }

            // Sıralama işlemi 
            query += $" ORDER BY price,year,km";

            // Sayfalama işlemi
            query += " OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY";

            var parameters = new
            {
                CategoryId = filter.CategoryId,
                Price = filter.Price,
                Gear = filter.Gear,
                Fuel = filter.Fuel,
                Offset = (filter.Page - 1) * filter.PageSize,
                PageSize = filter.PageSize
            };

            // Dapper kullanarak veritabanından reklamları çek
            var result = _dbConnection.Query<Advert>(query, parameters).ToList();

            return result;
        }

        public AdvertDetail GetAdvertById(int advertId)
        {
            var query = "SELECT * FROM Adverts WHERE id = @AdvertId";
            var result = SqlMapper.QueryFirstOrDefault<AdvertDetail>(_dbConnection, query, new { AdvertId = advertId });

            return result ?? new AdvertDetail();
        }

        public async void AddVisit(int advertId, string ipAddress)
        {
            string sql = "INSERT INTO AdvertVisits (advertId, iPAdress, visitDate) VALUES (@AdvertId, @IPAddress, @VisitDate)";
            await _dbConnection.ExecuteAsync(sql, new { AdvertId = advertId, IPAddress = GetClientIPAddress(), VisitDate = DateTime.UtcNow });
        }

        private string GetClientIPAddress()
        {
            Random random = new Random();
            int randomNumber = random.Next(1,10);

            // Gerekirse istemcinin IP adresini alma kodu ekleyebilirsiniz
            return "127.0.0."+ randomNumber;
        }
    }
}
