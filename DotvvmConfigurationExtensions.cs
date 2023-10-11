using DotVVM.Framework.Configuration;
using DotVVM.Framework.ResourceManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DotVVM.Contrib.BootstrapMaskedInput
{
    public static class DotvvmConfigurationExtensions
    {
        public static void AddContribBootstrapMaskedInputConfiguration(this DotvvmConfiguration config)
        {
            config.Markup.Controls.Add(new DotvvmControlConfiguration()
            {
                Assembly = typeof(BootstrapMaskedInput).Assembly.GetName().Name,
                Namespace = typeof(BootstrapMaskedInput).Namespace,
                TagPrefix = "da"
            });

            config.Resources.Register("dotvvm.contrib.BootstrapMaskedInput", new ScriptResource()
            {
                Location = new EmbeddedResourceLocation(typeof(BootstrapMaskedInput).GetTypeInfo().Assembly, "DotVVM.Contrib.BootstrapMaskedInput.Scripts.DotVVM.Contrib.BootstrapMaskedInput.js"),
                Dependencies = new[] { "dotvvm", "jquery", "dotvvm.contrib.BootstrapMaskedInput-js" }
            });
            config.Resources.Register("dotvvm.contrib.BootstrapMaskedInput-js", new ScriptResource()
            {
                Location = new EmbeddedResourceLocation(typeof(BootstrapMaskedInput).GetTypeInfo().Assembly, "DotVVM.Contrib.BootstrapMaskedInput.Scripts.BootstrapMaskedInput.js"),
                Dependencies = new[] { "dotvvm" }
            });

            // NOTE: all resource names should start with "dotvvm.contrib.BootstrapMaskedInput"
        }
    }
}