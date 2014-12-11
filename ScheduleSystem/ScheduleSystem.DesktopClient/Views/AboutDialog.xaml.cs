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
            timer.Interval = TimeSpan.FromMilliseconds(60);
            timer.Tick += timer_Tick;
            timer.Start();
        }
        private String aboutString = "ScheduleSystem!1\b\nMdae\b\b\bade bt\by:\nRene\bê\bë\bé & Andre\b\bers\n\nA schoolprojekt\b\bct for Ma\bercantek\bc Viborg.\b, Da\benmark!";
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
                    span.FontSize = 15;
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
                        timer.Interval = TimeSpan.FromMilliseconds(100 + new Random().Next(0, 30));
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
