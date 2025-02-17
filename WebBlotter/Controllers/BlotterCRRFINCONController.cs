﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebBlotter.Classes;
using WebBlotter.Models;
using WebBlotter.Repository;

namespace WebBlotter.Controllers
{
    [AuthAccess]
    public class BlotterCRRFINCONController : Controller
    {
        // GET: BlotterCRRFINCON

        UtilityClass UC = new UtilityClass();

        public ActionResult BlotterCRRFINCON(FormCollection form)
        {
            #region Added by shakir (Currency parameter)

            var selectCurrency = (dynamic)null;
            if (form["selectCurrency"] != null)
                selectCurrency = Convert.ToInt32(form["selectCurrency"].ToString());
            else
                selectCurrency = Convert.ToInt32(Session["SelectedCurrency"].ToString());
            UtilityClass.GetSelectedCurrecy(selectCurrency);

            #endregion

            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("/api/BlotterCRRFINCON/GetAllBlotterCRRFINCON?UserID=" + Session["UserID"].ToString() + "&BranchID=" + Session["BranchID"].ToString() + "&CurID=" + Session["SelectedCurrency"].ToString() + "&BR=" + Session["BR"].ToString());
            response.EnsureSuccessStatusCode();
            List<Models.SBP_BlotterCRRFINCON> blotterCRRFINCON = response.Content.ReadAsAsync<List<Models.SBP_BlotterCRRFINCON>>().Result;
            if (blotterCRRFINCON.Count < 1)
                ViewData["DataStatus"] = "Data Not Availavle";
            ViewBag.Title = "All Blotter Setup";
            var PAccess = Session["CurrentPagesAccess"].ToString().Split('~');
            UtilityClass.ActivityMonitor(Convert.ToInt32(Session["UserID"]), Session.SessionID, Request.UserHostAddress.ToString(), new Guid().ToString(), JsonConvert.SerializeObject(blotterCRRFINCON), this.RouteData.Values["action"].ToString(), Request.RawUrl.ToString());

            ViewData["isDateChangable"] = Convert.ToBoolean(PAccess[2]);
            ViewData["isEditable"] = Convert.ToBoolean(PAccess[3]);
            ViewData["IsDeletable"] = Convert.ToBoolean(PAccess[4]);
            return PartialView("_BlotterCRRFINCON", blotterCRRFINCON);
        }


        [HttpGet]
        public ActionResult Create()
        {
            var ActiveAction = RouteData.Values["action"].ToString();
            var ActiveController = RouteData.Values["controller"].ToString();
            Session["ActiveAction"] = ActiveController;
            Session["ActiveController"] = ActiveAction;

            UtilityClass.ActivityMonitor(Convert.ToInt32(Session["UserID"]), Session.SessionID, Request.UserHostAddress.ToString(), new Guid().ToString(), "", this.RouteData.Values["action"].ToString(), Request.RawUrl.ToString());
            SBP_BlotterCRRFINCON model = new SBP_BlotterCRRFINCON();
            try
            {
                if (ModelState.IsValid)
                {
                    model.CreateDate = DateTime.Now.Date;
                }
            }
            catch (Exception ex) { }
            return PartialView("_Create", model);

        }
        public ActionResult Create(FormCollection form)
        {
            #region Added by shakir (Currency parameter)

            var selectCurrency = (dynamic)null;
            if (form["selectCurrency"] != null)
                selectCurrency = Convert.ToInt32(form["selectCurrency"].ToString());
            else
                selectCurrency = Convert.ToInt32(Session["SelectedCurrency"].ToString());
            UtilityClass.GetSelectedCurrecy(selectCurrency);

            #endregion

            SBP_BlotterCRRFINCON model = new SBP_BlotterCRRFINCON();
            try
            {
                if (ModelState.IsValid)
                {
                    model.CreateDate = DateTime.Now.Date;
                }
            }
            catch (Exception ex) { }
            return PartialView("_Create", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult _Create(SBP_BlotterCRRFINCON BlotterCRRFINCON, FormCollection form)
        {
            try
            {
                #region Added by shakir (Currency parameter)

                var selectCurrency = (dynamic)null;
                if (form["selectCurrency"] != null)
                    selectCurrency = Convert.ToInt32(form["selectCurrency"].ToString());
                else
                    selectCurrency = Convert.ToInt32(Session["SelectedCurrency"].ToString());
                UtilityClass.GetSelectedCurrecy(selectCurrency);

                #endregion

                if (ModelState.IsValid)
                {

                    BlotterCRRFINCON.UserID = Convert.ToInt16(Session["UserID"].ToString());
                    BlotterCRRFINCON.BID = Convert.ToInt16(Session["BranchID"].ToString());
                    BlotterCRRFINCON.BR = Convert.ToInt16(Session["BR"].ToString());
                    BlotterCRRFINCON.CurID = Convert.ToInt16(Session["SelectedCurrency"].ToString());
                    BlotterCRRFINCON.CreateDate = DateTime.Now;
                    UtilityClass.ActivityMonitor(Convert.ToInt32(Session["UserID"]), Session.SessionID, Request.UserHostAddress.ToString(), new Guid().ToString(), JsonConvert.SerializeObject(BlotterCRRFINCON), this.RouteData.Values["action"].ToString(), Request.RawUrl.ToString());
                    ServiceRepository serviceObj = new ServiceRepository();
                    HttpResponseMessage response = serviceObj.PostResponse("api/BlotterCRRFINCON/InsertCRRFINCON", BlotterCRRFINCON);
                    response.EnsureSuccessStatusCode();
                    return RedirectToAction("BlotterCRRFINCON");
                }
            }
            catch (Exception ex) { }
            return PartialView("_Create", BlotterCRRFINCON);
        }

        public ActionResult Edit(int id, FormCollection form)
        {
            #region Added by shakir (Currency parameter)

            var selectCurrency = (dynamic)null;
            if (form["selectCurrency"] != null)
                selectCurrency = Convert.ToInt32(form["selectCurrency"].ToString());
            else
                selectCurrency = Convert.ToInt32(Session["SelectedCurrency"].ToString());
            UtilityClass.GetSelectedCurrecy(selectCurrency);

            #endregion

            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("/api/BlotterCRRFINCON/GetBlotterCRRFINCON?id=" + id.ToString());
            response.EnsureSuccessStatusCode();
            Models.SBP_BlotterCRRFINCON BlotterCRRFINCON = response.Content.ReadAsAsync<Models.SBP_BlotterCRRFINCON>().Result;
            UtilityClass.ActivityMonitor(Convert.ToInt32(Session["UserID"]), Session.SessionID, Request.UserHostAddress.ToString(), new Guid().ToString(), JsonConvert.SerializeObject(BlotterCRRFINCON), this.RouteData.Values["action"].ToString(), Request.RawUrl.ToString());
            return PartialView("_Edit", BlotterCRRFINCON);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(Models.SBP_BlotterCRRFINCON BlotterCRRFINCON)
        {
            BlotterCRRFINCON.UserID = Convert.ToInt16(Session["UserID"].ToString());
            BlotterCRRFINCON.BID = Convert.ToInt16(Session["BranchID"].ToString());
            BlotterCRRFINCON.BR = Convert.ToInt16(Session["BR"].ToString());
            BlotterCRRFINCON.CurID = Convert.ToInt16(Session["SelectedCurrency"].ToString());
            BlotterCRRFINCON.UpdateDate = DateTime.Now;
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.PutResponse("api/BlotterCRRFINCON/UpdateCRRFINCON", BlotterCRRFINCON);
            response.EnsureSuccessStatusCode();
            //ViewData["SysCurrentDt"] = GetCurrentDT().ToString("dd-MMM-yyyy");
            //ViewData["BrCode"] = BrCode;
            UtilityClass.ActivityMonitor(Convert.ToInt32(Session["UserID"]), Session.SessionID, Request.UserHostAddress.ToString(), new Guid().ToString(), JsonConvert.SerializeObject(BlotterCRRFINCON), this.RouteData.Values["action"].ToString(), Request.RawUrl.ToString());
            return RedirectToAction("BlotterCRRFINCON");
        }

        public ActionResult Delete(int id)
        {
            UtilityClass.ActivityMonitor(Convert.ToInt32(Session["UserID"]), Session.SessionID, Request.UserHostAddress.ToString(), new Guid().ToString(), JsonConvert.SerializeObject(id), this.RouteData.Values["action"].ToString(), Request.RawUrl.ToString());
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.DeleteResponse("api/BlotterCRRFINCON/DeleteCRRFINCON?id=" + id.ToString());
            response.EnsureSuccessStatusCode();
            return RedirectToAction("BlotterCRRFINCON");
        }
    }
}