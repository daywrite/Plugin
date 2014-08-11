using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UIShell.OSGi;
using UIShell.PageFlowService;

namespace MvcWebFramework
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Get PageFlowService.
            IPageFlowService pageFlowService = BundleRuntime.Instance.GetFirstOrDefaultService<IPageFlowService>();
            if (pageFlowService == null)
            {
                throw new ServiceNotAvailableException(typeof(IPageFlowService).FullName, "没有安装PageFlowService服务。");
            }

            if (string.IsNullOrEmpty(pageFlowService.FirstPageNodeValue))
            {
                throw new Exception("没有定义第一个页面节点。");
            }
            // Redirect to first node.
            Response.Redirect(pageFlowService.FirstPageNodeValue);
        }
    }
}