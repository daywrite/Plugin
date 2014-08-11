using OSharp.Core.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSharp.Plugin.Demo.Contracts.Models
{
    /// <summary>
    /// 实体类——示例实体
    /// </summary>
    public class DemoEntity : EntityBase<int>
    {
        public DemoEntity()
        {
            DemoDetails = new List<DemoDetail>();
        }

        /// <summary>
        /// 获取或设置 名称
        /// </summary>
        [Required, StringLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// 获取或设置 备注
        /// </summary>
        [StringLength(500)]
        public string Remark { get; set; }

        /// <summary>
        /// 集合类子属性
        /// </summary>
        public virtual ICollection<DemoDetail> DemoDetails { get; set; }
    }
}
