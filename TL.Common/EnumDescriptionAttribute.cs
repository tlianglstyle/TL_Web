using System;
using System.Collections.Generic;
using System.Text;

namespace TL.Common
{
    public class EnumDescriptionAttribute : Attribute
    {
        private string _text = "";
        public string Text
        {
            get { return this._text; }
        }
        public EnumDescriptionAttribute(string text)
        {
            _text = text;
        }
    }
}
