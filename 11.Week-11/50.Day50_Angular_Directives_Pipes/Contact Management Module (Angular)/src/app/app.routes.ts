import { Routes } from '@angular/router';
import { ContactListComponent } from './contacts/contact-list/contact-list';
import { AddContactComponent } from './contacts/add-contact/add-contact';
import { ContactDetailComponent } from './contacts/contact-detail/contact-detail';

export const routes: Routes = [
  { path: '', redirectTo: 'contacts', pathMatch: 'full' },
  { path: 'contacts', component: ContactListComponent },
  { path: 'add-contact', component: AddContactComponent },
  { path: 'contact/:id', component: ContactDetailComponent },
  { path: 'edit-contact/:id', component: AddContactComponent }
];