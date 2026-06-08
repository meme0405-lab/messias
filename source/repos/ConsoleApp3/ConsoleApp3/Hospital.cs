using System;

namespace hospital.com.br
{
    public class Hospital
    {
        const int MAX = 100;
        private Paciente[] fila = new Paciente[MAX];
        private int n = 0;

        public bool EstaVazio => n == 0;

        public void Cadastrar(Paciente pac)
        {
            if (n >= MAX) throw new InvalidOperationException("Fila cheia");
            if (pac.Preferencial)
            {
                int i = 0; while (i < n && fila[i].Preferencial) i++;
                for (int j = n; j > i; j--) fila[j] = fila[j - 1];
                fila[i] = pac;
            }
            else
            {
                fila[n] = pac;
            }
            n++;
        }

        public Paciente Atender()
        {
            if (n == 0) return null;
            var pac = fila[0];
            for (int i = 1; i < n; i++) fila[i - 1] = fila[i];
            fila[n - 1] = null;
            n--;
            return pac;
        }

        public Paciente[] Listar()
        {
            Paciente[] res = new Paciente[n];
            for (int i = 0; i < n; i++) res[i] = fila[i];
            return res;
        }

        public void Alterar(int pos, string novoNome, int? novaIdade, bool? novaPref)
        {
            if (pos < 0 || pos >= n) throw new ArgumentOutOfRangeException(nameof(pos));
            var pac = fila[pos];
            if (!string.IsNullOrWhiteSpace(novoNome)) pac.Nome = novoNome.Trim();
            if (novaIdade.HasValue) pac.Idade = novaIdade.Value;
            if (novaPref.HasValue && novaPref.Value != pac.Preferencial)
            {
                // remove e reinsera conforme prioridade
                for (int i = pos + 1; i < n; i++) fila[i - 1] = fila[i];
                fila[n - 1] = null; n--;
                pac.Preferencial = novaPref.Value;
                Cadastrar(pac);
            }
        }
    }
}
