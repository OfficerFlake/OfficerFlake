namespace Com.OfficerFlake.Libraries
{
    namespace UnitsOfMeasurement
    {
        public abstract class Measurement
        {
            private readonly decimal _value;
            private readonly decimal _conversionRatio;

            protected Measurement(decimal value, decimal conversionRatio)
            {
                _value = value;
                _conversionRatio = conversionRatio;
            }

            public decimal ConvertToBase => _value * _conversionRatio;
            public decimal RawValue => _value;
            public decimal RawConversionRatio => _conversionRatio;

            public override string ToString()
            {
                return _value.ToString();
            }
        }
    }
}
