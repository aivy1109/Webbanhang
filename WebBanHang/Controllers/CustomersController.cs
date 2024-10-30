using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Models;

namespace WebBanHang.Controllers
{
    public class CustomersController : Controller
    {
        private DBPNJwebEntities1 db = new DBPNJwebEntities1();

        // GET: Customers
        public ActionResult Index()
        {
            return View(db.Customers.ToList());
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDCus,NameCus,PhoneCus,EmailCus,UserName,Password")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDCus,NameCus,PhoneCus,EmailCus,UserName,Password")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }



        /*
        private Customer db = new Customer(); // Thay YourDbContext bằng tên context của bạn

        // Hiển thị trang đăng ký
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        // Xử lý đăng ký
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Kiểm tra xem tên người dùng đã tồn tại chưa
                if (db.Customers.Any(c => c.UserName == model.UserName))
                {
                    ModelState.AddModelError("", "Tên người dùng đã tồn tại.");
                    return View(model);
                }

                // Tạo đối tượng Customer và thêm vào cơ sở dữ liệu
                var customer = new Customer
                {
                    NameCus = model.NameCus,
                    PhoneCus = model.PhoneCus,
                    EmailCus = model.EmailCus,
                    UserName = model.UserName,
                    Password = model.Password // Mã hóa mật khẩu ở đây nếu cần
                };

                db.Customers.Add(customer);
                db.SaveChanges();

                // Chuyển hướng đến trang đăng nhập sau khi đăng ký thành công
                return RedirectToAction("Login");
            }

            return View(model);
        }

        // Hiển thị trang đăng nhập
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        // Xử lý đăng nhập
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Kiểm tra thông tin đăng nhập
                var customer = db.Customers.FirstOrDefault(c => c.UserName == model.UserName && c.Password == model.Password);

                if (customer != null)
                {
                    // Đăng nhập thành công, lưu thông tin vào Session hoặc Cookie
                    Session["UserName"] = customer.UserName;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Tài khoản hoặc mật khẩu không đúng.");
                }
            }

            return View(model);
        }
        */


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
