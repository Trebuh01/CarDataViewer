using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;


namespace lab10
{
    public partial class Form1 : Form
    {
        private SortableSearchableBindingList<Car> myCarsBindingList;
        //private SortableBindingList<Car> myCarsBindingList;
        private BindingSource carBindingSource;

        public Form1()
        {
            InitializeComponent();

            List<Car> myCars = new List<Car>()
            {
                new Car("E250", new Engine(1.8, 204, "CGI"), 2009),
                new Car("E350", new Engine(3.5, 292, "CGI"), 2009),
                new Car("A6", new Engine(2.5, 187, "FSI"), 2012),
                new Car("A6", new Engine(2.8, 220, "FSI"), 2012),
                new Car("A6", new Engine(3.0, 295, "TFSI"), 2012),
                new Car("A6", new Engine(2.0, 175, "TDI"), 2011),
                new Car("A6", new Engine(3.0, 309, "TDI"), 2011),
                new Car("S6", new Engine(4.0, 414, "TFSI"), 2012),
                new Car("S8", new Engine(4.0, 513, "TFSI"), 2012)
            };

            myCarsBindingList = new SortableSearchableBindingList<Car>(myCars);
            carBindingSource = new BindingSource();
            carBindingSource.DataSource = myCarsBindingList;

            dataGridView1.DataSource = carBindingSource;

            // Query expression syntax
            var querySyntax = from car in myCars
                              where car.Model == "A6"
                              let engineType = car.Motor.Model == "TDI" ? "diesel" : "petrol"
                              group car by engineType into g
                              let avgHPPL = g.Average(car => car.Motor.HorsePower / car.Motor.Displacement)
                              orderby avgHPPL descending
                              select new { engineType = g.Key, avgHPPL };

            richTextBox1.AppendText("Query expression syntax:\n");
            foreach (var e in querySyntax)
            {
                richTextBox1.AppendText(e.engineType + ": " + e.avgHPPL + "\n");
            }

            // Method-based query syntax
            var methodSyntax = myCars
                .Where(car => car.Model == "A6")
                .GroupBy(car => car.Motor.Model == "TDI" ? "diesel" : "petrol")
                .Select(g => new
                {
                    engineType = g.Key,
                    avgHPPL = g.Average(car => car.Motor.HorsePower / car.Motor.Displacement)
                })
                .OrderByDescending(result => result.avgHPPL);

            richTextBox1.AppendText("Method-based query syntax:\n");
            foreach (var e in methodSyntax)
            {
                richTextBox1.AppendText(e.engineType + ": " + e.avgHPPL + "\n");
            }

            // Definitions for arg1, arg2, and arg3
            Func<Car, Car, int> arg1 = (car1, car2) =>
            {
                return car2.Motor.HorsePower.CompareTo(car1.Motor.HorsePower);
            };

            Predicate<Car> arg2 = delegate (Car car)
            {
                return car.Motor.Model == "TDI";
            };

            Action<Car> arg3 = delegate (Car car)
            {
                MessageBox.Show(car.Model + " " + car.Year + " " + car.Motor.Model + " " + car.Motor.HorsePower + "HP " + car.Motor.Displacement + "L");
            };

            // Sort cars by horse power in descending order
            myCars.Sort(new Comparison<Car>(arg1));

            // Find all TDI cars and display each in a MessageBox
            myCars.FindAll(arg2).ForEach(arg3);

            
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            myCarsBindingList.Add(new Car("NewModel", new Engine(2.0, 150, "NewEngine"), 2024));
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                myCarsBindingList.Remove((Car)dataGridView1.CurrentRow.DataBoundItem);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchModel = txtSearch.Text.ToLower();
            var searchResult = myCarsBindingList.Where(car => car.Model.ToLower().Contains(searchModel)).ToList();

            if (searchResult.Any())
            {
                MessageBox.Show($"Found {searchResult.Count} cars.");
            }
            else
            {
                MessageBox.Show("No cars found.");
            }
        }
        private void btnSearchModel_Click(object sender, EventArgs e)
        {
            string searchModel = txtSearchModel.Text;
            int index = myCarsBindingList.Find("Model", searchModel);
            if (index >= 0)
            {
                MessageBox.Show("Found " + searchModel + " at index: " + index);
            }
            else
            {
                MessageBox.Show(searchModel + " not found.");
            }
        }

        private void btnSearchYear_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtSearchYear.Text, out int searchYear))
            {
                int index = myCarsBindingList.Find("Year", searchYear);
                if (index >= 0)
                {
                    MessageBox.Show("Found car with year " + searchYear + " at index: " + index);
                }
                else
                {
                    MessageBox.Show("Car with year " + searchYear + " not found.");
                }
            }
            else
            {
                MessageBox.Show("Invalid year input.");
            }
        }
        private void btnSortModel_Click(object sender, EventArgs e)
        {
            myCarsBindingList.Sort("Model", ListSortDirection.Ascending);
            MessageBox.Show("Sorted by Model");
        }

        private void btnSortYear_Click(object sender, EventArgs e)
        {
            myCarsBindingList.Sort("Year", ListSortDirection.Ascending);
            MessageBox.Show("Sorted by Year");
        }
        private void toolStripComboBox1_Enter(object sender, EventArgs e)
        {
            toolStripComboBox1.Items.Clear();
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(Car));
            foreach (PropertyDescriptor property in properties)
            {
                if (property.PropertyType == typeof(string) || property.PropertyType == typeof(int))
                {
                    toolStripComboBox1.Items.Add(property.Name);
                }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            string selectedProperty = toolStripComboBox1.SelectedItem?.ToString();
            string searchValue = toolStripTextBox1.Text;

            if (string.IsNullOrEmpty(selectedProperty) || string.IsNullOrEmpty(searchValue))
            {
                MessageBox.Show("Please select a property and enter a search value.");
                return;
            }

            int index;
            if (int.TryParse(searchValue, out int intValue))
            {
                index = myCarsBindingList.Find(selectedProperty, intValue);
            }
            else
            {
                index = myCarsBindingList.Find(selectedProperty, searchValue);
            }

            if (index >= 0)
            {
                MessageBox.Show($"Found value at index: {index}");
                dataGridView1.CurrentCell = dataGridView1.Rows[index].Cells[0];
                dataGridView1.Rows[index].Selected = true;
            }
            else
            {
                MessageBox.Show("Value not found.");
            }
        }


    }
}
