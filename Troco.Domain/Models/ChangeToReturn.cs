namespace Troco.Domain.Models
{
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