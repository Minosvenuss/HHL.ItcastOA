using HHL.ItcastOA.BLL;
using HHL.ItcastOA.IBLL;
using HHL.ItcastOA.Model.EnumType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HHL.ItcastOA.WebApp.Controllers
{
    public class UserInfoController : Controller
    {
        // GET: UserInfo
        IUserInfoService UserInfoService = new UserInfoService();
        public ActionResult Index()
        {
            ViewBag.Model = UserInfoService.LoadEntities(fin => true).ToList();
            return View();
        }

        [HttpPost]
        public JsonResult GetList()
        {
            int pageIndex = Request["page"] != null ? int.Parse(Request["page"]) : 1;
            int pageSize = Request["rows"] != null ? int.Parse(Request["rows"]) : 5;
            int totalCount;
            short delFlag = (short)DeleteEnumType.Normarl;
            var list = UserInfoService.LoadPageEntities<int>(pageIndex, pageSize, out totalCount, fin => fin.DelFlag == delFlag, fin => fin.ID, true);
            var temp = from u in list
                       select new
                       {
                           u.ID,
                           u.UserName,
                           u.Email,
                           u.RegTime,
                           u.Remark
                       };

            return Json(new { rows = temp, total = totalCount });
        }
    }
}