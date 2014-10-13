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
public partial class BlockExpression (Expression, INodeWithParameters, INodeWithBody):
	protected _parameters as ParameterDeclarationCollection

	protected _returnType as TypeReference

	protected _body as Block


	[System.CodeDom.Compiler.GeneratedCodeAttribute("Boo astgen.boo", "1")]
	public def CloneNode() as BlockExpression:
		return Clone() cast BlockExpression
	
	/// <summary>
	/// <see cref="Node.CleanClone"/>
	/// </summary>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Boo astgen.boo", "1")]
	public def CleanClone() as BlockExpression:
		return super.CleanClone() as BlockExpression

	[System.CodeDom.Compiler.GeneratedCodeAttribute("Boo astgen.boo", "1")]
	override public NodeType as NodeType:
		get: return NodeType.BlockExpression

	[System.CodeDom.Compiler.GeneratedCodeAttribute("Boo astgen.boo", "1")]
	override public def Accept(visitor as IAstVisitor) as void:
		visitor.OnBlockExpression(self)

	[System.CodeDom.Compiler.GeneratedCodeAttribute("Boo astgen.boo", "1")]
	override public def Matches(node as Node) as bool:
		return false if (node is null) or (NodeType != node.NodeType)
		other = node as BlockExpression
		return NoMatch("BlockExpression._parameters") unless Node.AllMatch(_parameters, other._parameters)
		return NoMatch("BlockExpression._returnType") unless Node.Matches(_returnType, other._returnType)
		return NoMatch("BlockExpression._body") unless Node.Matches(_body, other._body)
		return true

	[System.CodeDom.Compiler.GeneratedCodeAttribute("Boo astgen.boo", "1")]
	override public def Replace(existing as Node, newNode as Node) as bool:
		return true if super.Replace(existing, newNode)
		if _parameters is not null:
			item = existing as ParameterDeclaration
			if item is not null:
				newItem = newNode as ParameterDeclaration
				return true if _parameters.Replace(item, newItem)
		if _returnType == existing:
			self.ReturnType = newNode as TypeReference
			return true;
		if _body == existing:
			self.Body = newNode as Block
			return true;
		return false;

	[System.CodeDom.Compiler.GeneratedCodeAttribute("Boo astgen.boo", "1")]
	override public def Clone() as object:
		
		clone = BlockExpression()
		clone._lexicalInfo = _lexicalInfo
		clone._endSourceLocation = _endSourceLocation
		clone._documentation = _documentation
		clone._isSynthetic = _isSynthetic
		clone._entity = _entity
		if _annotations is not null: clone._annotations = _annotations.Clone() as Hashtable
		clone._expressionType = _expressionType
		if _parameters is not null:
			clone._parameters = _parameters.Clone() as ParameterDeclarationCollection
			clone._parameters.InitializeParent(clone)
		if _returnType is not null:
			clone._returnType = _returnType.Clone() as TypeReference
			clone._returnType.InitializeParent(clone)
		if _body is not null:
			clone._body = _body.Clone() as Block
			clone._body.InitializeParent(clone)
		return clone;


	

	[System.CodeDom.Compiler.GeneratedCodeAttribute("Boo astgen.boo", "1")]
	override internal def ClearTypeSystemBindings() as void:
		_annotations = null;
		_entity = null;
		_expressionType = null;
		if _parameters is not null:
			_parameters.ClearTypeSystemBindings()
		if _returnType is not null:
			_returnType.ClearTypeSystemBindings()
		if _body is not null:
			_body.ClearTypeSystemBindings()



	[System.Xml.Serialization.XmlArray]
	[System.Xml.Serialization.XmlArrayItem(typeof(ParameterDeclaration))]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Boo astgen.boo", "1")]
	public Parameters as ParameterDeclarationCollection:
		

		get:
			_parameters = ParameterDeclarationCollection(self)() if _parameters is null
			return _parameters 
		set:
			if _parameters != value:
				_parameters = value;
				if _parameters is not null:
					_parameters.InitializeParent(this);



	[System.Xml.Serialization.XmlElement]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Boo astgen.boo", "1")]
	public ReturnType as TypeReference:
		
		get: return _returnType
		set:
			if _returnType != value:
				_returnType = value;
				if _returnType is not null:
					_returnType.InitializeParent(this);



	[System.Xml.Serialization.XmlElement]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Boo astgen.boo", "1")]
	public Body as Block:
		
		get:
			if _body is null:
				_body = Block()
				_body.InitializeParent(this)
			return _body
		set:
			if _body != value:
				_body = value;
				if _body is not null:
					_body.InitializeParent(this);


