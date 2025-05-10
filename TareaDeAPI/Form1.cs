using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using TareaDeAPI.Models;

namespace TareaDeAPI
{
    public partial class Form1 : Form
    {
        private static readonly HttpClient httpClient = new HttpClient();

        public Form1()
        {
            InitializeComponent();
        }

        private async Task<Pokemon> GetPokemonAsync(string nombre)
        {
            string url = $"https://pokeapi.co/api/v2/pokemon/{nombre.ToLower()}";
            var response = await httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                throw new Exception("Pokémon no encontrado o error en la API.");

            string json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Pokemon>(json);
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            string nombre = txtBuscar.Text.Trim();

            if (string.IsNullOrEmpty(nombre))
            {
                MessageBox.Show("Ingresa el nombre de un Pokémon.");
                return;
            }

            try
            {
                btnBuscar.Enabled = false;
                lblNombre.Text = "Cargando...";
                lblTipo.Text = "Tipo:";
                lblDatos.Text = "Altura y Peso:";
                picPokemon.Image = null;

                var pokemon = await GetPokemonAsync(nombre);

                lblNombre.Text = $"Nombre: {pokemon.Name.ToUpper()}";

                string tipos = string.Join(", ", pokemon.Types.Select(t => t.Type.Name.ToUpper()));
                lblTipo.Text = $"Tipo: {tipos}";
                lblDatos.Text = $"Altura: {pokemon.Height} | Peso: {pokemon.Weight}";

                if (!string.IsNullOrEmpty(pokemon.Sprites.FrontDefault))
                {
                    picPokemon.Load(pokemon.Sprites.FrontDefault);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                lblNombre.Text = "Nombre:";
            }
            finally
            {
                btnBuscar.Enabled = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}