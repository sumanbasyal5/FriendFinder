using Entity;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapper.Account
{
    public class AccountMapper
    {
        public static User ConvertToEntity(Login login )
        {
            User entityUser = new User();
            try
            {
                entityUser.email = login.Email;
                entityUser.password = login.Password;
                entityUser.currentAddress = login.CurrentAddress;
                entityUser.currentCity = login.CurrentCity;
                entityUser.currentCountryId = login.CurrentCountryId;
                entityUser.currentStateId = login.CurrentStateId;
                entityUser.dateOfBirth = login.DateOfBirth;
                entityUser.firstName = login.FirstName;
                entityUser.genderId = login.GenderId;
                entityUser.lastName = login.LastName;
                entityUser.permanentAddress = login.PermanentAddress;
                entityUser.permanentCity = login.PermanentCity;
                entityUser.permanentCountryId = login.PermanentCountryId;
                
            }
            catch(Exception ex)
            {
                return null;
            }
               return entityUser;
            
        }

        public static IEnumerable<Login> ConvertToModel(IList<User> entityList)
        {
            IList<Login> loginList = new List<Login>();
            try
            {
                foreach(var entity in entityList)
                {
                    Login login = new Login();
                    login.CurrentAddress = entity.currentAddress;
                    login.CurrentCity = entity.currentCity;
                    login.CurrentCountryId = entity.currentCountryId;
                    login.CurrentStateId = entity.currentStateId;
                    login.DateOfBirth = entity.dateOfBirth;
                    login.Email = entity.email;
                    login.FirstName = entity.firstName;
                    login.GenderId = entity.genderId;
                    login.LastName = entity.lastName;
                    login.PermanentAddress = entity.permanentAddress;
                    login.PermanentCity = entity.permanentCity;
                    login.PermanentCountryId = entity.permanentCountryId;
                    login.UserId = Convert.ToInt32(entity.userId).ToString();
                    loginList.Add(login);
                }
            }
            catch(Exception ex)
            {
                return null;
            }
            return loginList;
        }
    }
}
