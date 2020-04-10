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
    namespace ConcreteFactoryAndroid
    {
        public class Android : IPlatform
        {
            //public Android()
            //{
            //    Console.WriteLine("android created");
            //}
            public IButton getButtonType()
            {
                return new ButtonAndroid();
            }

            public IGrid getGridType()
            {
                return new GridAndroid();
            }

            public ITextBox getTextType()
            {
                return new TextboxAndroid();
            }


        }

        public class GridAndroid : IGrid
        {
            private List<IButton> buttons = new List<IButton>();
            private List<ITextBox> texts = new List<ITextBox>();
            public GridAndroid()
            {
                Console.WriteLine($"{nameof(Android)} {nameof(GridAndroid)} created");
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
                return new List<ITextBox>();
            }
        }
        public class ButtonAndroid : IButton
        {
            private string text;
            public ButtonAndroid()
            {
                Console.WriteLine($"{nameof(Android)} {nameof(ButtonAndroid)} created");
            }
            public string Content
            {
                set
                {
                    if (value.Length > 8)
                        this.text = value.Substring(0, 8);
                    else
                        this.text = value;
                }
            }

            public void DrawContent()
            {
                Console.WriteLine(text);
            }
            public void ButtonPressed()
            {
                Console.WriteLine($"Sweet {text}!");
            }
        }

        public class TextboxAndroid : ITextBox
        {
            private string text;
            public TextboxAndroid()
            {
                Console.WriteLine($"{nameof(Android)} {nameof(TextboxAndroid)} created");
            }
            public string Content
            {
                set
                {
                    char[] charArray = value.ToCharArray();
                    Array.Reverse(charArray);
                    this.text = new string(charArray);
                }
            }

            public void DrawContent()
            {
                Console.WriteLine(text);
            }
        }
    }
//}
