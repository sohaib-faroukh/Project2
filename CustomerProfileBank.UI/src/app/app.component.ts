import { Component } from '@angular/core';
import { ConfigService } from './config/config.service';
import { STRING_TYPE } from '@angular/compiler/src/output/output_ast';
import { catchConnectionError } from './additional/functions';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'Customer Profiel Bank';

  constructor(private srv: ConfigService) {
    this.srv.getConfig().subscribe(
      res => {
        if (res["url"] && res["url"] != "") {
          localStorage.clear();
          if (typeof (res["url"]) == 'string') {
            localStorage.setItem("API_URL", res["url"])
          }
        }
        else {
          localStorage.clear();
          console.log("%c No url in config file ", "color:red")
        }
      },
      err => {
        catchConnectionError(err);
      })
  }

}
