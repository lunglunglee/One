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
    public class Data_CityController : Controller
    {
        private ModelONE db = new ModelONE();

        // GET: Data_City
        public async Task<ActionResult> Index()
        {
            var data_City = db.Data_City.Include(d => d.Data_Province);
            return View(await data_City.ToListAsync());
        }

        // GET: Data_City/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Data_City data_City = await db.Data_City.FindAsync(id);
            if (data_City == null)
            {
                return HttpNotFound();
            }
            return View(data_City);
        }

        // GET: Data_City/Create
        public ActionResult Create()
        {
            ViewBag.ProvinceCode = new SelectList(db.Data_Province, "ProvinceCode", "ProvinceName");
            return View();
        }

        // POST: Data_City/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CityCode,CityName,ProvinceCode")] Data_City data_City)
        {
            if (ModelState.IsValid)
            {
                db.Data_City.Add(data_City);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ProvinceCode = new SelectList(db.Data_Province, "ProvinceCode", "ProvinceName", data_City.ProvinceCode);
            return View(data_City);
        }

        // GET: Data_City/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Data_City data_City = await db.Data_City.FindAsync(id);
            if (data_City == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProvinceCode = new SelectList(db.Data_Province, "ProvinceCode", "ProvinceName", data_City.ProvinceCode);
            return View(data_City);
        }

        // POST: Data_City/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CityCode,CityName,ProvinceCode")] Data_City data_City)
        {
            if (ModelState.IsValid)
            {
                db.Entry(data_City).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ProvinceCode = new SelectList(db.Data_Province, "ProvinceCode", "ProvinceName", data_City.ProvinceCode);
            return View(data_City);
        }

        // GET: Data_City/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Data_City data_City = await db.Data_City.FindAsync(id);
            if (data_City == null)
            {
                return HttpNotFound();
            }
            return View(data_City);
        }

        // POST: Data_City/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Data_City data_City = await db.Data_City.FindAsync(id);
            db.Data_City.Remove(data_City);
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
