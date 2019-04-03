namespace Troco.Domain.Models
{
    /*
     Armazena quantidade e valor das notas e moedas para troco
     */
    public class ChangeToReturn
    {
        public int Quantity { get; set; }

        public double Value { get; set; }

        public ChangeToReturn(int Quantity, double Value)
        {
            this.Quantity = Quantity;
            this.Value = Value;
        }
    }
}