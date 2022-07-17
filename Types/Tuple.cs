using System;
using System.Collections.Generic;
using System.Linq;
using Velocitech.Utils.RustCodeGenerationTool.Exceptions;
using Velocitech.Utils.RustCodeGenerationTool.Utils;


namespace Velocitech.Utils.RustCodeGenerationTool.Types
{
    public class Tuple : Type, IRenderAsType
    {
        private string _name;
        private List<Type> _membersTuple;


        public Tuple(string name)
        {
            if (String.IsNullOrEmpty(name))
                throw new Exception("The Tuple name is incorrect");

            _name = name.Capitalize();
            _membersTuple = new List<Type>();
        }

        public void AddMember<T>(T type)
            where T : Type
        {
            _membersTuple.Add(type);
        }

        public override string GetRustType()
        {
            return _name;
        }

        public string RenderAsType()
        {
            var result = String.Empty;

            if (_membersTuple.Count() == 0)
                throw new MemberStructException("Any member has been defined for the tuple");

            result = String.Join(',', _membersTuple.Select(x => x.GetRustType()));

            if (result.Length > 0)
                result = result.TrimEnd(',');

            return $"{_name}({result});";
        }
    }
}
