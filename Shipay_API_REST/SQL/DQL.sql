USE Shipay

--2. Ainda utilizando a estrutura de dados address_state, address_city e buyers, escreva uma consulta SQL que irá trazer as seguintes informações: Nome completo, email, endereço contendo o nome da cidade e a sigla/unidade federativa do estado do comprador/buyer.
SELECT CONCAT(first_name, ' ', last_name) as "full name", email, "address",uf, address_states.name as "state name" FROM buyers
INNER JOIN address_cities ON address_cities.id = buyers.address_city_id
INNER JOIN address_states ON address_states.id = address_cities.address_state_id 

SELECT * FROM address_states;
SELECT * FROM address_cities;
SELECT * FROM buyers;