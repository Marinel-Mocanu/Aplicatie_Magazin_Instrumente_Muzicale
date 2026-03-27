namespace Aplicatie_Magazin_Instrumente_Muzicale
{
        public class Instrument
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string Brand { get; set; }
            public Instrument_Category Category { get; set; }
            public double Price { get; set; }
            public string Description { get; set; }
            public int Quantity { get; set; }
            public double Discount { get; set; }
            public CustomOrderColor Color {  get; set; }
            public double Final_Price()
            {
                return Price - (Price - Discount / 100);
            }
            public Instrument()
            {
                ID = 0;
                Name = string.Empty;
                Brand = string.Empty;
                Category = new Instrument_Category();
                Price = 0;
                Description = string.Empty;
                Quantity = 0;
                Discount = 0;
            }
            public Instrument(string NameIn, string BrandIn, double PriceIn, int idIn, double DiscountIn,int QuantityIn)
            {
                ID = idIn;
                Name = NameIn;
                Brand = BrandIn;
                Price = PriceIn;
                Discount = DiscountIn;
                Quantity=QuantityIn;
            }
        [Flags]
            public enum Instrument_Category
            {
                Guitars = 1,
                Drums = 2,
                Keyboards= 4,
                Mics = 8,
                Amps = 16,
                Synths = 32,
                Cables = 64,
                Strings = 128,
                Accessories= 256
            }
        [Flags]
        public enum CustomOrderColor
        {
            Blue = 1,
            Red = 2,
            Green = 4,
            Black = 8,
            Purple = 16,
            White  = 32,
            Orange = 64
        }
        
        public string Info()
        {
            string info = $"ID:{ID} Name:{Name} Brand:{Brand} Price:{Price} Quantity:{Quantity}";
            return info;
        }
            
        }
    
}
