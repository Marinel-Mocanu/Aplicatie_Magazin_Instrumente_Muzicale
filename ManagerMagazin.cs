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
            public enum Instrument_Category
            {
                Guitars,
                Drums,
                Keyboards,
                Mics,
                Amps,
                Synths,
                Cables,
                Strings,
                Accessories
            }
        public enum CustomOrderColor
        {
            Blue,
            Red,
            Green,
            Black,
            Purple,
            White,
            Orange
        }
        
        public string Info()
        {
            string info = $"ID:{ID} Name:{Name} Brand:{Brand} Price:{Price} Quantity:{Quantity}";
            return info;
        }
            
        }
    
}
