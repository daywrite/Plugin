// -----------------------------------------------------------------------
//  <copyright file="AbstractBuilder.cs" company="OSharp开源团队">
//      Copyright (c) OSharp 2014. All rights reserved.
//  </copyright>
//  <last-editor>郭明锋</last-editor>
//  <last-date>2014:06:28 17:41</last-date>
// -----------------------------------------------------------------------

using System.Xml;


namespace OSharp.Plugin.Extensions
{
    public class XmlUtility
    {
        public static string ReadAttribute(XmlNode node, string attributeName)
        {
            return ReadAttribute(node.Attributes, attributeName);
        }

        public static string ReadAttribute(XmlAttributeCollection attributes, string attributeName)
        {
            XmlAttribute attr = attributes[attributeName];
            return attr == null ? null : attr.Value;
        }
    }
}