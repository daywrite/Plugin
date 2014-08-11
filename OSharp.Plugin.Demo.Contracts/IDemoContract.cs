using OSharp.Core;
using OSharp.Plugin.Demo.Contracts.Dtos;
using OSharp.Plugin.Demo.Contracts.Models;
using OSharp.Utility.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSharp.Plugin.Demo.Contracts
{
    /// <summary>
    /// 示例业务契约
    /// </summary>
    public interface IDemoContract : IDependency
    {
        #region 示例实体业务

        /// <summary>
        /// 获取 示例实体查询数据集
        /// </summary>
        IQueryable<DemoEntity> DemoEntities { get; }

        /// <summary>
        /// 检查示例实体名称是否存在
        /// </summary>
        /// <param name="name">示例实体名称</param>
        /// <param name="checkType">数据存在性检查类型</param>
        /// <param name="id">更新的编号</param>
        /// <returns></returns>
        bool CheckDemoEntityName(string name, CheckExistsType checkType, int id = 0);

        /// <summary>
        /// 添加示例实体
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        OperationResult AddDemoEntity(DemoEntityDto dto);

        /// <summary>
        /// 修改示例实体
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        OperationResult UpdateDemoEntity(DemoEntityDto dto);

        /// <summary>
        /// 删除示例实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        OperationResult DeleteDemoEntity(int id);

        #endregion
    }
}
