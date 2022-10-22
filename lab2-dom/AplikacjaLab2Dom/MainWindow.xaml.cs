using System;

using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AplikacjaLab2Dom {
	public partial class MainWindow : Window {
		private TabControl tabs;

		private ModuleWatcher moduleWatcher;

		public MainWindow() {
			InitializeComponent();
			
			this.Width = 600;
			this.Height = 600;

			tabs = new TabControl();
			this.Content = tabs;
			
			var t = new TabItem();
			t.Header = "Default empty tab";
			tabs.Items.Add(t);

			moduleWatcher = new ModuleWatcher(this, tabs);

			var tx = new TextBlock();
			tx.Text = moduleWatcher.path;
			t.Content = tx;
		}
	}
	
}
