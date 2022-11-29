using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    public class RichTextBox : TextBox
    {
        protected new string text;
        
        public RichTextBox() : base()
        {
            text = $"{GetType()}:Type text";
        }
        public override void EditTextAllowed()
        {
            base.TypeText();
            Console.WriteLine(base.text);
            Console.WriteLine(baseText);
        }
        public override void EditTextDisAllowed()
        {
            TextBox thisTextBox = this;

            // thisTextBox.TypeText();
            // thisTextBox.text = "newText";
            // thisTextBox.baseText = "newBaseText";
        }
        protected override void TypeText()
        {
            Console.WriteLine(text);
        }
    }
}
