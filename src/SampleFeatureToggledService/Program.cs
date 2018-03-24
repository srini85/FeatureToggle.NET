using System;
using Unity;

namespace SampleFeatureToggledService
{
	static class Program
	{
		private static void Main()
		{
			IUnityContainer container = new UnityContainer();
			container.RegisterType<IGreeter, AussieGreeter>();

			var greeter = container.Resolve<IGreeter>();
			Console.WriteLine(greeter.Greet());

			Console.ReadLine();
		}
	}
}
