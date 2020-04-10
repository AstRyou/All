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
    namespace ConcreteFactoryiOS
    {
        public class iOS : IPlatform
        {
            //public iOS()
            //{
            //    Console.WriteLine("ios created");
            //}
            public IButton getButtonType()
            {
                return new ButtoniOS();
            }

            public IGrid getGridType()
            {
                return new GridiOS();
            }

            public ITextBox getTextType()
            {
                return new TextboxiOS();
            }

        }
        public class GridiOS : IGrid
        {
            private List<IButton> buttons = new List<IButton>();
            private List<ITextBox> texts = new List<ITextBox>();
            public GridiOS()
            {
                Console.WriteLine($"{nameof(iOS)} {nameof(GridiOS)} created");
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
                foreach (IButton button in buttons)
                {
                    yield return button;
                }
            }

            public IEnumerable<ITextBox> GetTextBoxes()
            {
                foreach (ITextBox text in texts)
                {
                    yield return text;
                }
            }
        }
        public class ButtoniOS : IButton
        {
            private string text;
            public ButtoniOS()
            {
                Console.WriteLine($"{nameof(iOS)} {nameof(ButtoniOS)} created");
            }
            public string Content
            {
                set { this.text = value; }
            }

            public void DrawContent()
            {
                Console.WriteLine(text);
            }
            public void ButtonPressed()
            {
                Console.WriteLine($"IOS Button pressed, content - {text}");
            }
        }
        public class TextboxiOS : ITextBox
        {
            private string text;
            public TextboxiOS()
            {

                Console.WriteLine($"{nameof(iOS)} {nameof(TextboxiOS)} created");
            }
            public string Content
            {
                set { this.text = value; }
            }

            public void DrawContent()
            {
                Console.WriteLine(text);
            }
        }
    }
//}