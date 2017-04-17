using DataAccessLayer;
using Mapper;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer
{
    public class CountryManager
    {
        CountryService _countryService;
        public CountryManager()
        {
            _countryService = new CountryService();
        }
        
        public IEnumerable<Country> GetAllCountries()
        {
            var listEntityCountry = _countryService.GetAllCountries();
            IEnumerable<Country> modelCountryList = CountryMapper.ConvertCountryEntityToModel(listEntityCountry);
            return modelCountryList;
        }
    }
}
