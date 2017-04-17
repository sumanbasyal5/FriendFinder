using BusinessAccessLayer;
using BusinessAccessLayer.Account;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FriendFinder.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        AccountManager _accountManager;
        GenderManager _genderManager;
        CountryManager _countryManager;
        StateManager _stateManager;
        public LoginController()
        {
            _accountManager = new AccountManager();
            _genderManager = new GenderManager();
            _countryManager = new CountryManager();
            _stateManager = new StateManager();
        }

        public ActionResult Index()
        {
            Login login = new Login();
            return View(login);
        }

        [HttpPost]
        public ActionResult Index(Login login)
        {
            if(ModelState.IsValid)
            {
                bool result = _accountManager.CheckUserNameAndPassword(login);
                if(result)
                {
                    FormsAuthentication.SetAuthCookie(login.Email, true);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Error = "Incorrect username or password";
                    return View(login);
                }
            }
            ViewBag.Error = "Invalid";

            return View(login);
        }

        public ActionResult Register()
        {
            Login login = new Login();
            login.listGender = _genderManager.GetAllGender();
            login.listCountry = _countryManager.GetAllCountries();
            login.listState = _stateManager.GetStates();
            return View(login);
        }

        [HttpPost]
        public ActionResult Register(Login login)
        {
            if(ModelState.IsValid)
            {
                bool result=_accountManager.SaveUserDetails(login);
                FormsAuthentication.SetAuthCookie(login.Email, true);
                return RedirectToAction("Index", "Home");
            }
            return View(login);
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Login login = new Login();

            return RedirectToAction("Index", "Login", login);
        }

        public JsonResult IsEmailExists(string email)
        {
            bool result= _accountManager.IsEmailExist(email);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SearchUser(string cityName, int? currentCountryId, int? currentStateId, int? permanentCountryId)
        {
            var list=_accountManager.GetUserAsPerCity(cityName,Convert.ToInt32(currentCountryId),Convert.ToInt32(currentStateId),Convert.ToInt32(permanentCountryId));
            return Json(list, JsonRequestBehavior.AllowGet);
        }

    }
}
