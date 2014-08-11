// -----------------------------------------------------------------------
//  <copyright file="AbstractBuilder.cs" company="OSharp开源团队">
//      Copyright (c) OSharp 2014. All rights reserved.
//  </copyright>
//  <last-editor>郭明锋</last-editor>
//  <last-date>2014:06:28 17:41</last-date>
// -----------------------------------------------------------------------

using System.Collections.Generic;


namespace OSharp.Plugin.Extensions
{
    public abstract class BuilderBase<T> : AbstractBuilder<T>
    {
        protected BuilderBase()
        {
            Items = new List<T>();
        }

        public ICollection<T> Items { get; private set; }

        public void AddItem(T item)
        {
            Items.Add(item);
            OnItemAdded(item);
        }

        #region Overrides of AbstractBuilder<T>

        /// <summary>
        /// 重置节点构建器，清空扩展节点信息
        /// </summary>
        public override void Reset()
        {
            foreach (T item in Items)
            {
                OnItemRemoved(item);
            }
            Items.Clear();
        }

        #endregion
    }
}