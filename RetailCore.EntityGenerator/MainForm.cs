
using Microsoft.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RetailCore.EntityGenerator
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
			InitializeData();
		}

		private void InitializeData()
		{
			checkedListBox.Items.Clear();
			groupBoxTables.Text = $"Tables({checkedListBox.Items.Count})";
			this.tbxConnectionString.Text = new string("Data Source=2212VIKASS0000L\\MSSQLSERVER2019;Initial Catalog=RetailCore;Persist Security Info=True;User ID=sa;Password=Microsoft#1234;TrustServerCertificate=True");
			this.tbxOutputDirectory.Text = string.Empty;
			this.btnSelectAll.Enabled = false;
			this.btnSelectDirectory.Enabled = false;
			this.btnGenerateEntities.Enabled = false;
			this.cbxDeleteContext.Checked = false;
			this.cbxDeleteContext.Enabled = false;
			this.btnReset.Enabled = false;
		}

		private void btnLoadTables_Click(object sender, EventArgs e)
		{
			string connectionString = tbxConnectionString.Text.Trim();

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.Open();

				DataTable schema = connection.GetSchema("Tables");

				checkedListBox.Items.Clear();
				foreach (DataRow row in schema.Rows)
				{
					string tableName = $"{row["TABLE_SCHEMA"]}.{row["TABLE_NAME"]}";
					checkedListBox.Items.Add(tableName);
				}
			}

			groupBoxTables.Text = $"Tables({checkedListBox.Items.Count})";
			this.btnSelectDirectory.Enabled = true;
			this.btnReset.Enabled = true;
			this.btnSelectAll.Enabled = checkedListBox.Items.Count > 0;
			this.cbxDeleteContext.Enabled = this.btnSelectAll.Enabled;
		}

		private void btnSelectAll_Click(object sender, EventArgs e)
		{
			bool allSelected = checkedListBox.CheckedItems.Count == checkedListBox.Items.Count;
			for (int i = 0; i < checkedListBox.Items.Count; i++)
			{
				checkedListBox.SetItemChecked(i, !allSelected);
			}
		}

		private void btnSelectDirectory_Click(object sender, EventArgs e)
		{
			using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
			{
				if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
				{
					this.tbxOutputDirectory.Text = folderBrowserDialog.SelectedPath;
					this.btnGenerateEntities.Enabled = true;
				}
			}
		}

		private void btnGenerateEntities_Click(object sender, EventArgs e)
		{
			string connectionString = tbxConnectionString.Text.Trim();
			string providerName = "Microsoft.EntityFrameworkCore.SqlServer";
			string outputDirectory = tbxOutputDirectory.Text.Trim();

			if (string.IsNullOrEmpty(outputDirectory))
			{
				MessageBox.Show("Please select an output directory.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			if (checkedListBox.CheckedItems.Count == 0)
			{
				DialogResult result = MessageBox.Show("No Table is selected, Do you want to generate entity for all the tables?", "Confirm Action", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (result == DialogResult.No)
				{
					return;
				}
			}

			string command = $"dotnet ef dbcontext scaffold \"{connectionString}\" {providerName} -o \"{outputDirectory}\"";

			StringBuilder selectedTables = new StringBuilder(string.Empty);

			foreach (var item in checkedListBox.CheckedItems)
			{
				selectedTables.Append($" --table {item}");
			}

			command = $"{command} {selectedTables.ToString()}";
			command = $"{command} --no-build --force";

			ExecuteCommand(command);
		}

		private void btnReset_Click(object sender, EventArgs e)
		{
			this.InitializeData();
		}

		private void ExecuteCommand(string command)
		{
			string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
			string projectDirectory = FindProjectDirectory(currentDirectory);

			if (projectDirectory != null)
			{
				WriteLog("Project Directory: " + projectDirectory);
			}
			else
			{
				MessageBox.Show($"No .csproj file found in the directory tree.", "Project Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			ProcessStartInfo processInfo = new ProcessStartInfo
			{
				FileName = "cmd.exe",
				Arguments = $"/c {command}",
				RedirectStandardOutput = true,
				RedirectStandardError = true,
				UseShellExecute = false,
				CreateNoWindow = true,
				WorkingDirectory = projectDirectory
			};

			using (Process process = new Process())
			{
				process.StartInfo = processInfo;
				process.Start();

				string output = process.StandardOutput.ReadToEnd();
				string error = process.StandardError.ReadToEnd();

				process.WaitForExit();

				if (string.IsNullOrWhiteSpace(error))
					WriteLog($"Generated entity models successfully");
				else
					WriteLog($"Output: {output}\nError: {error}");
			}

			PostProcessActivities();
		}

		private void PostProcessActivities()
		{
			var builder = new SqlConnectionStringBuilder(tbxConnectionString.Text.Trim());

			if (!cbxDeleteContext.Checked) return;

			if (!(string.IsNullOrWhiteSpace(builder.InitialCatalog) && string.IsNullOrWhiteSpace(tbxOutputDirectory.Text.Trim())))
			{
				string applicationContext = Path.Combine(tbxOutputDirectory.Text.Trim(), $"{builder.InitialCatalog}Context.cs");
				if (File.Exists(applicationContext))
				{
					System.IO.File.Delete(applicationContext);
					WriteLog($"Generated DbContext file deleted successfully");
				}
			}
		}

		private string FindProjectDirectory(string startDirectory)
		{
			string directory = startDirectory;

			while (!string.IsNullOrEmpty(directory))
			{
				// Check if any .csproj file exists in the current directory
				var csprojFile = Directory.GetFiles(directory, "*.csproj", SearchOption.TopDirectoryOnly);
				if (csprojFile.Length > 0)
				{
					return directory;
				}
				directory = Directory.GetParent(directory)?.FullName;
			}

			return null;
		}

		private void WriteLog(string message)
		{
			richTextBox.AppendText($"{DateTime.Now.ToLongTimeString()} {message}{Environment.NewLine}{Environment.NewLine}");
		}
	}
}
