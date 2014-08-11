using OSharp.Core.Data;
using OSharp.Utility.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSharp.Plugin.Demo.Contracts.Models
{
    public class DemoDetail : EntityBase<Guid>
    {
        public DemoDetail()
        {
            Id = CombHelper.NewComb();
        }

        public string Content { get; set; }

        public bool IsLocked { get; set; }

        public virtual DemoEntity DemoEntity { get; set; }
    }
}
