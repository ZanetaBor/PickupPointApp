using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using PickupPointWinForms.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace PickupPointWinForms
{
    public partial class Form1 : Form
    {
        private readonly HttpClient _httpClient;

        public Form1()
        {
            InitializeComponent();
            _httpClient = new HttpClient(); // Inicjallization HttpClient
            LoadPickupPoints();
        }

        // load api
        private async Task LoadPickupPoints()
        {
        
            {
                try
                {
                    var response = await _httpClient.GetAsync("https://localhost:7226/api/pickuppoints");
                    response.EnsureSuccessStatusCode();

                    var data = await response.Content.ReadAsStringAsync();
                    var pickupPoints = JsonConvert.DeserializeObject<List<PickupPointClient>>(data);

                    dgvPickupPoints.DataSource = new BindingSource { DataSource = pickupPoints }; 
                    dgvPickupPoints.Columns["Id"].Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading data: {ex.Message}");
                }
            }
        }

        // add new newPickupPoint
        private async Task AddPickupPoint(PickupPointClient newPickupPoint)
         {
            using (var client = new HttpClient())
             {
                 try
                 {
                     var json = JsonConvert.SerializeObject(newPickupPoint);
                     var content = new StringContent(json, Encoding.UTF8, "application/json");

                     var response = await client.PostAsync("https://localhost:7226/api/pickuppoints", content);
                     response.EnsureSuccessStatusCode();
                     MessageBox.Show("new Pickup Point has been added. ");
                     await LoadPickupPoints(); 
                 }
                 catch (Exception ex)
                 {
                     MessageBox.Show($"Error adding pickup point: {ex.Message}");
                 }
             }
         }



        // edit PickupPoint
        private async Task EditPickupPoint(PickupPointClient selectedPoint)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var json = JsonConvert.SerializeObject(selectedPoint);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    var response = await client.PutAsync($"https://localhost:7226/api/pickuppoints/{selectedPoint.Id}", content);
                    response.EnsureSuccessStatusCode();
                    MessageBox.Show("Pickup Point has been updated.");

                    await LoadPickupPoints(); 
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error editing pickup point: {ex.Message}");
                }
            }
        }

        // delete pickupPoint
        private async Task DeletePickupPoint(int id)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var response = await client.DeleteAsync($"https://localhost:7226/api/pickuppoints/{id}");
                    response.EnsureSuccessStatusCode();
                    await LoadPickupPoints(); 
                    MessageBox.Show("Pickup Piont has been deleted.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting pickup point: {ex.Message}");
                }
            }
        }

        // Buttons event handling
        private async void Form1_Load(object sender, EventArgs e)
        {
            await LoadPickupPoints(); 
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            using (var form = new AddEditPickupPointForm()) // Open Add/Edit Pickup form
            {
                if (form.ShowDialog() == DialogResult.OK) 
                {
                    // new PickupPointClient
                    var newPickupPoint = new PickupPointClient
                    {
                        Name = form.PickupPointName,
                        Address = form.Address,
                        OpeningHours = form.OpeningHours,
                        ContactNumber = form.ContactNumber
                    };

                    await AddPickupPoint(form.PickupPoint);
                }
            }
        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvPickupPoints.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select the pickup point to edit.");
                return;
            }

            var selectedPoint = (PickupPointClient)dgvPickupPoints.SelectedRows[0].DataBoundItem;

            using (var form = new AddEditPickupPointForm("Edit Pickup Point", selectedPoint))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    // API update 
                    selectedPoint.Name = form.PickupPointName;
                    selectedPoint.Address = form.Address;
                    selectedPoint.OpeningHours = form.OpeningHours;
                    selectedPoint.ContactNumber = form.ContactNumber;
                }
                await EditPickupPoint(form.PickupPoint);
                
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvPickupPoints.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select the pickup point to delete.");
                return;
            }

            var selectedPoint = (PickupPointClient)dgvPickupPoints.SelectedRows[0].DataBoundItem;

            var confirm = MessageBox.Show($"Are you sure you want to delete {selectedPoint.Name}?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                await DeletePickupPoint(selectedPoint.Id);
            }
        }

    }
}