using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Domain
{

    public class Validate
    {
        [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
        public class MobileAttribute : ValidationAttribute
        {
            public MobileAttribute(string ErrorMessage) : base()
            {
                this.ErrorMessage = ErrorMessage;
            }

            public override bool IsValid(object value)
            {
                if (value == null) return false;
                if (Isvalidex(value.ToString()) == false) return false;
                return true;
            }

            public bool Isvalidex(string ex)
            {
                if (!new Regex(@"09\d{2}\s*?\d{3}\s*?\d{4}$").IsMatch(ex)) return false;
                return true;
            }
        }
    }
}

