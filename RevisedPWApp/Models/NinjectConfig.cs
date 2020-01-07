using Model.Lib;
using Ninject;

namespace RevisedPWApp.Models
{
    public static class NinjectConfig
    {
        public static void CreateKernel()
        {
            Kernel = new StandardKernel();
            Kernel.Load(new CustomModule());
        }

        public static IKernel Kernel { get; private set; }
    }
}
