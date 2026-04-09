using System.Text;
using System.Text.Json;
using System.Xml.Serialization;

namespace HW_2
{
    public partial class BotanicalGardenForm : Form
    {
        public BotanicalGardenForm()
        {
            InitializeComponent();
            ConfigurePlantsTable();
            ShowGarden(new BotanicalGardenFile());
            LoadGardenImage();
        }

        private void LoadXmlButton_Click(object sender, EventArgs e)
        {
            openGardenFileDialog.Filter = "XML файлы (*.xml)|*.xml|Все файлы (*.*)|*.*";

            if (openGardenFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    ShowGarden(DeserializeXml(openGardenFileDialog.FileName));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        this,
                        $"Не удалось десериализовать файл.\n\n{ex.Message}",
                        "Ошибка загрузки",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void LoadJsonButton_Click(object sender, EventArgs e)
        {
            openGardenFileDialog.Filter = "JSON файлы (*.json)|*.json|Все файлы (*.*)|*.*";

            if (openGardenFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    ShowGarden(DeserializeJson(openGardenFileDialog.FileName));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        this,
                        $"Не удалось десериализовать файл.\n\n{ex.Message}",
                        "Ошибка загрузки",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void OpenDetailsButton_Click(object sender, EventArgs e)
        {
            OpenSelectedPlantDetails();
        }

        private void PlantTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node?.Tag is not GardenPlant plant)
            {
                return;
            }

            SelectPlantTableRow(plant);
            openDetailsButton.Enabled = true;
        }

        private void PlantsDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (plantsDataGridView.CurrentRow?.Tag is GardenPlant)
            {
                openDetailsButton.Enabled = true;
            }
        }

        private BotanicalGardenFile DeserializeXml(string filePath)
        {
            XmlSerializer serializer = new(typeof(BotanicalGardenFile));

            using FileStream fileStream = File.OpenRead(filePath);
            return (BotanicalGardenFile?)serializer.Deserialize(fileStream) ?? new BotanicalGardenFile();
        }

        private BotanicalGardenFile DeserializeJson(string filePath)
        {
            using FileStream fileStream = File.OpenRead(filePath);
            return JsonSerializer.Deserialize<BotanicalGardenFile>(fileStream) ?? new BotanicalGardenFile();
        }

        private void ConfigurePlantsTable()
        {
            plantsDataGridView.Columns.Clear();
            plantsDataGridView.Columns.Add("NameColumn", "Название");
            plantsDataGridView.Columns.Add("LatinNameColumn", "Латинское название");
            plantsDataGridView.Columns.Add("FamilyColumn", "Семейство");
            plantsDataGridView.Columns.Add("PlantTypeColumn", "Тип");
            plantsDataGridView.Columns.Add("AgeColumn", "Возраст");
            plantsDataGridView.Columns.Add("LocationColumn", "Место");
            plantsDataGridView.Columns.Add("CareColumn", "Уход");
        }

        private void ShowGarden(BotanicalGardenFile garden)
        {
            plantTreeView.BeginUpdate();
            plantsDataGridView.Rows.Clear();
            plantTreeView.Nodes.Clear();

            TreeNode rootNode = new("Ботанический сад");
            plantTreeView.Nodes.Add(rootNode);

            foreach (GardenPlant plant in garden.Plants)
            {
                AddPlantToTree(rootNode, plant);
                AddPlantToTable(plant);
            }

            rootNode.Expand();
            plantTreeView.EndUpdate();

            if (garden.Plants.Count > 0)
            {
                plantTreeView.SelectedNode = rootNode.Nodes[0];
                plantsDataGridView.Rows[0].Selected = true;
                plantsDataGridView.CurrentCell = plantsDataGridView.Rows[0].Cells[0];
                openDetailsButton.Enabled = true;
            }
            else
            {
                openDetailsButton.Enabled = false;
            }
        }

        private void AddPlantToTree(TreeNode rootNode, GardenPlant plant)
        {
            TreeNode plantNode = new(plant.Name)
            {
                Tag = plant
            };

            plantNode.Nodes.Add($"Латинское название: {plant.LatinName}");
            plantNode.Nodes.Add($"Семейство: {plant.Family}");
            plantNode.Nodes.Add($"Тип: {plant.PlantType}");
            plantNode.Nodes.Add($"Возраст: {plant.AgeYears} лет");

            TreeNode locationNode = new("Расположение")
            {
                Tag = plant.Location
            };
            locationNode.Nodes.Add($"Оранжерея: {plant.Location.Greenhouse}");
            locationNode.Nodes.Add($"Секция: {plant.Location.Section}");
            locationNode.Nodes.Add($"Грядка: {plant.Location.BedNumber}");
            plantNode.Nodes.Add(locationNode);

            TreeNode careNode = new("Уход")
            {
                Tag = plant.Care
            };
            careNode.Nodes.Add($"Полив: {plant.Care.Watering}");
            careNode.Nodes.Add($"Свет: {plant.Care.Light}");
            careNode.Nodes.Add($"Температура: {plant.Care.Temperature}");
            careNode.Nodes.Add($"Почва: {plant.Care.Soil}");
            plantNode.Nodes.Add(careNode);

            rootNode.Nodes.Add(plantNode);
        }

        private void AddPlantToTable(GardenPlant plant)
        {
            int rowIndex = plantsDataGridView.Rows.Add(
                plant.Name,
                plant.LatinName,
                plant.Family,
                plant.PlantType,
                plant.AgeYears,
                $"{plant.Location.Greenhouse}, {plant.Location.Section}",
                $"{plant.Care.Watering}, {plant.Care.Light}");

            plantsDataGridView.Rows[rowIndex].Tag = plant;
        }

        private void SelectPlantTableRow(GardenPlant plant)
        {
            foreach (DataGridViewRow row in plantsDataGridView.Rows)
            {
                if (ReferenceEquals(row.Tag, plant))
                {
                    row.Selected = true;
                    plantsDataGridView.CurrentCell = row.Cells[0];
                    return;
                }
            }
        }

        private void OpenSelectedPlantDetails()
        {
            GardenPlant? plant = null;

            if (plantsDataGridView.CurrentRow?.Tag is GardenPlant plantFromTable)
            {
                plant = plantFromTable;
            }
            else if (plantTreeView.SelectedNode?.Tag is GardenPlant plantFromTree)
            {
                plant = plantFromTree;
            }

            if (plant is null)
            {
                MessageBox.Show(
                    this,
                    "Сначала выберите растение в дереве или таблице.",
                    "Растение не выбрано",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            using PlantDetailsForm detailsForm = new(plant, FormatPlant(plant));
            detailsForm.ShowDialog(this);
        }

        private string FormatPlant(GardenPlant plant)
        {
            StringBuilder builder = new();
            builder.AppendLine($"Название: {plant.Name}");
            builder.AppendLine($"Латинское название: {plant.LatinName}");
            builder.AppendLine($"Семейство: {plant.Family}");
            builder.AppendLine($"Тип: {plant.PlantType}");
            builder.AppendLine($"Возраст: {plant.AgeYears} лет");
            builder.AppendLine($"Редкое растение: {(plant.IsRare ? "да" : "нет")}");
            builder.AppendLine();
            builder.AppendLine("Расположение:");
            builder.AppendLine($"  Оранжерея: {plant.Location.Greenhouse}");
            builder.AppendLine($"  Секция: {plant.Location.Section}");
            builder.AppendLine($"  Грядка: {plant.Location.BedNumber}");
            builder.AppendLine();
            builder.AppendLine("Уход:");
            builder.AppendLine($"  Полив: {plant.Care.Watering}");
            builder.AppendLine($"  Освещение: {plant.Care.Light}");
            builder.AppendLine($"  Температура: {plant.Care.Temperature}");
            builder.AppendLine($"  Почва: {plant.Care.Soil}");
            builder.AppendLine();
            builder.AppendLine("Описание:");
            builder.AppendLine(plant.Description);

            return builder.ToString();
        }

        private void LoadGardenImage()
        {
            string imagePath = Path.Combine(AppContext.BaseDirectory, "Assets", "botanical-garden.png");

            if (File.Exists(imagePath))
            {
                plantPictureBox.Image = Image.FromFile(imagePath);
            }
        }
    }
}
