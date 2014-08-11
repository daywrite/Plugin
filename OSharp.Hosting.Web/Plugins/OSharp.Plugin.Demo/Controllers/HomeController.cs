using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OSharp.Plugin.Demo.Contracts;
using OSharp.Core.Data;
using OSharp.Core.Data.Entity;
using OSharp.Plugin.Demo.Contracts.Models;
using OSharp.Plugin.Demo.Services;
using OSharp.Plugin.Demo.Contracts.Dtos;

namespace OSharp.Plugin.Demo.Controllers
{
    public class HomeController : Controller
    {
        private static IUnitOfWork u = new CodeFirstDbContext();
        private static IRepository<DemoEntity, int> _demoEntityRepository = new Repository<DemoEntity, int>(u);
        private static IRepository<DemoDetail, Guid> _demoDetailRepository = new Repository<DemoDetail, Guid>(u);
        private IDemoContract _demoContract = new DemoService(_demoEntityRepository, _demoDetailRepository);

        #region 视图功能
        public ActionResult Index()
        {
            DemoEntityDto d = new DemoEntityDto();
            d.Id = 0;
            d.Name = "123";
            d.Remark = "";
            
            _demoContract.AddDemoEntity(d);
            return View();
        }

        #endregion
    }
}