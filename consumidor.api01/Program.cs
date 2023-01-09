using consumidor.api01;
using Flurl;
using Flurl.Http;

string url = "https://localhost:7146/";
#region"Objeto Tarefa"
Item tarefa1 = new Item();
tarefa1.Id = 1;
tarefa1.Nome = "Pagar boleto";
tarefa1.Finalizado = false;

Item tarefa2 = new Item();
tarefa2.Id = 2;
tarefa2.Nome = "Lavar o carro";
tarefa2.Finalizado = true;
#endregion

// Gerar uma tarefa
string endpoint = url + "api/TarefaItems";

#region"POST / GET"
Console.WriteLine("Inclusão");

// Flurl POST
await endpoint.PostJsonAsync(tarefa1);
await endpoint.PostJsonAsync(tarefa2);

// Ler a lista
IEnumerable<Item>  listaDeTarefas = await endpoint.GetJsonAsync<IEnumerable<Item>>();

foreach (var item in listaDeTarefas)
{
    Console.WriteLine($"A Tarefa: {item.Nome} está {item.Finalizado}");
}
#endregion

#region"PUT / GET"
Console.WriteLine("Alteração, digite o ID: ");
// Editar a tarefa
int id = Convert.ToInt32(Console.ReadLine());
string endpointPUT = url + $"api/TarefaItems/{id}";
Item tarefa3 = new Item();
tarefa3.Id = 1;
tarefa3.Nome = "Receber salário";
tarefa3.Finalizado = true;

await endpointPUT.PutJsonAsync(tarefa3);

// Ler a lista
listaDeTarefas = await endpoint.GetJsonAsync<IEnumerable<Item>>();

foreach (var item in listaDeTarefas)
{
    Console.WriteLine($"A Tarefa: {item.Nome} está {item.Finalizado}");
}
#endregion

#region"DELTE / GET"
Console.WriteLine("Deletado");
// Deletar uma tarefa
string endpointDELETE = url + $"api/TarefaItems/2";
await endpointDELETE.DeleteAsync();

// Ler a lista
listaDeTarefas = await endpoint.GetJsonAsync<IEnumerable<Item>>();

foreach (var item in listaDeTarefas)
{
    Console.WriteLine($"A Tarefa: {item.Nome} está {item.Finalizado}");
}
#endregion

Console.WriteLine("Aperte qualquer tecla para finalizar o programa");
Console.Read();