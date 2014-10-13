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
public partial class Property (TypeMember, INodeWithParameters, IExplicitMember):
	protected _parameters as ParameterDeclarationCollection

	protected _getter as Method

	protected _setter as Method

	protected _type as TypeReference

	protected _explicitInfo as ExplicitMemberInfo


	[System.CodeDom.Compiler.GeneratedCodeAttribute("Boo astgen.boo", "1")]
	public def CloneNode() as Property:
		return Clone() cast Property
	
	/// <summary>
	/// <see cref="Node.CleanClone"/>
	/// </summary>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Boo astgen.boo", "1")]
	public def CleanClone() as Property:
		return super.CleanClone() as Property

	[System.CodeDom.Compiler.GeneratedCodeAttribute("Boo astgen.boo", "1")]
	override public NodeType as NodeType:
		get: return NodeType.Property

	[System.CodeDom.Compiler.GeneratedCodeAttribute("Boo astgen.boo", "1")]
	override public def Accept(visitor as IAstVisitor) as void:
		visitor.OnProperty(self)

	[System.CodeDom.Compiler.GeneratedCodeAttribute("Boo astgen.boo", "1")]
	override public def Matches(node as Node) as bool:
		return false if (node is null) or (NodeType != node.NodeType)
		other = node as Property
		return NoMatch("Property._modifiers") unless _modifiers == other._modifiers
		return NoMatch("Property._name") unless _name == other._name
		return NoMatch("Property._attributes") unless Node.AllMatch(_attributes, other._attributes)
		return NoMatch("Property._parameters") unless Node.AllMatch(_parameters, other._parameters)
		return NoMatch("Property._getter") unless Node.Matches(_getter, other._getter)
		return NoMatch("Property._setter") unless Node.Matches(_setter, other._setter)
		return NoMatch("Property._type") unless Node.Matches(_type, other._type)
		return NoMatch("Property._explicitInfo") unless Node.Matches(_explicitInfo, other._explicitInfo)
		return true

	[System.CodeDom.Compiler.GeneratedCodeAttribute("Boo astgen.boo", "1")]
	override public def Replace(existing as Node, newNode as Node) as bool:
		return true if super.Replace(existing, newNode)
		if _attributes is not null:
			item = existing as Attribute
			if item is not null:
				newItem = newNode as Attribute
				return true if _attributes.Replace(item, newItem)
		if _parameters is not null:
			item = existing as ParameterDeclaration
			if item is not null:
				newItem = newNode as ParameterDeclaration
				return true if _parameters.Replace(item, newItem)
		if _getter == existing:
			self.Getter = newNode as Method
			return true;
		if _setter == existing:
			self.Setter = newNode as Method
			return true;
		if _type == existing:
			self.Type = newNode as TypeReference
			return true;
		if _explicitInfo == existing:
			self.ExplicitInfo = newNode as ExplicitMemberInfo
			return true;
		return false;

	[System.CodeDom.Compiler.GeneratedCodeAttribute("Boo astgen.boo", "1")]
	override public def Clone() as object:
		
		clone = Property()
		clone._lexicalInfo = _lexicalInfo
		clone._endSourceLocation = _endSourceLocation
		clone._documentation = _documentation
		clone._isSynthetic = _isSynthetic
		clone._entity = _entity
		if _annotations is not null: clone._annotations = _annotations.Clone() as Hashtable
		clone._modifiers = _modifiers
		clone._name = _name
		if _attributes is not null:
			clone._attributes = _attributes.Clone() as AttributeCollection
			clone._attributes.InitializeParent(clone)
		if _parameters is not null:
			clone._parameters = _parameters.Clone() as ParameterDeclarationCollection
			clone._parameters.InitializeParent(clone)
		if _getter is not null:
			clone._getter = _getter.Clone() as Method
			clone._getter.InitializeParent(clone)
		if _setter is not null:
			clone._setter = _setter.Clone() as Method
			clone._setter.InitializeParent(clone)
		if _type is not null:
			clone._type = _type.Clone() as TypeReference
			clone._type.InitializeParent(clone)
		if _explicitInfo is not null:
			clone._explicitInfo = _explicitInfo.Clone() as ExplicitMemberInfo
			clone._explicitInfo.InitializeParent(clone)
		return clone;


	

	[System.CodeDom.Compiler.GeneratedCodeAttribute("Boo astgen.boo", "1")]
	override internal def ClearTypeSystemBindings() as void:
		_annotations = null;
		_entity = null;
		if _attributes is not null:
			_attributes.ClearTypeSystemBindings()
		if _parameters is not null:
			_parameters.ClearTypeSystemBindings()
		if _getter is not null:
			_getter.ClearTypeSystemBindings()
		if _setter is not null:
			_setter.ClearTypeSystemBindings()
		if _type is not null:
			_type.ClearTypeSystemBindings()
		if _explicitInfo is not null:
			_explicitInfo.ClearTypeSystemBindings()



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
	public Getter as Method:
		
		get: return _getter
		set:
			if _getter != value:
				_getter = value;
				if _getter is not null:
					_getter.InitializeParent(this);



	[System.Xml.Serialization.XmlElement]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Boo astgen.boo", "1")]
	public Setter as Method:
		
		get: return _setter
		set:
			if _setter != value:
				_setter = value;
				if _setter is not null:
					_setter.InitializeParent(this);



	[System.Xml.Serialization.XmlElement]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Boo astgen.boo", "1")]
	public Type as TypeReference:
		
		get: return _type
		set:
			if _type != value:
				_type = value;
				if _type is not null:
					_type.InitializeParent(this);



	[System.Xml.Serialization.XmlElement]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Boo astgen.boo", "1")]
	public ExplicitInfo as ExplicitMemberInfo:
		
		get: return _explicitInfo
		set:
			if _explicitInfo != value:
				_explicitInfo = value;
				if _explicitInfo is not null:
					_explicitInfo.InitializeParent(this);


