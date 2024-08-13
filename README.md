# Sistema para realizar pedidos via APP/site

Este é um projeto de backend implementado em C# que oferece um Sistema para relizar pedidos.

# Configuração do Ambiente de Desenvolvimento
- Certifique-se de ter o .NET Core SDK instalado na sua máquina.

- Abra o projeto no Visual Studio no Console Gerenciado de Pacotes e executar os seguintes comandos; 
#
Execute o seguinte comando para compilar o projeto, isso deve instalar todas as dependências necessárias:
```bash
dotnet build
```
#
Execute o seguinte comando para remover arquivos temporários e binários:
```bash
dotnet clean
```
Após o procedimento poderá executar a API no topo do ambiente do Visual Studio
#
Para seu conhecimento: Como se trata de uma api em um banco "in memory" será necessario usar o valores da lista abaixo para poder criar um pedido, segue os parametro e uma breve descrição.

O parametro **{productCode}** ele indica o produto que será adcionado ao pedio, e **{quantidade}** será a quantidade desejada do produto.Sabendo dessa informações também há regras, tais como, cada pedido não poder conter mais de um  item da mesma categoria **{sanduíche}**, **{batata_frita}**, **{refrigerante}**. Se forem enviados dois itens da mesma categoria será exibindo uma mesnagem de erro.

Abaixo segue o codigo dos produtos:


| productCode |Descrição |Categoria|
| :- |:----------|:-------|
| `1`| X-Burger  |sanduíche
| `2`| X-Egg     |sanduíche
| `3`| X-Bacon   |sanduíche
| `4`| Batata Frita  |batata_frita
| `5`| Refrigerante  |refrigerante

Valores informando acima também podem ser obtidos através da API/PRODUTOS.
