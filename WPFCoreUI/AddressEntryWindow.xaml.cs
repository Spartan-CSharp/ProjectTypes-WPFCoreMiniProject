using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using ClassLibrary;

namespace WPFCoreUI
{
	/// <summary>
	/// Interaction logic for AddressEntryWindow.xaml
	/// </summary>
	public partial class AddressEntryWindow : Window
	{
		private readonly ISaveAddress _parent;
		private readonly AddressModel _address = new AddressModel();

		public AddressEntryWindow(ISaveAddress parent)
		{
			InitializeComponent();

			_parent = parent;
		}

		private void SaveRecordButton_Click(object sender, RoutedEventArgs e)
		{
			if ( IsDataValid() )
			{
				_address.StreetAddress = streetAddressTextBox.Text;
				_address.City = cityTextBox.Text;
				_address.State = stateTextBox.Text;
				_address.ZipCode = zipCodeTextBox.Text;
				_parent.SaveAddress(_address);
				Close();
			}
		}

		private bool IsDataValid()
		{
			bool output = true;

			if ( string.IsNullOrWhiteSpace(streetAddressTextBox.Text) )
			{
				_ = MessageBox.Show("A Street Address is required.", "Street Address Blank", MessageBoxButton.OK, MessageBoxImage.Error);
				output = false;
			}

			if ( string.IsNullOrWhiteSpace(cityTextBox.Text) )
			{
				_ = MessageBox.Show("A City is required.", "City Blank", MessageBoxButton.OK, MessageBoxImage.Error);
				output = false;
			}

			if ( string.IsNullOrWhiteSpace(stateTextBox.Text) )
			{
				_ = MessageBox.Show("A State is required.", "State Blank", MessageBoxButton.OK, MessageBoxImage.Error);
				output = false;
			}

			if ( string.IsNullOrWhiteSpace(zipCodeTextBox.Text) )
			{
				_ = MessageBox.Show("A Zip Code is required.", "Zip Code Blank", MessageBoxButton.OK, MessageBoxImage.Error);
				output = false;
			}

			return output;
		}
	}
}
