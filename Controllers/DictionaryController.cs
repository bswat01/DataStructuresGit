using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dataStructuresGIT.Controllers
{
    public class DictionaryController : Controller
    {
        static Dictionary<int, string> myDict = new Dictionary<int, string>();

        // GET: Dictionary
        public ActionResult Index()
        {
            return View("Index");
        }
        //Method adds one entry to the stack
        public ActionResult AddOne()
        {
            myDict.Add((myDict.Count + 1), ("New Entry " + (myDict.Count + 1)));

            return View("Index");
        }
        //Method adds 2000 entries to the stack
        public ActionResult HugeList()
        {
            myDict.Clear();
            for (int iCount = 0; iCount < 2000; iCount++)
            {
                myDict.Add((iCount + 1), ("New Entry " + (iCount + 1)));
            }

            return View("Index");
        }

        public ActionResult DisplayDict()
        {
            if (myDict.Count == 0)
            {
                ViewBag.MyDict = null;
                ViewBag.DictClear = "There is nothing in the dictionary to display!";
            }
            else
            {
                ViewBag.MyDict = myDict;
            }
            return View("Index");
        }
        public ActionResult DeleteFromDict()
        {
            if (myDict.Count == 0)
            {
                ViewBag.DictClear = "There is nothing in the dictionary to delete!";
            }
            else
            {
                myDict.Remove(myDict.Count);
            }
            return View("Index");
        }
        public ActionResult ClearDict()
        {
            myDict.Clear();
            ViewBag.MyStack = null;
            ViewBag.DictClear = "The dictionary is now clear!";
            return View("Index");
        }
        public ActionResult SearchDict()
        {
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

            sw.Start();

            if (myDict.Count == 0)
            {
                ViewBag.DictClear = "There is nothing in the dictionary!";
            }
            else
            {
                string sSearch = "New Entry 20";
                foreach (KeyValuePair<int, string> vSearch in myDict)
                {
                    if (sSearch == vSearch.Value)
                    {
                        ViewBag.DictClear = "Search results: \"New Entry 20\" was found!";
                    }
                }
                if (ViewBag.DictClear == null)
                {
                    ViewBag.DictClear = "Search results: \"New Entry 20\" was NOT found!";
                }
                sw.Stop();

                TimeSpan ts = sw.Elapsed;

                ViewBag.DictClear += " Time elapsed for search: " + ts;
            }
            return View("Index");
        }
    }
}