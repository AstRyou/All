using AbstractFactoryPlatform;
using ConcreteButton;
//using AbstractFactoryPlatform.ConcreteFactoryAndroid;
//using AbstractFactoryPlatform.ConcreteFactoryiOS;
//using AbstractFactoryPlatform.ConcreteFactoryWindows;
using ConcreteFactoryAndroid;
using ConcreteFactoryiOS;
using ConcreteFactoryWindows;
using ConcreteGrid;
using ConcreteText;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiPlatform
{
	class Program
	{
		private static void BuildUI(in IPlatform platform) //... type of platform
		{
            IGrid Grid = platform.getGridType();
            IButton firstButton =platform.getButtonType();
            IButton secondButton = platform.getButtonType(); 
            IButton thirdButton = platform.getButtonType();
            firstButton.Content = "BigPurpleButton";
            secondButton.Content = "SmallButton";
            thirdButton.Content = "Baton";
            Grid.AddButton(firstButton);
            Grid.AddButton(secondButton);
            Grid.AddButton(thirdButton);


            ITextBox firstText = platform.getTextType();
            ITextBox secondText = platform.getTextType();
            ITextBox thirdText = platform.getTextType();
            firstText.Content = "";
            secondText.Content = "EmptyTextBox";
            thirdText.Content = "xoBtxeT";
            Grid.AddTextBox(firstText);
            Grid.AddTextBox(secondText);
            Grid.AddTextBox(thirdText);

            foreach (IButton button in Grid.GetButtons())
            {
                button.ButtonPressed();
                button.DrawContent();
            }
            foreach (ITextBox text in Grid.GetTextBoxes())
            {
                text.DrawContent();
            }
        }

		static void Main(string[] args)
		{

			Console.WriteLine("<---------------------iOS--------------------->");

            iOS ios = new iOS();
            BuildUI(ios);

            Console.WriteLine("<---------------------Windows--------------------->");

            Windows windows = new Windows();
            BuildUI(windows);
            Console.WriteLine("<---------------------Android--------------------->");
            Android android = new Android();
            BuildUI(android);
        }
	}
}
