using Microsoft.UI.Xaml;
using System;
using System.Linq;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace HelloWorld
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            using var db = new WordContext();
            Console.WriteLine("Saving Word");
            db.Add(new Word { SavedWord = saveText.Text.ToString() });
            db.SaveChanges();
        }

        private void displayButton_Click(object sender, RoutedEventArgs e)
        {
            using var db2 = new WordContext();
            Console.WriteLine("Querying for a blog");
            var input = db2.Words
                .OrderBy(b => b.WordId)
                .Last();
            displayText.Text = input.SavedWord.ToString();
            Console.WriteLine("testing git");
        }
    }
}
