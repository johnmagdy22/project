#region Usings

using System;
using System.Net;
using System.Web.Mvc;
using OnlineShop.Data;
using OnlineShopping.Models.Entities;

#endregion

namespace OnlineShop.Web.Areas.Admin.Controllers
{
    public class CategoriesController : BaseAdminController
    {
        private readonly UnitOfWork _uow;

        public CategoriesController(UnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: Admin/Categories
        public ActionResult Index()
        {
            return View(_uow.Categories.GetAll());
        }

        // GET: Admin/Categories/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Category category = _uow.Categories.GetById(id);
            if (category == null)
                return HttpNotFound();
            return View(category);
        }

        // GET: Admin/Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Category category)
        {
            if (ModelState.IsValid)
            {
                category.Id = Guid.NewGuid();
                _uow.Categories.Add(category);
                _uow.Complete();
                return RedirectToAction("Index");
            }

            return View(category);
        }

        // GET: Admin/Categories/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Category category = _uow.Categories.GetById(id);
            if (category == null)
                return HttpNotFound();
            return View(category);
        }

        // POST: Admin/Categories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Category category)
        {
            if (ModelState.IsValid)
            {
                _uow.Categories.Update(category);
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: Admin/Categories/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Category category = _uow.Categories.GetById(id);
            if (category == null)
                return HttpNotFound();
            return View(category);
        }

        // POST: Admin/Categories/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _uow.Categories.Delete(id);
            _uow.Complete();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _uow.Dispose();
            base.Dispose(disposing);
        }
    }
}