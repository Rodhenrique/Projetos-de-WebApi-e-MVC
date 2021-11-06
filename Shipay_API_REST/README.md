## Documentação da API Shipay

- **API**
	-  folder/Controllers
	-   folder/Repositories
	-   folder/Models
    -   server.py
  
 - **SQL**
	 -  DDL
	-   DML
	-   DQL

### Controllers

Responsável pelo contato entre usuário e micro-serviços, nessa pasta contém três controllers(**addressCityController**, **addressStatesController** e **buyersController**) cada um representa um repository.

### Repositories

Responsável pela comunicação entre banco de dados e controller ele oferece um **CRUD** completo e contém três repositories(**addressCityRepository**,**addressStatesRepository** e **buyersRepository**) que fornece acesso ao banco de dados através de micro-serviços.

### Models

Estabelece um relacionamento de entidade com banco de dados, facilitando o processamento de dados através dos models que contém três classes (**addressCities, addressStates e buyers**).  

### Server.py

Responsável por subir a aplicação no **localhost porta 5000** ele usa **flask** para subir essa aplicação web.

### SQL

-   **DDL**: Arquivo onde fica o script de criação do banco de dados.
    
-   **DML**: Arquivo responsável pela manipulação de dados para popular o banco de dados.
    
-   **DQL**: Arquivo onde contém script para fazer busca no banco de dados.
    

### Introdução

Para começar usar API você precisa alterar **string de conexão** que fica no arquivo **server.py** como padrão ela está definida como **localhost porta 1433**

Para rodar a aplicação você vai no CMD digitar **python server.py** no diretório do arquivo **server.py**.

### Bibliotecas usada:
-   flask
-   flask_sqlalchemy
-   sqlalchemy

### CRUD:
-   **addressStates URLs do endpoints**.

	```shell
			{
				"id": 1,
				"name": "São Paulo",
				"uf": "SP",
			}
	```


> Get: localhost:5000/addressStates
Return: Status code 200 e uma lista de address states.
Failed: status code 400 e uma mensagem de falha.

> GetById: localhost:5000/addressStates/id - tipo int
Return: Status code 200 e um objeto address states.
Failed: status code 400 e uma mensagem de falha.

  

> Post: localhost:5000/addressStates - body usado conforme a imagem acima.
Return: Status code 201 e uma mensagem que foi um sucesso.
Failed: status code 400 e uma mensagem de falha.  

>Put: localhost:5000/addressStates/id - tipo int e o body usado conforme a imagem acima.
Return: Status code 200 uma mensagem que foi um sucesso.
Failed: status code 400 e uma mensagem de falha.

  
> Delete: localhost:5000/addressStates/id - tipo int
Return: Status code 200 e uma lista de address states.
Failed: status code 400 e uma mensagem de falha.

-   **addressCities URLs do endpoints**.

	```shell
		{
			"id": 1,
			"name": "São Roque",
			"address_state_id": 2,
		}
	```
> Get: localhost:5000/addressCities
Return: Status code 200 e uma lista de address cities.
Failed: status code 400 e uma mensagem de falha.

> GetById: localhost:5000/addressCities/id - tipo int
Return: Status code 200 e um objeto address cities.
Failed: status code 400 e uma mensagem de falha.

> Post: localhost:5000/addressCities - body usado conforme a imagem acima.
Return: Status code 201 e uma mensagem que foi um sucesso.
Failed: status code 400 e uma mensagem de falha.

> Put: localhost:5000/addressCities/id - tipo int e o body usado conforme a imagem acima
Return: Status code 200 uma mensagem que foi um sucesso.
Failed: status code 400 e uma mensagem de falha.
  
> Delete: localhost:5000/addressCities/id - tipo int
Return: Status code 200 e uma lista de address states.
Failed: status code 400 e uma mensagem de falha.

-   **buyers URLs do endpoints**.

	```shell
	{
		"id": 1,
		"created_at": "2010-10-23 10:19:37.0000000",
		"updated_at": "2021-01-23 10:11:37.0000000",
		"first_name": "Marcos",
		"last_name": "Aurelio",
		"document": "32838232",
		"email": "marcos.aurelio@email.com",
		"phone": "112324343",
		"address": "Rua Carnalia 123",
		"address_city_id": 1
	}
	```
> Get: localhost:5000/buyers
Return: Status code 200 e uma lista de address cities.
Failed: status code 400 e uma mensagem de falha.

> GetById: localhost:5000/buyers/id - tipo int
Return: Status code 200 e um objeto address cities.
Failed: status code 400 e uma mensagem de falha.

> Post: localhost:5000/buyers - body usado conforme a imagem acima .
Return: Status code 201 e uma mensagem que foi um sucesso.
Failed: status code 400 e uma mensagem de falha.

> Put: localhost:5000/buyers/id - tipo int e o body usado conforme a imagem acima
Return: Status code 200 uma mensagem que foi um sucesso.
Failed: status code 400 e uma mensagem de falha.

  
  

> Delete: localhost:5000/buyers/id - tipo int
Return: Status code 200 e uma lista de address states.
Failed: status code 400 e uma mensagem de falha.