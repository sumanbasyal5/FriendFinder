using DataAccessLayer.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace DataAccessLayer.Account
{
    public class AccountService:BaseEntity
    {
        public AccountService()
        {

        }

        /// <summary>
        /// Author Suman Basyal
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool CheckUsernameAndPassword(User user)
        {
            try
            {
                using(finderAppEntities dbEntity=new finderAppEntities())
                {
                    var entityUser = dbEntity.Users.FirstOrDefault(m => m.email.Equals(user.email) && m.password.Equals(user.password));
                    if (entityUser == null)
                        return false;
                    else
                        return true;
                }
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Author Suman basyal
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool SaveUserDetails(User user)
        {
            try
            {
                var entity=dbEntity.Users.FirstOrDefault(m => m.email.Equals(user.email));
                if(entity==null)
                {
                    dbEntity.Users.Add(user);
                    dbEntity.SaveChanges();
                    return true;
                }
                else
                {
                    //Record already exists
                    return false;
                }
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Author: Suman Basyal
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool IsEmailExist(string email)
        {
            try
            {
                var entity=dbEntity.Users.FirstOrDefault(m => m.email.Equals(email));
                if(entity==null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public IEnumerable<User> GetUserAsPerCity(string cityName, int currentCountryId, int currentStateId, int permanentCountryId)
        {
            IList<User> listUser = new List<User>();
            try
            {
                listUser=dbEntity.Users.Where(q => cityName.Contains(q.currentCity) 
                        && q.currentCountryId==currentCountryId
                        && q.currentStateId==currentStateId
                        && q.permanentCountryId==permanentCountryId
                    ).ToList();
                //listUser=dbEntity.Users.Where(m => m.currentCity.Equals(cityName)).ToList();
                return listUser;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public int GetUserIdViaEmail(string email)
        {
            try
            {
                return dbEntity.Users.FirstOrDefault(x => x.email == email).userId;
            }
            catch(Exception ex)
            {
                return 0;
            }
        }

       
    }
}
