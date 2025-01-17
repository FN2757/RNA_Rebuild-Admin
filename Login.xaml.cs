﻿using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace RNA_Rebuild_Admin
{
	/// <summary>
	/// Interaction logic for Login.xaml
	/// </summary>
	public partial class Login : Window
	{
		public event LoginDelegate OnLoginning;
		public Login()
		{
			InitializeComponent();
		}
		private bool flag = false;
		private void Button_Click(object sender, RoutedEventArgs e)
		{
			if (OnLoginning.Invoke(LoginBox.Text, TB_pass.Text)) { flag = true; Close(); }
			else MessageBox.Show("Something went wrong!");
		}

		private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if (!flag) e.Cancel = true;
		}

		private void CheckBox_Checked(object sender, RoutedEventArgs e)
		{
			passbox.Visibility = Visibility.Collapsed;
			TB_pass.Visibility = Visibility.Visible;
		}

		private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
		{
			passbox.Visibility = Visibility.Visible;
			TB_pass.Visibility = Visibility.Collapsed;
		}

		private void passbox_PasswordChanged(object sender, RoutedEventArgs e)
		{
			TB_pass.Text = ((PasswordBox)sender).Password;
		}
	}
}
