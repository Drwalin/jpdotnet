#include <windows.h>
using namespace System::Reflection;
using namespace System::Security;

typedef System::Collections::ObjectModel::ObservableCollection<MethodInfo^> myList;
typedef System::Collections::ObjectModel::ObservableCollection<FieldInfo^> myList2;

ref class DataModel {
	SecurityZone selectedSecurityZone = System::Security::SecurityZone::MyComputer;
	myList^ methods = gcnew myList;
	myList2^ variables = gcnew myList2;
	// tutaj zdefiniuj pozosta�e zmienne modelu danych

public:
	property SecurityZone SelectedSecurityZone {
		SecurityZone get() {
			return selectedSecurityZone;
		}

		void set(SecurityZone value) {
			selectedSecurityZone = value;
		}
	}
	property myList2^ Variables {
		myList2^ get() {
			return variables;
		}

		void set(myList2^ value) {
			variables = value;
		}
	}
	property myList^ Methods {
		myList^ get() {
			return methods;
		}

		void set(myList^ value) {
			methods = value;
		}
	}

	// tutaj zdefiniuj pozosta�e w�a�ciwi�ci modelu danych

};