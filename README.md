
# GestorConfiguracao Developed By Marcelo do Nascimento ®
Aplicação de teste OAuth
Foram realizados os itens de 1 até 5, devido a uma falha no computador não foi possível realizar a app em Ionic3

- 1. A Aplicação, chamada de Gerenciador De Configuracao,  deverá utilizar as seguintes tecnologias: C#, ASP.NET WebApi, Angular, Microsoft SQL Server, OAUTH
 -2.O Gerenciador De Configuracao deverá ser capaz de armazenar configurações para uma aplicação web, denominada Aplicação Cliente.		 +2. O Gerenciador De Configuracao deverá ser capaz de armazenar configurações para uma aplicação web, denominada Aplicação Cliente.
 -3.As configurações poderão ser editadas por usuários com acesso ao Gerenciador De Configuracao.		 +3. As configurações poderão ser editadas por usuários com acesso ao Gerenciador De Configuracao.
 -4.Deverá existir uma forma de configurar os usuários que tem permissão para acessar o Gerenciador De Configuracao.		 +4. Deverá existir uma forma de configurar os usuários que tem permissão para acessar o Gerenciador De Configuracao.
 -5.A Aplicação cliente deverá ser capaz de consumir as configurações armazenadas utilizando chamadas à API do Gerenciador De Configuracao.		 +5. A Aplicação cliente deverá ser capaz de consumir as configurações armazenadas utilizando chamadas à API do Gerenciador De Configuracao.
 -6.Como bônus, seria interessante o desenvolvimento de um front end mobile, utilizando o framework IONIC 3, para gerenciamento das configurações.		 +6. Como bônus, seria interessante o desenvolvimento de um front end mobile, utilizando o framework IONIC 3, para gerenciamento das configurações.


Orientações de implantação do software:
 Passo 1:
 Executar os script.sql na pasta raiz da solução em um sqlserver 2016 ou 2017
 Passo 2:
 verificar a conection string usuário e senha do seu banco seu conferem com os dados presentes no webconfig.xml
 Passo 3:
 Realizar os Insert abaixo na table Perfil:
 Ex.: 
 INSERT INTO [Perfil](nome) VALUES('Admin');
 INSERT INTO [Perfil](nome) VALUES('Consultor');
 Passo 4:
 Criar um usuário Perfil 'Admin' passando o id do perfil 'Admin' gerado pela PK no passo 3, para acesso ao sistema na table de usuários:
 Ex.: INSERT Usuarios into ('Godofredo','Godo',1,'123')
 Passo 6:
 Realizar o login no sistema com o usuário e senha cadastrados e incluir os usuários e configurações desejados, lembrando que somente usuários Admin, poderão
 configurar novos usuários.

Obs.: Caso haja interesse na Aplicação de bonus e ainda seja possível mais alguns dias de prazo, estarei as ordens.
 