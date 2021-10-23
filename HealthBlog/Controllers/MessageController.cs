using FluentValidation.Results;
using HealthBlog.Bussiness.Concrete;
using HealthBlog.Bussiness.FluentValidation;
using HealthBlog.DataAccess.Concrete.EntityFramework;
using HealthBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HealthBlog.Controllers
{
    public class MessageController : Controller
    {
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        MessageValidator messageValidator = new MessageValidator();



        [HttpPost]
        public ActionResult IncomingMessages(Message message)
        {

            message.MessageDate = DateTime.Now;
            message.ReceiverMail = "yukseloguzhan53@gmail.com";
            ValidationResult results = messageValidator.Validate(message);

            if (results.IsValid)
            {
                messageManager.MessageAdd(message);
                return RedirectToAction("Index", "Default");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return RedirectToAction("Contact", "Contact");
        }

        public PartialViewResult MessageListMenu()
        {
            var list = messageManager.GetInboxList("yukseloguzhan53@gmail.com");
            ViewBag.number =  list.Count();
            return PartialView();
        }

        public ActionResult GetContactDetails(int id)
        {
            var messageValues = messageManager.MessageGetByID(id);
            return View(messageValues);
        }
        public ActionResult DeleteMessage(int id)
        {
            var message = messageManager.MessageGetByID(id);
            messageManager.MessageDelete(message);
            return RedirectToAction("AdminContact", "Contact");
        }


    }
}