namespace Silksprite.AdLib.Material.Impl
{
    public static class MToonEnums
    {
        public enum RenderMode
        {
            Opaque = 0,
            Cutout = 1,
            Transparent = 2,
            TransparentWithZWrite = 3,
        }

        public enum CullMode
        {
            Off = 0,
            Front = 1,
            Back = 2,
        }

        public enum OutlineWidthMode
        {
            None = 0,
            WorldCoordinates = 1,
            ScreenCoordinates = 2,
        }
    }
}
