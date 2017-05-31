using BusinessAccessLayer;
using BusinessAccessLayer.Account;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FriendFinder.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        CountryManager _countryManager;
        StateManager _stateManager;
        GenderManager _genderManager;
        MessageManager _messageManager;
        AccountManager _accountManager;
        public HomeController()
        {
            _countryManager = new CountryManager();
            _stateManager = new StateManager();
            _genderManager = new GenderManager();
            _messageManager = new MessageManager();
            _accountManager = new AccountManager();
        }

        [Authorize]
        public ActionResult Index()
        {
            Login login = new Login();
            login.listGender = _genderManager.GetAllGender();
            login.listCountry = _countryManager.GetAllCountries();
            login.listState = _stateManager.GetStates();
            return View(login);
        }

        public JsonResult GetListOfCountries()
        {
            try
            {
                var listCountries=_countryManager.GetAllCountries();
                return Json(listCountries, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public JsonResult SaveMessage(int? receiverId, string message)
        {
            string email = User.Identity.Name;
            bool result=_messageManager.SaveMessage(message, Convert.ToInt32(receiverId), _accountManager.GetUserIdViaEmail(email));
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Profile()
        {
            Model.Login login = new Model.Login();
            login = _accountManager.GetUserInfo(User.Identity.Name);
            return View(login);
        }
    }
}
