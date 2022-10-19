using System.Configuration;
using Microsoft.Practices.Unity.Configuration;
using Unity;
using Unity.Injection;
using Unity.Lifetime;

namespace lab2;

    public class Main
    {
        public static IUnityContainer cont = new UnityContainer();

        public static void main()
        {
            //register_file();
            register_code();
            run_simple();
        }

        private static void register_file()
        {
            cont.LoadConfiguration();
            //UnityConfigurationSection section = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
            //section.Configure(cont);
        }

        private static void register_code()
        {
            cont.RegisterInstance<ICalculator>("CatCalc", new CatCalc());
            cont.RegisterInstance<ICalculator>("PlusCalc", new PlusCalc());

            cont.RegisterInstance<ICalculator>("StateCalc", new StateCalc(1), InstanceLifetime.Singleton);

            cont.RegisterType<Worker>("Worker", new ContainerControlledLifetimeManager(),
                new InjectionConstructor(new ResolvedParameter<ICalculator>("CatCalc")));
            cont.RegisterType<Worker2>("Worker2", new ContainerControlledLifetimeManager(),
                new InjectionMethod("SetCalculator", new ResolvedParameter<ICalculator>("CatCalc")));
            cont.RegisterType<Worker3>("Worker3",
                new InjectionProperty("Calculator",
                    cont.Resolve<ICalculator>("CatCalc")));

            cont.RegisterType<Worker>("state", new ContainerControlledLifetimeManager(),
                new InjectionConstructor(new ResolvedParameter<ICalculator>("StateCalc")));
            cont.RegisterType<Worker2>("state", new ContainerControlledLifetimeManager(),
                new InjectionMethod("SetCalculator", new ResolvedParameter<ICalculator>("StateCalc")));
            cont.RegisterType<Worker3>("state",
                new InjectionProperty("Calculator",
                    new ResolvedParameter<ICalculator>("StateCalc")));

            Console.Out.WriteLine("Wykonano rejestracje");
        }

        private static void run_simple()
        {
            cont.Resolve<Worker>("Worker").Work("a", "b");
            cont.Resolve<Worker>("state").Work("b", "df");
            cont.Resolve<Worker>("state").Work("c", "c");
            cont.Resolve<Worker2>("state").Work("123", "111");
            cont.Resolve<Worker2>("Worker2").Work("1", "2");
            cont.Resolve<Worker3>("Worker3").Work("f", "b");
            cont.Resolve<Worker3>("state").Work("g", "c");
        }
    }
