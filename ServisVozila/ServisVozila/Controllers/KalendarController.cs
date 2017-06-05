using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DHTMLX.Scheduler;
using DHTMLX.Common;
using DHTMLX.Scheduler.Data;
using DHTMLX.Scheduler.Controls;
using ServisVozila.Models;

namespace paup_mcp.Controllers
{
    public class KalendarController : Controller
    {
        private PrijavaServisaDbContext db = new PrijavaServisaDbContext();

        public ActionResult KalendarDogadaja()
        {
            //Being initialized in that way, scheduler will use CalendarController.Data as a the datasource and CalendarController.Save to process changes
            var scheduler = new DHXScheduler(this);
            scheduler.Localization.Set("HRVATSKI"); // mjenja kalendar u hrvatski

                                                   /*
                                                   * It's possible to use different actions of the current controller
                                                   *      var scheduler = new DHXScheduler(this);     
                                                   *      scheduler.DataAction = "ActionName1";
                                                   *      scheduler.SaveAction = "ActionName2";
                                                   * 
                                                   * Or to specify full paths
                                                   *      var scheduler = new DHXScheduler();
                                                   *      scheduler.DataAction = Url.Action("Data", "Calendar");
                                                   *      scheduler.SaveAction = Url.Action("Save", "Calendar");
                                                   */


            /*
            * The default codebase folder is ~/Scripts/dhtmlxScheduler. It can be overriden:
            *      scheduler.Codebase = Url.Content("~/customCodebaseFolder");
            */

            // OVO SE ZAKOMENTIRA DA BUDE KALENDAR UPDATANI
            //scheduler.InitialDate = new DateTime(2012, 09, 03); 

            scheduler.LoadData = true;
            scheduler.EnableDataprocessor = true;

            return View(scheduler);
        }
        // OVO JE  UNUTAR DATA ALI SE MAKNE JER CEMO SPOJITI S SQL
        //new List<CalendarEvent>{ 
        //                new CalendarEvent{
        //                    id = 1, 
        //                    text = "Sample Event", 
        //                    start_date = new DateTime(2012, 09, 03, 6, 00, 00), 
        //                    end_date = new DateTime(2012, 09, 03, 8, 00, 00)
        //                },
        //                new CalendarEvent{
        //                    id = 2, 
        //                    text = "New Event", 
        //                    start_date = new DateTime(2012, 09, 05, 9, 00, 00), 
        //                    end_date = new DateTime(2012, 09, 05, 12, 00, 00)
        //                },
        //                new CalendarEvent{
        //                    id = 3, 
        //                    text = "Multiday Event", 
        //                    start_date = new DateTime(2012, 09, 03, 10, 00, 00), 
        //                    end_date = new DateTime(2012, 09, 10, 12, 00, 00)
        //                }
        //            }
        //        );
        //    return (ContentResult)data;
        //}

        // OVAJ POZIV JE ZA VIEV OD PRIJAVASERVISA ZA KALENDAR
        public ActionResult PrijavaServisa()
        {
            return View();
        }
        /* ovo je zbog primjera jer budem mozda tu iznad trebal pozivati db
        public ActionResult Admin()
        {
            return View(db.Servisi.ToList());
        }
        */
        public ActionResult PregledPrijavljenihServisa()
        {
            return View(db.PrServisa.ToList());
        }


        public ActionResult Register()

        {
            return View();
        }

        public ContentResult Save(int? id, FormCollection actionValues)
        {
            var action = new DataAction(actionValues);
            return (ContentResult)new AjaxSaveResponse(action);
        }
    }
}

