#include <windows.h>
#include "DataModel.h"
using namespace System::Runtime::Remoting;
using namespace System::Security::Policy;
using namespace System::Security;
using namespace System;
using namespace System::Windows;
using namespace System::IO;
using namespace System::Windows::Markup;
using namespace System::Windows::Controls;
using namespace System::CodeDom;
using namespace System::CodeDom::Compiler;
using namespace System::Reflection;
using namespace System::Windows::Documents;
using namespace std;


public ref class MyApplication : public Application {
public:

	DataModel^ h_dm;
	TextRange ^textRang;
	String ^ pathToVBCode, ^code, ^tekst, ^st;
	Button ^addBtn, ^invokeBtn, ^setBtn;
	RichTextBox ^codeRTB;
	ListBox ^errorsListBox, ^methodsListBox, ^variablesListBox;
	Assembly^ modul;
	Type^ t;
	Object^ obj;
	ObjectHandle^ handle;
	array<FieldInfo^>^ fields;
	MethodInfo^ mI;
	FieldInfo^ fI;
	TextBox ^resultTextBox, ^parameterTextBox, ^setTextBox, ^setTextBox2;
	ComboBox ^checkZoneComboBox;

	MyApplication(Window ^win) {
		h_dm = gcnew DataModel();
		win->DataContext = h_dm;

		pathToVBCode = gcnew String("..\\VBCode\\Class1.vb");
		
		code = File::ReadAllText(pathToVBCode);
		
		addBtn = (Button^)win->FindName("addButton");
		addBtn->Click += gcnew RoutedEventHandler(this, &MyApplication::OnAddBtnClick);
		
		invokeBtn = (Button^)win->FindName("invokeButton");
		invokeBtn->Click += gcnew RoutedEventHandler(this, &MyApplication::OninvokeBtnClick);
		
		setBtn = (Button^)win->FindName("setButton");
		setBtn->Click += gcnew RoutedEventHandler(this, &MyApplication::OnsetBtnClick);
		
		methodsListBox = (ListBox^)win->FindName("methodsListBox");
		methodsListBox->SelectionChanged += gcnew System::Windows::Controls::SelectionChangedEventHandler(this, &MyApplication::OnSelectionMethodsListBoxChanged);
		
		variablesListBox = (ListBox^)win->FindName("variablesListBox");
		variablesListBox->SelectionChanged += gcnew System::Windows::Controls::SelectionChangedEventHandler(this, &MyApplication::OnSelectionVariablesListBoxChanged);
		
		errorsListBox = (ListBox^)win->FindName("errorsListBox");
		methodsListBox = (ListBox^)win->FindName("methodsListBox");
		variablesListBox = (ListBox^)win->FindName("variablesListBox");
		
		resultTextBox = (TextBox^)win->FindName("resultTextBox");
		parameterTextBox = (TextBox^)win->FindName("parameterTextBox");
		
		setTextBox = (TextBox^)win->FindName("setTextBox");
		
		setTextBox2 = (TextBox^)win->FindName("setTextBox2");
		
		checkZoneComboBox = (ComboBox^)win->FindName("checkZoneComboBox");
		
		codeRTB = (RichTextBox^)win->FindName("codeRichTextBox");
		codeRTB->AppendText(code);
		codeRTB->Document->LineHeight = 0.1;
	}

	FieldInfo^ variable;
	
	System::Void OnSelectionMethodsListBoxChanged(Object^ sender, SelectionChangedEventArgs^ e) {
	}

	System::Void OnSelectionVariablesListBoxChanged(Object^ sender, SelectionChangedEventArgs^ e) {
		variable = (FieldInfo^)variablesListBox->SelectedItem;
		if(variable) {
			auto v = variable->GetValue(instance);
			if(v) {
				setTextBox->Text = v->ToString();
			} else {
				setTextBox->Text = gcnew String("[NULL]");
			}
		}
	}
	
	System::Void OninvokeBtnClick(Object^ sender, RoutedEventArgs^ e) {
		auto method = (MethodInfo^)methodsListBox->SelectedItem;
		array<Object^>^ params = {this->parameterTextBox->Text};
		auto res = method->Invoke(instance, params);
		resultTextBox->Text = (String^)res;
	}


	System::Void OnsetBtnClick(Object^ sender, RoutedEventArgs^ e) {
		auto variable = (FieldInfo^)variablesListBox->SelectedItem;
		if(variable) {
			if(variable->GetType()->Equals((gcnew Int32())->GetType())) {
				setTextBox->Text = gcnew String("INT");
				variable->SetValue(instance, Int32::Parse(setTextBox2->Text));
			} else if(variable->GetType()->Equals((gcnew String(""))->GetType())) {
				setTextBox->Text = gcnew String("STRING");
				variable->SetValue(instance, setTextBox2->Text);
			} else if(variable->GetType()->Equals((gcnew Boolean())->GetType())) {
				setTextBox->Text = gcnew String("BOOL");
				variable->SetValue(instance, Boolean::Parse(setTextBox2->Text));
			} else {
				setTextBox->Text = gcnew String("Unknown type");
			}
		} else {
			setTextBox->Text = gcnew String("Not selected");
		}
	}

	
	Object^ instance;

	System::Void OnAddBtnClick(Object^ sender, RoutedEventArgs^ e) {
		CodeDomProvider^ prov = CodeDomProvider::CreateProvider("VisualBasic");
		CompilerParameters^ param = gcnew CompilerParameters();
		param->GenerateInMemory = true;
		CodeSnippetCompileUnit^ csu = gcnew CodeSnippetCompileUnit(code);
		CompilerResults^ res = prov->CompileAssemblyFromDom(param, csu);
		array<CompilerError^>^ errors = {};
		if(res->Errors->HasErrors) {
			res->Errors->CopyTo(errors, 0);
			for(int i=0; i<errors->Length; ++i) {
				errorsListBox->Items->Add(errors->GetValue(i)->ToString());
			}
			resultTextBox->Text = gcnew String("Errory: ") + (gcnew Int32(errors->Length))->ToString();
		} else {
			if(methodsListBox ) {
				resultTextBox->Text = gcnew String("methodsListBox null");
			} else {
				resultTextBox->Text = gcnew String("Success");
			}

			auto ass = res->CompiledAssembly;
			auto type = ass->GetType("A");
			auto methods = type->GetMethods();
			for(int i=0; i<methods->Length; ++i) {
				h_dm->Methods->Add((MethodInfo^)methods->GetValue(i));
			}
			
			auto fields = type->GetFields();
			for(int i=0; i<fields->Length; ++i) {
				h_dm->Variables->Add((FieldInfo^)fields->GetValue(i));
			}

			instance = Activator::CreateInstance(type);

			
		}
	}
};

[STAThread]
int WINAPI WinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance,
	LPSTR lpCmd, int nCmd) {
	Stream^ st = File::OpenRead("MainWindow.xaml");
	Window^ win = (Window^)XamlReader::Load(st, nullptr);
	Application^ app = gcnew MyApplication(win);
	app->Run(win);
}


