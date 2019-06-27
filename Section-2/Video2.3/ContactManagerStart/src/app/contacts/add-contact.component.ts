import { Component, OnInit } from '@angular/core';
import { Contact } from "./contact";
import { ContactService } from './contact.service';
@Component({
  selector: 'app-add-contact',
  templateUrl: './add-contact.component.html',
  styleUrls: ['./add-contact.component.css']
})
export class AddContactComponent implements OnInit {

  constructor(private service: ContactService) { }

  ngOnInit() {
  }

  CreateContact(name, email)
  {
    let contactToCreate = {name: name, email: email} as Contact;
    console.log(contactToCreate);
    this.service.CreateContact(contactToCreate);
  }
}
