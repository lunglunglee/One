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
    public class Data_ProvinceController : Controller
    {
        private ModelONE db = new ModelONE();

        // GET: Data_Province
        public async Task<ActionResult> Index()
        {
            return View(await db.Data_Province.ToListAsync());
        }

        // GET: Data_Province/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Data_Province data_Province = await db.Data_Province.FindAsync(id);
            if (data_Province == null)
            {
                return HttpNotFound();
            }
            return View(data_Province);
        }

        // GET: Data_Province/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Data_Province/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ProvinceCode,ProvinceName")] Data_Province data_Province)
        {
            if (ModelState.IsValid)
            {
                db.Data_Province.Add(data_Province);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(data_Province);
        }

        // GET: Data_Province/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Data_Province data_Province = await db.Data_Province.FindAsync(id);
            if (data_Province == null)
            {
                return HttpNotFound();
            }
            return View(data_Province);
        }

        // POST: Data_Province/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ProvinceCode,ProvinceName")] Data_Province data_Province)
        {
            if (ModelState.IsValid)
            {
                db.Entry(data_Province).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(data_Province);
        }

        // GET: Data_Province/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Data_Province data_Province = await db.Data_Province.FindAsync(id);
            if (data_Province == null)
            {
                return HttpNotFound();
            }
            return View(data_Province);
        }

        // POST: Data_Province/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Data_Province data_Province = await db.Data_Province.FindAsync(id);
            db.Data_Province.Remove(data_Province);
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
