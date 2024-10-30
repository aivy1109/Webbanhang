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
    public class CategoryController : Controller
    {
        private DBPNJwebEntities1 db = new DBPNJwebEntities1();

        // GET: Category
        public ActionResult Index()
        {
            return View(db.Categories.ToList());
        }

        // GET: Category/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDCate,NameCate")] Category category)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(category);
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Category/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDCate,NameCate")] Category category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = db.Categories.Find(id);
            db.Categories.Remove(category);
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
        // Action PartialViewResult
        [ChildActionOnly] //viết action kiểu PartialViewResult trả về danh sách Category để gắn vào _Layout.cshtml.
        public PartialViewResult CategoryPartial()
        {
            var cateList = db.Categories.ToList();
            return PartialView(cateList);
        }

        //public class ShareholderMeeting
        //{
        //    public int Id { get; set; }
        //    public string ShareholderName { get; set; }
        //    // Nếu có mối quan hệ với bảng khác, bạn có thể thêm thuộc tính ở đây
        //}
        public ActionResult NavarLogo()
        {
            var products = db.Categories.AsQueryable();


            // Trả về Partial View với model
            return PartialView();
        }


        //public ViewResult NavarLogo(int id)
        //{
        //    if (id == 1)
        //    {
        //        ViewBag.Meetings = new List<string>
        //{
        //    "Đại hội đồng cổ đông năm 2024",
        //    "Đại hội đồng cổ đông năm 2023",
        //    "Đại hội đồng cổ đông năm 2022"
        //};
        //    }
        //    else if (id == 2)
        //    {
        //        // Truyền dữ liệu cho Cửa Hàng nếu cần
        //    }
        //    return View();
        //}

        //public ViewResult NavarLogo()
        //{
        //    ViewBag.Meetings = new List<string>
        //{
        //    "Đại hội đồng cổ đông năm 2024",
        //    "Đại hội đồng cổ đông năm 2023",
        //    "Đại hội đồng cổ đông năm 2022"
        //};

        //    return View();
        //}

        // Action cho Danh sách cổ đông
        /* public ActionResult ShareholderList()
         {
             var shareholders = db.ShareholderMeetings.ToList(); // Lấy toàn bộ dữ liệu từ bảng ShareholderMeetings
             return View(shareholders); // Trả về view với danh sách cổ đông
         }*/
    }
}
