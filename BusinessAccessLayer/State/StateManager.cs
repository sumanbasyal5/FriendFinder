using DataAccessLayer;
using Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessAccessLayer.State;

namespace BusinessAccessLayer
{
    public class StateManager
    {
        StateService _stateService;
        public StateManager()
        {
            _stateService = new StateService();
        }

        public IEnumerable<Model.State> GetStatePerCountryId(int countryId)
        {
            var listState=_stateService.GetAllStatePerCountry(countryId); 
            return StateMapper.ConvertToModel(listState);
        }

        public IEnumerable<Model.State> GetStates()
        {
            var listState = _stateService.GetAllStates();
            return StateMapper.ConvertToModel(listState);
        }
    }
}
