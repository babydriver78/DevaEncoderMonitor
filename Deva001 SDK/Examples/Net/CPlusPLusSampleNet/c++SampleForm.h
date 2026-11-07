#pragma once


namespace CSample {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;
	using namespace Deva;

	/// <summary>
	/// Summary for Form1
	///
	/// WARNING: If you change the name of this class, you will need to change the
	///          'Resource File Name' property for the managed resource compiler tool
	///          associated with all .resx files this class depends on.  Otherwise,
	///          the designers will not be able to interact properly with localized
	///          resources associated with this form.
	/// </summary>
	public ref class CPlusPlusSampleForm : public System::Windows::Forms::Form
	{
	public:
		CPlusPlusSampleForm(void)
		{
			InitializeComponent();
			//
			//TODO: Add the constructor code here
			//
			m_lNumAxes = 0;
			m_lCount = nullptr;
			m_EncoderOpened = false;
		}

	protected:
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		~CPlusPlusSampleForm()
		{
			if (components)
			{
				delete components;
			}
			if (m_lCount)
			{
				delete [] m_lCount;
			}
		}
	private: System::Windows::Forms::Button^  CloseButton;
	private: System::Windows::Forms::Timer^  MainFormTimer;
	private: System::ComponentModel::IContainer^  components;
	private: System::Windows::Forms::ComboBox^  AxisComboBox;
	private: System::Windows::Forms::Label^  AxisLabel;


	private: System::Windows::Forms::TextBox^  CountTextBox;
	private: System::Windows::Forms::Label^  CountLabel;

	private:
			long m_lNumAxes;
			int m_nSelectedAxis;
			long *m_lCount;
			long m_lLastCount;
			long *m_lProbe;
			long m_lLastProbe;
			bool m_EncoderOpened;

	private: System::Windows::Forms::Label^  ProbeLabel;
	private: System::Windows::Forms::CheckBox^  ProbeEnableCheckBox;
	private: System::Windows::Forms::TextBox^  ProbeTextBox;

	protected: 

	protected: 

	private:
		/// <summary>
		/// Required designer variable.
		/// </summary>


#pragma region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		void InitializeComponent(void)
		{
			this->components = (gcnew System::ComponentModel::Container());
			this->CloseButton = (gcnew System::Windows::Forms::Button());
			this->MainFormTimer = (gcnew System::Windows::Forms::Timer(this->components));
			this->AxisComboBox = (gcnew System::Windows::Forms::ComboBox());
			this->AxisLabel = (gcnew System::Windows::Forms::Label());
			this->CountTextBox = (gcnew System::Windows::Forms::TextBox());
			this->CountLabel = (gcnew System::Windows::Forms::Label());
			this->ProbeLabel = (gcnew System::Windows::Forms::Label());
			this->ProbeTextBox = (gcnew System::Windows::Forms::TextBox());
			this->ProbeEnableCheckBox = (gcnew System::Windows::Forms::CheckBox());
			this->SuspendLayout();
			// 
			// CloseButton
			// 
			this->CloseButton->Location = System::Drawing::Point(370, 151);
			this->CloseButton->Name = L"CloseButton";
			this->CloseButton->Size = System::Drawing::Size(73, 24);
			this->CloseButton->TabIndex = 0;
			this->CloseButton->Text = L"Close";
			this->CloseButton->UseVisualStyleBackColor = true;
			this->CloseButton->Click += gcnew System::EventHandler(this, &CPlusPlusSampleForm::OnClose);
			// 
			// MainFormTimer
			// 
			this->MainFormTimer->Interval = 10;
			this->MainFormTimer->Tick += gcnew System::EventHandler(this, &CPlusPlusSampleForm::OnTick);
			// 
			// AxisComboBox
			// 
			this->AxisComboBox->DropDownStyle = System::Windows::Forms::ComboBoxStyle::DropDownList;
			this->AxisComboBox->FormattingEnabled = true;
			this->AxisComboBox->Location = System::Drawing::Point(40, 49);
			this->AxisComboBox->Name = L"AxisComboBox";
			this->AxisComboBox->Size = System::Drawing::Size(77, 21);
			this->AxisComboBox->TabIndex = 1;
			this->AxisComboBox->SelectedIndexChanged += gcnew System::EventHandler(this, &CPlusPlusSampleForm::OnAxisChanged);
			// 
			// AxisLabel
			// 
			this->AxisLabel->AutoSize = true;
			this->AxisLabel->Location = System::Drawing::Point(46, 24);
			this->AxisLabel->Name = L"AxisLabel";
			this->AxisLabel->Size = System::Drawing::Size(26, 13);
			this->AxisLabel->TabIndex = 2;
			this->AxisLabel->Text = L"Axis";
			// 
			// CountTextBox
			// 
			this->CountTextBox->Location = System::Drawing::Point(152, 50);
			this->CountTextBox->Name = L"CountTextBox";
			this->CountTextBox->ReadOnly = true;
			this->CountTextBox->Size = System::Drawing::Size(73, 20);
			this->CountTextBox->TabIndex = 3;
			this->CountTextBox->TabStop = false;
			// 
			// CountLabel
			// 
			this->CountLabel->AutoSize = true;
			this->CountLabel->Location = System::Drawing::Point(159, 24);
			this->CountLabel->Name = L"CountLabel";
			this->CountLabel->Size = System::Drawing::Size(35, 13);
			this->CountLabel->TabIndex = 4;
			this->CountLabel->Text = L"Count";
			// 
			// ProbeLabel
			// 
			this->ProbeLabel->AutoSize = true;
			this->ProbeLabel->Location = System::Drawing::Point(265, 24);
			this->ProbeLabel->Name = L"ProbeLabel";
			this->ProbeLabel->Size = System::Drawing::Size(35, 13);
			this->ProbeLabel->TabIndex = 5;
			this->ProbeLabel->Text = L"Probe";
			// 
			// ProbeTextBox
			// 
			this->ProbeTextBox->Location = System::Drawing::Point(258, 50);
			this->ProbeTextBox->Name = L"ProbeTextBox";
			this->ProbeTextBox->ReadOnly = true;
			this->ProbeTextBox->Size = System::Drawing::Size(64, 20);
			this->ProbeTextBox->TabIndex = 6;
			this->ProbeTextBox->TabStop = false;
			// 
			// ProbeEnableCheckBox
			// 
			this->ProbeEnableCheckBox->AutoSize = true;
			this->ProbeEnableCheckBox->Location = System::Drawing::Point(353, 23);
			this->ProbeEnableCheckBox->Name = L"ProbeEnableCheckBox";
			this->ProbeEnableCheckBox->Size = System::Drawing::Size(90, 17);
			this->ProbeEnableCheckBox->TabIndex = 7;
			this->ProbeEnableCheckBox->Text = L"Probe Enable";
			this->ProbeEnableCheckBox->UseVisualStyleBackColor = true;
			this->ProbeEnableCheckBox->CheckedChanged += gcnew System::EventHandler(this, &CPlusPlusSampleForm::ProbeEnableCheckBox_CheckedChanged);
			// 
			// CPlusPlusSampleForm
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->ClientSize = System::Drawing::Size(464, 200);
			this->Controls->Add(this->ProbeEnableCheckBox);
			this->Controls->Add(this->ProbeTextBox);
			this->Controls->Add(this->ProbeLabel);
			this->Controls->Add(this->CountLabel);
			this->Controls->Add(this->CountTextBox);
			this->Controls->Add(this->AxisLabel);
			this->Controls->Add(this->AxisComboBox);
			this->Controls->Add(this->CloseButton);
			this->Name = L"CPlusPlusSampleForm";
			this->Text = L"C++ Deva 001 Sample";
			this->FormClosing += gcnew System::Windows::Forms::FormClosingEventHandler(this, &CPlusPlusSampleForm::OnFormClosing);
			this->Load += gcnew System::EventHandler(this, &CPlusPlusSampleForm::OnFormLoad);
			this->ResumeLayout(false);
			this->PerformLayout();

		}
#pragma endregion
	private: System::Void OnClose(System::Object^  sender, System::EventArgs^  e) {
				 this->Close();
			 }
	private: System::Void OnFormLoad(System::Object^  sender, System::EventArgs^  e) {
				 short sResult;
				 try
				 {
				 sResult = Deva::Enclib::open_encoder();
				 if (sResult != 0)
				 {
					 MessageBox::Show("Cannot Open EnclibNet!","Error");
					 this->Close();
					 return;
				 }
				 }
				 catch(...)
				 {
					 MessageBox::Show("Cannot Open EnclibNet!","Error");
					 this->Close();
					 return;
				 }
				 m_EncoderOpened = true;
				 m_lNumAxes = Deva::Enclib::read_encoder(Deva::Enclib::COMMANDS::NUM_AXES,0);
				 if (m_lNumAxes == 0)
				 {
					 MessageBox::Show("No Axes Found!","Error");
					 this->Close();
				 }
				 long i;
				 for (i = 0;i < m_lNumAxes;i++)
				 {
					 String ^AxisName = "Axis " + i.ToString();
					 AxisComboBox->Items->Add(AxisName);
				 }
				 AxisComboBox->SelectedIndex = 0;
				 m_nSelectedAxis = 0;
				 m_lCount = new long[m_lNumAxes];
				 for (i = 0;i < m_lNumAxes;i++)
				 {
					m_lCount[i] = 0;
				 }
				 m_lLastCount = -1;
				 m_lProbe = new long[m_lNumAxes];
				 for (i = 0;i < m_lNumAxes;i++)
				 {
					m_lProbe[i] = 0;
				 }
				 m_lLastProbe = -1;
				 ProbeEnableCheckBox->Checked = (Deva::Enclib::read_encoder(Deva::Enclib::COMMANDS::PROBE_FUNC,0) == 1 ? true : false); 
				 UpdateAxisData();
				 MainFormTimer->Enabled = true;
			 }

	private: System::Void OnFormClosing(System::Object^  sender, System::Windows::Forms::FormClosingEventArgs^  e) {
				 MainFormTimer->Enabled = false;
				 if (m_EncoderOpened)
				 {
					 Deva::Enclib::close_encoder();
				 }
				 if (m_lCount)
				 {
					 delete [] m_lCount;
					 m_lCount = nullptr;
				 }
				 if (m_lProbe)
				 {
					 delete [] m_lProbe;
					 m_lProbe = nullptr;
				 }
			 }
	private: System::Void OnTick(System::Object^  sender, System::EventArgs^  e) {
				short i;
				for (i = 0;i < m_lNumAxes;i++)
				{
					m_lCount[i] = Deva::Enclib::read_encoder(Deva::Enclib::COMMANDS::AXIS_32,i);
					m_lProbe[i] = Deva::Enclib::read_encoder(Deva::Enclib::COMMANDS::PROBE_32,i);
				}
				UpdateAxisData();
			 }

	private: System::Void OnAxisChanged(System::Object^  sender, System::EventArgs^  e) {
				if (AxisComboBox->SelectedIndex >= 0 && AxisComboBox->SelectedIndex < m_lNumAxes)
				{
					m_nSelectedAxis = AxisComboBox->SelectedIndex;
					UpdateAxisData();
				}
			 }
	private: System::Void UpdateAxisData(void) {
				 if (m_lCount != nullptr)
				 {
					 if (m_lLastCount != m_lCount[m_nSelectedAxis])
					 {
						 String ^CountText = m_lCount[m_nSelectedAxis].ToString();
						 CountTextBox->Text = CountText;
						 m_lLastCount = m_lCount[m_nSelectedAxis];
					 }
					 if (m_lLastProbe != m_lProbe[m_nSelectedAxis])
					 {
						 String ^ProbeText = m_lProbe[m_nSelectedAxis].ToString();
						 ProbeTextBox->Text = ProbeText;
						 m_lLastProbe = m_lProbe[m_nSelectedAxis];
					 }
				 }
		 }
private: System::Void ProbeEnableCheckBox_CheckedChanged(System::Object^  sender, System::EventArgs^  e) {
				 Deva::Enclib::write_encoder(Deva::Enclib::COMMANDS::PROBE_FUNC,0,((ProbeEnableCheckBox->Checked != 0) ? 1 : 0)); 
		 }
};
}

