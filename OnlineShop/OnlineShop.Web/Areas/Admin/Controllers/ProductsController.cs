using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineShop.Data;
using OnlineShop.StorageHelper;
using OnlineShop.Web.Areas.Admin.Models;
using OnlineShopping.Models.Entities;

namespace OnlineShop.Web.Areas.Admin.Controllers
{
    public class ProductsController : BaseAdminController
    {
        private readonly UnitOfWork _uow;

        public ProductsController(UnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: Admin/Products
        public ActionResult Index()
        {
            var products = _uow.Products
                .GetAllQueryable()
                .Include(p => p.Category)
                .Select(s => new ProductViewModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    CategoryId = s.CategoryId,
                    InStock = s.InStock,
                    Description = s.Description,
                    ImagePath = s.Image,
                    UnitPrice = s.UnitPrice,
                    Category = new CategoryViewModel
                    {
                        Id = s.Category.Id,
                        Name = s.Category.Name
                    }
                });
            return View(products.ToList());
        }

        // GET: Admin/Products/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = _uow.Products.GetById(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Admin/Products/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(_uow.Categories.GetAll(), "Id", "Name");
            return View();
        }

        // POST: Admin/Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,UnitPrice,InStock,Description,Image,CategoryId")] ProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                // check if image was not uploaded
                if (productViewModel.Image == null)
                {
                    ModelState.AddModelError("Image", "A Product image is mandatory.");

                    ViewBag.CategoryId = new SelectList(_uow.Categories.GetAll(), "Id", "Name", productViewModel.CategoryId);

                    return View(productViewModel);
                }

                productViewModel.Id = Guid.NewGuid();

                // save image and get final path
                var pathResult = LocalStorageHelper.SaveImage(productViewModel.Image, ImageCategory.Products, productViewModel.Id.ToString());

                // check if image saving was successful
                if (string.IsNullOrEmpty(pathResult))
                {
                    ModelState.AddModelError("Image", "Invalid image extension");

                    ViewBag.CategoryId = new SelectList(_uow.Categories.GetAll(), "Id", "Name", productViewModel.CategoryId);

                    return View(productViewModel);
                }
                
                // create new product
                var product = new Product
                {
                    Id = productViewModel.Id,
                    Name = productViewModel.Name,
                    CategoryId = productViewModel.CategoryId,
                    InStock = productViewModel.InStock,
                    Description = productViewModel.Description,
                    Image = pathResult,
                    UnitPrice = productViewModel.UnitPrice
                };

                // save the new product
                _uow.Products.Add(product);
                _uow.Complete();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(_uow.Categories.GetAll(), "Id", "Name", productViewModel.CategoryId);
            return View(productViewModel);
        }

        // GET: Admin/Products/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = _uow.Products.GetById(id);
            if (product == null)
            {
                return HttpNotFound();
            }

            var productViewModel = new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                CategoryId = product.CategoryId,
                InStock = product.InStock,
                Description = product.Description,
                ImagePath = product.Image,
                UnitPrice = product.UnitPrice
            };
            ViewBag.CategoryId = new SelectList(_uow.Categories.GetAll(), "Id", "Name", product.CategoryId);
            return View(productViewModel);
        }

        // POST: Admin/Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,UnitPrice,InStock,ImagePath,Description,Image,CategoryId")] ProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                var product = new Product
                {
                    Id = productViewModel.Id,
                    Name = productViewModel.Name,
                    CategoryId = productViewModel.CategoryId,
                    InStock = productViewModel.InStock,
                    Description = productViewModel.Description,
                    Image = productViewModel.Image != null 
                    ? LocalStorageHelper.SaveImage(productViewModel.Image, 
                    ImageCategory.Products, productViewModel.Id.ToString()) 
                    : productViewModel.ImagePath,
                    UnitPrice = productViewModel.UnitPrice
                };
                _uow.Products.Update(product);
                _uow.Complete();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(_uow.Categories.GetAll(), "Id", "Name", productViewModel.CategoryId);
            return View(productViewModel);
        }

        // GET: Admin/Products/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = _uow.Products.GetById(id);
            if (product == null)
            {
                return HttpNotFound();
            }

            var productViewModel = new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                CategoryId = product.CategoryId,
                InStock = product.InStock,
                Description = product.Description,
                //Image = product.Image,
                UnitPrice = product.UnitPrice
            };

            return View(productViewModel);
        }

        // POST: Admin/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _uow.Products.Delete(id);
            _uow.Complete();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _uow.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
