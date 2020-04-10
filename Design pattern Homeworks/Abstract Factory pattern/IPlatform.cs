//using Controls;
using ConcreteButton;
using ConcreteGrid;
using ConcreteText;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPlatform
{
    public interface IPlatform
    {
      
        IButton getButtonType();
        ITextBox getTextType();
        IGrid getGridType();
    }
}
