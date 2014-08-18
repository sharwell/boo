#region license
// Copyright (c) 2009 Rodrigo B. de Oliveira (rbo@acm.org)
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

//
// DO NOT EDIT THIS FILE!
//
// This file was generated automatically by astgen.boo.
//
namespace Boo.Lang.Compiler.Ast
{	
	using System.Collections;
	using System.Runtime.Serialization;
	
	[System.Serializable]
	public partial class ForStatement : Statement
	{
		protected DeclarationCollection _declarations;

		protected Expression _iterator;

		protected Block _block;

		protected Block _orBlock;

		protected Block _thenBlock;


		[System.CodeDom.Compiler.GeneratedCodeAttribute("astgen.boo", "1")]
		new public ForStatement CloneNode()
		{
			return (ForStatement)Clone();
		}
		
		/// <summary>
		/// <see cref="Node.CleanClone"/>
		/// </summary>
		[System.CodeDom.Compiler.GeneratedCodeAttribute("astgen.boo", "1")]
		new public ForStatement CleanClone()
		{
			return (ForStatement)base.CleanClone();
		}

		[System.CodeDom.Compiler.GeneratedCodeAttribute("astgen.boo", "1")]
		override public NodeType NodeType
		{
			get { return NodeType.ForStatement; }
		}

		[System.CodeDom.Compiler.GeneratedCodeAttribute("astgen.boo", "1")]
		override public void Accept(IAstVisitor visitor)
		{
			visitor.OnForStatement(this);
		}

		[System.CodeDom.Compiler.GeneratedCodeAttribute("astgen.boo", "1")]
		override public bool Matches(Node node)
		{	
			if (node == null) return false;
			if (NodeType != node.NodeType) return false;
			var other = ( ForStatement)node;
			if (!Node.Matches(_modifier, other._modifier)) return NoMatch("ForStatement._modifier");
			if (!Node.AllMatch(_declarations, other._declarations)) return NoMatch("ForStatement._declarations");
			if (!Node.Matches(_iterator, other._iterator)) return NoMatch("ForStatement._iterator");
			if (!Node.Matches(_block, other._block)) return NoMatch("ForStatement._block");
			if (!Node.Matches(_orBlock, other._orBlock)) return NoMatch("ForStatement._orBlock");
			if (!Node.Matches(_thenBlock, other._thenBlock)) return NoMatch("ForStatement._thenBlock");
			return true;
		}

		[System.CodeDom.Compiler.GeneratedCodeAttribute("astgen.boo", "1")]
		override public bool Replace(Node existing, Node newNode)
		{
			if (base.Replace(existing, newNode))
			{
				return true;
			}
			if (_modifier == existing)
			{
				this.Modifier = (StatementModifier)newNode;
				return true;
			}
			if (_declarations != null)
			{
				Declaration item = existing as Declaration;
				if (null != item)
				{
					Declaration newItem = (Declaration)newNode;
					if (_declarations.Replace(item, newItem))
					{
						return true;
					}
				}
			}
			if (_iterator == existing)
			{
				this.Iterator = (Expression)newNode;
				return true;
			}
			if (_block == existing)
			{
				this.Block = (Block)newNode;
				return true;
			}
			if (_orBlock == existing)
			{
				this.OrBlock = (Block)newNode;
				return true;
			}
			if (_thenBlock == existing)
			{
				this.ThenBlock = (Block)newNode;
				return true;
			}
			return false;
		}

		[System.CodeDom.Compiler.GeneratedCodeAttribute("astgen.boo", "1")]
		override public object Clone()
		{
		
			ForStatement clone = new ForStatement();
			clone._lexicalInfo = _lexicalInfo;
			clone._endSourceLocation = _endSourceLocation;
			clone._documentation = _documentation;
			clone._isSynthetic = _isSynthetic;
			clone._entity = _entity;
			if (_annotations != null) clone._annotations = (Hashtable)_annotations.Clone();
			if (null != _modifier)
			{
				clone._modifier = _modifier.Clone() as StatementModifier;
				clone._modifier.InitializeParent(clone);
			}
			if (null != _declarations)
			{
				clone._declarations = _declarations.Clone() as DeclarationCollection;
				clone._declarations.InitializeParent(clone);
			}
			if (null != _iterator)
			{
				clone._iterator = _iterator.Clone() as Expression;
				clone._iterator.InitializeParent(clone);
			}
			if (null != _block)
			{
				clone._block = _block.Clone() as Block;
				clone._block.InitializeParent(clone);
			}
			if (null != _orBlock)
			{
				clone._orBlock = _orBlock.Clone() as Block;
				clone._orBlock.InitializeParent(clone);
			}
			if (null != _thenBlock)
			{
				clone._thenBlock = _thenBlock.Clone() as Block;
				clone._thenBlock.InitializeParent(clone);
			}
			return clone;


		}

		[System.CodeDom.Compiler.GeneratedCodeAttribute("astgen.boo", "1")]
		override internal void ClearTypeSystemBindings()
		{
			_annotations = null;
			_entity = null;
			if (null != _modifier)
			{
				_modifier.ClearTypeSystemBindings();
			}
			if (null != _declarations)
			{
				_declarations.ClearTypeSystemBindings();
			}
			if (null != _iterator)
			{
				_iterator.ClearTypeSystemBindings();
			}
			if (null != _block)
			{
				_block.ClearTypeSystemBindings();
			}
			if (null != _orBlock)
			{
				_orBlock.ClearTypeSystemBindings();
			}
			if (null != _thenBlock)
			{
				_thenBlock.ClearTypeSystemBindings();
			}

		}
	

		[System.Xml.Serialization.XmlArray]
		[System.Xml.Serialization.XmlArrayItem(typeof(Declaration))]
		[System.CodeDom.Compiler.GeneratedCodeAttribute("astgen.boo", "1")]
		public DeclarationCollection Declarations
		{
			

			get { return _declarations ?? (_declarations = new DeclarationCollection(this)); }
			set
			{
				if (_declarations != value)
				{
					_declarations = value;
					if (null != _declarations)
					{
						_declarations.InitializeParent(this);
					}
				}
			}

		}
		

		[System.Xml.Serialization.XmlElement]
		[System.CodeDom.Compiler.GeneratedCodeAttribute("astgen.boo", "1")]
		public Expression Iterator
		{
			
			get { return _iterator; }
			set
			{
				if (_iterator != value)
				{
					_iterator = value;
					if (null != _iterator)
					{
						_iterator.InitializeParent(this);
					}
				}
			}

		}
		

		[System.Xml.Serialization.XmlElement]
		[System.CodeDom.Compiler.GeneratedCodeAttribute("astgen.boo", "1")]
		public Block Block
		{
			
			get
			{ 
				if (_block == null)
				{
					_block = new Block();
					_block.InitializeParent(this);
				}
				return _block;
			}
			set
			{
				if (_block != value)
				{
					_block = value;
					if (null != _block)
					{
						_block.InitializeParent(this);
					}
				}
			}

		}
		

		[System.Xml.Serialization.XmlElement]
		[System.CodeDom.Compiler.GeneratedCodeAttribute("astgen.boo", "1")]
		public Block OrBlock
		{
			
			get { return _orBlock; }
			set
			{
				if (_orBlock != value)
				{
					_orBlock = value;
					if (null != _orBlock)
					{
						_orBlock.InitializeParent(this);
					}
				}
			}

		}
		

		[System.Xml.Serialization.XmlElement]
		[System.CodeDom.Compiler.GeneratedCodeAttribute("astgen.boo", "1")]
		public Block ThenBlock
		{
			
			get { return _thenBlock; }
			set
			{
				if (_thenBlock != value)
				{
					_thenBlock = value;
					if (null != _thenBlock)
					{
						_thenBlock.InitializeParent(this);
					}
				}
			}

		}
		

	}
}

