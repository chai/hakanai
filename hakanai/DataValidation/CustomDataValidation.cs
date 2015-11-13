using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace hakanai.DataValidation
{
    public class FileAttribute: ValidationAttribute 
    {
        private readonly int _maxSize;

        public FileAttribute(int maxsize)
        {
            _maxSize = maxsize;
        }

        public override bool IsValid(object value)
        {
            if (value == null) return true;
            return (value as HttpPostedFileBase).ContentLength <= _maxSize;
        }
        public override string FormatErrorMessage(string name)
        {
            return $"File is larger than {_maxSize} KB";
            
        }


    }
}