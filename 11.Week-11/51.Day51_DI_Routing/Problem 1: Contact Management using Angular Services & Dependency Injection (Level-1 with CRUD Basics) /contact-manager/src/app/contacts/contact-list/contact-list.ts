import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ContactService } from '../../services/contact';
import { Contact } from '../../models/contact';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-contact-list',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './contact-list.html'
})
export class ContactListComponent {

  contacts:Contact[] = [];

  constructor(private contactService: ContactService) {
    this.contacts = this.contactService.getContacts();
  }
}