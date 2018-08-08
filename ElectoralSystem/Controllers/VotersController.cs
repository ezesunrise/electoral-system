using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ElectoralSystem.Entities;
using ElectoralSystem.Models;

namespace ElectoralSystem.Controllers
{
    public class VotersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Voters
        public async Task<ActionResult> Index()
        {
            return View(await db.Voters.ToListAsync());
        }

        // GET: Voters/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Voter voter = await db.Voters.FindAsync(id);
            if (voter == null)
            {
                return HttpNotFound();
            }
            return View(voter);
        }

        // GET: Voters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Voters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "UserId")] Voter voter)
        {
            if (ModelState.IsValid)
            {
                db.Voters.Add(voter);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(voter);
        }

        // GET: Voters/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Voter voter = await db.Voters.FindAsync(id);
            if (voter == null)
            {
                return HttpNotFound();
            }
            return View(voter);
        }

        // POST: Voters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "UserId")] Voter voter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(voter).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(voter);
        }

        // GET: Voters/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Voter voter = await db.Voters.FindAsync(id);
            if (voter == null)
            {
                return HttpNotFound();
            }
            return View(voter);
        }

        // POST: Voters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            Voter voter = await db.Voters.FindAsync(id);
            db.Voters.Remove(voter);
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
