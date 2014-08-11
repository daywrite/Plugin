using OSharp.Core.Data.Entity;
using OSharp.Plugin.Demo.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSharp.Plugin.Demo.Services.EntityConfigurations
{
    public class DemoDetailConfiguration : EntityConfigurationBase<DemoDetail, Guid>
    {
        public DemoDetailConfiguration()
        {
            HasRequired(m => m.DemoEntity).WithMany(n => n.DemoDetails);
        }
    }
}
