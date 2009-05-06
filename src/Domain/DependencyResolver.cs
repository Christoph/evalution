using Ninject;
namespace Domain
{
    public static class DependencyResolver
    {
        private static IKernel mKernel;

        public static void InitializeWith(IKernel kernel)
        {
            mKernel = kernel;
        }

        public static T Resolve<T>()
        {
            return mKernel.Get<T>();
        }
    }
}