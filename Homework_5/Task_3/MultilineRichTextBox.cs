using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3
{
    public class MultilineRichTextBox : RichTextBox
    {
        protected override void Undo()
        {
            Console.WriteLine($"{GetType()}.Undo");
        }
        public void PolyTest()
        {
            IUndoable item1 = new RichTextBox();
            item1.Undo();

            IUndoable item2 = new MultilineRichTextBox();
            item2.Undo();

            // Explanation
            //
            // When Undo() is executed for both upcasted classes, the program
            // goes to Undo() from IUndoable implementation with explicit name
            // qualification in class TextBox. Then because item1 and item2 are
            // successors of TextBox class, overridden Undo() methods in both
            // classes are executed, which leads us to this input.
        }
    }
}
