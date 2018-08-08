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
    public class VotesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Votes
        public async Task<ActionResult> Index()
        {
            var votes = db.Votes.Include(v => v.Candidate);
            return View(await votes.ToListAsync());
        }

        // GET: Votes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vote vote = await db.Votes.FindAsync(id);
            if (vote == null)
            {
                return HttpNotFound();
            }
            return View(vote);
        }

        // GET: Votes/Create
        public ActionResult Create()
        {
            ViewBag.CandidateId = new SelectList(db.Candidates, "Id", "Name");
            return View();
        }

        // POST: Votes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,VoterId,CandidateId")] Vote vote)
        {
            if (ModelState.IsValid)
            {
                db.Votes.Add(vote);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CandidateId = new SelectList(db.Candidates, "Id", "Name", vote.CandidateId);
            return View(vote);
        }

        // GET: Votes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vote vote = await db.Votes.FindAsync(id);
            if (vote == null)
            {
                return HttpNotFound();
            }
            ViewBag.CandidateId = new SelectList(db.Candidates, "Id", "Name", vote.CandidateId);
            return View(vote);
        }

        // POST: Votes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,VoterId,CandidateId")] Vote vote)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vote).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CandidateId = new SelectList(db.Candidates, "Id", "Name", vote.CandidateId);
            return View(vote);
        }

        // GET: Votes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vote vote = await db.Votes.FindAsync(id);
            if (vote == null)
            {
                return HttpNotFound();
            }
            return View(vote);
        }

        // POST: Votes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Vote vote = await db.Votes.FindAsync(id);
            db.Votes.Remove(vote);
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
