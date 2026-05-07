namespace ExtensionMethods
{
    public class Pizza
    {
        public string Content { get; set; }
        public decimal TotalPrice { get; set; }
        public override string ToString()
        {
            return $"{Content}\n------------------\nTotal Price: {TotalPrice.ToString("#.##")}$";
        }
    }
}
