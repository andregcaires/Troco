using Troco.Domain.Models;

namespace Troco.Service.Abstractions
{
    /*
     Interface utilizada para abstrair ChangeCervice para Injeção de Dependência
     e aplica conteitos de Façade acessando o subsistema do cálculo de troco*/
    public interface IChangeService
    {
        void calculateChange(Change change);
    }
}