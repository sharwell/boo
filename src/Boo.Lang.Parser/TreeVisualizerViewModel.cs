namespace Boo.Lang.Parser
{
    using System;
    using Antlr4.Runtime;
    using Antlr4.Runtime.Misc;
    using Antlr4.Runtime.Tree;

    public class TreeVisualizerViewModel
    {
        private readonly ISyntaxTree _tree;
        private readonly TreeViewModel _treeViewModel;
        private readonly ITokenStream _tokenStream;

        public TreeVisualizerViewModel(ISyntaxTree tree, ITokenStream tokenStream)
        {
            if (tree == null)
                throw new ArgumentNullException("tree");

            _tree = tree;
            _tokenStream = tokenStream;
            _treeViewModel = new TreeViewModel(tokenStream, tree);
        }

        public ISyntaxTree Tree
        {
            get
            {
                return _tree;
            }
        }

        public TreeViewModel TreeViewModel
        {
            get
            {
                return _treeViewModel;
            }
        }

        public ITokenStream TokenStream
        {
            get
            {
                return _tokenStream;
            }
        }

        public string SourceText
        {
            get
            {
                ITokenStream tokenStream = TokenStream;
                if (tokenStream == null)
                    return null;

                ITokenSource tokenSource = tokenStream.TokenSource;
                if (tokenSource == null)
                    return null;

                ICharStream inputStream = tokenSource.InputStream;
                if (inputStream == null)
                    return null;

                return inputStream.GetText(new Interval(0, inputStream.Size - 1));
            }
        }

        public IToken GetToken(int index)
        {
            ITokenStream tokenStream = TokenStream;
            if (tokenStream == null)
                return null;

            if (index < 0 || index >= tokenStream.Size)
                return null;

            return _tokenStream.Get(index);
        }
    }
}
