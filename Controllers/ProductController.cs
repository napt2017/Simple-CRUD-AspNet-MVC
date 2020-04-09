using System;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Security.AccessControl;
using System.Web.Mvc;

namespace NewAssignment.Controllers
{
    public class ProductController : Controller
    {
        private AssignmentEntities assignmentEntities;

        public ProductController()
        {
            assignmentEntities = new AssignmentEntities();
        }

        //private static int id = 2;
        //private static List<Product> products = new List<Product>() 
        //{
        //    new Product 
        //    {
        //        Id = 1,
        //        Name = "iPhone",
        //        Price = 100f,
        //        Quantity = 20
        //    }
        //};


        // GET: Product
        public ActionResult Index()
        {
            //ViewBag.TimeAccess = System.DateTime.Now;
            //ViewData["MessageFromActionMethod"] = "Hello world";
            //return View(products);

            var allProduct = assignmentEntities.Products.ToList();
            return View(allProduct);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            //var foundProduct = products.Find(product => product.Id == id);
            //if (foundProduct == null)
            //{
            //    return RedirectToAction("NotFound");
            //}
            //else
            //{
            //    return View(foundProduct);
            //}
            return View();
        }

        public HttpStatusCodeResult NotFound()
        {
            return new HttpStatusCodeResult(System.Net.HttpStatusCode.NotFound);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            var emptyProductModel = new Product();
            return View(emptyProductModel);
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                var name = collection.Get("Name");
                var price = double.Parse(collection.Get("Price"));
                var quantity = int.Parse(collection.Get("Quantity"));

                var newProduct = new Product();
                newProduct.Id = 1;
                newProduct.Name = name;
                newProduct.Price = price;
                newProduct.Quantity = quantity;

                // Save
                assignmentEntities.Products.Add(newProduct);
                assignmentEntities.SaveChanges();

                return RedirectToAction("Index");
            }
            catch(DbUpdateException ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            //var foundProduct = products.Find(product => product.Id == id);
            //if (foundProduct == null)
            //{
            //    return RedirectToAction("NotFound");
            //}
            //else
            //{
            //    return View(foundProduct);
            //}

            var foundProduct = assignmentEntities.Products.Where(product => product.Id == id).FirstOrDefault();
            if (foundProduct == null)
            {
                return RedirectToAction("NotFound");
            }
            else
            {
                return View(foundProduct);
            } 
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // Find old product
                //var foundProduct = products.Find(product => product.Id == id);

                //// Get the updated data
                //var name = collection.Get("Name");
                //var price = float.Parse(collection.Get("Price"));
                //var quantity = int.Parse(collection.Get("Quantity"));

                //// Set back to old product
                //foundProduct.Name = name;
                //foundProduct.Price = price;
                //foundProduct.Quantity = quantity;


                var foundProduct = assignmentEntities.Products.Where(product => product.Id == id).FirstOrDefault();
                //// Get the updated data
                var name = collection.Get("Name");
                var price = float.Parse(collection.Get("Price"));
                var quantity = int.Parse(collection.Get("Quantity"));

                foundProduct.Name = name;
                foundProduct.Price = price;
                foundProduct.Quantity = quantity;

                // Save 
                assignmentEntities.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            // Find old product
            //var foundProduct = products.Find(product => product.Id == id);
            //if (foundProduct == null)
            //{
            //    return RedirectToAction("NotFound");
            //}
            //else
            //{
            //    return View(foundProduct);
            //}

            var foundProduct = assignmentEntities.Products.Where(product => product.Id == id).FirstOrDefault();
            if (foundProduct == null)
            {
                return RedirectToAction("NotFound");
            }
            else
            {
                return View(foundProduct);
            } 
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                //var foundProduct = products.Find(product => product.Id == id);
                //products.Remove(foundProduct);
                var foundProduct = assignmentEntities.Products.Where(product => product.Id == id).FirstOrDefault();
                assignmentEntities.Products.Remove(foundProduct);
                assignmentEntities.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
