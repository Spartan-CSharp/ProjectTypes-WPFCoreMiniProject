using System.ComponentModel;
using System.Windows;

using ClassLibrary;

namespace WPFCoreUI
{
	/// <summary>
	/// Interaction logic for PersonEntryWindow.xaml
	/// </summary>
	public partial class PersonEntryWindow : Window, ISaveAddress
	{
		private readonly PersonModel _person = new PersonModel();
		private readonly BindingList<AddressModel> _addresses = new BindingList<AddressModel>();

		public PersonEntryWindow()
		{
			InitializeComponent();
		}

		public void SaveAddress(AddressModel address)
		{
			_addresses.Add(address);

			addressesListBox.ItemsSource = _addresses;
		}

		private void AddAddressButton_Click(object sender, RoutedEventArgs e)
		{
			AddressEntryWindow entrywindow = new AddressEntryWindow(this);
			entrywindow.Show();
		}

		private void SaveRecordButton_Click(object sender, RoutedEventArgs e)
		{
			if ( IsDataValid() )
			{
				_person.FirstName = firstNameTextBox.Text;
				_person.LastName = lastNameTextBox.Text;
				_person.IsActive = activeChecBox.IsChecked;
				foreach ( AddressModel address in _addresses )
				{
					_person.Addresses.Add(address);
				}

				firstNameTextBox.Text = "";
				lastNameTextBox.Text = "";
				_addresses.Clear();
				_ = firstNameTextBox.Focus();
			}
		}

		private bool IsDataValid()
		{
			bool output = true;

			if ( string.IsNullOrWhiteSpace(firstNameTextBox.Text) )
			{
				_ = MessageBox.Show("A First Name is required.", "First Name Blank", MessageBoxButton.OK, MessageBoxImage.Error);
				output = false;
			}

			if ( string.IsNullOrWhiteSpace(lastNameTextBox.Text) )
			{
				_ = MessageBox.Show("A Last Name is required.", "Last Name Blank", MessageBoxButton.OK, MessageBoxImage.Error);
				output = false;
			}

			if ( _addresses.Count < 1 )
			{
				_ = MessageBox.Show("At lease one Address is required.", "No Addresses", MessageBoxButton.OK, MessageBoxImage.Error);
				output = false;
			}

			return output;
		}
	}
}
