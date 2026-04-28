import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ContactService } from '../../services/contact';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-add-contact',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './add-contact.html'
})
export class AddContactComponent {

  contact = {
    id: 0,
    name: '',
    email: '',
    phone: ''
  };

  constructor(
    private service: ContactService,
    private router: Router
  ) {}

  add() {
    this.service.addContact(this.contact);
    this.router.navigate(['/contacts']);
  }
}