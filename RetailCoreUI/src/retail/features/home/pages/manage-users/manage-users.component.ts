import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { UI_Modules } from '../../../../shared/modules/ui-modules.export';

interface Column {
  field: string;
  header: string;
}

interface User {
    id: string;
    firstName: string;
    lastName: string;
    userName: string;
    email: string;
    isDeleted: false;
    mobile: string;
    address: string;
    active: boolean;
    role: string;
    lastActive: Date;
    createdOn: Date;
    updatedOn: Date;
}

@Component({
  selector: 'retail-manage-users',
  standalone: true,
  imports: [UI_Modules, FormsModule, RouterModule, CommonModule],
  templateUrl: './manage-users.component.html',
  styleUrl: './manage-users.component.scss'
})
export class ManageUsersComponent {

  users: User[] = [
    {
      id: '001',
      firstName: 'John',
      lastName: 'Doe',
      userName: 'jdoe',
      email: 'jdoe@example.com',
      isDeleted: false,
      mobile: '+1234567890',
      address: '123 Main St, Springfield, IL',
      active: true,
      role: 'Admin',
      lastActive: new Date('2024-09-18T12:30:00'),
      createdOn: new Date('2023-05-10T09:15:00'),
      updatedOn: new Date('2024-09-18T12:30:00')
    },
    {
      id: '002',
      firstName: 'Jane',
      lastName: 'Smith',
      userName: 'jsmith',
      email: 'jsmith@example.com',
      isDeleted: false,
      mobile: '+1234567891',
      address: '456 Oak St, Metropolis, NY',
      active: false,
      role: 'User',
      lastActive: new Date('2024-09-01T16:00:00'),
      createdOn: new Date('2023-06-22T11:30:00'),
      updatedOn: new Date('2024-09-02T09:00:00')
    },
    {
      id: '003',
      firstName: 'Robert',
      lastName: 'Brown',
      userName: 'rbrown',
      email: 'rbrown@example.com',
      isDeleted: false,
      mobile: '+1234567892',
      address: '789 Pine St, Gotham, NJ',
      active: true,
      role: 'Moderator',
      lastActive: new Date('2024-09-18T14:45:00'),
      createdOn: new Date('2023-07-14T08:45:00'),
      updatedOn: new Date('2024-09-18T14:45:00')
    },
    {
      id: '004',
      firstName: 'Emily',
      lastName: 'Davis',
      userName: 'edavis',
      email: 'edavis@example.com',
      isDeleted: false,
      mobile: '+1234567893',
      address: '321 Maple St, Star City, CA',
      active: true,
      role: 'User',
      lastActive: new Date('2024-09-17T10:00:00'),
      createdOn: new Date('2023-08-01T13:30:00'),
      updatedOn: new Date('2024-09-17T10:00:00')
    },
    {
      id: '005',
      firstName: 'Michael',
      lastName: 'Wilson',
      userName: 'mwilson',
      email: 'mwilson@example.com',
      isDeleted: false,
      mobile: '+1234567894',
      address: '555 Birch St, Starling City, WA',
      active: false,
      role: 'Admin',
      lastActive: new Date('2024-08-31T15:15:00'),
      createdOn: new Date('2023-03-19T14:30:00'),
      updatedOn: new Date('2024-09-01T08:00:00')
    },
    {
      id: '006',
      firstName: 'Olivia',
      lastName: 'Martinez',
      userName: 'omartinez',
      email: 'omartinez@example.com',
      isDeleted: false,
      mobile: '+1234567895',
      address: '987 Elm St, National City, TX',
      active: true,
      role: 'Moderator',
      lastActive: new Date('2024-09-16T17:20:00'),
      createdOn: new Date('2023-04-02T12:00:00'),
      updatedOn: new Date('2024-09-16T17:20:00')
    },
    {
      id: '007',
      firstName: 'David',
      lastName: 'Garcia',
      userName: 'dgarcia',
      email: 'dgarcia@example.com',
      isDeleted: false,
      mobile: '+1234567896',
      address: '222 Willow St, Central City, NV',
      active: false,
      role: 'User',
      lastActive: new Date('2024-08-15T10:00:00'),
      createdOn: new Date('2023-05-25T14:45:00'),
      updatedOn: new Date('2024-08-16T09:15:00')
    },
    {
      id: '008',
      firstName: 'Sophia',
      lastName: 'Johnson',
      userName: 'sjohnson',
      email: 'sjohnson@example.com',
      isDeleted: false,
      mobile: '+1234567897',
      address: '543 Cedar St, Blüdhaven, OR',
      active: true,
      role: 'Admin',
      lastActive: new Date('2024-09-18T08:30:00'),
      createdOn: new Date('2023-09-10T11:15:00'),
      updatedOn: new Date('2024-09-18T08:30:00')
    },
    {
      id: '009',
      firstName: 'Liam',
      lastName: 'Walker',
      userName: 'lwalker',
      email: 'lwalker@example.com',
      isDeleted: false,
      mobile: '+1234567898',
      address: '888 Cypress St, Coast City, MA',
      active: false,
      role: 'User',
      lastActive: new Date('2024-07-28T12:45:00'),
      createdOn: new Date('2023-01-29T15:00:00'),
      updatedOn: new Date('2024-07-29T09:00:00')
    },
    {
      id: '010',
      firstName: 'Lucas',
      lastName: 'Miller',
      userName: 'lmiller',
      email: 'lmiller@example.com',
      isDeleted: false,
      mobile: '+1234567899',
      address: '111 Poplar St, Keystone City, OH',
      active: true,
      role: 'Moderator',
      lastActive: new Date('2024-09-18T09:50:00'),
      createdOn: new Date('2023-12-05T10:45:00'),
      updatedOn: new Date('2024-09-18T09:50:00')
    }
  ];

  cols: Column[] = [
    { field: 'userId', header: 'User Id' },
    { field: 'firstName', header: 'First Name' },
    { field: 'lastName', header: 'Last Name' },
    { field: 'userName', header: 'User Name' },
    { field: 'email', header: 'Email' },
    { field: 'isDeleted', header: 'Is Deleted' },
    { field: 'createdOn', header: 'Created On' },
    { field: 'updatedOn', header: 'Updated On' }
  ];


}
