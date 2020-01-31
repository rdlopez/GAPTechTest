using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GAPTechTest.DataAccess;
using GAPTechTest.Models;
using GAPTechTest.Tests.Controllers.API;

namespace GAPTechTest.Web.Controllers
{
    public class PoliciesController : Controller
    {
        PolicyControllerAPI policyAPI;

        public PoliciesController()
        {
            policyAPI = new PolicyControllerAPI();
        }

        // GET: Policies
        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                var policies = policyAPI.GetAll();
                return View(policies);
            }
            catch (Exception ex)
            {
                //ToDo: Implement log to save detailed exception.
                return null;
            }
            
        }

        //// GET: Policies/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Policy policy = db.Policies.Find(id);
        //    if (policy == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(policy);
        //}

        // GET: Policies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Policies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,StartDate,Period,RiskType,Price")] Policy policy)
        {
            if (ModelState.IsValid)
            {
                var result = policyAPI.CreatePolicy(policy);
                return RedirectToAction("Index");
            }

            return View(policy);
        }

        // GET: Policies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Policy policy = policyAPI.GetById((int)id);
            if (policy == null)
            {
                return HttpNotFound();
            }
            return View(policy);
        }

        // POST: Policies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,StartDate,Period,RiskType,Price")] Policy policy)
        {
            if (ModelState.IsValid)
            {
                policyAPI.UpdatePolicy(policy);
                return RedirectToAction("Index");
            }
            return View(policy);
        }

        // GET: Policies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Policy policy = policyAPI.GetById((int)id);
            if (policy == null)
            {
                return HttpNotFound();
            }
            return View(policy);
        }

        // POST: Policies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            policyAPI.DeletePolicy(id);
            return RedirectToAction("Index");
        }        
    }
}
