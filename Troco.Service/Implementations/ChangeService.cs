using System.Collections.Generic;
using Troco.Domain.Models;
using Troco.Domain.Utils;
using Troco.Service.Abstractions;

namespace Troco.Service.Implementations
{
    /*
     Serviço responsável por realizar todo o cálculo de troco
     */
    public class ChangeService : IChangeService
    {
        private double remainingChange;

        /*
        * Recupera valores informados pelo usu�rio e inicia c�lculo do troco
        */
        public void calculateChange(Change change) {

            change.ChangeToReturn = new List<ChangeToReturn>();

            remainingChange = change.PaidValue - change.TotalValue;

            checkCurrentCashQuantity(remainingChange, change, CashTypes.HUNDRED);

        }

        /*
        * Verifica a quantidade de c�dulas / moedas necess�rias para realizar o troco,
        * priorizando as de maior valor
        */
        private void checkCurrentCashQuantity(double currentRemainingChange, Change change, double currentCash) {

            if (currentRemainingChange == 0 || currentRemainingChange == 0.0 || currentCash == 0.0) {
                return;
            }

            // verifica quantas notas atuais servem como troco para o valor restante de
            // troco
            int currentCashQuantity = (int) (currentRemainingChange / currentCash);

            // calcula o restante de troco
            currentRemainingChange = currentRemainingChange % currentCash;

            change.ChangeToReturn.Add(new ChangeToReturn(currentCashQuantity, currentCash));

            currentCash = updateChange(currentCashQuantity, change, currentCash);

            checkCurrentCashQuantity(currentRemainingChange, change, currentCash);
        }

        /*
        * Atualiza a próxima moeda a ser calculada
        */
        private double updateChange(int temporaryQuantity, Change change, double currentCash) {
            double temp = 0.0;
            
            switch (currentCash)
            {
                case CashTypes.HUNDRED:
                    temp = CashTypes.FIFTY;
                    break;
                case CashTypes.FIFTY:
                    temp = CashTypes.TEN;
                    break;
                case CashTypes.TEN:
                    temp = CashTypes.FIVE;
                    break;
                case CashTypes.FIVE:
                    temp = CashTypes.ONE;
                    break;
                case CashTypes.ONE:
                    temp = CashTypes.FIFTY_CENTS;
                    break;
                case CashTypes.FIFTY_CENTS:
                    temp = CashTypes.TEN_CENTS;
                    break;
                case CashTypes.TEN_CENTS:
                    temp = CashTypes.FIVE_CENTS;
                    break;
                case CashTypes.FIVE_CENTS:
                    temp = CashTypes.ONE_CENT;
                    break;
            }
            return temp;
        }
    }
}