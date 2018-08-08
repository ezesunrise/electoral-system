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
    public class CandidatesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Candidates
        public async Task<ActionResult> Index()
        {
            var candidates = db.Candidates.Include(c => c.Category).Include(c => c.Election).Include(c => c.Party);
            return View(await candidates.ToListAsync());
        }

        // GET: Candidates/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Candidate candidate = await db.Candidates.FindAsync(id);
            if (candidate == null)
            {
                return HttpNotFound();
            }
            return View(candidate);
        }

        // GET: Candidates/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Title");
            ViewBag.ElectionId = new SelectList(db.Elections, "Id", "Title");
            ViewBag.PartyId = new SelectList(db.Parties, "Id", "Name");
            return View();
        }

        // POST: Candidates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,NickName,CategoryId,PartyId,ElectionId")] Candidate candidate)
        {
            if (ModelState.IsValid)
            {
                db.Candidates.Add(candidate);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Title", candidate.CategoryId);
            ViewBag.ElectionId = new SelectList(db.Elections, "Id", "Title", candidate.ElectionId);
            ViewBag.PartyId = new SelectList(db.Parties, "Id", "Name", candidate.PartyId);
            return View(candidate);
        }

        // GET: Candidates/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Candidate candidate = await db.Candidates.FindAsync(id);
            if (candidate == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Title", candidate.CategoryId);
            ViewBag.ElectionId = new SelectList(db.Elections, "Id", "Title", candidate.ElectionId);
            ViewBag.PartyId = new SelectList(db.Parties, "Id", "Name", candidate.PartyId);
            return View(candidate);
        }

        // POST: Candidates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,NickName,CategoryId,PartyId,ElectionId")] Candidate candidate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(candidate).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Title", candidate.CategoryId);
            ViewBag.ElectionId = new SelectList(db.Elections, "Id", "Title", candidate.ElectionId);
            ViewBag.PartyId = new SelectList(db.Parties, "Id", "Name", candidate.PartyId);
            return View(candidate);
        }

        // GET: Candidates/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Candidate candidate = await db.Candidates.FindAsync(id);
            if (candidate == null)
            {
                return HttpNotFound();
            }
            return View(candidate);
        }

        // POST: Candidates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Candidate candidate = await db.Candidates.FindAsync(id);
            db.Candidates.Remove(candidate);
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
