# API : Gerenciamento de Livros

#### Objetivo:

- Criar uma API para buscar produtos no arquivo JSON disponibilizado.
- Que seja possível buscar livros por suas especificações(autor, nome do livro ou outro atributo)
- É preciso que o resultado possa ser ordenado pelo preço.(asc e desc)
- Disponibilizar um método que calcule o valor do frete em 20% o valor do livro.

#### Como utilizar?
Basta fazer uma requisição GET para o link base https://localhost:5001/api/v1/ (caso precise, trocar localhost pelo nome do site ou ip). Caso tenha colocado corretamente os parametros válidos, a api retornará um JSON.

#### Métodos disponíveis

```sh
https://localhost:5001/api/v1/ : Retorna todos os livros
```
```sh
https://localhost:5001/api/v1/id/{id} : Retorna livro com base no id(inteiro).
```
```sh

https://localhost:5001/api/v1/name/{name} : Retorna livro que corresponde ao nome.
```
```sh
https://localhost:5001/api/v1/author/{author} : Retorna livros que contém nome do author.
```
```sh
https://localhost:5001/api/v1/genres/{genres} : Retorna livros que contém gêneros iguais. (existe bugs)
```
```sh
https://localhost:5001/api/v1/shipping/{id} : Retorna o valor do frete.
```
```sh
https://localhost:5001/api/v1/asc/ : Retorna todos os livros ordenados pelo preço ascendente.
```
```sh
https://localhost:5001/api/v1/asc/{preço} : Retorna todos os livros com preços acima do inserido.
```
```sh
https://localhost:5001/api/v1/desc/ : Retorna todos os livros ordenados pelo preço descendente.
```
```sh
https://localhost:5001/api/v1/desc/{preço} : Retorna todos os livros com preços abaixo do inserido.
```
```sh
https://localhost:5001/api/v1/page/{int} : Retorna todos os livros com números de páginas maior ou igual int.
```


- {id} = inteiro

### Múltiplos métodos
Para fazer uma pesquisa Customizada com mais de um método basta usar o link base https://localhost:5001/api/v1/filter.

```sh
    https://localhost:5001/api/v1/filter?author=J. K. Rowling&desc=true
```


## Como executar
 - É preciso ter instalado na máquina .net core 5
 - Faça um clone do repositório
 - Abra o terminal e navegue até a pasta api
 
```sh
    $ cd pastaRepositorio/api/
    $ dotnet run
```

 - Se tudo correu bem o servidor estará online e api funcionando.

### Desenvolvedor

 - Luan Vilela Lopes