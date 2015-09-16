﻿#region license
// Copyright (c) 2004, Rodrigo B. de Oliveira (rbo@acm.org)
// All rights reserved.
// 
// Redistribution and use in source and binary forms, with or without modification,
// are permitted provided that the following conditions are met:
// 
//     * Redistributions of source code must retain the above copyright notice,
//     this list of conditions and the following disclaimer.
//     * Redistributions in binary form must reproduce the above copyright notice,
//     this list of conditions and the following disclaimer in the documentation
//     and/or other materials provided with the distribution.
//     * Neither the name of Rodrigo B. de Oliveira nor the names of its
//     contributors may be used to endorse or promote products derived from this
//     software without specific prior written permission.
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
// ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
// DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE
// FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
// DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
// SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
// CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY,
// OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF
// THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
#endregion

using System;
using Boo.Lang.Compiler.Ast;
using Boo.Lang.Compiler;
using Boo.Lang.Environments;
using Boo.Lang.Parser.Util;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

namespace Boo.Lang.ParserV4
{
	/// <summary>
	/// Step 1. Parses any input fed to the compiler.
	/// 
	/// Parsing behaviour can be customized by providing a specific <see cref="ParserSettings"/> instance through
	/// <see cref="CompilerParameters.Environment" />.
	/// </summary>
	public class BooParsingStep : ICompilerStep
	{
		CompilerContext _context;
		
		protected CompilerContext Context
		{
			get { return _context; }
		}
		
		public void Initialize(CompilerContext context)
		{
			_context = context;
		}
		
		public void Dispose()
		{
			_context = null;
		}

		protected int TabSize
		{
			get { return My<Boo.Lang.Parser.ParserSettings>.Instance.TabSize;  }
		}

		public void Run()
		{
			foreach (var input in _context.Parameters.Input)
			{
				try
				{
					using (var reader = input.Open())
						ParseModule(input.Name, reader);
				}				
				catch (CompilerError error)
				{
					_context.Errors.Add(error);
				}
/*				catch (TokenStreamRecognitionException x)
				{
					OnParserError(x.recog);
				}*/
				catch (Exception x)
				{
					_context.Errors.Add(CompilerErrorFactory.InputError(input.Name, x));
				}
			}
		}

/*		[Obsolete]
		protected virtual void ParseModule(string inputName, System.IO.TextReader reader, Boo.Lang.Parser.ParserErrorHandler errorHandler)
		{
			// We need to replace and later restore the error handler in the settings
			var settings = My<Boo.Lang.Parser.ParserSettings>.Instance;
			var prevHandler = settings.ErrorHandler;
			//settings.ErrorHandler = errorHandler;

			try
			{
				ParseModule(inputName, reader);
			} 
			finally 
			{
				settings.ErrorHandler = prevHandler;
			}
		}
*/
		protected virtual void ParseModule(string inputName, System.IO.TextReader reader)
		{
            /*
            var settings = My<Boo.Lang.Parser.ParserSettings>.Instance;
            new BooParser(new BooLexer())*/

            AntlrInputStream stream = new AntlrInputStream(reader);
            ITokenSource lexer = new BooLexer(stream);
            ITokenSource filter = new IndentTokenStreamFilterV4(lexer, BooLexer.WS, BooLexer.NEWLINE, BooLexer.INDENT, BooLexer.DEDENT, BooLexer.EOL, BooLexer.END, BooLexer.ID);
            ITokenStream tokens = new CommonTokenStream(filter);
            var parser = new BooParser(tokens);
            parser.BuildParseTree = true;
            var tree = parser.start();
            BooParser.Visualize(tree, tokens);
            var visitor = new BooParserAstBuilderListener(_context.CompileUnit, inputName);
            visitor.VisitStart(tree);
            //BooParser.ParseModule(settings, _context.CompileUnit, inputName, reader);
		}

/*
        void OnParserError(Antlr4.Runtime.RecognitionException error)
		{			
			var location = new LexicalInfo(error.getFilename(), error.getLine(), error.getColumn());
			var nvae = error as NoViableAltException;
			if (null != nvae)
				ParserError(location, nvae);
			else
				GenericParserError(location, error);
		}
*/
		private void GenericParserError(LexicalInfo data, RecognitionException error)
		{
			_context.Errors.Add(CompilerErrorFactory.GenericParserError(data, error));
		}

        /*
		void ParserError(LexicalInfo data, NoViableAltException error)
		{			
			_context.Errors.Add(CompilerErrorFactory.UnexpectedToken(data, error, error.token.getText()));
		}
        */
	}
}