using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//namespace Controls
//{
    namespace ConcreteButton
    {
        public interface IButton
        {
            string Content { set; }
            void DrawContent();
            void ButtonPressed();
        }
    }
//}
