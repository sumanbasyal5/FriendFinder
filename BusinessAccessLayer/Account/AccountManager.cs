using DataAccessLayer.Account;
using Mapper.Account;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Account
{
    public class AccountManager
    {
        private AccountService _accountService;
        public AccountManager()
        {
            _accountService = new AccountService();
        }
        
        /// <summary>
        /// Author:Suman Basyal
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public bool CheckUserNameAndPassword(Login login)
        {
            var entityUser = AccountMapper.ConvertToEntity(login);
            return  _accountService.CheckUsernameAndPassword(entityUser);
        }

        /// <summary>
        /// Author: Suman Basyal
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public bool SaveUserDetails(Login login)
        {
            var entityUser = AccountMapper.ConvertToEntity(login);
            bool result=_accountService.SaveUserDetails(entityUser);
            return result;
        }

        /// <summary>
        /// Author:Suman Basyal
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool IsEmailExist(string email)
        {
            return _accountService.IsEmailExist(email);
        }

        public IEnumerable<Login> GetUserAsPerCity(string cityName,int currentCountryId, int  currentStateId, int  permanentCountryId)
        {
            var entityList = _accountService.GetUserAsPerCity(cityName,currentCountryId,currentStateId,permanentCountryId).ToList();
            return AccountMapper.ConvertToModel(entityList);
        }

        public int GetUserIdViaEmail(string email)
        {
            return _accountService.GetUserIdViaEmail(email);
        }

        public IEnumerable<Login> GetAllUser()
        {
            var list=_accountService.GetAllUser().ToList();
            var convertedList = AccountMapper.ConvertToModel(list);
            return convertedList;
        }

        public Model.Login GetUserInfo(string email)
        {
             return AccountMapper.ConvertToModel(_accountService.GetUserInfo(email));
        }

        public bool SaveUserPhoto(string email, byte[] array)
        {
            return _accountService.UploadImage(email, array);
        }
    }
}
