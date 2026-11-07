using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Deva;

namespace namespaceExample1
{
	public partial class classExample1 : Form
	{
		//Axis channels
		private const short X_AXIS_CHANNEL = 0;
		private const short Y_AXIS_CHANNEL = 1;
		private const short Z_AXIS_CHANNEL = 2;
		//ZERO value
		private const short ZERO = 0;
        private bool m_EncoderOpened;

		//constructor
		public classExample1()
		{
			InitializeComponent();
            m_EncoderOpened = false;
			try
			{
                Enclib.open_encoder();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Unable to load Deva001 Driver Info");
				this.Close();
				return;
			}

			this.Text = "MSCS Example1 ("+ Enclib.enclib_version() + ")";
			//enable timer
			_pollTimer.Enabled = true;
            m_EncoderOpened = true;
        }

		//Zero button events
		private void _xZeroButton_Click(object sender, EventArgs e) {
			Enclib.write_encoder(Enclib.COMMANDS.AXIS_32,X_AXIS_CHANNEL, ZERO);
		}
		private void _yZeroButton_Click(object sender, EventArgs e) {
			Enclib.write_encoder(Enclib.COMMANDS.AXIS_32, Y_AXIS_CHANNEL, ZERO);
		}
		private void _zZeroButton_Click(object sender, EventArgs e) {
			Enclib.write_encoder(Enclib.COMMANDS.AXIS_32, Z_AXIS_CHANNEL, ZERO);
		}

		//Handle MARK check box changes
		private void _xMarkCheckBox_CheckedChanged(object sender, EventArgs e) {
			if (_xMarkCheckBox.Checked)
				Enclib.write_encoder(Enclib.COMMANDS.MARK_FUNC, X_AXIS_CHANNEL, 1);	//1 = MARK
			else
				Enclib.write_encoder(Enclib.COMMANDS.MARK_FUNC, X_AXIS_CHANNEL, 0);	//0 = MARK off
		}
		private void _yMarkCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (_yMarkCheckBox.Checked)
				Enclib.write_encoder(Enclib.COMMANDS.MARK_FUNC, Y_AXIS_CHANNEL, 1);	//1 = MARK
			else
				Enclib.write_encoder(Enclib.COMMANDS.MARK_FUNC, Y_AXIS_CHANNEL, 0);	//0 = MARK off
		}
		private void _zMarkCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (_zMarkCheckBox.Checked)
				Enclib.write_encoder(Enclib.COMMANDS.MARK_FUNC, Z_AXIS_CHANNEL, 1);	//1 = MARK
			else
				Enclib.write_encoder(Enclib.COMMANDS.MARK_FUNC, Z_AXIS_CHANNEL, 0);	//0 = MARK off
		}


		private void _probeEnableCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (_probeEnableCheckBox.Checked)
			{//turn on probe for all axes
				Enclib.write_encoder(Enclib.COMMANDS.PROBE_FUNC,0, 1);
			}
			else
			{//turn off probe for all axes
				Enclib.write_encoder(Enclib.COMMANDS.PROBE_FUNC,0, 0);
			}
		}

		private void _footswitchEnableCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (_footswitchEnableCheckBox.Checked)
			{//turn on footswitch for all axes
				Enclib.write_encoder(Enclib.COMMANDS.PROBE_FOOTSWITCH,0, 1);
			}
			else
			{//turn off footswitch for all axes
				Enclib.write_encoder(Enclib.COMMANDS.PROBE_FOOTSWITCH,0, 0);
			}
		}

		//Timer tick event
		private void _pollTimer_Tick(object sender, EventArgs e) {
			UpdateAxes();
		}


		private void UpdateAxes() {
			
			//Xaxis
			_xIncrementalLabel.Text = Enclib.read_encoder(Enclib.COMMANDS.AXIS_32, X_AXIS_CHANNEL).ToString();
			_xAbsoluteLabel.Text = Enclib.read_encoder(Enclib.COMMANDS.ABSOLUTE_32, X_AXIS_CHANNEL).ToString();
			_xMarkersLabel.Text = Enclib.read_encoder(Enclib.COMMANDS.MARK_32, X_AXIS_CHANNEL).ToString();
			_xProbeLabel.Text = Enclib.read_encoder(Enclib.COMMANDS.PROBE_32, X_AXIS_CHANNEL).ToString();
			
			//Yaxis
			_yIncrementalLabel.Text = Enclib.read_encoder(Enclib.COMMANDS.AXIS_32, Y_AXIS_CHANNEL).ToString();
			_yAbsoluteLabel.Text = Enclib.read_encoder(Enclib.COMMANDS.ABSOLUTE_32, Y_AXIS_CHANNEL).ToString();
			_yMarkersLabel.Text = Enclib.read_encoder(Enclib.COMMANDS.MARK_32, Y_AXIS_CHANNEL).ToString();
			_yProbeLabel.Text = Enclib.read_encoder(Enclib.COMMANDS.PROBE_32, Y_AXIS_CHANNEL).ToString();
			
			//Zaxis
			_zIncrementalLabel.Text = Enclib.read_encoder(Enclib.COMMANDS.AXIS_32, Z_AXIS_CHANNEL).ToString();
			_zAbsoluteLabel.Text = Enclib.read_encoder(Enclib.COMMANDS.ABSOLUTE_32, Z_AXIS_CHANNEL).ToString();
			_zMarkersLabel.Text = Enclib.read_encoder(Enclib.COMMANDS.MARK_32, Z_AXIS_CHANNEL).ToString();
			_zProbeLabel.Text = Enclib.read_encoder(Enclib.COMMANDS.PROBE_32, Z_AXIS_CHANNEL).ToString();
			
			//update the marker status
			_xMarkCheckBox.Checked = Enclib.read_encoder(Enclib.COMMANDS.MARK_FUNC, X_AXIS_CHANNEL) == 0 ? false : true;
			_yMarkCheckBox.Checked = Enclib.read_encoder(Enclib.COMMANDS.MARK_FUNC, Y_AXIS_CHANNEL) == 0 ? false : true;
			_zMarkCheckBox.Checked = Enclib.read_encoder(Enclib.COMMANDS.MARK_FUNC, Z_AXIS_CHANNEL) == 0 ? false : true;

			//update probe and footswitch
			_footswitchEnableCheckBox.Checked = Enclib.read_encoder(Enclib.COMMANDS.PROBE_FOOTSWITCH,0) == 0 ? false : true;
			_probeEnableCheckBox.Checked = Enclib.read_encoder(Enclib.COMMANDS.PROBE_FUNC,0) == 0 ? false : true;
		}

        private void OnClosing(object sender, FormClosingEventArgs e)
        {
            if (m_EncoderOpened)
            {
                Enclib.close_encoder();
            }
        }
	}
}