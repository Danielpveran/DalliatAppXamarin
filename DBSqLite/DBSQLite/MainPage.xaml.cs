using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using DBSQlite.Models;

namespace DBSQLite
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            LlenarDatos();
        }
        private void LimpiarControles()
        {
            txtVentaId.Text = "";
            txtApellidoVendedor.Text = "";
            txtNombreVendedor.Text = "";
            txtProductoVendido.Text = "";
            txtCantidadVendida.Text = "";
            dpFechaVenta.Date = DateTime.Today;
        }
        private async void btnActualizar_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtVentaId.Text))
            {
                Venta venta = new Venta()
                {
                    VentaId = Convert.ToInt32(txtVentaId.Text),
                    ApellidoVendedor = txtApellidoVendedor.Text,
                    NombreVendedor = txtNombreVendedor.Text,
                    ProductoVendido = txtProductoVendido.Text,
                    CantidadVendida = Convert.ToInt32(txtCantidadVendida.Text),
                    FechaVenta = dpFechaVenta.Date,
                };
                await App.SQLiteDB.GuardarVentaAsync(venta);
                await DisplayAlert("✅ Éxito", "La venta ha sido actualizada correctamente", "Aceptar");

                txtVentaId.IsVisible = false;
                btnActualizar.IsVisible = false;
                btnRegistrar.IsVisible = true;
                LimpiarControles();
                LlenarDatos();

            }
        }
        private async void btnEliminar_Clicked(object sender, EventArgs e)
        {
            var venta = await App.SQLiteDB.GetVentaByIdAsync(Convert.ToInt32(txtVentaId.Text));
            if (venta != null)
            {
                await App.SQLiteDB.DeleteVentaAsync(venta);
                await DisplayAlert("🗑️ Eliminado", "La venta ha sido eliminada correctamente", "Aceptar");
                LimpiarControles();
                LlenarDatos();

                txtVentaId.IsVisible = false;
                btnActualizar.IsVisible = false;
                btnEliminar.IsVisible = false;
                btnRegistrar.IsVisible = true;
                
            }
        }
        private async void lstVentas_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var obj = (Venta)e.SelectedItem;
            //agregamos la visibilidad de los botones
            btnRegistrar.IsVisible = false;
            txtVentaId.IsVisible = true;
            btnActualizar.IsVisible = true;
            btnEliminar.IsVisible = true;
            //Validacion para que no de error al seleccionar un item vacio
            if (!string.IsNullOrEmpty(obj.VentaId.ToString()))
            {
                var venta = await App.SQLiteDB.GetVentaByIdAsync(obj.VentaId);
                if (venta != null)
                {
                    txtVentaId.Text = venta.VentaId.ToString();
                    txtApellidoVendedor.Text = venta.ApellidoVendedor;
                    txtNombreVendedor.Text = venta.NombreVendedor;
                    txtProductoVendido.Text = venta.ProductoVendido;
                    txtCantidadVendida.Text = venta.CantidadVendida.ToString();
                    dpFechaVenta.Date = venta.FechaVenta;
                }
            }
        }
        private async void btnRegistrar_Clicked(object sender, EventArgs e)
        {
            if (validarDatos())
            {
                //Crear el objeto venta
                Venta nueva = new Venta
                {
                    ApellidoVendedor = txtApellidoVendedor.Text,
                    NombreVendedor = txtNombreVendedor.Text,
                    ProductoVendido = txtProductoVendido.Text,
                    CantidadVendida = int.Parse(txtCantidadVendida.Text),
                    FechaVenta = dpFechaVenta.Date,
                };
                //guardar la venta
                await App.SQLiteDB.GuardarVentaAsync(nueva);
                await DisplayAlert("✅ Registrado", "La venta ha sido registrada exitosamente", "Aceptar");
                LimpiarControles();
                LlenarDatos();
                //declaramos una varible

            }
            else
            {                 
                await DisplayAlert("⚠️ Error", "Por favor, complete todos los campos requeridos", "Entendido"); 
            }
        }
        public async void LlenarDatos()
        {
            var ventas = await App.SQLiteDB.GetVentasAsync();
            if (ventas != null)
            {
                lstVentas.ItemsSource = ventas;
            }
        }
        private bool validarDatos()
        {
            bool respuesta;
            if (string.IsNullOrEmpty(txtApellidoVendedor.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(txtNombreVendedor.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(txtProductoVendido.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(txtCantidadVendida.Text))
            {
                respuesta = false;
            }
            else if (dpFechaVenta.Date == default(DateTime))
            {
                respuesta = false;
            }
            else
            {
                respuesta = true;
            }
            return respuesta;
        }

    }
}
