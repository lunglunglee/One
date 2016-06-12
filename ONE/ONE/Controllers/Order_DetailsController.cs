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
    public class Order_DetailsController : Controller
    {
        private ModelONE db = new ModelONE();

        // GET: Order_Details
        public async Task<ActionResult> Index()
        {
            var order_Details = db.Order_Details.Include(o => o.Categories).Include(o => o.Main_Employees).Include(o => o.Orders);
            return View(await order_Details.ToListAsync());
        }

        // GET: Order_Details/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order_Details order_Details = await db.Order_Details.FindAsync(id);
            if (order_Details == null)
            {
                return HttpNotFound();
            }
            return View(order_Details);
        }

        // GET: Order_Details/Create
        public ActionResult Create()
        {
            ViewBag.訂購貨品 = new SelectList(db.Categories, "CategoryID", "貨品名稱");
            ViewBag.訂購代理 = new SelectList(db.Main_Employees, "EmployeeID", "代理稱謂");
            ViewBag.OrderID = new SelectList(db.Orders, "OrderID", "客戶");
            return View();
        }

        // POST: Order_Details/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "OrderID,訂購日期,訂購代理,訂購貨品,UnitPrice,Quantity,Discount,支付方式,相關客戶,貨品狀況,More")] Order_Details order_Details)
        {
            if (ModelState.IsValid)
            {
                db.Order_Details.Add(order_Details);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.訂購貨品 = new SelectList(db.Categories, "CategoryID", "貨品名稱", order_Details.訂購貨品);
            ViewBag.訂購代理 = new SelectList(db.Main_Employees, "EmployeeID", "代理稱謂", order_Details.訂購代理);
            ViewBag.OrderID = new SelectList(db.Orders, "OrderID", "客戶", order_Details.OrderID);
            return View(order_Details);
        }

        // GET: Order_Details/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order_Details order_Details = await db.Order_Details.FindAsync(id);
            if (order_Details == null)
            {
                return HttpNotFound();
            }
            ViewBag.訂購貨品 = new SelectList(db.Categories, "CategoryID", "貨品名稱", order_Details.訂購貨品);
            ViewBag.訂購代理 = new SelectList(db.Main_Employees, "EmployeeID", "代理稱謂", order_Details.訂購代理);
            ViewBag.OrderID = new SelectList(db.Orders, "OrderID", "客戶", order_Details.OrderID);
            return View(order_Details);
        }

        // POST: Order_Details/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "OrderID,訂購日期,訂購代理,訂購貨品,UnitPrice,Quantity,Discount,支付方式,相關客戶,貨品狀況,More")] Order_Details order_Details)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order_Details).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.訂購貨品 = new SelectList(db.Categories, "CategoryID", "貨品名稱", order_Details.訂購貨品);
            ViewBag.訂購代理 = new SelectList(db.Main_Employees, "EmployeeID", "代理稱謂", order_Details.訂購代理);
            ViewBag.OrderID = new SelectList(db.Orders, "OrderID", "客戶", order_Details.OrderID);
            return View(order_Details);
        }

        // GET: Order_Details/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order_Details order_Details = await db.Order_Details.FindAsync(id);
            if (order_Details == null)
            {
                return HttpNotFound();
            }
            return View(order_Details);
        }

        // POST: Order_Details/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Order_Details order_Details = await db.Order_Details.FindAsync(id);
            db.Order_Details.Remove(order_Details);
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
