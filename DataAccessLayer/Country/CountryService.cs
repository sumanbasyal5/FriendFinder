using DataAccessLayer.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
namespace DataAccessLayer
{
    public class CountryService:BaseEntity
    {
        public IEnumerable<Country> GetAllCountries()
        {
            IEnumerable<Country> listCountry = new List<Country>();
            try
            {
                listCountry=dbEntity.Countries.ToList();
            }
            catch(Exception ex)
            {
                return null;
            }
            return listCountry;
        }
    }
}
