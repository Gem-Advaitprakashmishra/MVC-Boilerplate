using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using mvcBolierplate.Models;

namespace mvcBolierplate.Controllers
{
    public class HomeController : Controller
    {
        // GET: City
        Helper helper = new Helper();
      
        [HttpGet]
        public ActionResult Index()
        {
            return View(helper.show());
        }
        public ActionResult Create()
        {
            return View(new cityModel());
        }

        // POST: City/Create
        [HttpPost]
        public ActionResult Create(cityModel CityModel)
        {   
            helper.addnew(CityModel);
            return RedirectToAction("Index");
        }

        // GET: City/Edit/5
        public ActionResult Edit(int id)
        {
            DataTable dt = helper.Edit(id);
            if (dt.Rows.Count == 1)
            {
                cityModel CityModel = new cityModel();
                CityModel.CityId = Convert.ToInt32(dt.Rows[0][0].ToString());
                CityModel.CityName = dt.Rows[0][1].ToString();
                return View(CityModel);
            }
            else
                return RedirectToAction("Index");
        }

        // POST: City/Edit/5
        [HttpPost]
        public ActionResult Edit(cityModel CityModel)
        {
           helper.Edit(CityModel);
            return RedirectToAction("Index");
        }

        // GET: City/Delete/5
        public ActionResult Delete(int id)
        {
            helper.Delete(id);
            return RedirectToAction("Index");
        }

        // POST: City/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
