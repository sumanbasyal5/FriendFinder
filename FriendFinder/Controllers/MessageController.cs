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
    public class MessageController : Controller
    {
        //
        // GET: /Message/
        MessageManager _messageManager;
        AccountManager _accountManager;
        public MessageController()
        {
            _messageManager = new MessageManager();
            _accountManager = new AccountManager();
        }

        public ActionResult Index()
        {
            IEnumerable<Login> listLogin=_accountManager.GetAllUser();
            return View(listLogin);
        }

        public JsonResult FindMessageNumber()
        {
            string userEmail = User.Identity.Name;
            int messageNumber=_messageManager.FindMessageNumber(userEmail);
            return Json(messageNumber, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllMessageFromSender(int? senderId)
        {
            var receiverId = _accountManager.GetUserIdViaEmail(User.Identity.Name);
            var list=_messageManager.GetAllMessageFromSender(Convert.ToInt32(senderId),receiverId);
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllUnSeenMessagesFromSender(int ?senderId)
        {
            var receiverId=_accountManager.GetUserIdViaEmail(User.Identity.Name);
            var list = _messageManager.GetAllUnSeenMessagesFromSender(Convert.ToInt32(senderId),receiverId);
            return Json(list, JsonRequestBehavior.AllowGet);
        }


        

    }
}
