using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace EmployeeDirectory
{
    public class Employee
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public string Department { get; set; }
    }

    public partial class Form1 : Form
    {
        private Button btnAdd;
        private Button btnList;
        private TextBox txtName;
        private TextBox txtPosition;
        private TextBox txtDepartment;
        private ListBox lstEmployees;
        private List<Employee> employeesList = new List<Employee>(); // To store employee information

        public Form1()
        {
            // Set up the form
            this.Text = "Employee Directory";
            this.Size = new System.Drawing.Size(375, 240); // Adjusted the form size

            // Make the form size unchangeable
            this.FormBorderStyle = FormBorderStyle.FixedSingle; // Set the form border style to FixedSingle

            // Creating labels
            Label lblName = new Label();
            lblName.Text = "Name:";
            lblName.Location = new System.Drawing.Point(20, 20);
            lblName.Font = new System.Drawing.Font("Segoe UI", 12, System.Drawing.FontStyle.Bold);
            lblName.ForeColor = System.Drawing.Color.DarkBlue;

            Label lblPosition = new Label();
            lblPosition.Text = "Position:";
            lblPosition.Location = new System.Drawing.Point(20, 60);
            lblPosition.Font = new System.Drawing.Font("Segoe UI", 12, System.Drawing.FontStyle.Bold);
            lblPosition.ForeColor = System.Drawing.Color.DarkBlue;

            Label lblDepartment = new Label();
            lblDepartment.Text = "Department:";
            lblDepartment.Location = new System.Drawing.Point(20, 100);
            lblDepartment.Font = new System.Drawing.Font("Segoe UI", 12, System.Drawing.FontStyle.Bold);
            lblDepartment.ForeColor = System.Drawing.Color.DarkBlue;
            lblDepartment.AutoSize = true; // Auto-size the label

            // Creating text boxes
            txtName = new TextBox();
            txtName.Location = new System.Drawing.Point(140, 20);
            txtName.Size = new System.Drawing.Size(200, 30);
            txtName.Font = new System.Drawing.Font("Segoe UI", 12);
            txtName.BorderStyle = BorderStyle.None;

            txtPosition = new TextBox();
            txtPosition.Location = new System.Drawing.Point(140, 60);
            txtPosition.Size = new System.Drawing.Size(200, 30);
            txtPosition.Font = new System.Drawing.Font("Segoe UI", 12);
            txtPosition.BorderStyle = BorderStyle.None;

            txtDepartment = new TextBox();
            txtDepartment.Location = new System.Drawing.Point(140, 100);
            txtDepartment.Size = new System.Drawing.Size(200, 30);
            txtDepartment.Font = new System.Drawing.Font("Segoe UI", 12);
            txtDepartment.BorderStyle = BorderStyle.None;

            // Creating buttons
            btnAdd = new Button();
            btnAdd.Text = "Add Employee";
            btnAdd.Location = new System.Drawing.Point(20, 140);
            btnAdd.Font = new System.Drawing.Font("Segoe UI", 12, System.Drawing.FontStyle.Bold);
            btnAdd.BackColor = System.Drawing.Color.DarkGreen;
            btnAdd.ForeColor = System.Drawing.Color.White;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Size = new System.Drawing.Size(150, 40);

            btnList = new Button();
            btnList.Text = "List Employees";
            btnList.Location = new System.Drawing.Point(190, 140);
            btnList.Font = new System.Drawing.Font("Segoe UI", 12, System.Drawing.FontStyle.Bold);
            btnList.BackColor = System.Drawing.Color.SteelBlue;
            btnList.ForeColor = System.Drawing.Color.White;
            btnList.FlatStyle = FlatStyle.Flat;
            btnList.Size = new System.Drawing.Size(150, 40);

            // Hook up event handlers for button clicks
            btnAdd.Click += BtnAdd_Click;
            btnList.Click += BtnList_Click;

            // Add controls to the form
            this.Controls.Add(lblName);
            this.Controls.Add(lblPosition);
            this.Controls.Add(lblDepartment);
            this.Controls.Add(txtName);
            this.Controls.Add(txtPosition);
            this.Controls.Add(txtDepartment);
            this.Controls.Add(btnAdd);
            this.Controls.Add(btnList);
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            // Get user input
            string name = txtName.Text;
            string position = txtPosition.Text;
            string department = txtDepartment.Text;

            // Check if any of the text boxes are empty
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(position) || string.IsNullOrWhiteSpace(department))
            {
                // Show an error pop-up notification
                MessageBox.Show("Please complete the required fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // All fields are filled, so proceed to add the employee

                // Create an Employee object and add it to the list
                Employee employee = new Employee { Name = name, Position = position, Department = department };
                employeesList.Add(employee);

                // Show a success pop-up notification
                MessageBox.Show("Employee successfully added", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear text boxes
                txtName.Text = "";
                txtPosition.Text = "";
                txtDepartment.Text = "";
            }
        }

        private void BtnList_Click(object sender, EventArgs e)
        {
            // Create a message to display employee information
            string employeeListMessage = "List of Employees:\n\n";

            foreach (var employee in employeesList)
            {
                employeeListMessage += $"Name: {employee.Name}\n";
                employeeListMessage += $"Position: {employee.Position}\n";
                employeeListMessage += $"Department: {employee.Department}\n\n";
            }

            // Show a pop-up notification with the employee list
            MessageBox.Show(employeeListMessage, "List of Employees", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
