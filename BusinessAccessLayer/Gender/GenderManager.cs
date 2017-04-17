using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessAccessLayer
{
    public class GenderManager
    {
        private GenderService _genderService;
        public GenderManager()
        {
            _genderService = new GenderService();
        }
        public IEnumerable<Item> GetAllGender()
        {
            var list=_genderService.GetAllGender().Select(x => new Item { Id = x.genderId, Name = x.type }).ToList();
            return list;
        }
    }
}
