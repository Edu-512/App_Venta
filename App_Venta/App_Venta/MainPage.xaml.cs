using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App_Venta
{
    public partial class MainPage : ContentPage
    {
        Dictionary<string, int> carrito = new Dictionary<string, int>();
        Dictionary<string, int> precios = new Dictionary<string, int>();

        public MainPage()
        {
            InitializeComponent();

            precios.Add("Tamborín", 1);
            precios.Add("Picafresa", 2);
            precios.Add("Bola Chamoy", 2);
            precios.Add("Hershey", 3);
            precios.Add("Nikolo", 5);
            precios.Add("Bocadín", 5);
            precios.Add("Mazapan", 5);
            precios.Add("Totis", 5);
            precios.Add("Kranky", 5);
            precios.Add("Barritas", 5);
            precios.Add("Pelón", 5);
            precios.Add("Paleta de luz", 7);
            precios.Add("Lucas", 9);
            precios.Add("Chocoretas", 5);


            var productList = new List<string>(precios.Keys);
            pickerPRoduct.ItemsSource = productList;
        }

        void AgregarButton_Clicked(System.Object sender, System.EventArgs e)
        {
            string nombreProducto = pickerPRoduct.SelectedItem.ToString();
            int cantidad = int.Parse(cantidadEntry.Text);

            if (carrito.ContainsKey(nombreProducto))
                carrito[nombreProducto] += cantidad;
            else
                carrito.Add(nombreProducto, cantidad);

            ActualizarTabla();
        }

        void BorrarButton_Clicked(System.Object sender, System.EventArgs e)
        {
            carrito.Clear();
            ActualizarTabla();
        }

        void CalcularTotalButton_Clicked(object sender, EventArgs e)
        {
            decimal totalCompra = 0;

            foreach (var item in carrito)
            {
                string producto = item.Key;
                int cantidad = item.Value;
                int precio = precios[producto];
                totalCompra += cantidad * precio;
            }

            totalCompraLabel.Text = $"Total: ${totalCompra:0.00}";
        }

        void ActualizarTabla()
        {
            carritoGrid.Children.Clear();

            int row = 0;
            foreach (var item in carrito)
            {
                string producto = item.Key;
                int cantidad = item.Value;
                int precio = precios[producto];
                carritoGrid.Children.Add(new Label { Text = producto }, 0, row);
                carritoGrid.Children.Add(new Label { Text = cantidad.ToString() }, 1, row);
                carritoGrid.Children.Add(new Label { Text = precio.ToString() }, 2, row);
                row++;
            }
        }
    }
}