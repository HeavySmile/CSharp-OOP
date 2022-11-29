using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    public class TestPolymorphismProtected
    {
        public static void Main()
        {
            List<TextBox> textBoxes = new List<TextBox>() 
            { 
                new EditTextBox(), 
                new RichTextBox(), 
                new MultiLineTextBox() 
            };

            foreach (var item in textBoxes)
            {
                // Compilation error due to protection level of TypeText method (protected)
                // item.TypeText();
            }
        }
    }
}
