import { Component, OnInit } from '@angular/core';
import { Customer } from 'src/app/models/Customer';
import { ActivatedRoute, Router } from '@angular/router';
import { REQUIREDPATTERN } from 'src/app/additional/data';
import { onValueChange, showNotification, catchConnectionError } from 'src/app/additional/functions';
import { CustomersService } from '../customers.service';
import { state } from 'src/app/User Role Management/component-state';


@Component({
  selector: 'app-add-edit-customer',
  templateUrl: './add-edit-customer.component.html',
  styleUrls: ['./add-edit-customer.component.scss']
})
export class AddEditCustomerComponent implements OnInit {


  RequiredPattern: string = REQUIREDPATTERN;

  Customer: Customer = new Customer();
  CustomerCopy: Customer = new Customer();
  valuesChanged: boolean = false;

  compoState: state = state.add;

  constructor(private srv: CustomersService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit() {

    this.Customer = new Customer();
    this.CustomerCopy = new Customer();


    let RouteData = this.route.snapshot.data;

    let ActionRouteParam: string = this.route.snapshot.params["action"];

    if (ActionRouteParam && ActionRouteParam.trim().toLowerCase() == "edit") {
      this.compoState = state.edit;

      this.Customer = RouteData["Customer"];

      Object.assign(this.CustomerCopy, this.Customer);


    }
    else if (ActionRouteParam && ActionRouteParam.trim().toLowerCase() == "add") {
      this.compoState = state.add;
    }
    else {
      this.router.navigate(['/customers']);
    }
  }


  onSubmit() {
    switch (this.compoState) {
      case state.add: {
        this.post();
        break;
      }
      case state.edit: {
        this.put()
        break;
      }
      default: {
        break;
      }
    }
  }


  // to use for post new  role by calling the service method which connect via HTTP with backend
  post() {
    this.srv.post(this.Customer).subscribe(
      res => {
        this.valuesChanged = false;

        if (res) {
          console.log("POSTED : " + JSON.stringify(res));
          showNotification("Added succesfully", "bottom", "center", "success");
        }
        else {
          console.log("%c Can't POSTED , no result returned", 'color:red');
          showNotification("Can't POSTED , no result returned", "bottom", "center", "danger");
        }

        this.router.navigate(['/customers']);
      },
      err => {
        showNotification("Error : " + JSON.stringify(err), "bottom", "center", "danger");
        catchConnectionError(err);
      }
    )
  }



  // to use for update existing role by calling the service method which connect via HTTP with backend
  put() {
    this.srv.put(this.Customer).subscribe(
      res => {

        this.valuesChanged = false;
        if (res) {
          showNotification("Updated succesfully", "bottom", "center", "success");
          console.log("UPDATED : " + JSON.stringify(res));
        }
        else {
          showNotification("Can't UPDATED , no result returned", "bottom", "center", "danger");
          console.error("%c Can't UPDATED , no result", 'color:red');
        }
        this.router.navigate(['/customers']);
      },
      err => {
        showNotification("Can't UPDATED , no result returned", "bottom", "center", "danger");
        catchConnectionError(err);
      }
    )
  }

  onValueChange() {
    this.valuesChanged = onValueChange(this.Customer, this.CustomerCopy);
  }
}
