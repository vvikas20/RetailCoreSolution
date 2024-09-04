using RetailCore.ServiceContracts;

namespace RetailCore.WindowsApp
{
	public partial class MainForm : Form
	{

		private readonly IRoleService _roleService;
		private readonly IRoleLevelService _roleLevelService;
		private readonly IUserService _userService;

		private readonly AddUserForm addUserForm;
		private readonly AddRoleLevelForm addRoleLevelForm;
		private readonly AddRoleForm addRoleForm;

		public Guid CurrentUser { get; set; }

		public MainForm(IRoleService roleService, IRoleLevelService roleLevelService, IUserService userService, AddUserForm addUserForm, AddRoleLevelForm addRoleLevelForm, AddRoleForm addRoleForm)
		{
			InitializeComponent();

			this._roleService = roleService;
			this._roleLevelService = roleLevelService;
			this._userService = userService;

			this.addUserForm = addUserForm;
			this.addRoleLevelForm = addRoleLevelForm;
			this.addRoleForm = addRoleForm;
		}

		private void SetupUI()
		{
			var userCount = this._userService.GetUserCount();
			var roleCount = this._roleService.GetRoleCount();
			var roleLevelCount = this._roleLevelService.GetRoleLevelCount();

			btnAddUser.Enabled = !(buttonAddDefaultUser.Enabled = userCount == 0) && roleCount > 0;

			tabControl1.TabPages["tabPageRoles"].Enabled = userCount != 0 && roleLevelCount > 0;
			tabControl1.TabPages["tabPageRoleLevels"].Enabled = userCount != 0;



			this.dataGridViewUsers.DataSource = this._userService.GetUsers();
			this.dataGridViewRoleLevels.DataSource = this._roleLevelService.GetRoleLevels();
			this.dataGridViewRoles.DataSource = this._roleService.GetRoles();

			var userData = this._userService.GetUserById(CurrentUser);
			if (userData != null)
			{
				var userRole = userData.UserRoles.Single();

				textBoxUserId.Text = userData.UserId.ToString();
				textBoxUsername.Text = userData.Username;
				textBoxRole.Text = $"{userRole.Role.RoleDisplayName} [{userRole.Role.RoleLevel.RoleLevelDisplayName}]";
				textBoxFName.Text = userData.FirstName;
				textBoxMName.Text = userData.MiddleName;
				textBoxLName.Text = userData.LastName;
				textBoxEmail.Text = userData.Email;
				checkBox1.Checked = userData.IsActive;
				checkBox2.Checked = userData.Verified;
				textBoxCreatedBy.Text = $"{userData.CreatedByNavigation?.FirstName} {userData.CreatedByNavigation?.LastName}";
				textBoxCreatedDate.Text = userData.CreatedOn.ToString();
				textBoxModifiedBy.Text = $"{userData.ModifiedByNavigation?.FirstName} {userData.ModifiedByNavigation?.LastName}";
				textBoxModifiedDate.Text = userData.ModifiedOn.ToString();
			}
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			this.SetupUI();
		}

		private void btnAddRole_Click(object sender, EventArgs e)
		{
			addRoleForm.ShowDialog();
			SetupUI();
		}

		private void buttonAddRoleLevel_Click(object sender, EventArgs e)
		{
			addRoleLevelForm.ShowDialog();
			SetupUI();
		}

		private void btnAddUser_Click(object sender, EventArgs e)
		{
			addUserForm.ShowDialog();
			SetupUI();
		}

		private void buttonAddDefaultUser_Click(object sender, EventArgs e)
		{
			Guid superAdminRoleLevelId = Guid.NewGuid();
			Guid superAdminRoleId = Guid.NewGuid();
			Guid superAmdinUserId = Guid.NewGuid();

			this._userService.AddUser(new BusinessObjects.BusinessObjects.User
			{
				UserId = superAmdinUserId,
				Username = "sa",
				FirstName = "Administrator",
				MiddleName = string.Empty,
				LastName = string.Empty,
				Email = "vsvikassingh49@gmail.com",
				Password = "Microsoft#1234",
				IsActive = true,
				Verified = true
			});

			this._roleLevelService.AddRoleLevel(new BusinessObjects.BusinessObjects.RoleLevel
			{
				RoleLevelId = superAdminRoleLevelId,
				RoleLevelName = "RL_SUPER_ADMIN",
				RoleLevelDisplayName = "SUPER ADMIN",
				CreatedBy = superAmdinUserId,
				CreatedOn = DateTime.Now,
			});

			this._roleService.AddRole(new BusinessObjects.BusinessObjects.Role
			{
				RoleId = superAdminRoleId,
				RoleName = "R_SUPER_ADMIN",
				RoleDisplayName = "SUPER ADMIN",
				RoleLevelId = superAdminRoleLevelId,
				CreatedBy = superAmdinUserId,
				CreatedDate = DateTime.Now,
			});

			this._userService.AddUserRole(superAmdinUserId, superAdminRoleId);
			this.CurrentUser = superAmdinUserId;

			MessageBox.Show("Administrator added successfully", "Administrator", MessageBoxButtons.OK, MessageBoxIcon.Information);
			this.SetupUI();
		}
	}
}
