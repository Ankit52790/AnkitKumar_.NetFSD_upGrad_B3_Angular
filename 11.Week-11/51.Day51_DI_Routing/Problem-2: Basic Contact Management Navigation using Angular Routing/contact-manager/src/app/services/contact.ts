import { Injectable } from '@angular/core';
import { Contact } from '../models/contact';

@Injectable({
  providedIn: 'root'
})
export class ContactService {

  private contacts: Contact[] = [
    { id: 1, name: 'Ankit', email: 'ankit@gmail.com', phone: '9876543210' },
    { id: 2, name: 'Rahul', email: 'rahul@gmail.com', phone: '9876501234' },
    { id: 3, name: 'Scott', email: 'scott@gmail.com', phone: '9123456780' }
  ];

  getContacts(): Contact[] {
    return this.contacts;
  }

  addContact(contact: Contact): void {
    this.contacts.push(contact);
  }

  getContactById(id: number): Contact | undefined {
    return this.contacts.find(c => c.id === id);
  }
  
  deleteContact(id: number): void {
  this.contacts = this.contacts.filter(c => c.id !== id);
}

updateContact(updatedContact: any): void {
  const index = this.contacts.findIndex(c => c.id === updatedContact.id);

  if (index !== -1) {
    this.contacts[index] = updatedContact;
  }
}
}