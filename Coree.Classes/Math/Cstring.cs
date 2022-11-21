using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coree.Classes.Math
{
    public class Cstring
    {
        private string _string;

        public Cstring()
        {
            this._string = null;
        }

        public Cstring(string @string)
        {
            this._string = @string;
        }


        public static implicit operator Cstring(string @string)
        {
            return new Cstring(@string);
        }

        public static implicit operator string(Cstring v)
        {
            return v._string;
        }


        //return new value / temp in method
        public Cstring ToUpper()
        {
            return new Cstring(this._string.ToUpper());
        }

 
        public override string ToString()
        {
            return this._string;
        }

    }

    
}
