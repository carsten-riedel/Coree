using System.Diagnostics;
using System.Numerics;
using System.Text.Json;

namespace Coree.Classes.Math
{

    public class Prime
    {
        public class StateFullPrimeGenerator
        {
            private System.Threading.SynchronizationContext uiContext;
            public class PrimeCalculatedEventArgs
            {
                public int Primex { get; set; }
            }


            private event EventHandler<PrimeCalculatedEventArgs> _PrimeCalculatedEvent;

            public event EventHandler<PrimeCalculatedEventArgs> PrimeCalculatedEvent
            {
                add
                {
                    uiContext = System.ComponentModel.AsyncOperationManager.SynchronizationContext;
                    _PrimeCalculatedEvent += value;
                }

                remove
                {
                    _PrimeCalculatedEvent -= value;
                }
            }

            protected virtual void OnPrimeCalculated(int e)
            {
                EventHandler<PrimeCalculatedEventArgs> handler = _PrimeCalculatedEvent;
                if (handler != null)
                {
                    uiContext.Post(new System.Threading.SendOrPostCallback((o)=> { handler(this, new PrimeCalculatedEventArgs() { Primex = e }); ; }), null);
                }
            }

            public List<int> primes = new();
            public List<int> nonprimes = new();

            private int toBeTestedPointer;

            public int ToBeTestedPointer
            {
                get { return toBeTestedPointer; }
                set { toBeTestedPointer = value; }
            }

            private int toBeTested;

            public int ToBeTested
            {
                get { return toBeTested; }
                set { toBeTested = value; }
            }

            public int PrimeNumbersTotal
            {
                get { return primes.Count; }
            }

            public StateFullPrimeGenerator()
            {
            }


            public void GeneratePrimesNaiveT(int amount)
            {
                System.Threading.Thread thread = new Thread((o)=>GeneratePrimesNaive(amount));
                thread.IsBackground = true;
                thread.Start();
            }
            public void GeneratePrimesNaive(int amount)
            {
                if (primes.Count == 0)
                {
                    primes.Add(2);
                    OnPrimeCalculated(2);
                    nonprimes.Add(1);
                    amount--;
                }
                int lastprime = primes.Last();
                if (lastprime == 2)
                {
                    toBeTested = lastprime + 1;
                }
                else
                {
                    toBeTested = lastprime + 2;
                }

                while (amount>0)
                {
                    int sqrt = (int)System.Math.Sqrt(toBeTested);
                    bool isPrime = true;

                    for (int i = ToBeTestedPointer; (int)primes[i] <= sqrt; i++)
                    {
                        System.Threading.Thread.Sleep(1);
                        ToBeTestedPointer = i;
                        if (toBeTested % primes[i] == 0)
                        {
                            isPrime = false;
                            nonprimes.Add(toBeTested);
                            break;
                        }
                    }
                    if (isPrime)
                    {
                        primes.Add(toBeTested);
                        OnPrimeCalculated(toBeTested);
                
                        amount--;
                    }
                    ToBeTestedPointer = 0;
                    toBeTested += 2;
                }
            }
        }

  
        public static List<int> GeneratePrimesNaive(int n)
        {
            List<int> primes = new List<int>();
            primes.Add(2);
            int nextPrime = 3;
            while (primes.Count < n)
            {
                int sqrt = (int)System.Math.Sqrt(nextPrime);
                bool isPrime = true;
                for (int i = 0; (int)primes[i] <= sqrt; i++)
                {
                    if (nextPrime % primes[i] == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                {
                    primes.Add(nextPrime);
                }
                nextPrime += 2;
            }
            return primes;
        }

        public static List<int> GeneratePrimesNaive2(ref List<int> primes, int n)
        {
            if (primes.Count == 0)
            {
                primes.Add(2);
                n--;
            }
            var lastprime = primes.Last();
            int nextPrime;
            if (lastprime == 2)
            {
                nextPrime = lastprime + 1;
            }
            else
            {
                nextPrime = lastprime + 2;
            }

            var initialCount = primes.Count;

            while (primes.Count < initialCount + n)
            {
                int sqrt = (int)System.Math.Sqrt(nextPrime);
                bool isPrime = true;
                for (int i = 0; (int)primes[i] <= sqrt; i++)
                {
                    if (nextPrime % primes[i] == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                {
                    primes.Add(nextPrime);
                }
                nextPrime += 2;
            }
            return primes;
        }

        public static void TestingStuff()
        {
            List<int> ints = new List<int>() { 1 };
            List<int> ints2 = new List<int>() { 99 };

            var ss = ints.GetHashCode();
            var ss2 = ints2.GetHashCode();
            ints = ints2;
            var ss3 = ints.GetHashCode();

            GeneratePrimesNaive2(ref ints, 100);
            GeneratePrimesNaive2(ref ints, 100);

            Cint ddx3 = (long)int.MaxValue;
            Cint dd = int.MaxValue;
            Cint ddx = int.MaxValue;
            Cint sssdgsd = int.MaxValue;
            Cint sss1 = Cint.MaxValue;
            Cint sss2 = Cint.MaxValue;

            if (sss1.IsEven == sss2.IsOdd)
            {
            }
            //string jsonString = JsonSerializer.Serialize(ints);

            //Debug.WriteLine(jsonString);
        }
    }
}