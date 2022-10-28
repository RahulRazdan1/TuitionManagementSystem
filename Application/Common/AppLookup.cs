namespace Application.Common
{
    public class AppLookup
    {
        public string Key { get; set; } = default!;
        public string Value { get; set; } = default!;
        public TOutput GetKeyAs<TOutput>(Func<string, TOutput> callback)
        {
            if (string.IsNullOrEmpty(Key))
            {
                return default(TOutput);
            }
            return callback(Key);
        }
    }
}

