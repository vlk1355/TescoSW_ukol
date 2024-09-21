using System.Diagnostics;
using System.Globalization;
using System.Runtime.Intrinsics.Arm;
using System.Xml.Linq;
using TescoSw_ProgramatorBE.Zaznamy;

namespace TescoSw_ProgramatorBE
{
    public partial class Form1 : Form
    {
        List<Zaznam> ZaznamyGlobal = new List<Zaznam>();
        private string xmlFilePath = string.Empty;

        public Form1()
        {
            InitializeComponent();
        }

        // Metoda pro ziskani vikendu
        DateTime GetWeekendStart(DateTime date)
        {
            return date.DayOfWeek == DayOfWeek.Sunday ? date.AddDays(-1) : date;
        }

        public void ReadZaznamyFromXml()
        {
            Debug.WriteLine(xmlFilePath);
            if (xmlFilePath == string.Empty)
            {
                Debug.WriteLine("No Xml file set");
                return;
            }

            // Load the XML document
            XDocument xmlDoc = XDocument.Load(xmlFilePath);
            ZaznamyGlobal.Clear();

            // Parse the XML and create Zaznam objects
            foreach (var carElement in xmlDoc.Descendants("Car"))
            {
                string model = carElement.Element("ModelName")?.Value;
                DateTime saleDate = DateTime.Parse(carElement.Element("SaleDate")?.Value);
                string priceString = carElement.Element("Price")?.Value.Replace(".", "").Replace(",-", "");
                double price = double.Parse(priceString);
                double dph = double.Parse(carElement.Element("DPH")?.Value);

                // Create a new Zaznam and add it to the list
                Zaznam zaznam = new Zaznam(model, saleDate, price, dph);
                ZaznamyGlobal.Add(zaznam);
            }
            ZaznamyGlobal = ZaznamyGlobal.OrderBy(x => x.Model).ToList();
        }

        public void VyberXmlSoubor()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "";
                openFileDialog.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Get the path of the selected file
                    xmlFilePath = (string)openFileDialog.FileName;
                    return;
                }
            }

            xmlFilePath = string.Empty; // If no file is selected or dialog is canceled
        }

        private void FindXML_Btn_Click(object sender, EventArgs e)
        {
            VyberXmlSoubor();
            ReadZaznamyFromXml();
        }

        private void ParseData_Btn_Click(object sender, EventArgs e)
        {
            ShowInfo(ZaznamyGlobal);
        }

        private void ShowInfo(List<Zaznam> Zaznams)
        {
            listView1.Columns.Clear();
            listView1.Columns.Add("Model").Width = 100;
            listView1.Columns.Add("Datum prodeje").Width = 100;
            listView1.Columns.Add("Cena s DPH").Width = 100;
            listView1.Columns.Add("DPH").Width = 50;
            listView1.View = View.Details;
            listView1.Items.Clear();

            foreach (Zaznam zaznam in Zaznams)
            {
                //add item to listview
                ListViewItem item = new ListViewItem(zaznam.Model);
                item.SubItems.Add(zaznam.DatumProdeje.ToString().Split(" ")[0]);
                item.SubItems.Add(zaznam.cena.ToString());
                item.SubItems.Add(zaznam.Dph.ToString());
                listView1.Items.Add(item);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Zaznam> WeekendReport = ZaznamyGlobal.Where(x => (x.DatumProdeje.DayOfWeek == DayOfWeek.Saturday) || (x.DatumProdeje.DayOfWeek == DayOfWeek.Sunday)).ToList();
            WeekendReport = WeekendReport.OrderBy(x => x.DatumProdeje.DayOfWeek).ToList();
            var mergedWeekendReport = WeekendReport
                .GroupBy(x => new { x.Model, WeekendStart = GetWeekendStart(x.DatumProdeje) })
                .Select(group =>
                {
                    double totalCena = group.Sum(x => x.cena); // Total price for the group
                    double totalDph = group.Sum(x => (x.Dph / 100) * x.cena); // Total DPH amount (not percentage)

                    return new Zaznam(group.Key.Model, group.Min(x => x.DatumProdeje), totalCena - totalDph, totalDph);
                })
                .ToList();



            listView1.Columns.Clear();
            listView1.Columns.Add("Model").Width = 100;
            listView1.Columns.Add("Cena").Width = 1000;
            listView1.View = View.Tile;
            listView1.FullRowSelect = true;
            listView1.Items.Clear();

            foreach (Zaznam zaznam in mergedWeekendReport)
            {
                //add item to listview
                ListViewItem item = new ListViewItem(zaznam.Model);
                item.SubItems.Add($"{zaznam.cena.ToString()}     {zaznam.Dph.ToString()}");
                listView1.Items.Add(item);
            }
        }

        private void FilterBTN_Click(object sender, EventArgs e)
        {
            List<Zaznam> FilterdZaznamy = ZaznamyGlobal;
            if(ModelTB.Text is not null || ModelTB.Text != "")
            {
                FilterdZaznamy = FilterdZaznamy.Where(x => x.Model.Contains(ModelTB.Text)).ToList();
            }

            try
            {
                DateTime datum = DateTime.Parse(DatumTB.Text);
                FilterdZaznamy = FilterdZaznamy.Where(x => x.DatumProdeje.Equals(datum)).ToList();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Cant parse value.\n{ex}");
            }


            int cena = 0;
            try
            {
                cena = int.Parse(CenaTB.Text);
            }
            catch { }
            int filterCeny = CenaCB.SelectedIndex;
            switch(filterCeny)
            {
                case 0:
                    FilterdZaznamy = FilterdZaznamy.Where(x => x.cena > cena).ToList();
                    break;
                case 1:
                    FilterdZaznamy = FilterdZaznamy.Where(x => x.cena < cena).ToList();
                    break;
                case 2:
                    FilterdZaznamy = FilterdZaznamy.Where(x => x.cena == cena).ToList();
                    break;
                default:
                    break;
            }
            ShowInfo(FilterdZaznamy);
        }

    }
}
