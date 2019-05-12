import { Component } from '@angular/core';
import { ConfigService } from './config/config.service';
import { STRING_TYPE } from '@angular/compiler/src/output/output_ast';
import { catchConnectionError } from './additional/functions';
import { UsersService } from './User Role Management/users/users.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'Customer Profiel Bank';

  constructor() {}
}
