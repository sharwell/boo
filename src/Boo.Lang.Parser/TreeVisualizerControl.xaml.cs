namespace Boo.Lang.Parser
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Documents;
    using System.Windows.Media;
    using Antlr4.Runtime;
    using Antlr4.Runtime.Misc;

    /// <summary>
    /// Interaction logic for TreeVisualizerControl.xaml
    /// </summary>
    public partial class TreeVisualizerControl : UserControl
    {
        public TreeVisualizerControl()
        {
            InitializeComponent();
        }

        public TreeVisualizerViewModel ViewModel
        {
            get
            {
                return DataContext as TreeVisualizerViewModel;
            }

            set
            {
                DataContext = value;
            }
        }

        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            if (e.Property == DataContextProperty)
            {
                var viewModel = ViewModel;
                if (viewModel == null)
                    return;

                SourceTextBox.Document = new FlowDocument(new Paragraph(new Run(viewModel.SourceText)
                {
                    FontFamily = new FontFamily("Consolas")
                }));
            }

            base.OnPropertyChanged(e);
        }

        private void HandleAstTreeViewSelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            TreeVisualizerViewModel viewModel = ViewModel;
            if (viewModel == null)
            {
                Highlight(SourceTextBox.Document, new Interval());
                return;
            }

            TreeViewModel node = AstTreeView.SelectedItem as TreeViewModel;
            if (node == null)
            {
                Highlight(SourceTextBox.Document, new Interval());
                return;
            }

            IToken a = viewModel.GetToken(node.Tree.SourceInterval.a);
            IToken b = viewModel.GetToken(node.Tree.SourceInterval.b);
            if (a == null || b == null)
            {
                Highlight(SourceTextBox.Document, new Interval());
                return;
            }

            Highlight(SourceTextBox.Document, new Interval(a.StartIndex, b.StopIndex));
        }

        private static TextPointer Highlight(FlowDocument document, Interval interval)
        {
            if (document == null)
                throw new ArgumentNullException("document");

            TextPointer contentStart = document.ContentStart;

            // clear any existing highlight
            TextRange documentRange = new TextRange(document.ContentStart, document.ContentEnd);
            documentRange.ApplyPropertyValue(FlowDocument.BackgroundProperty, FlowDocument.BackgroundProperty.DefaultMetadata.DefaultValue);

            if (interval.Length <= 0)
                return null;

            // highlight the new text
            int startOffset = interval.a;
            int endOffset = interval.b + 1;
            TextPointer highlightStart = document.GetPointerFromCharOffset(ref startOffset);
            TextPointer highlightStop = document.GetPointerFromCharOffset(ref endOffset);
            if (startOffset != 0 || endOffset != 0)
                return null;

            var textRange = new TextRange(highlightStart, highlightStop);
            textRange.ApplyPropertyValue(FlowDocument.BackgroundProperty, Brushes.Yellow);
            return textRange.Start;
        }
    }
}
