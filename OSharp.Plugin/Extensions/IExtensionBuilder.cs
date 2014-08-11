// -----------------------------------------------------------------------
//  <copyright file="AbstractBuilder.cs" company="OSharp开源团队">
//      Copyright (c) OSharp 2014. All rights reserved.
//  </copyright>
//  <last-editor>郭明锋</last-editor>
//  <last-date>2014:06:28 17:41</last-date>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Xml;

using UIShell.OSGi;
using UIShell.OSGi.Utility;


namespace OSharp.Plugin.Extensions
{
    /// <summary>
    /// 定义OSGi.NET扩展节点构造器的行为
    /// </summary>
    public interface IExtensionBuilder
    {
        /// <summary>
        /// 添加节点事件
        /// </summary>
        event EventHandler<EventArgs<object>> ItemAdded;

        /// <summary>
        /// 移除节点事件
        /// </summary>
        event EventHandler<EventArgs<object>> ItemRemoved;

        /// <summary>
        /// 以<see cref="XmlNode"/>创建节点
        /// </summary>
        void Build(XmlNode xmlNode, IBundle owner);

        /// <summary>
        /// 以<see cref="XmlNodeList"/>创建节点
        /// </summary>
        void Build(XmlNodeList nodeList, IBundle owner);

        /// <summary>
        /// 以<see cref="IEnumerable{XmlNode}"/>创建节点
        /// </summary>
        void Build(IEnumerable<XmlNode> xmlNodes, IBundle owner);

        /// <summary>
        /// 重置节点构建器，清空扩展节点信息
        /// </summary>
        void Reset();
    }
}