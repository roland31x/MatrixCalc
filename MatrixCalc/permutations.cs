using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixCalc
{
    public struct PermutationSet
    {
        public int[] Series { get; set; }

        public List<Permutation> Totals { get; set; }

        public PermutationSet(int n)
        {
            Totals = new List<Permutation>();
            Series = new int[n + 1];
            for (int i = 1; i <= n; i++)
            {
                Series[i] = i;
            }
            new Permutation(this);
        }
    }
    public struct Permutation
    {
        public int[] Permuted { get; set; }

        public int Sign { get; set; }

        public Permutation(PermutationSet ps)
        {
            int n = ps.Series.Length - 1;
            Sign = 0;
            Permuted = new int[n + 1];
            this.Back(1, ps);
        }
        private Permutation(int[] perms, int sign)
        {
            Permuted = new int[perms.Length];
            for (int i = 0; i < Permuted.Length; i++)
            {
                Permuted[i] = perms[i];
            }
            Sign = sign;
        }
        private void Back(int k, PermutationSet ps1)
        {
            for (int i = 1; i < Permuted.Length; i++)
            {
                this.Permuted[k] = i;
                if (Ok(k))
                {
                    if (k + 1 == Permuted.Length)
                    {
                        Sign = getSign(this);
                        ps1.Totals.Add(new Permutation(this.Permuted, this.Sign));
                    }
                    else
                    {
                        Back(k + 1, ps1);
                    }
                }
            }
        }
        private bool Ok(int k)
        {
            for (int i = 0; i < k; i++)
            {
                if (this.Permuted[i] == this.Permuted[k])
                {
                    return false;
                }
            }
            return true;
        }
        private int getSign(Permutation p)
        {
            int sign = 0;
            for (int i = 1; i < p.Permuted.Length; i++)
            {
                for (int j = i + 1; j < p.Permuted.Length; j++)
                {
                    if (p.Permuted[i] > p.Permuted[j])
                    {
                        sign++;
                    }
                }
            }
            return sign;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 1; i < Permuted.Length; i++)
            {
                sb.Append(this.Permuted[i].ToString() + " ");
            }
            return sb.ToString();
        }
    }
}
