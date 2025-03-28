namespace Proyecto
{
    public partial class Form1 : Form
    {
        private List<(string, int)> inventory = new List<(string, int)>();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            if (int.TryParse(textBox2.Text, out int quantity) && !string.IsNullOrWhiteSpace(name))
            {
                inventory.Add((name, quantity));
                UpdateInventory();
                textBox1.Text = string.Empty;
                textBox2.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("Ingrese un nombre válido y una cantidad numérica.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var index = listBox1.SelectedIndex;
            listBox1.Items.RemoveAt(index);
        }

        private void UpdateInventory()
        {
            inventory = inventory.OrderBy(p => p.Item1).ToList();
            listBox1.Items.Clear();
            foreach (var item in inventory)
            {
                listBox1.Items.Add($"{item.Item1}: {item.Item2}");
            }
        }
    }
}