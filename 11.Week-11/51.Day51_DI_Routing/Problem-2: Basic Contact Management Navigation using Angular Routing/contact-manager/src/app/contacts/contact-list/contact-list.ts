import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ContactService } from '../../services/contact';
import { Contact } from '../../models/contact';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { SearchFilterPipe } from '../../pipes/search-filter-pipe';

@Component({
  selector: 'app-contact-list',
  standalone: true,
  imports: [CommonModule, RouterModule,FormsModule, SearchFilterPipe],
  templateUrl: './contact-list.html'
})
export class ContactListComponent {

  contacts:Contact[] = [];
  searchText: string = '';

  constructor(private contactService: ContactService) {
    this.contacts = this.contactService.getContacts();
  }


deleteContact(id: number) {
  this.contacts = this.contacts.filter(c => c.id !== id);
}
}