namespace SignalRWebUI.Dtos.BasketDtos
{
    public class ResultBasketDto
    {
        public int BasketID { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public decimal TotalPrice { get; set; }
        public int ProductID { get; set; }
        public int TableDetailID { get; set; }
        public string? ProductName { get; set; }
    }
}
