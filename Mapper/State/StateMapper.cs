using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapper
{
    public class StateMapper
    {
        public static IEnumerable<Model.State> ConvertToModel(IEnumerable<Entity.State> listEntity)
        {
            IList<Model.State> listState= new List<Model.State>();
            try{
                foreach(var entity in listEntity)
                {
                    Model.State state = new Model.State();
                    state.countryId = entity.countryId;
                    state.stateId = entity.stateId;
                    state.stateName = entity.name;
                    listState.Add(state);

                }
            }
            catch(Exception ex)
            {
                return null;
            }
            return listState;
        }
    }
}
