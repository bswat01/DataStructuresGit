using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dataStructuresGIT.Controllers
{
    public class StackController : Controller
    {
        static Stack<string> myStack = new Stack<string>();

        // GET: Stack
        public ActionResult Index()
        {
            //ViewBag.MyStack = myStack;
            return View("Index");
        }
        //Method adds one entry to the stack
        public ActionResult AddOne()
        {
            myStack.Push("New Entry " + (myStack.Count + 1));

            return View("Index");
        }
        //Method adds 2000 entries to the stack
        public ActionResult HugeList()
        {
            myStack.Clear();
            for (int iCount = 0; iCount < 2000; iCount++)
            {
                myStack.Push("New Entry " + (iCount + 1));
            }

            return View("Index");
        }

        public ActionResult DisplayStack()
        {
            if (myStack.Count == 0)
            {
                ViewBag.MyStack = null;
                ViewBag.Clear = "There is nothing in the stack to display!";
            }
            else
            {
                ViewBag.MyStack = myStack;
            }
            return View("Index");
        }
        public ActionResult DeleteFromStack()
        {
            if (myStack.Count == 0)
            {
                ViewBag.Clear = "There is nothing in the stack to delete!";
            }
            else
            {
                myStack.Pop();
            }
            return View("Index");
        }
        public ActionResult ClearStack()
        {
            myStack.Clear();
            ViewBag.MyStack = null;
            ViewBag.Clear = "The Stack is now clear!";
            return View("Index");
        }
        public ActionResult SearchStack()
        {
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

            sw.Start();

            if (myStack.Count == 0)
            {
                ViewBag.Clear = "There is nothing in the stack!";
            }
            else
            {
                string sSearch = "New Entry 20";
                foreach (var vSearch in myStack)
                {
                    if (sSearch == vSearch)
                    {
                        ViewBag.Clear = "Search results: \"New Entry 20\" was found!";
                    }
                }
                if (ViewBag.Clear == null)
                {
                    ViewBag.Clear = "Search results: \"New Entry 20\" was NOT found!";
                }
                sw.Stop();

                TimeSpan ts = sw.Elapsed;

                ViewBag.Clear += " Time elapsed for search: " + ts;
            }
            return View("Index");
        }

    }
}