using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LumenCompiler
{
    class NestingType
    {
        public int PC = 0;
        public bool JMP = false;

        public NestingType(int PC, bool JMP)
        {
            this.PC = PC;
            this.JMP = JMP;
        }
    }
}
