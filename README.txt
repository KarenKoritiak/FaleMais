***** SOBRE O PROJETO *****


O teste foi divido em dois projetos:

- FaleMais: 
	- Projeto ASP.Net MVC, que contém as funcionalidades exigidas no teste.
	- As principais bibliotecas padrão do ASP.Net MVC foram utilizas, mas outras 3 foram adicionadas:
		- Entity Framework, para acesso ao banco de dados SQL Server. As migrations foram habilitadas e utilizadas;
		- Twitter.Boostrap: para aplicação do layout;
		- log4net: para criação de log de erros em arquivo de texto;

- FaleMais.Tests: 
	- Contém os testes unitários do projeto FaleMais;
	- A biblioteca de testes utilizada foi a NUnit;




***** EXECUTANDO OS TESTES *****


- FaleMais.Testes: para executar os testes unitários, basta compilar esse projeto, carregar sua DLL na NUnit GUI e rodar os testes.


- FaleMais:
	- Instruções técnicas:
		- O Entity Framework tentará criar o banco de dados em uma instância local do SQL Server. Caso seja necessário, altere a connection string "DefaultConnection" no web.config;
		- No Package Manager Console, executar Update-Database, para que os migrations sejam rodados;
		- Instalar o site no IIS ou executar direto do Visual Studio;

	- Instruções para testes:
		- O site deverá ser carregado pela sua página de "Home", que funciona como uma página instituicional do FaleMais;
		- Através do menu, acesse a página "Tarifa", ~/tarifa;
		- Na opção padrão de busca, serão exibidos dois combos, um com os DDDs de origem e outro com os DDDs de destino;
		- Ao mudar o valor do DDD de origem, os valores do DDD de destino são recarregados, exibindo apenas os destinos disponíveis para aquela origem, conforme dados de tarifa cadastrados;
		- Existe a opção de pesquisa por cidade, acessada pelo menu lateral da página. Nesse caso, o usuário digita o nome de uma cidade, escolhe a cidade no "autocomplete", e o sistema carrega seu DDD. Isso vale tanto para a cidade de origem como de destino;
		- Ao calcular a tarifa, o sistema valida os valores. Caso algum valor não seja informado, exibe mensagens de erro;
		- Caso a tarifa da origem e destino não seja encontrada, o sistema exibe as tarifas com um "traço", "-". Essa condição só é possível na busca por cidades;
		- Caso os valores passem va validação, o sistema exibe a tarifa com e sem FaleMais;
		- Caso alguma página inexistente seja acessada, o sistema deverá redirecionar o usuário para a página ~/erro/paginanaoencontrada;
		- Caso ocorra algum erro durante a execução dos testes, o sistema deverá criar um novo registro no arquivo de log, ~/App_Data/FaleMais.log, e redirecionar o usuário para a página ~/erro;
		