import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { PhoneFormatPipe } from '../pipes/phone-format-pipe';
import { StatusPipe } from '../pipes/status-pipe';
import { SearchFilterPipe } from '../pipes/search-filter-pipe';
import { GradePipe } from '../pipes/grade-pipe';

@Component({
  selector: 'app-contacts',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    PhoneFormatPipe,
    StatusPipe,
    SearchFilterPipe,
    GradePipe
  ],
  templateUrl: './contacts.html',
  styleUrls: ['./contacts.css']
})
export class Contacts {

  searchText = '';

  contacts = [
  { name: 'Ankit', email: 'ankit@gmail.com', phone: '9876543210', status: true, grade: 1 },
  { name: 'Rahul', email: 'rahul@gmail.com', phone: '9876501234', status: false, grade: 2 },
  { name: 'Priya', email: 'priya@gmail.com', phone: '9123456780', status: true, grade: 3 }
];

  toggleStatus(contact: any) {
    contact.status = !contact.status;
  }
}