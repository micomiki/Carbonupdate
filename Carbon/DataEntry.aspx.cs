using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace CarbonFootprintCalculator
{
    public partial class DataEntry : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Page load logic if needed
        }

        protected void btnSubmitTransport_Click(object sender, EventArgs e)
        {
            // Get user inputs from the Transport Emissions section
            string vehicleType = ddlVehicleType.SelectedValue;
            double distance = double.Parse(txtDistance.Text);
            string fuelType = ddlFuelType.SelectedValue;
            double fuelEfficiency = double.Parse(txtFuelEfficiency.Text);
            string entryDate = txtDateTransport.Text;

            // Perform calculation
            double transportEmissions = CalculateTransportEmissions(distance, fuelEfficiency);

            // Display result or save data to database
            // For example:

        // lblResult.Text = $"Carbon emissions for {vehicleType}: {transportEmissions} kg CO2 on {entryDate}";
        }

        protected void btnSubmitElectricity_Click(object sender, EventArgs e)
        {
            // Get user inputs from the Electricity Consumption section
            string energySource = ddlEnergySource.SelectedValue;
            double electricityUsage = double.Parse(txtElectricityUsage.Text);
            string entryDate = txtDateElectricity.Text;

            // Perform calculation
            double electricityEmissions = CalculateElectricityEmissions(electricityUsage);

            // Display result or save data to database
            // For example:
           // lblResult.Text = $"Carbon emissions from {energySource} electricity source: {electricityEmissions} kg CO2 on {entryDate}";
        }

        // Method to calculate emissions from transport
        private double CalculateTransportEmissions(double distance, double fuelEfficiency)
        {
            // Formula for emissions calculation: Emissions (kg) = (Distance (km) / Fuel Efficiency (km/L)) * Carbon Emission Factor (kg CO2/L)
            // Common carbon emission factors (kg CO2/L): Gasoline - 2.31, Diesel - 2.68, Petrol - 2.31, Electric - 0 (assuming no direct emissions)

            double carbonEmissionFactor = 0;
            switch (ddlFuelType.SelectedValue)
            {
                case "Gasoline":
                    carbonEmissionFactor = 2.31;
                    break;
                case "Diesel":
                    carbonEmissionFactor = 2.68;
                    break;
                case "Petrol":
                    carbonEmissionFactor = 2.31;
                    break;
                case "Electric":
                    // Assuming no direct emissions from electric vehicles
                    carbonEmissionFactor = 0;
                    break;
            }

            double emissions = (distance / fuelEfficiency) * carbonEmissionFactor;
            return emissions;
        }

        // Method to calculate emissions from electricity consumption
        private double CalculateElectricityEmissions(double electricityUsage)
        {
            // Formula for emissions calculation: Emissions (kg CO2) = Electricity Usage (kWh) * Carbon Intensity (kg CO2/kWh)
            // Common carbon intensity (kg CO2/kWh): Grid - 0.5, Solar - 0 (assuming no emissions), Wind - 0 (assuming no emissions)

            double carbonIntensity = 0;
            switch (ddlEnergySource.SelectedValue)
            {
                case "Grid":
                    carbonIntensity = 0.5;
                    break;
                case "Solar":
                    // Assuming no emissions from solar energy
                    carbonIntensity = 0;
                    break;
                case "Wind":
                    // Assuming no emissions from wind energy
                    carbonIntensity = 0;
                    break;
            }

            double emissions = electricityUsage * carbonIntensity;
            return emissions;
        }
    }
}
