<h1 align="center"><img src="https://raw.githubusercontent.com/BrasilAPI/BrasilAPI/master/public/brasilapi-logo-small.png">Brasil API</h1>

<div align="center">
  <p>
    <strong>Vamos transformar o Brasil em uma API?</strong>
  </p>
</div>

# Atenção
Este é um SDK/Client .Net para <a href="https://github.com/BrasilAPI/BrasilAPI" target="_blank">BrasilAPI</a>!

## Como utilizar
* NuGet disponível: https://www.nuget.org/packages/BrasilAPI [![NuGet](https://img.shields.io/nuget/v/BrasilAPI.svg)](https://www.nuget.org/packages/BrasilAPI/)


## Utilização com injeção de dependencia

Realizar a injeção na sua camada de service. 
ConfigureServices na classe Startup.cs ou Program.cs como abaixo.

Exemplo da implementação no Program.cs
``` cs
using SDKBrasilAPI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddBrasilApi();
``` 

Utilização em um endpoint minimal API
``` cs
app.MapGet("/ParticipantesPIX", async (IBrasilAPI brasilAPI) =>
{ 
    return await brasilAPI.ParticipantesPIX();
});
``` 

Utilização em uma controller MVC
``` cs 
[ApiVersion("2")]
[Route("v{version:apiVersion}/[controller]")]
public class ServiceController : ControllerBase
{ 
	private readonly IBrasilAPI _brasilAPI;

	public ServiceController(IBrasilAPI brasilAPI)
	{
		_brasilAPI = brasilAPI; 
	}
}
```
 
 
## Utilização sem injeção de dependencia (não recomendado)

``` cs
using SDKBrasilAPI;
``` 

Exemplo para receber a lista de cidades com DDD 17:
``` cs
using (var brasilAPI = new BrasilAPI())
{
  var response = await brasilAPI.DDD(17);
  foreach (var city in response.Cities)
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

Pode ser utilizado a partir do seu sistema .Net Framework 4.6.1+, .Net Core 2.0+ ou Xamarin. Consulte a <a href="https://docs.microsoft.com/en-us/dotnet/standard/net-standard" target="_blank">documentação</a> oficial da Microsoft para mais informações.


