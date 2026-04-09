namespace HW_2;

public class PlantDetailsForm : Form
{
    public PlantDetailsForm(GardenPlant plant, string detailsText)
    {
        Text = $"Карточка растения - {plant.Name}";
        StartPosition = FormStartPosition.CenterParent;
        MinimumSize = new Size(500, 400);
        Size = new Size(650, 520);

        TextBox plantDetailsTextBox = new()
        {
            Dock = DockStyle.Fill,
            Multiline = true,
            ReadOnly = true,
            ScrollBars = ScrollBars.Vertical,
            Text = detailsText
        };

        Controls.Add(plantDetailsTextBox);
    }
}
