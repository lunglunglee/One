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
    public class Main_EmployeesController : Controller
    {
        private ModelONE db = new ModelONE();

        // GET: Main_Employees
        public async Task<ActionResult> Index()
        {
            return View(await db.Main_Employees.ToListAsync());
        }

        // GET: Main_Employees/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Main_Employees main_Employees = await db.Main_Employees.FindAsync(id);
            if (main_Employees == null)
            {
                return HttpNotFound();
            }
            return View(main_Employees);
        }

        // GET: Main_Employees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Main_Employees/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "EmployeeID,代理稱謂,FirstName,Title,TitleOfCourtesy,BirthDate,HireDate,Address,City,Region,PostalCode,Country,HomePhone,Extension,Photo,Notes,ReportsTo,PhotoPath")] Main_Employees main_Employees)
        {
            if (ModelState.IsValid)
            {
                db.Main_Employees.Add(main_Employees);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(main_Employees);
        }

        // GET: Main_Employees/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Main_Employees main_Employees = await db.Main_Employees.FindAsync(id);
            if (main_Employees == null)
            {
                return HttpNotFound();
            }
            return View(main_Employees);
        }

        // POST: Main_Employees/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "EmployeeID,代理稱謂,FirstName,Title,TitleOfCourtesy,BirthDate,HireDate,Address,City,Region,PostalCode,Country,HomePhone,Extension,Photo,Notes,ReportsTo,PhotoPath")] Main_Employees main_Employees)
        {
            if (ModelState.IsValid)
            {
                db.Entry(main_Employees).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(main_Employees);
        }

        // GET: Main_Employees/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Main_Employees main_Employees = await db.Main_Employees.FindAsync(id);
            if (main_Employees == null)
            {
                return HttpNotFound();
            }
            return View(main_Employees);
        }

        // POST: Main_Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Main_Employees main_Employees = await db.Main_Employees.FindAsync(id);
            db.Main_Employees.Remove(main_Employees);
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
