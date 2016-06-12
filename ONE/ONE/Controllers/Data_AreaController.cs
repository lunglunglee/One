using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ONE.Models;

namespace ONE.Controllers
{
    public class Data_AreaController : Controller
    {
        private ModelONE db = new ModelONE();

        // GET: Data_Area
        public async Task<ActionResult> Index()
        {
            var data_Area = db.Data_Area.Include(d => d.Data_City);
            return View(await data_Area.ToListAsync());
        }

        // GET: Data_Area/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Data_Area data_Area = await db.Data_Area.FindAsync(id);
            if (data_Area == null)
            {
                return HttpNotFound();
            }
            return View(data_Area);
        }

        // GET: Data_Area/Create
        public ActionResult Create()
        {
            ViewBag.CityCode = new SelectList(db.Data_City, "CityCode", "CityName");
            return View();
        }

        // POST: Data_Area/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "AreaCode,AreaName,CityCode,CityName")] Data_Area data_Area)
        {
            if (ModelState.IsValid)
            {
                db.Data_Area.Add(data_Area);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CityCode = new SelectList(db.Data_City, "CityCode", "CityName", data_Area.CityCode);
            return View(data_Area);
        }

        // GET: Data_Area/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Data_Area data_Area = await db.Data_Area.FindAsync(id);
            if (data_Area == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityCode = new SelectList(db.Data_City, "CityCode", "CityName", data_Area.CityCode);
            return View(data_Area);
        }

        // POST: Data_Area/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "AreaCode,AreaName,CityCode,CityName")] Data_Area data_Area)
        {
            if (ModelState.IsValid)
            {
                db.Entry(data_Area).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CityCode = new SelectList(db.Data_City, "CityCode", "CityName", data_Area.CityCode);
            return View(data_Area);
        }

        // GET: Data_Area/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Data_Area data_Area = await db.Data_Area.FindAsync(id);
            if (data_Area == null)
            {
                return HttpNotFound();
            }
            return View(data_Area);
        }

        // POST: Data_Area/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Data_Area data_Area = await db.Data_Area.FindAsync(id);
            db.Data_Area.Remove(data_Area);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
