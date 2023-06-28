using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmpTask.Models;
using System.Data;


namespace EmpTask.Controllers
{
    [RoutePrefix("User")]
    public class UserController : Controller
    {


        [HttpGet]
        [Route("IndexViewModel")]
        public ActionResult IndexViewModel()
        {
            State_Bind();
            return View();
        }


        public ActionResult Index()
        {

            UserDetailBLL bl = new UserDetailBLL();
            List<UserDetail> userDetails = bl.userDetails();

            return View(userDetails);
        }



        [HttpPost]


      
        public ActionResult Create(UserDetail model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UserDetail p = new UserDetail
                    {
                        Name = model.Name,
                        Phone = model.Phone,
                        Email = model.Email,
                        Address = model.Address,
                        StateId = model.StateId,
                        CityId = model.CityId
                    };

                    UserDetailBLL bl = new UserDetailBLL();
                    if (bl.Create(p))
                    {
                        return RedirectToAction("IndexViewModel");
                    }
                    else
                    {
                        return Json(new { success = false, message = "Failed to create UserDetail." });
                    }
                }
                else
                {
                    var errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage));
                    return Json(new { success = false, message = "Model state is not valid.", errors = errors });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "An error occurred: " + ex.Message });
            }
        }



        [HttpGet]
        public ActionResult Edit(int id)
        {
            UserDetailBLL bl = new UserDetailBLL();
            UserDetail p = bl.DetailsById(id);
            return View(p);
        }



        [HttpPost]
        public ActionResult Edit(UserDetail userDetail)
        {
            UserDetailBLL bl = new UserDetailBLL();
            if (bl.Update(userDetail))
            {
                return RedirectToAction("IndexViewModel");
            }

            return View(userDetail);
        }

        [HttpGet]
        [ActionName("Delete")]
        public ActionResult Delete_Get(int Id)
        {
            UserDetailBLL bl = new UserDetailBLL();
            UserDetail p = bl.DetailsById(Id);
            return View(p);
        }


        [HttpPost]
        [ActionName("Delete")]
        public ActionResult Delete_Post(int Id)
        {
            UserDetailBLL bl = new UserDetailBLL();
            if (bl.Delete(Id))
            {
                return RedirectToAction("IndexViewModel");
            }
            UserDetail p = bl.DetailsById(Id);
            return View(p);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            UserDetailBLL bl = new UserDetailBLL();
            UserDetail p = bl.DetailsById(id);
            return View(p);
        }

        public void State_Bind()
        {
            stateCityDB db = new stateCityDB();
            DataSet ds = db.GetState();
            List<SelectListItem> statelist = new List<SelectListItem>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                statelist.Add(new SelectListItem {Text=dr["StateName"].ToString(),Value=dr["Id"].ToString() });
            }
             ViewBag.state = statelist;
        }

        public JsonResult CityBind(string stateId)
        {
            stateCityDB db = new stateCityDB();
            DataSet ds = db.GetCity(stateId);
            List<SelectListItem> citylist = new List<SelectListItem>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                citylist.Add(new SelectListItem { Text = dr["CityName"].ToString(), Value = dr["Id"].ToString() });
            }
            return Json(citylist,JsonRequestBehavior.AllowGet);
        }
        
     


    }
}