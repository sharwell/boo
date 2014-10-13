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
// This file was generated automatically by Boo astgen.boo.
//
namespace Boo.Lang.Compiler.Ast

import System.Collections
import System.Runtime.Serialization

[System.Serializable]
public partial class ConditionalExpression (Expression):
	protected _condition as Expression

	protected _trueValue as Expression

	protected _falseValue as Expression


	[System.CodeDom.Compiler.GeneratedCodeAttribute("Boo astgen.boo", "1")]
	public def CloneNode() as ConditionalExpression:
		return Clone() cast ConditionalExpression
	
	/// <summary>
	/// <see cref="Node.CleanClone"/>
	/// </summary>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Boo astgen.boo", "1")]
	public def CleanClone() as ConditionalExpression:
		return super.CleanClone() as ConditionalExpression

	[System.CodeDom.Compiler.GeneratedCodeAttribute("Boo astgen.boo", "1")]
	override public NodeType as NodeType:
		get: return NodeType.ConditionalExpression

	[System.CodeDom.Compiler.GeneratedCodeAttribute("Boo astgen.boo", "1")]
	override public def Accept(visitor as IAstVisitor) as void:
		visitor.OnConditionalExpression(self)

	[System.CodeDom.Compiler.GeneratedCodeAttribute("Boo astgen.boo", "1")]
	override public def Matches(node as Node) as bool:
		return false if (node is null) or (NodeType != node.NodeType)
		other = node as ConditionalExpression
		return NoMatch("ConditionalExpression._condition") unless Node.Matches(_condition, other._condition)
		return NoMatch("ConditionalExpression._trueValue") unless Node.Matches(_trueValue, other._trueValue)
		return NoMatch("ConditionalExpression._falseValue") unless Node.Matches(_falseValue, other._falseValue)
		return true

	[System.CodeDom.Compiler.GeneratedCodeAttribute("Boo astgen.boo", "1")]
	override public def Replace(existing as Node, newNode as Node) as bool:
		return true if super.Replace(existing, newNode)
		if _condition == existing:
			self.Condition = newNode as Expression
			return true;
		if _trueValue == existing:
			self.TrueValue = newNode as Expression
			return true;
		if _falseValue == existing:
			self.FalseValue = newNode as Expression
			return true;
		return false;

	[System.CodeDom.Compiler.GeneratedCodeAttribute("Boo astgen.boo", "1")]
	override public def Clone() as object:
		
		clone = ConditionalExpression()
		clone._lexicalInfo = _lexicalInfo
		clone._endSourceLocation = _endSourceLocation
		clone._documentation = _documentation
		clone._isSynthetic = _isSynthetic
		clone._entity = _entity
		if _annotations is not null: clone._annotations = _annotations.Clone() as Hashtable
		clone._expressionType = _expressionType
		if _condition is not null:
			clone._condition = _condition.Clone() as Expression
			clone._condition.InitializeParent(clone)
		if _trueValue is not null:
			clone._trueValue = _trueValue.Clone() as Expression
			clone._trueValue.InitializeParent(clone)
		if _falseValue is not null:
			clone._falseValue = _falseValue.Clone() as Expression
			clone._falseValue.InitializeParent(clone)
		return clone;


	

	[System.CodeDom.Compiler.GeneratedCodeAttribute("Boo astgen.boo", "1")]
	override internal def ClearTypeSystemBindings() as void:
		_annotations = null;
		_entity = null;
		_expressionType = null;
		if _condition is not null:
			_condition.ClearTypeSystemBindings()
		if _trueValue is not null:
			_trueValue.ClearTypeSystemBindings()
		if _falseValue is not null:
			_falseValue.ClearTypeSystemBindings()



	[System.Xml.Serialization.XmlElement]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Boo astgen.boo", "1")]
	public Condition as Expression:
		
		get: return _condition
		set:
			if _condition != value:
				_condition = value;
				if _condition is not null:
					_condition.InitializeParent(this);



	[System.Xml.Serialization.XmlElement]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Boo astgen.boo", "1")]
	public TrueValue as Expression:
		
		get: return _trueValue
		set:
			if _trueValue != value:
				_trueValue = value;
				if _trueValue is not null:
					_trueValue.InitializeParent(this);



	[System.Xml.Serialization.XmlElement]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Boo astgen.boo", "1")]
	public FalseValue as Expression:
		
		get: return _falseValue
		set:
			if _falseValue != value:
				_falseValue = value;
				if _falseValue is not null:
					_falseValue.InitializeParent(this);


