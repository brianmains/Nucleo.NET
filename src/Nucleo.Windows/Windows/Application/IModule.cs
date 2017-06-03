using System;


namespace Nucleo.Windows.Application
{
	public interface IModule
	{
		void Initialize();
		void Hide();
		void Show();
		void Shutdown();
	}
}
