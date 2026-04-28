import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { RouterModule } from '@angular/router';
import { ContactService } from '../../services/contact';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-contact-detail',
  standalone: true,
  imports: [CommonModule,RouterModule],
  templateUrl: './contact-detail.html'
})
export class ContactDetailComponent {

  contact: any;

  constructor(
    private route: ActivatedRoute,
    private service: ContactService
  ) {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.contact = this.service.getContactById(id);
  }
}