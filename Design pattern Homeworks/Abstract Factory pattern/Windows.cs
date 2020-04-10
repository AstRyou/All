using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractFactoryPlatform;
using ConcreteButton;
using ConcreteGrid;
using ConcreteText;

//namespace AbstractFactoryPlatform
//{
    namespace ConcreteFactoryWindows
    {
        public class Windows : IPlatform
        {
            public IButton getButtonType()
            {
                return new ButtonWindows();
            }

            public IGrid getGridType()
            {
                return new GridWindows();
            }

            public ITextBox getTextType()
            {
                return new TextboxWindows();
            }

        }
        public class GridWindows : IGrid
        {
            private List<IButton> buttons = new List<IButton>();
            private List<ITextBox> texts = new List<ITextBox>();
            public GridWindows()
            {
                Console.WriteLine($"{nameof(Windows)} {nameof(GridWindows)} created");
            }
            public void AddButton(IButton button)
            {
                buttons.Add(button);
            }

            public void AddTextBox(ITextBox textBox)
            {
                texts.Add(textBox);
            }

            public IEnumerable<IButton> GetButtons()
            {
                buttons.Reverse();
                //buttons.AsEnumerable().Reverse();
                foreach (IButton button in buttons)
                {
                    yield return button;
                }
                buttons.Reverse();
            }

            public IEnumerable<ITextBox> GetTextBoxes()
            {
                texts.Reverse(1, texts.Count - 1);
                foreach (ITextBox text in texts)
                {
                    yield return text;
                }
                texts.Reverse(1, texts.Count - 1);
            }
        }
        public class ButtonWindows : IButton
        {
            private string text;
            public ButtonWindows()
            {
                Console.WriteLine($"{nameof(Windows)} {nameof(ButtonWindows)} created");
            }
            public string Content
            {
                set { this.text = value.ToUpper(); }
            }

            public void DrawContent()
            {
                Console.WriteLine(text);
            }
            public void ButtonPressed()
            {
                Console.WriteLine("Windows button pressed");
            }
        }
        public class TextboxWindows : ITextBox
        {
            private string text;
            public TextboxWindows()
            {

                Console.WriteLine($"{nameof(Windows)} {nameof(TextboxWindows)} created");
            }
            public string Content
            {
                set
                {
                    if (value.Length % 2 == 0)
                        this.text = value.Substring(value.Length / 2, value.Length / 2) + " by .Net Core";
                    else
                        this.text = value.Substring(value.Length / 2, (value.Length / 2) + 1) + " by .Net Core";
                }
            }

            public void DrawContent()
            {
                Console.WriteLine(text);
            }
        }
    }
//}