using Nancy;
using System.Collections.Generic;
namespace HelloNancy
{
    public class HelloModule : NancyModule
    {
        public HelloModule()
        {
            Get("/", args =>
            {

                ViewBag.MyMessageToUsers = "Hello from me.";
                ViewBag.AnswerText = "Cool!";
                ViewBag.show = true;
                ViewBag.list = Session["user"];

                List<string> listOfStuffToDisplay = new List<string>{"cassidy","preeya","cindy"};

                return View["Hello.sshtml", listOfStuffToDisplay];
            });
            Post("/formsubmitted", args =>
            {
                string User = Request.Form["first_name"];
                Session["user"] = User;
                return Response.AsRedirect("/");
            });


        }
    }
}