using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Threading;

namespace ScheduleSystem.DesktopClient.Views
{
    /// <summary>
    /// Interaction logic for AboutDialog.xaml
    /// ATTENTION:
    ///     We know that this is not (more like 'absolutely not') related to MVVM.
    ///     This is just our signature!
    /// </summary>
    public partial class AboutDialog : Window
    {
        public AboutDialog()
        {
            InitializeComponent();
        }
        private DispatcherTimer timer = new DispatcherTimer();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            aboutString += fakeErrString("System information:");
            aboutString += "\n" + fakeErrString(Environment.OSVersion.VersionString);
            aboutString += "\n" + fakeErrString("Logged in as: \n      " + Environment.UserName);
            aboutString += "\n" + fakeErrString("Computername: \n      " + Environment.MachineName);
            timer.Interval = TimeSpan.FromMilliseconds(35);
            timer.Tick += timer_Tick;
            timer.Start();
        }
        private string fakeErrString(string original)
        {
            string newstring = "";
            int n;
            Random rnd = new Random();
            for (int i = 0, len = original.Length; i < len; i++)
            {
                string outp = original[i].ToString();
                int v = rnd.Next(0, 8);
                if (v > 6)
                {
                    bool number = Char.IsNumber(original[i]);
                    bool letter = Char.IsLetter(original[i]);
                    if (letter)
                    {
                        
                        int code = new Random().Next(65, 65 + 25);
                        char newChar = (char)code;
                        if (Char.IsUpper(original[i]))
                        {
                            newChar = Char.ToUpper(newChar);
                        }
                        else
                        {
                            newChar = Char.ToLower(newChar);
                        }
                        outp = newChar.ToString() + "\b" + original[i].ToString();
                    }
                    else if (number)
                    {
                        
                        int num;
                        bool r = int.TryParse(original[i].ToString(), out num);
                        if (r)
                        {
                            Random rnd2 = new Random();
                            int newNumber = rnd2.Next(0, 9);
                            while (newNumber == num)
                            {
                                newNumber = rnd2.Next(0, 9);
                            }
                            outp = newNumber.ToString() + "\b" + original[i].ToString();
                        }
                    }
                }
                
                newstring += outp;
            }
            return newstring;
        }
        private String aboutString = "ScheduleSystem!1\b\nMdae\b\b\bade bt\by:\nRene\bê\bë\bé & Andre\b\bers\n\nA schoolprojekt\b\bct for Ma\bercantek\bc Viborg.\b, Da\benmark!\n\n";
        int cursor = 0;
        void timer_Tick(object sender, EventArgs e)
        {
            if (cursor < aboutString.Length)
            {
                if (aboutString[cursor] == '\n')
                {
                    Paragraph p = new Paragraph();
                    Span span = new Span();
                    Run run = new Run("");
                    span.Inlines.Add(run);
                    span.FontSize = 13;
                    p.LineHeight = 1;
                    p.Inlines.Add(span);
                    RTBox.Document.Blocks.Add(p);
                }
                else if (aboutString[cursor] == '\b')
                {
                    Paragraph p = (Paragraph)RTBox.Document.Blocks.LastBlock;
                    Inline line = p.Inlines.LastInline;
                    Run run = new Run();
                    if (line.GetType().ToString().Contains(".Run"))
                    {
                        run = (Run)line;
                    }
                    else if (line.GetType().ToString().Contains(".Span"))
                    {
                        Span span = (Span)line;
                        run = (Run)span.Inlines.LastInline;
                    }
                    run.Text = run.Text.Substring(0, run.Text.Length - 1);
                }
                else
                {
                    RTBox.AppendText(aboutString[cursor].ToString());
                }
                cursor++;
                if (cursor < aboutString.Length)
                {
                    if ((aboutString[cursor] == '\b') && (aboutString[cursor - 1] != '\b'))
                    {
                        timer.Interval = TimeSpan.FromMilliseconds(35 + new Random().Next(0, 80));
                    }
                }
            }
            else
            {
                timer.Stop();
            }
            
        }

        private void RTBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
