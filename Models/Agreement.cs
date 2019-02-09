namespace RateEvaluator.SharedModels
{

    public class Agreement
    {
        public int Id { get; set; }

        public int Amount { get; set; }
        public BaseRate BaseRate { get; set; }
        public float Margin { get; }
        public int Duration { get; set; }

        public Customer Customer { get; set; }

        public Agreement() { } // for serialization

        public Agreement(int id, int amount, BaseRate baseRate, float margin, int duration, Customer customer)
        {
            this.Id = id;
            this.Amount = amount;
            this.BaseRate = baseRate;
            this.Margin = margin;
            this.Duration = duration;
            this.Customer = customer;
        }
    }
}