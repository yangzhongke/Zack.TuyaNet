namespace Zack.TuyaNet.Devices
{
    public record HSV
    {
        public ushort H { get; private set; }
        public byte S { get; private set; }
        public byte V { get; private set; }
        public HSV(ushort h, byte s, byte v)
        {
            if(h<=0||h>360)
            {
                throw new ArgumentOutOfRangeException(nameof(h));
            }
            if (s <=0)
            {
                throw new ArgumentOutOfRangeException(nameof(s));
            }
            if (v <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(v));
            }
            H = h;
            S = s;
            V = v;
        }
    }
}
