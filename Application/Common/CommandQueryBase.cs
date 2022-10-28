namespace Application.Common
{
    public abstract class CommandQueryBase
    {
        protected Providers Providers { get; private set; }
        public CommandQueryBase(Providers providers)
        {
            Providers = providers;
        }
    }
}