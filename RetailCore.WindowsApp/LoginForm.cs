using RetailCore.BusinessObjects.BusinessObjects;
using RetailCore.Interfaces.DataAccess;
using RetailCore.ServiceContracts;
using RetailCore.Services;

namespace RetailCore.WindowsApp
{
	public partial class LoginForm : Form
	{
		private readonly IUserService _userService;

		private readonly MainForm _mainForm;

		public LoginForm(IUnitOfWork unitOfWork, MainForm mainForm, IUserService userService)
		{
			InitializeComponent();

			this._userService = userService;
			this._mainForm = mainForm;
		}

		private void btnLogin_Click(object sender, EventArgs e)
		{
			var existingUser = this._userService.VerifyUser(textBoxUsername.Text, textBoxPassword.Text);

			if (existingUser != null)
			{
				MessageBox.Show("User logged in successfully", "Administrator", MessageBoxButtons.OK, MessageBoxIcon.Information);
				this._mainForm.CurrentUser=existingUser.UserId;
				this._mainForm.Show();
				this.Hide();
				return;
			}

			MessageBox.Show("Unable to login", "Administrator", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		private void AddRoleForm_FormClosing(object sender, FormClosingEventArgs e)
		{

		}

		private void AddRoleForm_Load(object sender, EventArgs e)
		{
			this.textBoxUsername.Text = string.Empty;
			this.textBoxPassword.Text = string.Empty;
		}
	}
}
