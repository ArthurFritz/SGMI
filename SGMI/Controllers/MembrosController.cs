using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SGMI.Models;

namespace SGMI.Controllers
{
    public class MembrosController : Controller
    {
        private ContextoDb db = new ContextoDb();

        // GET: Membros
        public async Task<ActionResult> Index()
        {
            var membros = db.Membros.Include(m => m.Cidade);
            return View(await membros.ToListAsync());
        }

        // GET: Membros/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MembrosModel membrosModel = await db.Membros.FindAsync(id);
            if (membrosModel == null)
            {
                return HttpNotFound();
            }
            return View(membrosModel);
        }

        // GET: Membros/Create
        public ActionResult Create()
        {
            ViewBag.CidadeId = new SelectList(db.Cidades, "Id", "Nome");
            return View();
        }

        // POST: Membros/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Nome,Telefone,Email,Cpf,Endereco,CidadeId")] MembrosModel membrosModel)
        {
            if (ModelState.IsValid)
            {
                db.Membros.Add(membrosModel);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CidadeId = new SelectList(db.Cidades, "Id", "Nome", membrosModel.CidadeId);
            return View(membrosModel);
        }

        // GET: Membros/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MembrosModel membrosModel = await db.Membros.FindAsync(id);
            if (membrosModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.CidadeId = new SelectList(db.Cidades, "Id", "Nome", membrosModel.CidadeId);
            return View(membrosModel);
        }

        // POST: Membros/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Nome,Telefone,Email,Cpf,Endereco,CidadeId")] MembrosModel membrosModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(membrosModel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CidadeId = new SelectList(db.Cidades, "Id", "Nome", membrosModel.CidadeId);
            return View(membrosModel);
        }

        // GET: Membros/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MembrosModel membrosModel = await db.Membros.FindAsync(id);
            if (membrosModel == null)
            {
                return HttpNotFound();
            }
            return View(membrosModel);
        }

        // POST: Membros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            MembrosModel membrosModel = await db.Membros.FindAsync(id);
            db.Membros.Remove(membrosModel);
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
