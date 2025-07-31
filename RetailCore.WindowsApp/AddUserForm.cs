using RetailCore.BusinessObjects.BusinessObjects;
using RetailCore.Interfaces.DataAccess;
using RetailCore.ServiceContracts;

namespace RetailCore.WindowsApp
{
    public partial class AddUserForm : Form
    {
        private readonly IRoleService _roleService;
        private readonly IUserService _userService;

        private User existingUser = null;

        public AddUserForm(IRoleService roleService, IUserService userService)
        {
            InitializeComponent();

            this._roleService = roleService;
            this._userService = userService;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var adminUser = _userService.GetAdminUser();

            if (existingUser != null)
            {
                // Update existing user
                this._userService.UpdateUser(new User
                {
                    UserId = existingUser.UserId,
                    Username = tbxUsername.Text,
                    RoleId = Guid.Parse(Convert.ToString(this.cbxRole.SelectedValue)),
                    FirstName = tbxFirstName.Text,
                    LastName = tbxLName.Text,
                    Email = tbxEmail.Text,
                    Password = tbxPassword.Text,
                    ModifiedBy = adminUser.UserId,
                    ModifiedDate = DateTime.Now
                });
            }
            else
            {
                this._userService.AddUser(new User
                {
                    UserId = Guid.Parse(this.textBoxUserId.Text),
                    Username = tbxUsername.Text,
                    RoleId = Guid.Parse(Convert.ToString(this.cbxRole.SelectedValue)),
                    FirstName = tbxFirstName.Text,
                    LastName = tbxLName.Text,
                    Email = tbxEmail.Text,
                    Password = tbxPassword.Text,
                    CreatedBy = adminUser.UserId,
                    CreatedDate = DateTime.Now
                });
            }

            //Add MessageBox to confirm save
            string message = existingUser == null ? "User Added Successfully" : "User Updated Successfully";
            MessageBox.Show(message, "Administrator", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
        }

        private void AddRoleForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            existingUser = null; // Clear the existing user reference on form closing
        }

        private void AddRoleForm_Load(object sender, EventArgs e)
        {
            this.textBoxUserId.Text = Guid.NewGuid().ToString();

            this.tbxUsername.Text = tbxFirstName.Text = tbxMName.Text = tbxLName.Text = tbxPassword.Text = tbxEmail.Text = string.Empty;
            checkBoxActive.Checked = checkBoxVerified.Checked = true;

            this.cbxRole.DataSource = null; // Clear previous data source
            this.cbxRole.Items.Clear(); // Clear previous items

            this.cbxRole.DataSource = this._roleService.GetRoles();
            this.cbxRole.DisplayMember = "RoleName";
            this.cbxRole.ValueMember = "RoleId";

            // Set UI for existing user if available
            if (existingUser != null)
            {
                this.textBoxUserId.Text = existingUser.UserId.ToString();
                this.tbxUsername.Text = existingUser.Username;
                this.tbxFirstName.Text = existingUser.FirstName;
                this.tbxMName.Text = string.Empty; // Handle potential null for MiddleName
                this.tbxLName.Text = existingUser.LastName;
                this.tbxEmail.Text = existingUser.Email;
                this.tbxPassword.Text = existingUser.Password;
                this.cbxRole.SelectedValue = existingUser.RoleId;
                checkBoxActive.Checked = true;
                checkBoxVerified.Checked = true;

                // Set the button text to "Update" for existing user
                this.btnSave.Text = "Update";
            }
            else
            {
                this.btnSave.Text = "Save";
            }
        }

        internal void SetUIForExistingUser(User currentRow)
        {
            existingUser = currentRow;
        }
    }
}
