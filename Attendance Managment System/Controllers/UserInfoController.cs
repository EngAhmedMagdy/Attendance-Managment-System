using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Attendance_Managment_System.Models;

namespace Attendance_Managment_System.Controllers
{
    public class UserInfoController : Controller
    {
        private Model1 db = new Model1();

        // GET: UserInfo
        public async Task<ActionResult> Index()
        {
            
            return View(await db.UserInfoes.ToListAsync());
        }

        // GET: UserInfo/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserInfo userInfo = await db.UserInfoes.FindAsync(id);
            if (userInfo == null)
            {
                return HttpNotFound();
            }
            return View(userInfo);
        }

        // GET: UserInfo/Create
        public ActionResult Create()
        {

            ViewBag.Type = new List<SelectListItem>() {
                new SelectListItem(){Value="Employee",Text="Employee"},
                new SelectListItem(){Value="Head of Department",Text="Head of Department"},
                new SelectListItem(){Value="Admin",Text="Admin"}
            };
            ViewBag.Gender = new List<SelectListItem>() {
                new SelectListItem(){Value="Male",Text="Male"},
                new SelectListItem(){Value="Female",Text="Female"},
            };
            return View();
        }

        // POST: UserInfo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Type,Name,Passward,Email,Gender")] UserInfo userInfo)
        {
            if (ModelState.IsValid)
            {
                db.UserInfoes.Add(userInfo);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(userInfo);
        }

        // GET: UserInfo/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {

            ViewBag.Type = new List<SelectListItem>() {
                new SelectListItem(){Value="Employee",Text="Employee"},
                new SelectListItem(){Value="Head of Department",Text="Head of Department"},
                new SelectListItem(){Value="Admin",Text="Admin"}
            };
            ViewBag.Gender = new List<SelectListItem>() {
                new SelectListItem(){Value="Male",Text="Male"},
                new SelectListItem(){Value="Female",Text="Female"},
            };
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserInfo userInfo = await db.UserInfoes.FindAsync(id);
            if (userInfo == null)
            {
                return HttpNotFound();
            }
            return View(userInfo);
        }

        // POST: UserInfo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Type,Name,Passward,Email,Gender")] UserInfo userInfo)
        {
            
            if (ModelState.IsValid)
            {
                db.Entry(userInfo).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(userInfo);
        }

        // GET: UserInfo/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserInfo userInfo = await db.UserInfoes.FindAsync(id);
            if (userInfo == null)
            {
                return HttpNotFound();
            }
            return View(userInfo);
        }

        // POST: UserInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            UserInfo userInfo = await db.UserInfoes.FindAsync(id);
            db.UserInfoes.Remove(userInfo);
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
