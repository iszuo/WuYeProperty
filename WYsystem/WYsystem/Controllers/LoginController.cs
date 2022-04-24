using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WYsystem.Models;

namespace WYsystem.Controllers
{
    public class LoginController : Controller
    {
        // 数据库上下文连接对象
        private wyEntities db = new wyEntities();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        // 登录功能
        [HttpPost]
        public ActionResult Index(string username,string password)
        {
            if (username == "")
            {
                ViewBag.notice = "用户名不能为空！";
                return View();
            }
            if (password == "")
            {
                ViewBag.notice = "密码不能为空！";
                return View();
            }
            // 去数据库查询
            w_admin admin = db.w_admin.FirstOrDefault(p => p.username == username);
            if (admin == null)
            {
                ViewBag.notice = "用户名不存在！";
            }else if(admin.pass != password)
            {
                ViewBag.notice = "密码不正确！";
            }
            else
            {
                // 登录成功,跳转到后端的页面
                return Redirect("/Admin/index");
            }
            return View();
        }
    }
}