using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    public class EditTextBox : TextBox
    {
        protected new string text;
        public EditTextBox() : base()
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

            // Cannot execute this method or access data members because its marked protected
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
