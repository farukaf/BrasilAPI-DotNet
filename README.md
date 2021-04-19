<h1 align="center"><img src="https://raw.githubusercontent.com/BrasilAPI/BrasilAPI/master/public/brasilapi-logo-small.png">Brasil API</h1>

<div align="center">
  <p>
    <strong>Vamos transformar o Brasil em uma API?</strong>
  </p>
</div>

## Atenção
Este é uma SDK/Client .Net para <a href="https://github.com/BrasilAPI/BrasilAPI" target="_blank">BrasilAPI</a>!

## Progress 
- [x] Criar acesso a todos os endpoints (disponiveis até então)
- [x] Implementar tratamento de erros
- [ ] Disponibilizar .dll via nuget 

## Como utilizar
Exemplo para receber a lista de cidades com DDD 17:
``` cs
using (var brasilAPI = new BrasilAPI())
{
  var response = await brasilAPI.DDD(17);
  foreach (var city in dddResponse.Cities)
  {
    Console.WriteLine(city);
  }
}
```

Exemplo de como tratar erros:
``` cs
//cnpj inválido
var cnpj = "00.000.000/0001-00";

try
{
  using (var brasilAPI = new BrasilAPI())
  {
    var response = await brasilAPI.CNPJ(cnpj);
  }
}
catch (BrasilAPIException ex)
{
  //Codigo HTTP de erro
  Console.WriteLine(ex.Code);
  //Mensagem de erro: CNPJ 00.000.000/0001-00 inválido.
  Console.WriteLine(ex.Message);
  //Conteudo recebido: {message:"CNPJ 00.000.000/0001-00 inválido."}
  Console.WriteLine(ex.ContentData);
  //URL gerada para a requisição
  Console.WriteLine(ex.URL);
} 
```


## Sobre a Biblioteca
- Utilizado .Net Standart 2.0 
- Requer Newtonsoft.Json 10.0.3+
- Pode ser utilizado a partir do seu sistema .Net Framework 4.6.1+, .Net Core 2.0+ ou Xamarin. Consulte a <a href="https://docs.microsoft.com/en-us/dotnet/standard/net-standard" target="_blank">documentação</a> oficial da Microsoft para mais informações.


