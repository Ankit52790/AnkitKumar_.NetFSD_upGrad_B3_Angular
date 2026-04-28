import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ContactService } from '../../services/contact';
import { Router } from '@angular/router';
import { ActivatedRoute } from '@angular/router';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-add-contact',
  standalone: true,
  imports: [FormsModule, CommonModule,RouterModule],
  templateUrl: './add-contact.html'
})
export class AddContactComponent {

  contact:any = {
    id: 0,
    name: '',
    email: '',
    phone: ''
  };

  isEdit = false;

  constructor(
    private service: ContactService,
    private router: Router,
    private route: ActivatedRoute
  ) {}

ngOnInit() {
    const id = this.route.snapshot.paramMap.get('id');

    if (id) {
      this.isEdit = true;
      const existing = this.service.getContactById(Number(id));
      if (existing) {
        this.contact = { ...existing }; 
      }
    }
  }

  save() {
    this.contact.id = Number(this.contact.id);

    if (this.isEdit) {
      this.service.updateContact(this.contact); // UPDATE
    } else {
      this.service.addContact(this.contact); // ADD
    }

    this.router.navigate(['/contacts']);
  }
}