using RetailCore.ServiceContracts;
using System.Data;

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

			DataTable usersDatatable = new DataTable();
			usersDatatable.Columns.Add("UserId");
			usersDatatable.Columns.Add("FirstName");
			usersDatatable.Columns.Add("LastName");
			usersDatatable.Columns.Add("Username");
			usersDatatable.Columns.Add("Email");
			usersDatatable.Columns.Add("IsDeleted");
			usersDatatable.Columns.Add("CreatedDate");
			usersDatatable.Columns.Add("ModifiedDate");

			foreach (var user in this._userService.GetUsers())
			{
				usersDatatable.Rows.Add(user.UserId, user.FirstName, user.LastName, user.Username, user.Email, user.IsDeleted, user.CreatedDate, user.ModifiedDate);
			}

			this.dataGridViewUsers.DataSource = usersDatatable;

			DataTable roleLevelDatatable = new DataTable();
			roleLevelDatatable.Columns.Add("RoleLevelId");
			roleLevelDatatable.Columns.Add("RoleLevelName");
			roleLevelDatatable.Columns.Add("IsDeleted");
			roleLevelDatatable.Columns.Add("CreatedDate");
			roleLevelDatatable.Columns.Add("ModifiedDate");

			foreach (var roleLevel in this._roleLevelService.GetRoleLevels())
			{
				roleLevelDatatable.Rows.Add(roleLevel.RoleLevelId, roleLevel.RoleLevelName, roleLevel.IsDeleted, roleLevel.CreatedDate, roleLevel.ModifiedDate);
			}

			this.dataGridViewRoleLevels.DataSource = roleLevelDatatable;

			DataTable roleDatatable = new DataTable();
			roleDatatable.Columns.Add("RoleId");
			roleDatatable.Columns.Add("RoleName");
			roleDatatable.Columns.Add("IsDeleted");
			roleDatatable.Columns.Add("CreatedDate");
			roleDatatable.Columns.Add("ModifiedDate");

			foreach (var role in this._roleService.GetRoles())
			{
				roleDatatable.Rows.Add(role.RoleId, role.RoleName, role.IsDeleted, role.CreatedDate, role.ModifiedDate);
			}

			this.dataGridViewRoles.DataSource = roleDatatable;

			var userData = this._userService.GetUserById(CurrentUser);
			if (userData != null)
			{

				textBoxUserId.Text = userData.UserId.ToString();
				textBoxUsername.Text = userData.Username;
				textBoxRole.Text = $"{userData.Role.RoleName}";
				textBoxFName.Text = userData.FirstName;
				textBoxLName.Text = userData.LastName;
				textBoxEmail.Text = userData.Email;
				textBoxCreatedBy.Text = $"{userData.CreatedByNavigation?.FirstName} {userData.CreatedByNavigation?.LastName}";
				textBoxCreatedDate.Text = userData.CreatedDate.ToString();
				textBoxModifiedBy.Text = $"{userData.ModifiedByNavigation?.FirstName} {userData.ModifiedByNavigation?.LastName}";
				textBoxModifiedDate.Text = userData.ModifiedDate.ToString();
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

			this._roleLevelService.AddRoleLevel(new BusinessObjects.BusinessObjects.RoleLevel
			{
				RoleLevelId = superAdminRoleLevelId,
				RoleLevelName = "RL_SUPER_ADMIN",
				CreatedDate = DateTime.Now,
			});

			this._roleService.AddRole(new BusinessObjects.BusinessObjects.Role
			{
				RoleId = superAdminRoleId,
				RoleName = "R_SUPER_ADMIN",
				RoleLevelId = superAdminRoleLevelId,
				CreatedDate = DateTime.Now,
			});

			this._userService.AddUser(new BusinessObjects.BusinessObjects.User
			{
				UserId = superAmdinUserId,
				Username = "sa",
				FirstName = "Super",
				LastName = "Admin",
				Email = "vsvikassingh49@gmail.com",
				Password = "Microsoft#1234",
				RoleId = superAdminRoleId
			});

			this.CurrentUser = superAmdinUserId;

			MessageBox.Show("Administrator added successfully", "Administrator", MessageBoxButtons.OK, MessageBoxIcon.Information);
			this.SetupUI();
		}
	}
}
