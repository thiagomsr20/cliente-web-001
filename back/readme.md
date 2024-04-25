API feita com ASP.NET

Verificar Design System em './design/system/system.pdf'

Serviços que a API deve possuir:
obs: não haverá login de usuário.
obs: Usar cookies, para fazer com q o usuário n logue, mas possa acessar compras antigas ou não precisar inserir dados de cliente ou localização, usar o Permanent cookie

A API deverá poder fazer o seguinte:

1. Retornar todos os produtos, colocando em prioridade itens que estejam em promoção, e itens novos também.
2. Retornar itens filtrados com base em: categoria (calça, acessório, camistea, etc...), cor, tamanho, range de preço, pois o cliente pode filtrar busca por itens, ou seja, quando for preenchido o formulário, e o cliente clicar em filtrar, deverá se
3. Cadastro de novos produtos (requer autenticação e endpoint secreto com acesso ao login de admin para cadastro de novos produtos)

exemplo, ordem de compra:
{
    "ordemcompra": {

        "userinfo": {
            "cliente": {
                "id": 1
                "nome": "Thiago Maciel Soares",
                "CPF": "345.345.345-45",
                "Email": "testeweb@gmail.com",
            },

            "endereço": {
                "id": 1,
                "CEP": "56745-958",
                "Rua": "Rua teste 4560",
                "Complemento": "Casa"
                "Bairro": "Esplanada"
            }
        }

        "carrinho": {
            "id": 1,
            "preçototal": 70.00,
            "quantidadetotal": 5,

            "produto":{
                "id": 5348,
                "nome": "calça cargo",
                "preçounitario": 20.00,
                "quantidade": 2
            },
            "produto":{
                "id":8948,
                "nome": "camiseta nike",
                "preçounitario": 10.00,
                "quantidade": 3
            },
        }
    }
}