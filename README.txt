***** SOBRE O PROJETO *****


O teste foi divido em dois projetos:

- FaleMais: 
	- Projeto ASP.Net MVC, que cont�m as funcionalidades exigidas no teste.
	- As principais bibliotecas padr�o do ASP.Net MVC foram utilizas, mas outras 3 foram adicionadas:
		- Entity Framework, para acesso ao banco de dados SQL Server. As migrations foram habilitadas e utilizadas;
		- Twitter.Boostrap: para aplica��o do layout;
		- log4net: para cria��o de log de erros em arquivo de texto;

- FaleMais.Tests: 
	- Cont�m os testes unit�rios do projeto FaleMais;
	- A biblioteca de testes utilizada foi a NUnit;




***** EXECUTANDO OS TESTES *****


- FaleMais.Testes: para executar os testes unit�rios, basta compilar esse projeto, carregar sua DLL na NUnit GUI e rodar os testes.


- FaleMais:
	- Instru��es t�cnicas:
		- O Entity Framework tentar� criar o banco de dados em uma inst�ncia local do SQL Server. Caso seja necess�rio, altere a connection string "DefaultConnection" no web.config;
		- No Package Manager Console, executar Update-Database, para que os migrations sejam rodados;
		- Instalar o site no IIS ou executar direto do Visual Studio;

	- Instru��es para testes:
		- O site dever� ser carregado pela sua p�gina de "Home", que funciona como uma p�gina instituicional do FaleMais;
		- Atrav�s do menu, acesse a p�gina "Tarifa", ~/tarifa;
		- Na op��o padr�o de busca, ser�o exibidos dois combos, um com os DDDs de origem e outro com os DDDs de destino;
		- Ao mudar o valor do DDD de origem, os valores do DDD de destino s�o recarregados, exibindo apenas os destinos dispon�veis para aquela origem, conforme dados de tarifa cadastrados;
		- Existe a op��o de pesquisa por cidade, acessada pelo menu lateral da p�gina. Nesse caso, o usu�rio digita o nome de uma cidade, escolhe a cidade no "autocomplete", e o sistema carrega seu DDD. Isso vale tanto para a cidade de origem como de destino;
		- Ao calcular a tarifa, o sistema valida os valores. Caso algum valor n�o seja informado, exibe mensagens de erro;
		- Caso a tarifa da origem e destino n�o seja encontrada, o sistema exibe as tarifas com um "tra�o", "-". Essa condi��o s� � poss�vel na busca por cidades;
		- Caso os valores passem va valida��o, o sistema exibe a tarifa com e sem FaleMais;
		- Caso alguma p�gina inexistente seja acessada, o sistema dever� redirecionar o usu�rio para a p�gina ~/erro/paginanaoencontrada;
		- Caso ocorra algum erro durante a execu��o dos testes, o sistema dever� criar um novo registro no arquivo de log, ~/App_Data/FaleMais.log, e redirecionar o usu�rio para a p�gina ~/erro;
		