using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace WpfNetcoreTest
{
    public class Program
    { 
        public Program()
        {
            var printDialog = new PrintDialog
            {
                PageRangeSelection = PageRangeSelection.AllPages,
                UserPageRangeEnabled = true
            };

            printDialog.ShowDialog();
            printDialog.PrintDocument(this.PreparePrintDocument(printDialog), "Test");
        }

        private static Size GetPageSize(PrintDialog printDialog) => new Size(printDialog.PrintableAreaWidth, printDialog.PrintableAreaHeight);

        private static void SetPos(UIElement ui, double left, double top)
        {
            FixedPage.SetLeft(ui, left);
            FixedPage.SetTop(ui, top);
        }

        private DocumentPaginator PreparePrintDocument(PrintDialog printDialog)
        {
            //Document
            FixedDocument document = new FixedDocument();
            document.DocumentPaginator.PageSize = GetPageSize(printDialog);

            //Page of document
            FixedPage page = new FixedPage
            {
                Width = document.DocumentPaginator.PageSize.Width,
                Height = document.DocumentPaginator.PageSize.Height
            };

            //Heading
            TextBlock textBlock = new TextBlock
            {
                Text = "Test",
                FontSize = 27,
                Margin = new Thickness(96)
            };
            SetPos(textBlock, 170, 35);
            page.Children.Add(textBlock);

            //Document number
            TextBlock textBlock2 = new TextBlock
            {
                Text = "Test2",
                FontSize = 20,
                Margin = new Thickness(96)
            };
            SetPos(textBlock2, 170, 65);
            page.Children.Add(textBlock2);
            document.Pages.Add(new PageContent { Child = page });
            return document.DocumentPaginator;
        }
    }
}
