using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WYsystem.Models;

namespace WYsystem.Controllers
{
    public class SystemController : Controller
    {
        private wyEntities db = new wyEntities();

        // GET: System
        public ActionResult Index()
        {
            return View(db.w_system_params.ToList());
        }

        // GET: System/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            w_system_params w_system_params = db.w_system_params.Find(id);
            if (w_system_params == null)
            {
                return HttpNotFound();
            }
            return View(w_system_params);
        }

        // GET: System/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: System/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,code,name,type")] w_system_params w_system_params)
        {
            db.w_system_params.Add(w_system_params);
            if (db.SaveChanges() > 0)
            {
                return Content("<script>alert('保存系统参数成功！');window.location.href='/System/Index';</script>");
            }
            else
            {
                ViewBag.erroy = "保存系统参数失败！";
            }

            return View(w_system_params);
        }

        // GET: System/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            w_system_params w_system_params = db.w_system_params.Find(id);
            if (w_system_params == null)
            {
                return HttpNotFound();
            }
            return View(w_system_params);
        }

        // POST: System/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,code,name,type")] w_system_params w_system_params)
        {
            if (ModelState.IsValid)
            {
                db.Entry(w_system_params).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(w_system_params);
        }

        // GET: System/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            w_system_params w_system_params = db.w_system_params.Find(id);
            if (w_system_params == null)
            {
                return HttpNotFound();
            }
            return View(w_system_params);
        }

        // POST: System/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            w_system_params w_system_params = db.w_system_params.Find(id);
            db.w_system_params.Remove(w_system_params);
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
