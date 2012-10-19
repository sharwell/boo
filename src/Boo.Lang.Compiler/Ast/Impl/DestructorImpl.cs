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
	public partial class Destructor : Method
	{

		[System.CodeDom.Compiler.GeneratedCodeAttribute("astgen.boo", "1")]
		new public Destructor CloneNode()
		{
			return (Destructor)Clone();
		}
		
		/// <summary>
		/// <see cref="Node.CleanClone"/>
		/// </summary>
		[System.CodeDom.Compiler.GeneratedCodeAttribute("astgen.boo", "1")]
		new public Destructor CleanClone()
		{
			return (Destructor)base.CleanClone();
		}

		[System.CodeDom.Compiler.GeneratedCodeAttribute("astgen.boo", "1")]
		override public NodeType NodeType
		{
			get { return NodeType.Destructor; }
		}

		[System.CodeDom.Compiler.GeneratedCodeAttribute("astgen.boo", "1")]
		override public void Accept(IAstVisitor visitor)
		{
			visitor.OnDestructor(this);
		}

		[System.CodeDom.Compiler.GeneratedCodeAttribute("astgen.boo", "1")]
		override public bool Matches(Node node)
		{	
			if (node == null) return false;
			if (NodeType != node.NodeType) return false;
			var other = ( Destructor)node;
			if (_modifiers != other._modifiers) return NoMatch("Destructor._modifiers");
			if (_name != other._name) return NoMatch("Destructor._name");
			if (!Node.AllMatch(_attributes, other._attributes)) return NoMatch("Destructor._attributes");
			if (!Node.AllMatch(_parameters, other._parameters)) return NoMatch("Destructor._parameters");
			if (!Node.AllMatch(_genericParameters, other._genericParameters)) return NoMatch("Destructor._genericParameters");
			if (!Node.Matches(_returnType, other._returnType)) return NoMatch("Destructor._returnType");
			if (!Node.AllMatch(_returnTypeAttributes, other._returnTypeAttributes)) return NoMatch("Destructor._returnTypeAttributes");
			if (!Node.Matches(_body, other._body)) return NoMatch("Destructor._body");
			if (!Node.AllMatch(_locals, other._locals)) return NoMatch("Destructor._locals");
			if (_implementationFlags != other._implementationFlags) return NoMatch("Destructor._implementationFlags");
			if (!Node.Matches(_explicitInfo, other._explicitInfo)) return NoMatch("Destructor._explicitInfo");
			return true;
		}

		[System.CodeDom.Compiler.GeneratedCodeAttribute("astgen.boo", "1")]
		override public bool Replace(Node existing, Node newNode)
		{
			if (base.Replace(existing, newNode))
			{
				return true;
			}
			if (_attributes != null)
			{
				Attribute item = existing as Attribute;
				if (null != item)
				{
					Attribute newItem = (Attribute)newNode;
					if (_attributes.Replace(item, newItem))
					{
						return true;
					}
				}
			}
			if (_parameters != null)
			{
				ParameterDeclaration item = existing as ParameterDeclaration;
				if (null != item)
				{
					ParameterDeclaration newItem = (ParameterDeclaration)newNode;
					if (_parameters.Replace(item, newItem))
					{
						return true;
					}
				}
			}
			if (_genericParameters != null)
			{
				GenericParameterDeclaration item = existing as GenericParameterDeclaration;
				if (null != item)
				{
					GenericParameterDeclaration newItem = (GenericParameterDeclaration)newNode;
					if (_genericParameters.Replace(item, newItem))
					{
						return true;
					}
				}
			}
			if (_returnType == existing)
			{
				this.ReturnType = (TypeReference)newNode;
				return true;
			}
			if (_returnTypeAttributes != null)
			{
				Attribute item = existing as Attribute;
				if (null != item)
				{
					Attribute newItem = (Attribute)newNode;
					if (_returnTypeAttributes.Replace(item, newItem))
					{
						return true;
					}
				}
			}
			if (_body == existing)
			{
				this.Body = (Block)newNode;
				return true;
			}
			if (_locals != null)
			{
				Local item = existing as Local;
				if (null != item)
				{
					Local newItem = (Local)newNode;
					if (_locals.Replace(item, newItem))
					{
						return true;
					}
				}
			}
			if (_explicitInfo == existing)
			{
				this.ExplicitInfo = (ExplicitMemberInfo)newNode;
				return true;
			}
			return false;
		}

		[System.CodeDom.Compiler.GeneratedCodeAttribute("astgen.boo", "1")]
		override public object Clone()
		{
			Destructor clone = (Destructor)FormatterServices.GetUninitializedObject(typeof(Destructor));
			clone._lexicalInfo = _lexicalInfo;
			clone._endSourceLocation = _endSourceLocation;
			clone._documentation = _documentation;
			clone._isSynthetic = _isSynthetic;
			clone._entity = _entity;
			if (_annotations != null) clone._annotations = (Hashtable)_annotations.Clone();
		
			clone._modifiers = _modifiers;
			clone._name = _name;
			if (null != _attributes)
			{
				clone._attributes = _attributes.Clone() as AttributeCollection;
				clone._attributes.InitializeParent(clone);
			}
			if (null != _parameters)
			{
				clone._parameters = _parameters.Clone() as ParameterDeclarationCollection;
				clone._parameters.InitializeParent(clone);
			}
			if (null != _genericParameters)
			{
				clone._genericParameters = _genericParameters.Clone() as GenericParameterDeclarationCollection;
				clone._genericParameters.InitializeParent(clone);
			}
			if (null != _returnType)
			{
				clone._returnType = _returnType.Clone() as TypeReference;
				clone._returnType.InitializeParent(clone);
			}
			if (null != _returnTypeAttributes)
			{
				clone._returnTypeAttributes = _returnTypeAttributes.Clone() as AttributeCollection;
				clone._returnTypeAttributes.InitializeParent(clone);
			}
			if (null != _body)
			{
				clone._body = _body.Clone() as Block;
				clone._body.InitializeParent(clone);
			}
			if (null != _locals)
			{
				clone._locals = _locals.Clone() as LocalCollection;
				clone._locals.InitializeParent(clone);
			}
			clone._implementationFlags = _implementationFlags;
			if (null != _explicitInfo)
			{
				clone._explicitInfo = _explicitInfo.Clone() as ExplicitMemberInfo;
				clone._explicitInfo.InitializeParent(clone);
			}
			return clone;
		}

		[System.CodeDom.Compiler.GeneratedCodeAttribute("astgen.boo", "1")]
		override internal void ClearTypeSystemBindings()
		{
			_annotations = null;
			_entity = null;
			if (null != _attributes)
			{
				_attributes.ClearTypeSystemBindings();
			}
			if (null != _parameters)
			{
				_parameters.ClearTypeSystemBindings();
			}
			if (null != _genericParameters)
			{
				_genericParameters.ClearTypeSystemBindings();
			}
			if (null != _returnType)
			{
				_returnType.ClearTypeSystemBindings();
			}
			if (null != _returnTypeAttributes)
			{
				_returnTypeAttributes.ClearTypeSystemBindings();
			}
			if (null != _body)
			{
				_body.ClearTypeSystemBindings();
			}
			if (null != _locals)
			{
				_locals.ClearTypeSystemBindings();
			}
			if (null != _explicitInfo)
			{
				_explicitInfo.ClearTypeSystemBindings();
			}

		}
	

	}
}

