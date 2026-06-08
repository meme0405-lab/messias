# Fila de Pacientes (Vetor) - hospital.com.br

Exercício: controle de fila de pacientes de um hospital usando apenas um vetor (array).

Funcionalidades:
- Cadastrar paciente (pacientes preferenciais são colocados antes dos não preferenciais)
- Listar pacientes na fila
- Atender próximo paciente (remove o primeiro da fila)
- Alterar dados cadastrais de um paciente
- Digitar 'q' no menu para sair

Como executar:
1. Abra a pasta `ConsoleApp3` no Visual Studio (projeto .NET Framework 4.7.2). Se desejar, renomeie o namespace para `hospital.com.br` no arquivo Program.cs.
2. Compile e execute (F5 ou Ctrl+F5).
3. Use o menu para testar as funcionalidades.

Observações técnicas:
- A fila é mantida em um único vetor (array) de capacidade fixa (100).
- Ao inserir um paciente preferencial, o programa insere antes do primeiro não preferencial existente.
- Ao alterar a preferência de um paciente, ele é removido da posição atual e reinserido conforme a prioridade.

Autor: Seu Nome

(Instruções para subir no GitHub: criar repositório remoto e dar push. Não foi feito push remoto automaticamente.)
