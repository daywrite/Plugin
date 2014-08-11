// -----------------------------------------------------------------------
//  <copyright file="IServiceResolver.cs" company="OSharp开源团队">
//      Copyright (c) 2014 OSharp. All rights reserved.
//  </copyright>
//  <last-editor>郭明锋</last-editor>
//  <last-date>2014-07-17 3:47</last-date>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;


namespace OSharp.Plugin.Mvc
{
    /// <summary>
    /// 对象创建者接口，负责创建对象并进行属性注入
    /// </summary>
    public interface IServiceResolver
    {
        /// <summary>
        /// 获取IController实例，构造函数注入方式可用
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        object Resolve(Type type);

        /// <summary>
        /// 对现有对象进行属性注入，可以先由无参构造函数生成对象，再进行属性注入
        /// </summary>
        /// <param name="instance">未进行属性注入的对象</param>
        T InjectProperties<T>(T instance);
    }
}