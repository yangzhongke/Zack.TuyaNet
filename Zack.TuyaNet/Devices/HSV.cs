namespace Zack.TuyaNet.Devices
{
    public record HSV
    {
        public ushort H { get; private set; }
        public ushort S { get; private set; }
        public ushort V { get; private set; }
        public HSV(ushort h, ushort s, ushort v)
        {
            if (h < 0 || h > 360)
            {
                throw new ArgumentOutOfRangeException(nameof(h));
            }
            if (s > 1000)
            {
                throw new ArgumentOutOfRangeException(nameof(s));
            }
            if (v > 1000)
            {
                throw new ArgumentOutOfRangeException(nameof(v));
            }
            H = h;
            S = s;
            V = v;
        }
    }
}
