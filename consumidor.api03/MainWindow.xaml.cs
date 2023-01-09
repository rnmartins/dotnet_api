using consumidor.api02;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Windows;


namespace consumidor.api03
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAtualizar_Click(object sender, RoutedEventArgs e)
        {
            string url = "https://localhost:7146/";
            string endpoint = url + "api/TarefaItems";
            IEnumerable<Trabalho> listaDeTarefas = endpoint.GetJsonAsync<IEnumerable<Trabalho>>().Result;

            dtgGrid.ItemsSource= listaDeTarefas;
        }
    }
}
