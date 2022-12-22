using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SynthesisLogic
{
    public static class Extensions
    {
        public static bool IsNullOrWhiteSpace(this string self)
        {
            return string.IsNullOrWhiteSpace(self);
        }

        public static bool IsEmail(this string self)
        {
            return Regex.IsMatch(self, @"^[a-z]+\.?[a-z]+@[a-z]+\.[a-z]{1,3}$");
        }
    }
}
