// -----------------------------------------------------------------------
//  <copyright file="AbstractBuilder.cs" company="OSharp开源团队">
//      Copyright (c) OSharp 2014. All rights reserved.
//  </copyright>
//  <last-editor>郭明锋</last-editor>
//  <last-date>2014:06:28 17:41</last-date>
// -----------------------------------------------------------------------

using System;

using UIShell.OSGi.Utility;


namespace OSharp.Plugin.Extensions
{
    public class ExtensionChangeHandler : Disposable
    {
        public ExtensionChangeHandler()
        { }

        public ExtensionChangeHandler(IExtensionBuilder builder,
            Action<object> newItemHandler,
            Action<object> extensionRemoveHandler)
        {
            Initialize(builder, newItemHandler, extensionRemoveHandler);
        }

        public IExtensionBuilder Builder { get; protected set; }
        public Action<object> NewItemHandler { get; protected set; }
        public Action<object> RemoveItemHandler { get; protected set; }

        #region Implementation of IDisposable

        protected override void Dispose(bool disposing)
        {
            if (!disposing)
            {
                return;
            }
            Builder.ItemAdded -= builder_ItemAdded;
            Builder.ItemRemoved -= builder_ItemRemoved;
        }

        #endregion

        protected void Initialize(IExtensionBuilder builder,
            Action<object> newItemHandler,
            Action<object> extensionsRemovedHandler)
        {
            Builder = builder;
            NewItemHandler = newItemHandler;
            RemoveItemHandler = extensionsRemovedHandler;

            builder.ItemAdded += builder_ItemAdded;
            builder.ItemRemoved += builder_ItemRemoved;
        }

        private void builder_ItemAdded(object sender, EventArgs<object> e)
        {
            if (NewItemHandler != null)
            {
                NewItemHandler(e.Item);
            }
        }

        private void builder_ItemRemoved(object sender, EventArgs<object> e)
        {
            if (RemoveItemHandler != null)
            {
                RemoveItemHandler(e.Item);
            }
        }
    }
}