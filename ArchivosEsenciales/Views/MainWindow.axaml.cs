using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using System.Collections.Generic;
using System;

namespace ArchivosEsenciales.Views;

public partial class MainWindow : Window
{
	public MainWindow()
	{
		InitializeComponent();
	}

	private void Window_KeyDown(object? sender, KeyEventArgs e)
	{
		//if (e.Key == Key.Escape)
		//{
		//	Close();
		//}
		if (e.Key == Key.Q && e.KeyModifiers.HasFlag(KeyModifiers.Control))
		{
			Close();
		}
	}
}
