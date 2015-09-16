namespace Boo.Lang.Parser
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using Antlr4.Runtime;
    using Antlr4.Runtime.Tree;

    public class TreeViewModel
    {
        private readonly ITokenStream _source;
        private readonly ISyntaxTree _tree;
        private readonly bool _trailing;
        private ReadOnlyCollection<TreeViewModel> _children;

        public TreeViewModel(ITokenStream source, ISyntaxTree tree)
            : this(source, tree, false)
        {
        }

        private TreeViewModel(ITokenStream source, ISyntaxTree tree, bool trailing)
        {
            if (tree == null)
                throw new ArgumentNullException("tree");

            _source = source;
            _tree = tree;
            _trailing = trailing;
        }

        public ISyntaxTree Tree
        {
            get
            {
                return _tree;
            }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public ReadOnlyCollection<TreeViewModel> Children
        {
            get
            {
                if (_children == null)
                {
                    List<TreeViewModel> children = new List<TreeViewModel>();
                    if (IsNonTerminal)
                    {
                        int count = _tree.ChildCount;
                        for (int i = 0; i < count; i++)
                        {
                            ISyntaxTree child = (ISyntaxTree)_tree.GetChild(i);
                            if (child == null)
                                continue;

                            children.Add(new TreeViewModel(_source, child));
                        }
                    }
                    else if (!IsTrivia)
                    {
                        ITerminalNode terminalNode = Tree as ITerminalNode;
                        if (terminalNode != null)
                        {
                            int index = terminalNode.Symbol.TokenIndex;
                            int firstNewlineIndex = -1;
                            for (int i = index - 1; i >= 0 && _source.Get(i).Channel != TokenConstants.DefaultChannel; i--)
                            {
                                if (firstNewlineIndex < 0 && _source.Get(i).Type == BooLexer.NEWLINE)
                                {
                                    firstNewlineIndex = i;
                                }

                                children.Insert(0, new TreeViewModel(_source, new TerminalNodeImpl(_source.Get(i)), false));
                            }

                            //if (firstNewlineIndex < 0)
                            //{
                            //    // Leading trivia is actually trailing trivia of the previous token.
                            //    children.Clear();
                            //}

                            firstNewlineIndex = -1;
                            for (int i = index + 1; i < _source.Size && _source.Get(i).Channel != TokenConstants.DefaultChannel; i++)
                            {
                                children.Add(new TreeViewModel(_source, new TerminalNodeImpl(_source.Get(i)), true));
                                if (firstNewlineIndex < 0 && _source.Get(i).Type == BooLexer.NEWLINE)
                                {
                                    firstNewlineIndex = i;
                                }
                            }

                            if (firstNewlineIndex >= 0)
                            {
                                children.RemoveRange(firstNewlineIndex + 1, children.Count - firstNewlineIndex - 1);
                            }
                        }
                    }

                    if (children.Count == 0)
                    {
                    }

                    _children = children.AsReadOnly();
                }

                return _children;
            }
        }

        public bool IsNonTerminal
        {
            get
            {
                return Tree is IRuleNode;
            }
        }

        public bool IsTrivia
        {
            get
            {
                ITerminalNode terminalNode = Tree as ITerminalNode;
                if (terminalNode == null)
                    return false;

                return terminalNode.Symbol.Channel != TokenConstants.DefaultChannel;
            }
        }

        public string Title
        {
            get
            {
                IRuleNode ruleNode = Tree as IRuleNode;
                if (ruleNode != null)
                    return ParserV4.BooParser.ruleNames[ruleNode.RuleContext.RuleIndex];

                ITerminalNode terminalNode = Tree as ITerminalNode;
                if (terminalNode != null)
                {
                    string text = ParserV4.BooParser.DefaultVocabulary.GetSymbolicName(terminalNode.Symbol.Type)
                        ?? ParserV4.BooParser.DefaultVocabulary.GetDisplayName(terminalNode.Symbol.Type);
                    if (IsTrivia)
                    {
                        text = (_trailing ? "Trail: " : "Lead: ") + text;
                    }

                    return text;
                }

                IToken firstToken = _source.Get(_tree.SourceInterval.a);
                IToken lastToken = _source.Get(_tree.SourceInterval.b);
                return _source.GetText(firstToken, lastToken);
            }
        }

        public string Text
        {
            get
            {
                IRuleNode ruleNode = Tree as IRuleNode;
                if (ruleNode != null)
                    return ParserV4.BooParser.ruleNames[ruleNode.RuleContext.RuleIndex];

                IToken firstToken = _source.Get(_tree.SourceInterval.a);
                IToken lastToken = _source.Get(_tree.SourceInterval.b);
                return _source.GetText(firstToken, lastToken);
            }
        }
    }
}
