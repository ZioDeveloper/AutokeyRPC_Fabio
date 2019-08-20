using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutokeyRPC.Models;

namespace AutokeyRPC.Controllers
{
    public class DanniXTelaioController : Controller
    {
        private AutokeyEntities db = new AutokeyEntities();

        // GET: DanniXTelaio
        public ActionResult Index()
        {
            var rPC_DanniXTelaio = db.RPC_DanniXTelaio.Include(r => r.RPC_Danni).Include(r => r.RPC_Gravita).Include(r => r.RPC_Parti).Include(r => r.RPC_Telai);
            return View(rPC_DanniXTelaio.ToList());
        }

        // GET: DanniXTelaio/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RPC_DanniXTelaio rPC_DanniXTelaio = db.RPC_DanniXTelaio.Find(id);
            if (rPC_DanniXTelaio == null)
            {
                return HttpNotFound();
            }
            return View(rPC_DanniXTelaio);
        }

        // GET: DanniXTelaio/Create
        public ActionResult Create(int? idtelaio)
        {
            ViewBag.IDDanno = new SelectList(db.RPC_Danni, "ID", "Descr");
            ViewBag.IDGravita = new SelectList(db.RPC_Gravita, "ID", "Descr");
            ViewBag.IDParte = new SelectList(db.RPC_Parti, "ID", "Descr");
            
            return View();
        }

        // POST: DanniXTelaio/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDTelaio,IDParte,IDDanno,IDGravita,InsertDate,NoteDanno")] RPC_DanniXTelaio rPC_DanniXTelaio)
        {

            if (ModelState.IsValid)
            {
                db.RPC_DanniXTelaio.Add(rPC_DanniXTelaio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDDanno = new SelectList(db.RPC_Danni, "ID", "Descr", rPC_DanniXTelaio.IDDanno);
            ViewBag.IDGravita = new SelectList(db.RPC_Gravita, "ID", "Descr", rPC_DanniXTelaio.IDGravita);
            ViewBag.IDParte = new SelectList(db.RPC_Parti, "ID", "Descr", rPC_DanniXTelaio.IDParte);
            //ViewBag.IDTelaio = new SelectList(db.RPC_Telai, "ID", "IDOperatore", rPC_DanniXTelaio.IDTelaio);
            return View(rPC_DanniXTelaio);
        }

        // GET: DanniXTelaio/Edit/5
        public ActionResult Edit(int? id, int?idtelaio)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RPC_DanniXTelaio rPC_DanniXTelaio = db.RPC_DanniXTelaio.Find(id);
            if (rPC_DanniXTelaio == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDDanno = new SelectList(db.RPC_Danni, "ID", "Descr", rPC_DanniXTelaio.IDDanno);
            ViewBag.IDGravita = new SelectList(db.RPC_Gravita, "ID", "Descr", rPC_DanniXTelaio.IDGravita);
            ViewBag.IDParte = new SelectList(db.RPC_Parti, "ID", "Descr", rPC_DanniXTelaio.IDParte);
            //ViewBag.IDTelaio = new SelectList(db.RPC_Telai, "ID", "IDOperatore", rPC_DanniXTelaio.IDTelaio);
            return View(rPC_DanniXTelaio);
        }

        // POST: DanniXTelaio/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,IDTelaio,IDParte,IDDanno,IDGravita,InsertDate,NoteDanno")] RPC_DanniXTelaio rPC_DanniXTelaio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rPC_DanniXTelaio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDDanno = new SelectList(db.RPC_Danni, "ID", "Descr", rPC_DanniXTelaio.IDDanno);
            ViewBag.IDGravita = new SelectList(db.RPC_Gravita, "ID", "Descr", rPC_DanniXTelaio.IDGravita);
            ViewBag.IDParte = new SelectList(db.RPC_Parti, "ID", "Descr", rPC_DanniXTelaio.IDParte);
            ViewBag.IDTelaio = new SelectList(db.RPC_Telai, "ID", "IDOperatore", rPC_DanniXTelaio.IDTelaio);
            return View(rPC_DanniXTelaio);
        }

        // GET: DanniXTelaio/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RPC_DanniXTelaio rPC_DanniXTelaio = db.RPC_DanniXTelaio.Find(id);
            if (rPC_DanniXTelaio == null)
            {
                return HttpNotFound();
            }
            return View(rPC_DanniXTelaio);
        }

        // POST: DanniXTelaio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RPC_DanniXTelaio rPC_DanniXTelaio = db.RPC_DanniXTelaio.Find(id);
            db.RPC_DanniXTelaio.Remove(rPC_DanniXTelaio);
            db.SaveChanges();
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
