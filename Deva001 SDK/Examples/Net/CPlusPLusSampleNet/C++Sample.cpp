// C++Sample.cpp : main project file.

#include "stdafx.h"
#include "c++SampleForm.h"

using namespace CSample;

[STAThreadAttribute]
int main(array<System::String ^> ^args)
{
	// Enabling Windows XP visual effects before any controls are created
	Application::EnableVisualStyles();
	Application::SetCompatibleTextRenderingDefault(false); 

	// Create the main window and run it
	Application::Run(gcnew CPlusPlusSampleForm());
	return 0;
}
