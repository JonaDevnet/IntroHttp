namespace BackEnd.Services
{
    public class RandonService : IRandomService
    {
        private readonly int _value;
        
        public int Value
        {
            get => _value;
        }

        public RandonService()
        {
            // Genera un número aleatório para la lectura
            _value = new Random().Next(100); 
        }
    }
}
