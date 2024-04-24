API feita com ASP.NET

Verificar Design System em './design/system/system.pdf'

Serviços que a API deve possuir:
obs: não haverá login de usuário.
obs: Usar cookies, para fazer com q o usuário n logue, mas possa acessar compras antigas ou não precisar inserir dados de cliente ou localização, usar o Permanent cookie

1. get: produtos cadastrados
2. permanência dos dados do cliente e do seu endereço (via cookies)
3. post: ordem de compra

endpoints (exemplo):

Filta retorno por categoria
https://mensstore/produtos/category

Registra ordem de compra e manda por WhatsApp
https://mensstore/ordemdecompra

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