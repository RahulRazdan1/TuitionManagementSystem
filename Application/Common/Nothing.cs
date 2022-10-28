namespace Application.Common
{
    public class Nothing
    {
        private Nothing()
        {

        }
        public static Nothing Instance
        {
            get { return new Nothing(); }
        }
    }
}
