using System;

namespace hospital.com.br
{
    class Program
    {
        static Hospital hospital = new Hospital();

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
            try
            {
                Console.Write("Nome: ");
                string nome = Console.ReadLine(); if (string.IsNullOrWhiteSpace(nome)) { Console.WriteLine("Nome inválido."); return; }
                Console.Write("Idade: "); if (!int.TryParse(Console.ReadLine(), out int idade)) { Console.WriteLine("Idade inválida."); return; }
                Console.Write("Preferencial (s/n): "); string p = Console.ReadLine(); bool pref = !string.IsNullOrWhiteSpace(p) && p.Trim().ToLower().StartsWith("s");
                var pac = new Paciente { Nome = nome.Trim(), Idade = idade, Preferencial = pref };
                hospital.Cadastrar(pac);
                Console.WriteLine("Cadastrado.");
            }
            catch (Exception ex) { Console.WriteLine("Erro: " + ex.Message); }
        }

        static void Listar()
        {
            var arr = hospital.Listar();
            if (arr.Length == 0) { Console.WriteLine("Fila vazia."); return; }
            for (int i = 0; i < arr.Length; i++) Console.WriteLine((i + 1) + " - " + arr[i]);
        }

        static void Atender()
        {
            var pac = hospital.Atender();
            if (pac == null) Console.WriteLine("Nada a atender."); else Console.WriteLine("Atendendo: " + pac);
        }

        static void Alterar()
        {
            var arr = hospital.Listar(); if (arr.Length == 0) { Console.WriteLine("Fila vazia."); return; }
            for (int i = 0; i < arr.Length; i++) Console.WriteLine((i + 1) + " - " + arr[i]);
            Console.Write("Número a alterar: "); if (!int.TryParse(Console.ReadLine(), out int num) || num < 1 || num > arr.Length) { Console.WriteLine("Número inválido."); return; }
            int idx = num - 1;
            Console.Write("Nome (" + arr[idx].Nome + "): "); string nome = Console.ReadLine();
            Console.Write("Idade (" + arr[idx].Idade + "): "); string idStr = Console.ReadLine(); int? idade = null; if (int.TryParse(idStr, out int idNova)) idade = idNova;
            Console.Write("Preferencial (s/n) (" + (arr[idx].Preferencial ? "s" : "n") + "): "); string pref = Console.ReadLine(); bool? novoPref = null; if (!string.IsNullOrWhiteSpace(pref)) novoPref = pref.Trim().ToLower().StartsWith("s");
            try { hospital.Alterar(idx, nome, idade, novoPref); Console.WriteLine("Alterado."); } catch (Exception ex) { Console.WriteLine("Erro: " + ex.Message); }
        }
    }
}
