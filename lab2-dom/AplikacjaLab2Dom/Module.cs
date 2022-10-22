using System;
using System.IO;
using System.Reflection;
using CalcInterface;

namespace AplikacjaLab2Dom; 

public class Module {
	private Assembly assembly;
	private ICalculator calculator;

	public Module(string path, string moduleName) {
		assembly = Assembly.LoadFile(path + "\\" + moduleName + ".dll");
		var types = assembly.ExportedTypes;
		foreach(var it in types) {
			if(it.Namespace == moduleName) {
				if(it.Name == moduleName) {
					var str = typeof(CalcInterface.ICalculator).Assembly.Location;
					var s2 = it.GetInterface("ICalculator").Assembly.Location;
					calculator = (CalcInterface.ICalculator)Activator.CreateInstance(it);
					return;
				}
			}
		}
		
	}

	public ICalculator GetCalculator() {
		return calculator;
	}

	public void Unload() {
		calculator = null;
		assembly = null;
		System.GC.Collect();
	}
	
	
}
