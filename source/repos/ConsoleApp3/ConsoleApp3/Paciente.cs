using System;

namespace hospital.com.br
{
    public class Paciente
    {
        public string Nome;
        public int Idade;
        public bool Preferencial;

        public override string ToString()
        {
            return Nome + ", " + Idade + " anos" + (Preferencial ? " (P)" : "");
        }
    }
}
