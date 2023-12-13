# Tarefa.Api
## Descrição
Consiste em uma API capaz de realizar crud em RESTful. 
Pode ser util como base de estudo para utilização do Mediatr juntamente com o FluentValidation.

## Objetivo
Cadastrar Tarefas e alterar suas descrições enquanto as atividades estiverem com o status de não completadas, podendo obter todas as tarefas em uma listagem ou também uma tarefa específica  com a utilização do seu Id. 

## Banco de Dados e Instalação
Essa api utiliza o EntityFramework.SQLite ao executar a aplicação a mesma criará o banco de dados e executarar o migration para relizar a criação/atualização das entidades incluídas nesse projeto.

## Utilizando a API 
através dos endpoints 

Tasks/RegisterTask/registar-tarefa ( POST )
atualizar-tarefa ( PUT ) 
deletar-tarefa ( DELETE )
obter-tarefa-por-id ( GET ) 
obter-todas-tarefas ( GET )

podemos executar os métodos, para mais informações sobre os models utilizados nas requisições consulte o swagger da aplicação.
