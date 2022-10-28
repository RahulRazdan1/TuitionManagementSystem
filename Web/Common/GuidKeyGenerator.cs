namespace Web.Common
{
    public static class GuidKeyGenerator
    {
        public static string Generate()
        {
            return Guid.NewGuid().ToString("N");
        }
    }
}
