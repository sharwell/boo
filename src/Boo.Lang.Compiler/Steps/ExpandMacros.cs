#region license
// boo - an extensible programming language for the CLI
// Copyright (C) 2004 Rodrigo B. de Oliveira
//
// Permission is hereby granted, free of charge, to any person 
// obtaining a copy of this software and associated documentation 
// files (the "Software"), to deal in the Software without restriction, 
// including without limitation the rights to use, copy, modify, merge, 
// publish, distribute, sublicense, and/or sell copies of the Software, 
// and to permit persons to whom the Software is furnished to do so, 
// subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included 
// in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, 
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF 
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. 
// IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY 
// CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, 
// TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE 
// OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// 
// Contact Information
//
// mailto:rbo@acm.org
#endregion

namespace Boo.Lang.Compiler.Steps
{
	using System;
	using System.Text;
	using Boo.Lang;
	using Boo.Lang.Compiler.Ast;
	using Boo.Lang.Compiler;
	using Boo.Lang.Compiler.Bindings;
	
	public class ExpandMacros : AbstractNamespaceSensitiveCompilerStep
	{
		StringBuilder _buffer = new StringBuilder();
		
		override public void Run()
		{
			Accept(CompileUnit);
		}
		
		override public void OnModule(Module module)
		{			
			PushNamespace((INamespace)BindingService.GetBinding(module));
			Accept(module.Members);
			Accept(module.Globals);			
			PopNamespace();
		}
		
		override public void OnMacroStatement(MacroStatement node)
		{
			Accept(node.Block);
			Accept(node.Arguments);
			
			Node replacement = null;
			
			IBinding binding = ResolveQualifiedName(node, node.Name);
			if (null == binding)
			{
				binding = ResolveQualifiedName(node, BuildMacroTypeName(node.Name));
			}
			
			if (null == binding)
			{
				Errors.Add(CompilerErrorFactory.UnknownMacro(node, node.Name));
			}
			else
			{
				if (BindingType.TypeReference != binding.BindingType)
				{
					Errors.Add(CompilerErrorFactory.InvalidMacro(node, node.Name));
				}
				else
				{
					ITypeBinding macroType = ((TypeReferenceBinding)binding).BoundType;
					ExternalTypeBinding type = macroType as ExternalTypeBinding;
					if (null == type)
					{
						Errors.Add(CompilerErrorFactory.AstMacroMustBeExternal(node, macroType.FullName));
					}
					else
					{
						object macroInstance = Activator.CreateInstance(type.Type);
						if (!(macroInstance is IAstMacro))
						{
							Errors.Add(CompilerErrorFactory.InvalidMacro(node, macroType.FullName));
						}
						else
						{							
							try
							{
								using (IAstMacro macro = ((IAstMacro)macroInstance))
								{
									macro.Initialize(_context);
									replacement = macro.Expand(node);
								}
							}
							catch (Exception error)
							{
								Errors.Add(CompilerErrorFactory.MacroExpansionError(node, error));
							}
						}
					}
				}
			}
			ReplaceCurrentNode(replacement);
		}
		
		string BuildMacroTypeName(string name)
		{
			_buffer.Length = 0;
			if (!Char.IsUpper(name[0]))
			{
				_buffer.Append(Char.ToUpper(name[0]));
				_buffer.Append(name.Substring(1));
				_buffer.Append("Macro");
			}
			else
			{
				_buffer.Append(name);
				_buffer.Append("Macro");
			}
			return _buffer.ToString();
		}
	}
}
