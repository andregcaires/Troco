using Troco.Domain.Models;

namespace Troco.Service.Abstractions
{
    /*
     Interface utilizada para abstrair ChangeCervice para Inje��o de Depend�ncia
     e aplica conteitos de Fa�ade acessando o subsistema do c�lculo de troco*/
    public interface IChangeService
    {
        void calculateChange(Change change);
    }
}