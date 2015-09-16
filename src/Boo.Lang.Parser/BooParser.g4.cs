namespace Boo.Lang.ParserV4
{
    using System.Collections.Generic;
    using System.Windows.Controls;
    using Antlr4.Runtime;
    using TreeVisualizerControl = Boo.Lang.Parser.TreeVisualizerControl;
    using TreeVisualizerViewModel = Boo.Lang.Parser.TreeVisualizerViewModel;

    partial class BooParser
    {
        private static bool IsValidMacroArgument(int tokenType)
        {
            return LPAREN != tokenType && LBRACK != tokenType && DOT != tokenType && MULTIPLY != tokenType;
        }

        protected bool IsValidClosureMacroArgument(int tokenType)
        {
            if (!IsValidMacroArgument(tokenType))
                return false;

            return SUBTRACT != tokenType;
        }

        public static void Visualize(ParserRuleContext context, ITokenStream tokenStream)
        {
            Visualize(context, tokenStream, BooParser.ruleNames, BooParser.DefaultVocabulary);
        }

        public static void Visualize(ParserRuleContext context, ITokenStream tokenStream, IList<string> ruleNames, IVocabulary vocabulary)
        {
            BaseTreeVisualizer visualizer = new BaseTreeVisualizer(context, tokenStream, ruleNames, vocabulary);
            visualizer.ShowDialog();
        }

        private class BaseTreeVisualizer : System.Windows.Window
        {
            private readonly ParserRuleContext _context;
            private readonly IList<string> _ruleNames;
            private readonly IVocabulary _vocabulary;

            public BaseTreeVisualizer(ParserRuleContext context, ITokenStream tokenStream, IList<string> ruleNames, IVocabulary vocabulary)
            {
                this._context = context;
                this._ruleNames = ruleNames;
                this._vocabulary = vocabulary;

                this.Content = new TreeVisualizerControl()
                {
                    ViewModel = new TreeVisualizerViewModel(context, tokenStream)
                };
            }
        }
    }
}
