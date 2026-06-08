using System;

namespace hospital.com.br
{
    class Paciente
    {
        public string Nome;
        public int Idade;
        public bool Preferencial;

        public override string ToString()
        {
            return Nome + ", " + Idade + " anos" + (Preferencial ? " (P)" : "");
        }
    }

    class Program
    {
        const int MAX = 100;
        static Paciente[] fila = new Paciente[MAX];
        static int n = 0; // quantidade de pacientes

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("1 - Cadastrar");
                Console.WriteLine("2 - Listar");
                Console.WriteLine("3 - Atender");
                Console.WriteLine("4 - Alterar");
                Console.WriteLine("q - Sair");
                Console.Write("Opção: ");
                string op = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(op)) continue;
                op = op.Trim().ToLower();
                if (op == "q") break;

                if (op == "1") Cadastrar();
                else if (op == "2") Listar();
                else if (op == "3") Atender();
                else if (op == "4") Alterar();
                else Console.WriteLine("Opção inválida.");
            }
        }

        static void Cadastrar()
        {
            if (n >= MAX)
            {
                Console.WriteLine("Fila cheia.");
                return;
            }

            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(nome)) { Console.WriteLine("Nome inválido."); return; }

            Console.Write("Idade: ");
            if (!int.TryParse(Console.ReadLine(), out int idade)) { Console.WriteLine("Idade inválida."); return; }

            Console.Write("Preferencial (s/n): ");
            string p = Console.ReadLine();
            bool pref = !string.IsNullOrWhiteSpace(p) && (p.Trim().ToLower().StartsWith("s"));

            Paciente pac = new Paciente { Nome = nome.Trim(), Idade = idade, Preferencial = pref };

            if (pref)
            {
                int i = 0;
                while (i < n && fila[i].Preferencial) i++;
                for (int j = n; j > i; j--) fila[j] = fila[j - 1];
                fila[i] = pac;
            }
            else
            {
                fila[n] = pac;
            }
            n++;
            Console.WriteLine("Cadastrado.");
        }

        static void Listar()
        {
            if (n == 0) { Console.WriteLine("Fila vazia."); return; }
            for (int i = 0; i < n; i++) Console.WriteLine((i + 1) + " - " + fila[i]);
        }

        static void Atender()
        {
            if (n == 0) { Console.WriteLine("Nada a atender."); return; }
            Console.WriteLine("Atendendo: " + fila[0]);
            for (int i = 1; i < n; i++) fila[i - 1] = fila[i];
            fila[n - 1] = null;
            n--;
        }

        static void Alterar()
        {
            if (n == 0) { Console.WriteLine("Fila vazia."); return; }
            Listar();
            Console.Write("Número a alterar: ");
            if (!int.TryParse(Console.ReadLine(), out int num) || num < 1 || num > n) { Console.WriteLine("Número inválido."); return; }
            int idx = num - 1;
            Paciente pac = fila[idx];
            Console.Write("Nome (" + pac.Nome + "): ");
            string nome = Console.ReadLine(); if (!string.IsNullOrWhiteSpace(nome)) pac.Nome = nome.Trim();
            Console.Write("Idade (" + pac.Idade + "): ");
            string idStr = Console.ReadLine(); if (int.TryParse(idStr, out int idNova)) pac.Idade = idNova;
            Console.Write("Preferencial (s/n) (" + (pac.Preferencial ? "s" : "n") + "): ");
            string pref = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(pref))
            {
                bool novoPref = pref.Trim().ToLower().StartsWith("s");
                if (novoPref != pac.Preferencial)
                {
                    // remover da posição atual
                    for (int i = idx + 1; i < n; i++) fila[i - 1] = fila[i];
                    fila[n - 1] = null;
                    n--;
                    pac.Preferencial = novoPref;
                    // reinserir conforme prioridade
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
            }
            Console.WriteLine("Alterado.");
        }
    }
}
