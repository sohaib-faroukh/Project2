import { Component, OnInit } from '@angular/core';
import { Customer } from 'src/app/models/Customer';

@Component({
  selector: 'app-add-edit-customer',
  templateUrl: './add-edit-customer.component.html',
  styleUrls: ['./add-edit-customer.component.scss']
})
export class AddEditCustomerComponent implements OnInit {


  Customer:Customer=new Customer();


  constructor() { }

  ngOnInit() {
  }

}
