using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataStructuresAssignment.Controllers
{
    public class DictionaryController : Controller
    {

        //Creates static dicitonary object
        static Dictionary<string, int> myDictionary = new Dictionary<string, int>();

        // GET: Dictionary
        public ActionResult Index()
        {
            return View();
        }

        //Add one item to dictionary
        public ActionResult AddOne()
        {
            //Int to hold increment amount
            int iNextEntry = 1;

            //Finds next available key value
            while (myDictionary.ContainsKey("New Entry " + (iNextEntry)))
            {
                iNextEntry++;
            }

            //Adds new key value pair to dictionary
            myDictionary.Add("New Entry " + iNextEntry, iNextEntry);

            //Notifes user that a new entry was added
            ViewBag.Message = "New Entry " + (iNextEntry) + " has been added to the dictionary.";

            return View("Index");
        }

        //Add huge list of items to dictionary
        public ActionResult AddList()
        {
            //Clears the dictionary
            myDictionary.Clear();

            //Generates 2000 items in the dictionary
            for (int i = 0; i < 2000; i++)
            {
                myDictionary.Add("New Entry " + (myDictionary.Count + 1), myDictionary.Count + 1);
            }

            //Notifies user that items have been created
            ViewBag.Message = "2000 new entries have been created.";

            return View("Index");
        }

        //Display dictionary
        public ActionResult Display()
        {
            //Updates the view bag
            ViewBag.Dictionary = myDictionary;

            return View("Index");
        }

        //Delete from dictionary
        public ActionResult DeleteItem()
        {
            //Creates a random number generator
            Random oRand = new Random();

            //Int that holds value to be deleted
            int iDelete;

            //Int that holds max value in dictionary
            int iMaxValue = (myDictionary.Count);

            //List that holds dictionary
            List<int> lDictCopy = new List<int>();

            //If the dictionary is empty the user is notified, otherwise a random value is picked to delete
            if (myDictionary.Count == 0)
            {
                ViewBag.Message = "The dictionary is empty. Nothing was deleted.";
            }
            else
            {
                //Saves dictionary into a list
                foreach (KeyValuePair<string, int> dictItem in myDictionary)
                {
                    lDictCopy.Add(dictItem.Value);
                }

                //Generates random number
                iDelete = oRand.Next(lDictCopy.Count);

                //Removes random item from dictionary
                myDictionary.Remove("New Entry " + lDictCopy[iDelete]);
                ViewBag.Message = "\'New Entry " + lDictCopy[iDelete] + "\' was deleted.";
            }

            return View("Index");
        }

        //Clear dictionary
        public ActionResult Clear()
        {
            //Clears the dictionary
            myDictionary.Clear();

            //Notifies the user that the dictionary has been cleared
            ViewBag.Message = "The Dictionary has been cleared!";

            return View("Index");
        }

        //Search dictionary
        public ActionResult Search()
        {
            //String variable that is searched for
            string sSearch = "New Entry 15";

            //Creates new timer variable
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

            //Sets default message displayed to user
            ViewBag.Message = "\'" + sSearch + "\' was not found.";

            //Starts the stopwatch
            sw.Start();

            //Searches dictionary for specified string
            foreach (KeyValuePair<string, int> vSearch in myDictionary)
            {
                if (sSearch == vSearch.Key)
                {
                    ViewBag.Message = "\'" + sSearch + "\' was found!";
                }
            }

            //Stops the stopwatch
            sw.Stop();

            //Calculates elapsed time
            TimeSpan ts = sw.Elapsed;

            //Adds elapsed time to viewbag
            ViewBag.Message += " Elapsed search time: " + ts;

            return View("Index");
        }

    }
}