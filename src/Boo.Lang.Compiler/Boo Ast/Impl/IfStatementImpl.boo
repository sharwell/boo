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
public partial class IfStatement (ConditionalStatement):
	protected _trueBlock as Block

	protected _falseBlock as Block


	[System.CodeDom.Compiler.GeneratedCodeAttribute("Boo astgen.boo", "1")]
	public def CloneNode() as IfStatement:
		return Clone() cast IfStatement
	
	/// <summary>
	/// <see cref="Node.CleanClone"/>
	/// </summary>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Boo astgen.boo", "1")]
	public def CleanClone() as IfStatement:
		return super.CleanClone() as IfStatement

	[System.CodeDom.Compiler.GeneratedCodeAttribute("Boo astgen.boo", "1")]
	override public NodeType as NodeType:
		get: return NodeType.IfStatement

	[System.CodeDom.Compiler.GeneratedCodeAttribute("Boo astgen.boo", "1")]
	override public def Accept(visitor as IAstVisitor) as void:
		visitor.OnIfStatement(self)

	[System.CodeDom.Compiler.GeneratedCodeAttribute("Boo astgen.boo", "1")]
	override public def Matches(node as Node) as bool:
		return false if (node is null) or (NodeType != node.NodeType)
		other = node as IfStatement
		return NoMatch("IfStatement._modifier") unless Node.Matches(_modifier, other._modifier)
		return NoMatch("IfStatement._condition") unless Node.Matches(_condition, other._condition)
		return NoMatch("IfStatement._trueBlock") unless Node.Matches(_trueBlock, other._trueBlock)
		return NoMatch("IfStatement._falseBlock") unless Node.Matches(_falseBlock, other._falseBlock)
		return true

	[System.CodeDom.Compiler.GeneratedCodeAttribute("Boo astgen.boo", "1")]
	override public def Replace(existing as Node, newNode as Node) as bool:
		return true if super.Replace(existing, newNode)
		if _modifier == existing:
			self.Modifier = newNode as StatementModifier
			return true;
		if _condition == existing:
			self.Condition = newNode as Expression
			return true;
		if _trueBlock == existing:
			self.TrueBlock = newNode as Block
			return true;
		if _falseBlock == existing:
			self.FalseBlock = newNode as Block
			return true;
		return false;

	[System.CodeDom.Compiler.GeneratedCodeAttribute("Boo astgen.boo", "1")]
	override public def Clone() as object:
		
		clone = IfStatement()
		clone._lexicalInfo = _lexicalInfo
		clone._endSourceLocation = _endSourceLocation
		clone._documentation = _documentation
		clone._isSynthetic = _isSynthetic
		clone._entity = _entity
		if _annotations is not null: clone._annotations = _annotations.Clone() as Hashtable
		if _modifier is not null:
			clone._modifier = _modifier.Clone() as StatementModifier
			clone._modifier.InitializeParent(clone)
		if _condition is not null:
			clone._condition = _condition.Clone() as Expression
			clone._condition.InitializeParent(clone)
		if _trueBlock is not null:
			clone._trueBlock = _trueBlock.Clone() as Block
			clone._trueBlock.InitializeParent(clone)
		if _falseBlock is not null:
			clone._falseBlock = _falseBlock.Clone() as Block
			clone._falseBlock.InitializeParent(clone)
		return clone;


	

	[System.CodeDom.Compiler.GeneratedCodeAttribute("Boo astgen.boo", "1")]
	override internal def ClearTypeSystemBindings() as void:
		_annotations = null;
		_entity = null;
		if _modifier is not null:
			_modifier.ClearTypeSystemBindings()
		if _condition is not null:
			_condition.ClearTypeSystemBindings()
		if _trueBlock is not null:
			_trueBlock.ClearTypeSystemBindings()
		if _falseBlock is not null:
			_falseBlock.ClearTypeSystemBindings()



	[System.Xml.Serialization.XmlElement]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Boo astgen.boo", "1")]
	public TrueBlock as Block:
		
		get: return _trueBlock
		set:
			if _trueBlock != value:
				_trueBlock = value;
				if _trueBlock is not null:
					_trueBlock.InitializeParent(this);



	[System.Xml.Serialization.XmlElement]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Boo astgen.boo", "1")]
	public FalseBlock as Block:
		
		get: return _falseBlock
		set:
			if _falseBlock != value:
				_falseBlock = value;
				if _falseBlock is not null:
					_falseBlock.InitializeParent(this);


