using System;
using System.Collections.Generic;
using Velocitech.Utils.RustCodeGenerationTool.Utils;
using System.Linq;
using Velocitech.Utils.RustCodeGenerationTool.Exceptions;

namespace Velocitech.Utils.RustCodeGenerationTool.Types
{
    public class Struct : Type, IRenderAsType
    {
        private string _name;
        private Dictionary<string, Type> _members;
        private List<Type> _membersTuple;
        private bool _isTupleStruct = false;

        public Struct(string name, bool isTupleStruct)
        {
            if (String.IsNullOrEmpty(name))
                throw new Exception("The Struct name is incorrect");

            _name = name.Capitalize();
            _members = new Dictionary<string, Type>();
            _membersTuple = new List<Type>();
            _isTupleStruct = isTupleStruct;
        }

        public void AddMember<T>(string name, T type)
            where T : Type
        {
            if (_isTupleStruct)
                AddMember(type);

            if (String.IsNullOrEmpty(name))
                throw new MemberStructException("The name of struct member can not be empty");

            _members.Add(name, type);
        }

        public void AddMember<T>(T type)
            where T : Type
        {
            _isTupleStruct = true;
            _membersTuple.Add(type);
        }

        public string RenderAsType()
        {
            if (_membersTuple.Count() == 0 && _members.Count() == 0)
                return $"struct {_name};";

            if (_isTupleStruct)
                return RenderStructAsTupleStruct();
            else
                return RenderStruct();
        }

        private string RenderStructAsTupleStruct()
        {
            return $"struct {_name}({RenderMembersAsTuple()});";
        }

        private string RenderStruct()
        {
            return $"struct {_name}\n{{\n{RenderMembers()}\n}}";
        }

        private string RenderMembers()
        {
            var result = String.Empty;

            if (_members.Count() == 0)
                throw new MemberStructException("Any member has been defined for the struct");

            foreach (KeyValuePair<string, Type> member in _members)
            {
                if ( member.Value == this)
                {
                    result += $"\t{member.Key}:Box<{member.Value.GetRustType()}>,\n";
                }
                else
                {
                    result += $"\t{member.Key}:{member.Value.GetRustType()},\n";
                }
                
            }
            if (result.Length > 0)
            {
                var last = result.LastIndexOf(',');
                result = result.Substring(0, last);
            }
            return result;
        }

        private string RenderMembersAsTuple()
        {
            var result = String.Empty;

            if (_membersTuple.Count() == 0)
                throw new MemberStructException("Any member has been defined for the struct");

            result = String.Join(',', _membersTuple.Select(x => x.GetRustType()));

            if (result.Length > 0)
                result = result.TrimEnd(',');

            return result;
        }

        public override string GetRustType()
        {
            return _name;
        }
    }
}
