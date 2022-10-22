using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Controls;

namespace AplikacjaLab2Dom; 

public class ModuleWatcher {
	private MainWindow window;
	private TabControl tabControl;
	private Dictionary<string, Tab> tabs = new Dictionary<string, Tab>();
	private FileSystemWatcher watcher;
	public string path;

	public ModuleWatcher(MainWindow window, TabControl tabControl) {
		this.window = window;
		this.tabControl = tabControl;
		
		path = new DirectoryInfo(".").FullName + "\\Plugins";

		var dir = new DirectoryInfo(path);
		foreach(var it in dir.GetFiles()) {
			if(it.Extension == ".dll") {
				var tab = new Tab(window, tabControl, path,
					Path.GetFileNameWithoutExtension(it.Name));
				if(tab.calc != null) {
					tabs.Add(it.Name, tab);
				}
			}
		}
		
		watcher = new FileSystemWatcher(path);
		watcher.NotifyFilter = NotifyFilters.Attributes
		                       | NotifyFilters.CreationTime
		                       | NotifyFilters.DirectoryName
		                       | NotifyFilters.FileName
		                       | NotifyFilters.LastAccess
		                       | NotifyFilters.LastWrite
		                       | NotifyFilters.Security
		                       | NotifyFilters.Size;
		watcher.Deleted += (object o, FileSystemEventArgs args) => {
			window.Dispatcher.Invoke(new Action(delegate() {
				var f = new FileInfo(args.FullPath);
				Tab tab;
				if(tabs.TryGetValue(f.Name, out tab)) {
					tab.Remove();
				}
			}));
		};
		watcher.Created += (object o, FileSystemEventArgs args) => {
			window.Dispatcher.Invoke(new Action(delegate() {
				var f = new FileInfo(args.FullPath);
				var tab = new Tab(window, tabControl, path,
					Path.GetFileNameWithoutExtension(f.Name));
				if(tab.calc != null) {
					tabs.Add(f.Name, tab);
				}
			}));
		};
		watcher.Filter = "*.dll";
		watcher.EnableRaisingEvents = true;
	}
}
