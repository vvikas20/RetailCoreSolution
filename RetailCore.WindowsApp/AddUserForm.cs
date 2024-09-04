using RetailCore.BusinessObjects.BusinessObjects;
using RetailCore.Interfaces.DataAccess;
using RetailCore.ServiceContracts;

namespace RetailCore.WindowsApp
{
	public partial class AddUserForm : Form
	{
		private readonly IRoleService _roleService;
		private readonly IUserService _userService;


		public AddUserForm(IRoleService roleService, IUserService userService)
		{
			InitializeComponent();

			this._roleService = roleService;
			this._userService = userService;
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			var adminUser = _userService.GetAdminUser();

			this._userService.AddUser(new User
			{
				UserId = Guid.Parse(this.textBoxUserId.Text),
				Username = tbxUsername.Text,
				RoleId = Guid.Parse(Convert.ToString(this.cbxRole.SelectedValue)),
				FirstName = tbxFirstName.Text,
				MiddleName = tbxMName.Text,
				LastName = tbxLName.Text,
				Email = tbxEmail.Text,
				Password = tbxPassword.Text,
				IsActive = checkBoxActive.Checked,
				Verified = checkBoxVerified.Checked,
				CreatedBy = adminUser.UserId,
				CreatedOn = DateTime.Now
			});
			this.Close();
		}

		private void AddRoleForm_FormClosing(object sender, FormClosingEventArgs e)
		{

		}

		private void AddRoleForm_Load(object sender, EventArgs e)
		{
			this.textBoxUserId.Text = Guid.NewGuid().ToString();

			this.tbxUsername.Text = tbxFirstName.Text = tbxMName.Text = tbxLName.Text = tbxPassword.Text = tbxEmail.Text = string.Empty;
			checkBoxActive.Checked = checkBoxVerified.Checked = true;

			this.cbxRole.DataSource = this._roleService.GetRoles();
			this.cbxRole.DisplayMember = "RoleDisplayName";
			this.cbxRole.ValueMember = "RoleId";
		}
	}
}
