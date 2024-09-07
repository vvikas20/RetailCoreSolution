using RetailCore.ServiceContracts;
using System.Data;

namespace RetailCore.WindowsApp
{
    public partial class MainForm : Form
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IRoleService _roleService;
        private readonly IRoleLevelService _roleLevelService;
        private readonly IUserService _userService;
        private readonly IPermissionTypeService _permissionTypeService;
        private readonly IPermissionService _permissionService;

        private readonly AddUserForm addUserForm;
        private readonly AddRoleLevelForm addRoleLevelForm;
        private readonly AddRoleForm addRoleForm;

        public MainForm(ICurrentUserService currentUserService, IRoleService roleService, IRoleLevelService roleLevelService, IUserService userService, IPermissionTypeService permissionTypeService, IPermissionService permissionService,
                        AddUserForm addUserForm, AddRoleLevelForm addRoleLevelForm, AddRoleForm addRoleForm)
        {
            InitializeComponent();

            this._currentUserService = currentUserService;
            this._roleService = roleService;
            this._roleLevelService = roleLevelService;
            this._userService = userService;
            this._permissionTypeService = permissionTypeService;
            this._permissionService = permissionService;

            this.addUserForm = addUserForm;
            this.addRoleLevelForm = addRoleLevelForm;
            this.addRoleForm = addRoleForm;
        }

        private void SetupUI()
        {

            string loggedInUser = string.IsNullOrEmpty(this._currentUserService.Username) ? "Guest" : this._currentUserService.Username;
            this.Text = $"Welcome - {loggedInUser}";

            var userCount = this._userService.GetUserCount();
            var roleCount = this._roleService.GetRoleCount();
            var roleLevelCount = this._roleLevelService.GetRoleLevelCount();

            btnAddUser.Enabled = !(buttonInitializeSystem.Enabled = userCount == 0) && roleCount > 0;

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

            DataTable userPermissionDatatable = new DataTable();
            userPermissionDatatable.Columns.Add("Sr No");
            userPermissionDatatable.Columns.Add("Name");
            userPermissionDatatable.Columns.Add("DisplayName");
            userPermissionDatatable.Columns.Add("Type");
            userPermissionDatatable.Columns.Add("IsDeleted");

            var userData = this._userService.GetUserById(this._currentUserService.UserId);
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


                var permissions = _roleService.GetPermissionByRoleId((Guid)userData.RoleId);
                if (permissions != null)
                {
                    int i = 1;
                    foreach (var item in permissions)
                    {
                        userPermissionDatatable.Rows.Add(i++, item.PermissionName, item.PermissionDisplayName, item.PermissionType.TypeName, item.IsDeleted);
                    }
                }
            }
            dataGridViewPermissions.DataSource = userPermissionDatatable;
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

        private void buttonInitializeSystem_Click(object sender, EventArgs e)
        {
            Guid superAdminRoleLevelId = Guid.NewGuid();
            Guid superAdminRoleId = Guid.NewGuid();
            Guid superAmdinUserId = Guid.NewGuid();

            this._roleLevelService.AddRoleLevel(new BusinessObjects.BusinessObjects.RoleLevel
            {
                RoleLevelId = superAdminRoleLevelId,
                RoleLevelName = "SUPERADMIN",
                RoleLevelDisplayName = "Super Admin",
                RoleLevel1 = 100,
                CreatedDate = DateTime.Now,
            });

            this._roleService.AddRole(new BusinessObjects.BusinessObjects.Role
            {
                RoleId = superAdminRoleId,
                RoleName = "SUPER ADMIN",
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

            this._currentUserService.UserId = superAmdinUserId;

            if (this._permissionTypeService.GetPermissionTypeCount() == 0)
            {
                Dictionary<string, List<string>> keyValuePairs = new Dictionary<string, List<string>>();

                keyValuePairs.Add(PermissionTypes.SystemManagement, new List<string> { "Manage Roles", "Manage Role Levels" });
                keyValuePairs.Add(PermissionTypes.UserManagement, new List<string> { "View Users", "Add User", "Edit User", "Delete User", "Assign Roles" });
                keyValuePairs.Add(PermissionTypes.ProductManagement, new List<string> { "View Products", "Add Product", "Edit Product", "Delete Product", "Manage Inventory", "Manage Categories" });
                keyValuePairs.Add(PermissionTypes.OrderManagement, new List<string> { "View Orders", "Process Orders", "Manage Returns", "Manage Shipping", "Cancel Orders" });
                keyValuePairs.Add(PermissionTypes.CustomerSupport, new List<string> { "View Support Tickets", "Respond to Tickets" });
                keyValuePairs.Add(PermissionTypes.SystemSettings, new List<string> { "Manage Settings", "View Audit Logs" });
                keyValuePairs.Add(PermissionTypes.CustomerAccess, new List<string> { "Browse Products", "Place Orders", "Track Orders", "Manage Account", "View Order History" });


                foreach (var ptype in keyValuePairs)
                {
                    var permissionTypeId = this._permissionTypeService.AddPermissionType(new BusinessObjects.BusinessObjects.PermissionType
                    {
                        PermissionTypeId = Guid.NewGuid(),
                        TypeName = ptype.Key,
                        IsDeleted = false,
                        CreatedBy = superAmdinUserId,
                        CreatedDate = DateTime.Now
                    });

                    foreach (var permission in ptype.Value)
                    {
                        string permissionKey = $"KEY_{permission.Replace(" ", "_").ToUpper()}";

                        this._permissionService.AddPermission(new BusinessObjects.BusinessObjects.Permission
                        {
                            PermissionId = Guid.NewGuid(),
                            PermissionTypeId = permissionTypeId,
                            PermissionName = permissionKey,
                            PermissionDisplayName = permission,
                            IsDeleted = false,
                            CreatedBy = superAmdinUserId,
                            CreatedDate = DateTime.Now
                        });
                    }

                    this._roleLevelService.AddRoleLevelPermissionTypes(superAdminRoleLevelId, new List<BusinessObjects.BusinessObjects.PermissionType> { new BusinessObjects.BusinessObjects.PermissionType { PermissionTypeId = permissionTypeId } });
                }

                this._roleService.AssignDefaultPermissionOnRole(superAdminRoleId);
            }

            MessageBox.Show("Administrator added successfully", "Administrator", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.SetupUI();
        }
    }
}
