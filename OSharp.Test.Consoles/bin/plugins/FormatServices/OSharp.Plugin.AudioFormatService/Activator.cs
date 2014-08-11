using System;
using System.Collections.Generic;
using System.Text;
using UIShell.OSGi;

namespace OSharp.Plugin.AudioFormatService
{
    public class Activator : IBundleActivator
    {
        public void Start(IBundleContext context)
        {
            context.AddService<IAudioFormatExtensionService>(new AudioFormatExtensionService());

            context.ExtensionChanged += context_ExtensionChanged;

            List<Extension> extensionList = context.GetExtensions("OSharp.Plugin.AudioFormat");
            if (extensionList != null && extensionList.Count > 0)
            {
                foreach (Extension extension in extensionList)
                {
                    //deal with each extension in AudioFormatExtensionContainer
                    AudioFormatExtensionContainer.Intance.CollectAudioFormatExtension(extension);
                }
            }
        }
        void context_ExtensionChanged(object sender, ExtensionEventArgs e)
        {
            throw new NotImplementedException();
        }
        public void Stop(IBundleContext context)
        {
            //todo:
        }
    }
}
