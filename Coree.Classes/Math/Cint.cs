using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coree.Classes.Math
{
    public class Cint
    {
        private int _int;

        public Cint()
        {
            this._int = 0;
        }

        public Cint(int @int)
        {
            this._int = @int;
        }

        /// <summary>
        /// Will be called in assignments MyInt ddx3 = (int)int.MaxValue;
        /// </summary>
        /// <param name="int"></param>
        public static implicit operator Cint(int @int)
        {
            return new Cint(@int);
        }

        /// <summary>
        /// Will be called in assignments MyInt ddx3 = (long)int.MaxValue;
        /// </summary>
        /// <param name="int"></param>
        public static implicit operator Cint(long @int)
        {
            if (@int >= Int32.MinValue && @int <= Int32.MaxValue)
            {
                return new Cint((int)@int);
            }
            else
            {
                throw new ArgumentException("Assignment. Out of range exception");
            }
        }



        public static Cint operator +(Cint left, Cint right)
        {
            checked
            {
                return new Cint(left._int + right._int);
            }
        }

        public static bool operator ==(Cint left, Cint right)
        {
            checked
            {
                return left._int == right._int;
            }
        }

        public static bool operator !=(Cint left, Cint right)
        {
            checked
            {
                return left._int != right._int;
            }
        }

        public static Cint operator -(Cint left, Cint right)
        {
            checked
            {
                return new Cint(left._int - right._int);
            }
        }

        public static Cint operator *(Cint left, Cint right)
        {
            checked
            {
                return new Cint(left._int * right._int);
            }
        }

        public static Cint operator /(Cint left, Cint right)
        {
            checked
            {
                return new Cint(left._int / right._int);
            }
        }

        public static Cint operator ++(Cint left)
        {
            checked
            {
                return new Cint(left._int++);
            }
        }

        public static Cint operator --(Cint left)
        {
            checked
            {
                return new Cint(left._int--);
            }
        }

        public static implicit operator int(Cint v)
        {
            return v._int;
        }

        public static implicit operator long(Cint v)
        {
            return (long)v._int;
        }

        public bool IsEven
        {
            get
            {
                return _int % 2 == 0;
            }
        }

        public bool IsOdd
        {
            get
            {
                return (_int % 2 != 0);
            }
        }


        public Cint NextOddNumber()
        {
            checked
            {
                if (_int % 2 == 0)
                {
                    return new Cint(this._int + 1);
                }
                else
                {
                    return new Cint(this._int + 2);
                }
            }
        }

        public override string ToString()
        {
            return this._int.ToString();
        }

         public static Cint MaxValue
        {
            get { return new Cint(int.MaxValue); }
        }

        public static Cint MinValue
        {
            get { return new Cint(int.MinValue); }
        }

    }
}
