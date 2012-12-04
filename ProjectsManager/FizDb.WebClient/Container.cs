using Red;

namespace FizDb.WebClient
{
    public class Container
    {
        private static volatile RedContext context;
        private static volatile RedDataSet dataset;

        public static RedContext Context
        {
            get
            {
                lock (context)
                {
                    return context;
                }
            }
            set { context = value; }
        }

        public static RedDataSet Dataset
        {
            get
            {
                lock (dataset)
                {
                    return dataset;
                }
            }
            set { dataset = value; }
        }
    }
}