using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WYsystem.Models;

namespace WYsystem.Controllers
{
    public class AdminController : Controller
    {
        private wyEntities db = new wyEntities();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        // 小区管理部分的编写
        // 小区管理首页
        public ActionResult RoomIndex()
        {
            // 获取一条小区信息回来展示
            w_room_info info = db.w_room_info.FirstOrDefault();
            return View(info);
        }

        // 实现添加小区
        public ActionResult AddRoom()
        {
            return View();
        }
        // 实现添加小区操作
        [HttpPost]
        public ActionResult AddRoom(w_room_info room)
        {
            db.w_room_info.Add(room);
            if (db.SaveChanges() > 0)
            {
                return Content("<script>alert('保存小区信息成功！');window.location.href='/Admin/RoomIndex';</script>");
            }
            else
            {
                ViewBag.erroy = "所填信息有误，请重新输入";
            }
            return View();
        }

        // 编辑小区信息
        public ActionResult UpdateRoom()
        {
            // 获取一条小区信息回来展示
            w_room_info info = db.w_room_info.FirstOrDefault();
            if (info == null)
            {
                // 如果不操编辑的信息，需要先提升新增
                return Content("<script>alert('请先添加小区信息！');window.location.href='/Admin/RoomIndex';</script>");
            }
            return View(info);
        }
        // 小区信息修改
        [HttpPost]
        public ActionResult UpdateRoom(w_room_info info)
        {
            db.Entry(info).State = System.Data.Entity.EntityState.Modified;
            if (db.SaveChanges() > 0)
            {
                return Content("<script>alert('小区信息修改成功！');window.location.href='/Admin/RoomIndex';</script>");
            }
            else
            {
                ViewBag.erroy = "编辑小区信息失败，请重新填写！";
            }
            return View();
        }



    }
}