namespace Treino.API.Requests;

public record TreinoRequest(string local, double distancia, DateTime data, TimeSpan tempo);
