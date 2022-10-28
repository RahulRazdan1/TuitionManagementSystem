namespace Application.Common
{

    public abstract class Query<TInput, TOutput> : CommandQueryBase
    {
        public Query(Providers provider) : base(provider)
        {
        }
        public abstract TOutput Execute(TInput input);

    }
    public abstract class Query<TOutput> : CommandQueryBase
    {
        public Query(Providers provider) : base(provider)
        {
        }
        public abstract TOutput Execute();
    }

    public abstract class QueryAsync<TInput, TOutput>: CommandQueryBase
    {
        public QueryAsync(Providers provider) : base(provider)
        {
        }
        public abstract Task<TOutput> ExecuteAsync(TInput input);
    }
    public abstract class QueryAsync<TInput, TInput1, TOutput> : CommandQueryBase
    {
        public QueryAsync(Providers provider) : base(provider)
        {
        }
        public abstract Task<TOutput> ExecuteAsync(TInput input, TInput1 input1);
    }

    public abstract class QueryAsync<TOutput>: CommandQueryBase
    {
        public QueryAsync(Providers provider) : base(provider)
        {
        }
        public abstract Task<TOutput> ExecuteAsync();
    }
}
