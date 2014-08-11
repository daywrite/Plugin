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
    /// OSGi扩展节点构建器基本行为实现
    /// </summary>
    public abstract class AbstractBuilder<T> : IExtensionBuilder
    {
        protected void OnItemAdded(T control)
        {
            if (ItemAdded != null)
            {
                ItemAdded(this, new EventArgs<object>(control));
            }
        }

        protected void OnItemRemoved(T control)
        {
            if (ItemRemoved != null)
            {
                ItemRemoved(this, new EventArgs<object>(control));
            }
        }

        #region Implementation of IExtensionBuilder

        /// <summary>
        /// 添加节点事件
        /// </summary>
        public event EventHandler<EventArgs<object>> ItemAdded;

        /// <summary>
        /// 移除节点事件
        /// </summary>
        public event EventHandler<EventArgs<object>> ItemRemoved;

        /// <summary>
        /// 以<see cref="XmlNode"/>创建节点
        /// </summary>
        public abstract void Build(XmlNode xmlNode, IBundle owner);

        /// <summary>
        /// 以<see cref="XmlNodeList"/>创建节点
        /// </summary>
        public void Build(XmlNodeList nodeList, IBundle owner)
        {
            for (int index = 0; index < nodeList.Count; index++)
            {
                Build(nodeList[index], owner);
            }
        }

        /// <summary>
        /// 以<see cref="IEnumerable{XmlNode}"/>创建节点
        /// </summary>
        public void Build(IEnumerable<XmlNode> xmlNodes, IBundle owner)
        {
            foreach (XmlNode xmlNode in xmlNodes)
            {
                Build(xmlNode, owner);
            }
        }

        /// <summary>
        /// 重置节点构建器，清空扩展节点信息
        /// </summary>
        public abstract void Reset();

        #endregion
    }
}