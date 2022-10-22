using System;
using System.Windows;
using System.Windows.Controls;
using CalcInterface;

namespace AplikacjaLab2Dom; 

public class Tab {
	public string moduleName;
	public ICalculator calc;
	public Module module;
	public TabItem tabItem;
	public Grid grid;
	public TextBox operandAstring, operandBstring, operatorString;
	public MainWindow window;
	public TabControl tabControl;
	public string path;

	public TextBlock pluginInfo, result;
	public Button calculateButton;

	public void Remove() {
		window.Dispatcher.Invoke(new Action(delegate() {
			this.UnloadDll();
			this.tabControl.Items.Remove(tabItem);
		}));
	}

	public void Reload() {
		window.Dispatcher.Invoke(new Action(delegate() {
			if(calc != null) {
				UnloadDll();
				LoadDll();
			}
		}));
	}
	
	public Tab(MainWindow window, TabControl tabControl, string path, string moduleName) {
		//throw new Exception("new Tab");
		this.path = path;
		this.tabControl = tabControl;
		this.window = window;
		this.moduleName = moduleName;
		
		tabItem = new TabItem();
		tabControl.Items.Add(tabItem);
		tabItem.Header = moduleName;

		tabItem.GotFocus += (object o, RoutedEventArgs args) => {
			this.LoadDll();
		};

		tabItem.LostFocus += (object o, RoutedEventArgs args) => {
			this.UnloadDll();
		};

		grid = new Grid();
		tabItem.Content = grid;

		MakeGrid(3, 3);

		AddElement<TextBlock>(0, 0).Text = "a: ";
		operandAstring = AddElement<TextBox>(1, 0);
		AddElement<TextBlock>(0, 2).Text = "b: ";
		operandBstring = AddElement<TextBox>(1, 2);
		AddElement<TextBlock>(0, 1).Text = "operator: ";
		operatorString = AddElement<TextBox>(1, 1);

		pluginInfo = AddElement<TextBlock>(2, 0);
		result = AddElement<TextBlock>(2, 2);

		calculateButton = AddElement<Button>(2, 1);
		calculateButton.Click += (object o, RoutedEventArgs args) => {
			var a = operandAstring.Text;
			var b = operandBstring.Text;
			var op = operatorString.Text;

			if(!calc.IsValidOperand(a)) {
				result.Text = "Operand a is invalid:\n" + a;
				return;
			}
			if(!calc.IsValidOperand(b)) {
				result.Text = "Operand b is invalid:\n" + b;
				return;
			}
			if(!calc.IsValidOperator(op)) {
				result.Text = "Operator is invalid:\n" + o;
				return;
			}
			
			result.Text = calc.Process(a, op, b);
		};
		PrintText("Calculate", 2, 1).IsHitTestVisible = false;
	}

	TextBlock PrintText(string text, int x, int y) {
		var e = AddElement<TextBlock>(x, y);
		e.Text = text;
		return e;
	}

	T AddElement<T>(int x, int y) where T : UIElement, new() {
		T element = new T();
		Grid.SetColumn(element, x);
		Grid.SetRow(element, y);
		grid.Children.Add(element);
		return element;
	}

	void LoadDll() {
		module = new Module(path, moduleName);
		calc = module.GetCalculator();
		pluginInfo.Text = calc.GetDescription();
	}

	void UnloadDll() {
		pluginInfo.Text = null;
		calc = null;
		module.Unload();
		module = null;
	}

	void MakeGrid(int w, int h) {
		for(int i = 0; i < w; ++i) {
			var c = new ColumnDefinition();
			grid.ColumnDefinitions.Add(c);
			for(int j = 0; j < h; ++j) {
				if(i == 0) {
					var r = new RowDefinition();
					grid.RowDefinitions.Add(r);
				}
			}
		}
	}
}
