using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//namespace Controls
//{
    namespace ConcreteText
    {
        public interface ITextBox
        {
            string Content { set; }
            void DrawContent();
        }
    }
//}
