
# GestorConfiguracao 
#Developed By Marcelo do Nascimento ®
Aplicação de teste OAuth
Foram realizados os itens de 1 até 5, devido a uma falha no computador não foi possível realizar a app em Ionic3

 ## Orientações de implantação do software:
 <p>Passo 1:
 Executar os script.sql na pasta raiz da solução em um sqlserver 2016 ou 2017</p>
 <p> Passo 2:
 verificar a conection string usuário e senha do seu banco seu conferem com os dados presentes no webconfig.xml</p>
  <p>Passo 3:
 Realizar os Insert abaixo na table Perfil:</p>
  <p>Ex.: 
 INSERT INTO [Perfil](nome) VALUES('Admin');</p>
 <p> INSERT INTO [Perfil](nome) VALUES('Consultor');</p>
 <p> Passo 4:
 Criar um usuário Perfil 'Admin' passando o id do perfil 'Admin' gerado pela PK no passo 3, para acesso ao sistema na table de usuários:</p>
 <p> Ex.: INSERT Usuarios into ('Godofredo','Godo',1,'123')</p>
  <p>Passo 6:
  Realizar o login no sistema com o usuário e senha cadastrados e incluir os usuários e configurações desejados, lembrando que somente  <p>usuários Admin, poderão</p>
 
