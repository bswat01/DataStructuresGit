using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dataStructuresGIT.Controllers
{
    public class QueueController : Controller
    {
        static Queue<string> myQueue= new Queue<string>();

        // GET: Queue
        public ActionResult Index()
        {
            //ViewBag.MyQueue = myQueue;
            return View("Index");
        }
        //Method adds one entry to the Queue
        public ActionResult AddOne()
        {
            myQueue.Enqueue("New Entry " + (myQueue.Count + 1));

            return View("Index");
        }
        //Method adds 2000 entries to the queue
        public ActionResult HugeList()
        {
            myQueue.Clear();
            for (int iCount = 0; iCount < 2000; iCount++)
            {
                myQueue.Enqueue("New Entry " + (iCount + 1));
            }

            return View("Index");
        }

        public ActionResult DisplayQueue()
        {
            if (myQueue.Count == 0)
            {
                ViewBag.MyQueue = null;
                ViewBag.Clear = "There is nothing in the queue to display!";
            }
            else
            {
                ViewBag.MyQueue = myQueue;
            }
            return View("Index");
        }
        public ActionResult DeleteFromQueue()
        {
            if (myQueue.Count == 0)
            {
                ViewBag.Clear = "There is nothing in the queue to delete!";
            }
            else
            {
                myQueue.Dequeue();
            }
            return View("Index");
        }
        public ActionResult ClearQueue()
        {
            myQueue.Clear();
            ViewBag.MyQueue = null;
            ViewBag.Clear = "The Queue is now clear!";
            return View("Index");
        }
        public ActionResult SearchQueue()
        {
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

            sw.Start();

            if (myQueue.Count == 0)
            {
                ViewBag.Clear = "There is nothing in the queue!";
            }
            else
            {
                string sSearch = "New Entry 20";
                foreach (var vSearch in myQueue)
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