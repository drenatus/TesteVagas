# TesteVagas

Como rodar:


1 - Instalar o sdk .net https://www.microsoft.com/net/download/thank-you/dotnet-sdk-2.1.401-windows-x64-installer

2 - (Somente em Windows) Após instalar o sdk, acessar o diretório do mesmo, mover ou excluir as pastas de linguagem devido a um bug em instalações windows com outras linguagens que não seja o Inglês (geralmente fica em C:\Program Files\dotnet\sdk\2.1.401 (todas as pastas de linguagem sem exceção (cs, de, en, pt-br, zh-Hans, zh-Hant, etc.) 

3 - Instalar o Visual Studio Code - https://code.visualstudio.com/

4 - Após instalar o Visual Studio Code, acessar o ícone "Extensions" e instalar as seguintes extensões: "C#", ".NET Core Test Explorer" (para ver os testes listados) e "NuGet Package Manager".     

5 - Clonar o repositorio.  

6 - Antes de "Montar" o projeto do repositório, configurar nas variáveis do ambiente o caminho do drive do google chrome (No Windows, acessar Propriedades do Sistema, Variáveis de Ambiente. Adicionar o caminho XXX:\TesteVagas\bin\Debug\netcoreapp2.1 em "Path" nas variáveis de ambiente para os usuários e para o sistema (Path, Editar, Novo, colar o caminho completo, OK.))

7 - Ao acessar o VSCode, Abrir a pasta do projeto (Teste Vagas). No terminal, digitar "dotnet build" e o projeto vai ser montado. 

8 - Algumas vezes o VS Code não some com os erros sozinho. Basta fechar e abrir de novo caso nao  tenha dado nenhum erro no console. 

9 - Acessar o ícone "Test" na parte esquerda do VSCode (um ícone parecendo um tubo de ensaio). Os testes vão ser listados. Basta dar um play e avaliar o resultado.       