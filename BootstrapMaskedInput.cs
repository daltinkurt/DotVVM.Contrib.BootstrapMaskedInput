using DotVVM.Framework.Binding;
using DotVVM.Framework.Binding.Expressions;
using DotVVM.Framework.Controls;
using DotVVM.Framework.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotVVM.Contrib.BootstrapMaskedInput
{
    public class BootstrapMaskedInput : HtmlGenericControl
    {
        public BootstrapMaskedInput() : base("input")
        {
        }

        [MarkupOptions(Required = true)]
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        public static readonly DotvvmProperty TextProperty
            = DotvvmProperty.Register<string, BootstrapMaskedInput>(c => c.Text, null);

        [MarkupOptions(Required = true)]
        public string Mask
        {
            get { return (string)GetValue(MaskProperty); }
            set { SetValue(MaskProperty, value); }
        }
        public static readonly DotvvmProperty MaskProperty
            = DotvvmProperty.Register<string, BootstrapMaskedInput>(c => c.Mask, null);

        //[MarkupOptions(AllowBinding = false)]

        public Command Changed
        {
            get { return (Command)GetValue(ChangedProperty); }
            set { SetValue(ChangedProperty, value); }
        }
        public static readonly DotvvmProperty ChangedProperty =
            DotvvmProperty.Register<Command, BootstrapMaskedInput>(t => t.Changed, null);

        protected override void AddAttributesToRender(IHtmlWriter writer, IDotvvmRequestContext context)
        {
            context.ResourceManager.AddCurrentCultureGlobalizationResource();

            IValueBinding textBinding = null;
            IValueBinding maskBinding = null;

            foreach (var item in Properties)
            {
                if (item.Key == TextProperty)
                    textBinding = item.Value as IValueBinding;
                if (item.Key == MaskProperty)
                    maskBinding = item.Value as IValueBinding;
            }
            if (textBinding == null)
            {
                var expression = textBinding.GetKnockoutBindingExpression(this);
                //expression = "dotvvm.globalize.formatString(" + JsonConvert.ToString("d.M.yyyy") + ", " + expression + ")";
                writer.AddKnockoutDataBind("dotvvm-contrib-BootstrapMaskedInput-Text", expression);
            }
            else
            {
                writer.AddKnockoutDataBind("dotvvm-contrib-BootstrapMaskedInput-Text", this, TextProperty, renderEvenInServerRenderingMode: true);
            }

            if (maskBinding == null)
            {
                var expression = maskBinding.GetKnockoutBindingExpression(this);
                //expression = "dotvvm.globalize.formatString(" + "" + ", " + expression + ")";
                writer.AddKnockoutDataBind("dotvvm-contrib-BootstrapMaskedInput-Mask", expression);
            }
            else
            {
                writer.AddKnockoutDataBind("dotvvm-contrib-BootstrapMaskedInput-Mask", this, MaskProperty, renderEvenInServerRenderingMode: true);
            }

            var activeTabChangedBinding = GetCommandBinding(ChangedProperty);
            if (activeTabChangedBinding != null)
            {
                writer.AddAttribute("data-dotvvm-contrib-BootstrapMaskedInput-changed", KnockoutHelper.GenerateClientPostBackScript(nameof(Changed), activeTabChangedBinding, this, true, null));
            }


            base.AddAttributesToRender(writer, context);
        }

        protected override void OnPreRender(IDotvvmRequestContext context)
        {
            context.ResourceManager.AddRequiredResource("dotvvm.contrib.BootstrapMaskedInput");

            base.OnPreRender(context);
        }

        protected override void RenderBeginTag(IHtmlWriter writer, IDotvvmRequestContext context)
        {
            writer.RenderSelfClosingTag(TagName);
        }

        protected override void RenderEndTag(IHtmlWriter writer, IDotvvmRequestContext context)
        {
        }
    }
}